using System;
using System.Collections.Generic;

namespace mDome.API.Database
{
    public partial class UserProfile
    {
        public UserProfile()
        {
            AlbumList = new HashSet<AlbumList>();
            LoginLogTable = new HashSet<LoginLogTable>();
            Notification = new HashSet<Notification>();
            Post = new HashSet<Post>();
            Request = new HashSet<Request>();
            Review = new HashSet<Review>();
            Tracklist = new HashSet<Tracklist>();
            UserAlbumVote = new HashSet<UserAlbumVote>();
            UserCommentPost = new HashSet<UserCommentPost>();
            UserFollowersFollowedByUser = new HashSet<UserFollowers>();
            UserFollowersUser = new HashSet<UserFollowers>();
            UserFollowsArtist = new HashSet<UserFollowsArtist>();
            UserLikePost = new HashSet<UserLikePost>();
            UserTrackVote = new HashSet<UserTrackVote>();
        }

        public int UserId { get; set; }
        public string Username { get; set; }
        public string PasswordSalt { get; set; }
        public string PasswordHash { get; set; }
        public string Email { get; set; }
        public string About { get; set; }
        public DateTime? RegisteredAt { get; set; }
        public bool? SuspendedFlag { get; set; }
        public int? RecommendedAlbum1 { get; set; }
        public int? RecommendedAlbum2 { get; set; }
        public int? RecommendedAlbum3 { get; set; }
        public int? RecommendedArtist1 { get; set; }
        public int? RecommendedArtist2 { get; set; }
        public int? RecommendedArtist3 { get; set; }
        public byte[] UserPhoto { get; set; }
        public byte[] UserWallpaper { get; set; }

        public virtual Album RecommendedAlbum1Navigation { get; set; }
        public virtual Album RecommendedAlbum2Navigation { get; set; }
        public virtual Album RecommendedAlbum3Navigation { get; set; }
        public virtual Artist RecommendedArtist1Navigation { get; set; }
        public virtual Artist RecommendedArtist2Navigation { get; set; }
        public virtual Artist RecommendedArtist3Navigation { get; set; }
        public virtual ICollection<AlbumList> AlbumList { get; set; }
        public virtual ICollection<LoginLogTable> LoginLogTable { get; set; }
        public virtual ICollection<Notification> Notification { get; set; }
        public virtual ICollection<Post> Post { get; set; }
        public virtual ICollection<Request> Request { get; set; }
        public virtual ICollection<Review> Review { get; set; }
        public virtual ICollection<Tracklist> Tracklist { get; set; }
        public virtual ICollection<UserAlbumVote> UserAlbumVote { get; set; }
        public virtual ICollection<UserCommentPost> UserCommentPost { get; set; }
        public virtual ICollection<UserFollowers> UserFollowersFollowedByUser { get; set; }
        public virtual ICollection<UserFollowers> UserFollowersUser { get; set; }
        public virtual ICollection<UserFollowsArtist> UserFollowsArtist { get; set; }
        public virtual ICollection<UserLikePost> UserLikePost { get; set; }
        public virtual ICollection<UserTrackVote> UserTrackVote { get; set; }
    }
}
