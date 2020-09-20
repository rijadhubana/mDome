using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using mDome.API.Controllers;
using mDome.API.Database;
using mDome.API.Security;
using mDome.API.Services;
using mDome.Model.Requests;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Hangfire;
using Hangfire.MemoryStorage;

namespace mDome.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHangfire(config =>
            config.SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
            .UseSimpleAssemblyNameTypeSerializer().
            UseDefaultTypeSerializer().UseMemoryStorage());
            services.AddHangfireServer();
            services.AddAutoMapper(typeof(Startup));
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "mDome API", Version = "v1" });

                // basic auth swagger
                c.AddSecurityDefinition("basic", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "basic",
                    In = ParameterLocation.Header,
                    Description = "Basic Authorization header using the Bearer scheme."
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "basic"
                            }
                        },
                        new string[] {}
                    }
                });
            });
            services.AddControllers();
            var connection = Configuration.GetConnectionString("mDome");
            services.AddAuthentication("BasicAuthentication").AddScheme
                <AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);
            #region dependency
            services.AddDbContext<mDomeT1Context>(options => options.UseSqlServer(connection));
            services.AddScoped<ICRUDService<Model.Genre, GenreSearchRequest, GenreUpsertRequest, GenreUpsertRequest>, GenreService>();
            services.AddScoped<ICRUDService<Model.Artist, ArtistSearchRequest, ArtistUpsertRequest, ArtistUpsertRequest>, ArtistService>();
            services.AddScoped<ICRUDService<Model.ArtistGenre, ArtistGenreSearchRequest, ArtistGenreUpsertRequest, ArtistGenreUpsertRequest>, ArtistGenreService>();
            services.AddScoped<ICRUDService<Model.Album, AlbumSearchRequest, AlbumUpsertRequest, AlbumUpsertRequest>, AlbumService>();
            services.AddScoped<ICRUDService<Model.Track, TrackSearchRequest, TrackUpsertRequest, TrackUpsertRequest>, TrackService>();
            services.AddScoped<ICRUDService<Model.Request, RequestSearchRequest, RequestUpsertRequest, RequestUpsertRequest>, RequestService>();
            services.AddScoped<ICRUDService<Model.Notification, NotificationSearchRequest, NotificationUpsertRequest, NotificationUpsertRequest>, NotificationService>();
            services.AddScoped<ICRUDService<Model.UserProfile, UserProfileSearchRequest, UserProfileUpsertRequest, UserProfileUpsertRequest>, UserProfileService>();
            services.AddScoped<ICRUDService<Model.AdministratorLogin, AdminSearchRequest, AdminUpsertRequest, AdminUpsertRequest>, AdministratorLoginService>();
            services.AddScoped<ICRUDService<Model.Post, PostSearchRequest, PostUpsertRequest, PostUpsertRequest>, PostService>();
            services.AddScoped<ICRUDService<Model.Review, ReviewSearchRequest, ReviewUpsertRequest, ReviewUpsertRequest>, ReviewService>();
            services.AddScoped<ICRUDService<Model.UserFollowers, UserFollowersSearchRequest, UserFollowersUpsertRequest, UserFollowersUpsertRequest>, UserFollowersService>();
            services.AddScoped<ICRUDService<Model.UserFollowsArtist, UserFollowsArtistSearchRequest, UserFollowsArtistUpsertRequest, UserFollowsArtistUpsertRequest>, UserFollowsArtistService>();
            services.AddScoped<ICRUDService<Model.UserCommentPost, UserCommentPostSearchRequest, UserCommentPostUpsertRequest, UserCommentPostUpsertRequest>, UserCommentPostService>();
            services.AddScoped<ICRUDService<Model.UserLikePost, UserLikePostSearchRequest, UserLikePostUpsertRequest, UserLikePostUpsertRequest>, UserLikePostService>();
            services.AddScoped<ICRUDService<Model.Tracklist, TracklistSearchRequest, TracklistUpsertRequest, TracklistUpsertRequest>, TracklistService>();
            services.AddScoped<ICRUDService<Model.TracklistTrack, TracklistTrackSearchRequest, TracklistTrackUpsertRequest, TracklistTrackUpsertRequest>, TracklistTrackService>();
            services.AddScoped<ICRUDService<Model.AlbumList, AlbumListSearchRequest, AlbumListUpsertRequest, AlbumListUpsertRequest>, AlbumListService>();
            services.AddScoped<ICRUDService<Model.AlbumListAlbum, AlbumListAlbumSearchRequest, AlbumListAlbumUpsertRequest, AlbumListAlbumUpsertRequest>, AlbumListAlbumService>();
            services.AddScoped<ICRUDService<Model.UserAlbumVote, UserAlbumVoteSearchRequest, UserAlbumVoteUpsertRequest, UserAlbumVoteUpsertRequest>, UserAlbumVoteService>();
            services.AddScoped<ICRUDService<Model.UserTrackVote, UserTrackVoteSearchRequest, UserTrackVoteUpsertRequest, UserTrackVoteUpsertRequest>, UserTrackVoteService>();
            services.AddScoped<ICRUDService<Model.LoginLogTable,LoginLogSearchRequest,LoginLogUpsertRequest,LoginLogUpsertRequest>,LoginLogTableService>();
            #endregion
            services.AddScoped<IRecommendService, RecommendService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, 
            IBackgroundJobClient backgroundJobClient,
             IRecurringJobManager recurringJobManager,
             IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "mDome API V1");
            });
            //app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseRouting();


            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseHangfireDashboard();
            //backgroundJobClient.Enqueue(() => serviceProvider.GetService<IRecommendService>().RefreshDiscoveryQueues());
            recurringJobManager.AddOrUpdate(
                "Refresh Discovery Queues", () => serviceProvider.GetService<IRecommendService>
                ().RefreshDiscoveryQueues(), Cron.Daily());
        }
    }
}
