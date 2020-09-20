using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace mDome.API.Database
{
    public partial class mDomeT1Context : DbContext
    {
        public mDomeT1Context()
        {
        }

        public mDomeT1Context(DbContextOptions<mDomeT1Context> options)
            : base(options)
        {
        }

        public virtual DbSet<AdministratorLogin> AdministratorLogin { get; set; }
        public virtual DbSet<Album> Album { get; set; }
        public virtual DbSet<AlbumList> AlbumList { get; set; }
        public virtual DbSet<AlbumListAlbum> AlbumListAlbum { get; set; }
        public virtual DbSet<Artist> Artist { get; set; }
        public virtual DbSet<ArtistGenre> ArtistGenre { get; set; }
        public virtual DbSet<Genre> Genre { get; set; }
        public virtual DbSet<LoginLogTable> LoginLogTable { get; set; }
        public virtual DbSet<Notification> Notification { get; set; }
        public virtual DbSet<Post> Post { get; set; }
        public virtual DbSet<Request> Request { get; set; }
        public virtual DbSet<Review> Review { get; set; }
        public virtual DbSet<Track> Track { get; set; }
        public virtual DbSet<Tracklist> Tracklist { get; set; }
        public virtual DbSet<TracklistTrack> TracklistTrack { get; set; }
        public virtual DbSet<UserAlbumVote> UserAlbumVote { get; set; }
        public virtual DbSet<UserCommentPost> UserCommentPost { get; set; }
        public virtual DbSet<UserFollowers> UserFollowers { get; set; }
        public virtual DbSet<UserFollowsArtist> UserFollowsArtist { get; set; }
        public virtual DbSet<UserLikePost> UserLikePost { get; set; }
        public virtual DbSet<UserProfile> UserProfile { get; set; }
        public virtual DbSet<UserTrackVote> UserTrackVote { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();
                optionsBuilder.UseSqlServer(configuration.GetConnectionString("mDome"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AdministratorLogin>(entity =>
            {
                entity.HasKey(e => e.AdministratorId)
                    .HasName("PK_AdminId");

                entity.Property(e => e.AdminName)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.Property(e => e.PasswordHash)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.PasswordSalt)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Album>(entity =>
            {
                entity.Property(e => e.AlbumGeneratedRating).HasDefaultValueSql("((0))");

                entity.Property(e => e.AlbumName)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.DateReleased).HasMaxLength(20);

                entity.HasOne(d => d.Artist)
                    .WithMany(p => p.Album)
                    .HasForeignKey(d => d.ArtistId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AlbumArtistId");
            });

            modelBuilder.Entity<AlbumList>(entity =>
            {
                entity.HasIndex(e => e.UniqueKey)
                    .HasName("UQ__AlbumLis__2DE46E93D323461F")
                    .IsUnique();

                entity.Property(e => e.AlbumListName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.AlbumListType)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasDefaultValueSql("('Private')");

                entity.Property(e => e.ListDateCreated).HasColumnType("datetime");

                entity.Property(e => e.UniqueKey).HasMaxLength(20);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AlbumList)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AlbumListUserId");
            });

            modelBuilder.Entity<AlbumListAlbum>(entity =>
            {
                entity.HasKey(e => new { e.AlbumListId, e.AlbumId });

                entity.HasOne(d => d.Album)
                    .WithMany(p => p.AlbumListAlbum)
                    .HasForeignKey(d => d.AlbumId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AlbumListAlbumA");

                entity.HasOne(d => d.AlbumList)
                    .WithMany(p => p.AlbumListAlbum)
                    .HasForeignKey(d => d.AlbumListId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AlbumListAlbumAL");
            });

            modelBuilder.Entity<Artist>(entity =>
            {
                entity.Property(e => e.ArtistName)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<ArtistGenre>(entity =>
            {
                entity.HasKey(e => new { e.GenreId, e.ArtistId });

                entity.HasOne(d => d.Artist)
                    .WithMany(p => p.ArtistGenre)
                    .HasForeignKey(d => d.ArtistId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ArtistGenreArtistId");

                entity.HasOne(d => d.Genre)
                    .WithMany(p => p.ArtistGenre)
                    .HasForeignKey(d => d.GenreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ArtistGenreGenreId");
            });

            modelBuilder.Entity<Genre>(entity =>
            {
                entity.Property(e => e.GenreName)
                    .IsRequired()
                    .HasMaxLength(25);
            });

            modelBuilder.Entity<LoginLogTable>(entity =>
            {
                entity.Property(e => e.DateOfLogin).HasColumnType("datetime");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.LoginLogTable)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LoginLogTableUserId");
            });

            modelBuilder.Entity<Notification>(entity =>
            {
                entity.Property(e => e.NotifDateTime).HasColumnType("datetime");

                entity.Property(e => e.NotifText).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Notification)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserID");
            });

            modelBuilder.Entity<Post>(entity =>
            {
                entity.Property(e => e.AdminName).HasMaxLength(25);

                entity.Property(e => e.IsGlobal).HasDefaultValueSql("((0))");

                entity.Property(e => e.Opphoto).HasColumnName("OPPhoto");

                entity.Property(e => e.PostDateTime).HasColumnType("datetime");

                entity.Property(e => e.PostText).IsRequired();

                entity.Property(e => e.PostTitle)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.ArtistRelated)
                    .WithMany(p => p.Post)
                    .HasForeignKey(d => d.ArtistRelatedId)
                    .HasConstraintName("FK_PostArtistRelatedId");

                entity.HasOne(d => d.ReviewRelated)
                    .WithMany(p => p.Post)
                    .HasForeignKey(d => d.ReviewRelatedId)
                    .HasConstraintName("FK_PostReviewRelatedId");

                entity.HasOne(d => d.UserRelated)
                    .WithMany(p => p.Post)
                    .HasForeignKey(d => d.UserRelatedId)
                    .HasConstraintName("FK_PostUserRelatedId");
            });

            modelBuilder.Entity<Request>(entity =>
            {
                entity.Property(e => e.NameOfUser)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.Property(e => e.RequestDate).HasColumnType("datetime");

                entity.Property(e => e.RequestText).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Request)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RequestUserId");
            });

            modelBuilder.Entity<Review>(entity =>
            {
                entity.Property(e => e.ReviewText).IsRequired();

                entity.HasOne(d => d.Album)
                    .WithMany(p => p.Review)
                    .HasForeignKey(d => d.AlbumId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ReviewAlbumId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Review)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ReviewUserId");
            });

            modelBuilder.Entity<Track>(entity =>
            {
                entity.Property(e => e.TrackLyrics).HasDefaultValueSql("('')");

                entity.Property(e => e.TrackName)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.TrackViews).HasDefaultValueSql("((0))");

                entity.Property(e => e.TrackYoutubeId).HasMaxLength(50);

                entity.HasOne(d => d.Album)
                    .WithMany(p => p.Track)
                    .HasForeignKey(d => d.AlbumId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TrackAlbumId");
            });

            modelBuilder.Entity<Tracklist>(entity =>
            {
                entity.HasIndex(e => e.UniqueKey)
                    .HasName("UQ__Tracklis__2DE46E9327EC5917")
                    .IsUnique();

                entity.Property(e => e.ListDateCreated).HasColumnType("datetime");

                entity.Property(e => e.TracklistName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.TracklistType)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasDefaultValueSql("('Private')");

                entity.Property(e => e.UniqueKey).HasMaxLength(20);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Tracklist)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TracklistUserId");
            });

            modelBuilder.Entity<TracklistTrack>(entity =>
            {
                entity.HasKey(e => new { e.TracklistId, e.TrackId });

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.HasOne(d => d.Track)
                    .WithMany(p => p.TracklistTrack)
                    .HasForeignKey(d => d.TrackId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TracklistTrackT");

                entity.HasOne(d => d.Tracklist)
                    .WithMany(p => p.TracklistTrack)
                    .HasForeignKey(d => d.TracklistId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TracklistTrackTL");
            });

            modelBuilder.Entity<UserAlbumVote>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.AlbumId });

                entity.HasOne(d => d.Album)
                    .WithMany(p => p.UserAlbumVote)
                    .HasForeignKey(d => d.AlbumId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserAlbumVoteAlbumId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserAlbumVote)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserAlbumVoteUserId");
            });

            modelBuilder.Entity<UserCommentPost>(entity =>
            {
                entity.Property(e => e.CommentDate).HasColumnType("datetime");

                entity.Property(e => e.CommentText).IsRequired();

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.UserCommentPost)
                    .HasForeignKey(d => d.PostId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserCommentPostPostId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserCommentPost)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserCommentPostUserId");
            });

            modelBuilder.Entity<UserFollowers>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.FollowedByUserId });

                entity.HasOne(d => d.FollowedByUser)
                    .WithMany(p => p.UserFollowersFollowedByUser)
                    .HasForeignKey(d => d.FollowedByUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserFollowersBy");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserFollowersUser)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserFollowersUser");
            });

            modelBuilder.Entity<UserFollowsArtist>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.ArtistId });

                entity.HasOne(d => d.Artist)
                    .WithMany(p => p.UserFollowsArtist)
                    .HasForeignKey(d => d.ArtistId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserFollowsArtistArtistId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserFollowsArtist)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserFollowsArtistUserId");
            });

            modelBuilder.Entity<UserLikePost>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.PostId });

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.UserLikePost)
                    .HasForeignKey(d => d.PostId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserLikePostPostId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserLikePost)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserLikePostUserId");
            });

            modelBuilder.Entity<UserProfile>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK_UserId");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.PasswordHash)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.PasswordSalt)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.RegisteredAt).HasColumnType("datetime");

                entity.Property(e => e.SuspendedFlag).HasDefaultValueSql("((0))");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.HasOne(d => d.RecommendedAlbum1Navigation)
                    .WithMany(p => p.UserProfileRecommendedAlbum1Navigation)
                    .HasForeignKey(d => d.RecommendedAlbum1)
                    .HasConstraintName("FK_UserRecommendedAlbum1");

                entity.HasOne(d => d.RecommendedAlbum2Navigation)
                    .WithMany(p => p.UserProfileRecommendedAlbum2Navigation)
                    .HasForeignKey(d => d.RecommendedAlbum2)
                    .HasConstraintName("FK_UserRecommendedAlbum2");

                entity.HasOne(d => d.RecommendedAlbum3Navigation)
                    .WithMany(p => p.UserProfileRecommendedAlbum3Navigation)
                    .HasForeignKey(d => d.RecommendedAlbum3)
                    .HasConstraintName("FK_UserRecommendedAlbum3");

                entity.HasOne(d => d.RecommendedArtist1Navigation)
                    .WithMany(p => p.UserProfileRecommendedArtist1Navigation)
                    .HasForeignKey(d => d.RecommendedArtist1)
                    .HasConstraintName("FK_UserRecommendedArtist1");

                entity.HasOne(d => d.RecommendedArtist2Navigation)
                    .WithMany(p => p.UserProfileRecommendedArtist2Navigation)
                    .HasForeignKey(d => d.RecommendedArtist2)
                    .HasConstraintName("FK_UserRecommendedArtist2");

                entity.HasOne(d => d.RecommendedArtist3Navigation)
                    .WithMany(p => p.UserProfileRecommendedArtist3Navigation)
                    .HasForeignKey(d => d.RecommendedArtist3)
                    .HasConstraintName("FK_UserRecommendedArtist3");
            });

            modelBuilder.Entity<UserTrackVote>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.TrackId });

                entity.HasOne(d => d.Track)
                    .WithMany(p => p.UserTrackVote)
                    .HasForeignKey(d => d.TrackId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserTrackVoteTrackId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserTrackVote)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserTrackVoteUserId");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
