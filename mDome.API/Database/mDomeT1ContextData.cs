using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mDome.API.Database
{
    public partial class mDomeT1Context
    {
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserProfile>().HasData(Helper.Methods.LoadJsonFromFile<UserProfile>
                  ("UserBasicJson.json"));
            modelBuilder.Entity<AdministratorLogin>().
                HasData(Helper.Methods.LoadJsonFromFile<AdministratorLogin>
                ("AdministratorJson.json"));
            modelBuilder.Entity<Genre>().HasData(Helper.Methods.LoadJsonFromFile<Genre>
                ("GenreBasicJson.json"));
            modelBuilder.Entity<Artist>().HasData(Helper.Methods.LoadJsonFromFile<Artist>
                ("ArtistBasicJson.json"));
            modelBuilder.Entity<ArtistGenre>().HasData(Helper.Methods.LoadJsonFromFile<ArtistGenre>
                ("ArtistGenreBasicJson.json"));
            modelBuilder.Entity<Album>().HasData(Helper.Methods.LoadJsonFromFile<Album>
                ("AlbumBasicJson.json"));
            modelBuilder.Entity<Track>().HasData(Helper.Methods.LoadJsonFromFile<Track>
                ("TrackBasicJson.json"));
            modelBuilder.Entity<Review>().HasData(Helper.Methods.LoadJsonFromFile<Review>
                ("ReviewBasicJson.json"));
            modelBuilder.Entity<Post>().HasData(Helper.Methods.LoadJsonFromFile<Post>
                ("PostBasicJson.json"));
            modelBuilder.Entity<AlbumList>().HasData(Helper.Methods.LoadJsonFromFile<AlbumList>
                ("AlbumListBasicJson.json"));
            modelBuilder.Entity<Tracklist>().HasData(Helper.Methods.LoadJsonFromFile<Tracklist>
                ("TracklistBasicJson.json"));
            modelBuilder.Entity<Request>().HasData(Helper.Methods.LoadJsonFromFile<Request>
                ("RequestBasicJson.json"));
            modelBuilder.Entity<Notification>().HasData(Helper.Methods.LoadJsonFromFile<Notification>
                ("NotificationBasicJson.json"));
        }
    }
}
