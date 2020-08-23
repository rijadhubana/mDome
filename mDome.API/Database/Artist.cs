using System;
using System.Collections.Generic;

namespace mDome.API.Database
{
    public partial class Artist
    {
        public Artist()
        {
            Album = new HashSet<Album>();
            ArtistGenre = new HashSet<ArtistGenre>();
            Post = new HashSet<Post>();
            UserFollowsArtist = new HashSet<UserFollowsArtist>();
            UserProfileRecommendedArtist1Navigation = new HashSet<UserProfile>();
            UserProfileRecommendedArtist2Navigation = new HashSet<UserProfile>();
            UserProfileRecommendedArtist3Navigation = new HashSet<UserProfile>();
        }

        public int ArtistId { get; set; }
        public string ArtistName { get; set; }
        public string ArtistBio { get; set; }
        public string ArtistMembers { get; set; }
        public byte[] ArtistPhoto { get; set; }
        public byte[] ArtistPhotoThumb { get; set; }

        public virtual ICollection<Album> Album { get; set; }
        public virtual ICollection<ArtistGenre> ArtistGenre { get; set; }
        public virtual ICollection<Post> Post { get; set; }
        public virtual ICollection<UserFollowsArtist> UserFollowsArtist { get; set; }
        public virtual ICollection<UserProfile> UserProfileRecommendedArtist1Navigation { get; set; }
        public virtual ICollection<UserProfile> UserProfileRecommendedArtist2Navigation { get; set; }
        public virtual ICollection<UserProfile> UserProfileRecommendedArtist3Navigation { get; set; }
    }
}
