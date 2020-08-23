using System;
using System.Collections.Generic;

namespace mDome.API.Database
{
    public partial class Album
    {
        public Album()
        {
            AlbumListAlbum = new HashSet<AlbumListAlbum>();
            Review = new HashSet<Review>();
            Track = new HashSet<Track>();
            UserAlbumVote = new HashSet<UserAlbumVote>();
            UserProfileRecommendedAlbum1Navigation = new HashSet<UserProfile>();
            UserProfileRecommendedAlbum2Navigation = new HashSet<UserProfile>();
            UserProfileRecommendedAlbum3Navigation = new HashSet<UserProfile>();
        }

        public int AlbumId { get; set; }
        public string AlbumName { get; set; }
        public string AlbumDescription { get; set; }
        public double? AlbumGeneratedRating { get; set; }
        public byte[] AlbumPhoto { get; set; }
        public byte[] AlbumPhotoThumb { get; set; }
        public int ArtistId { get; set; }
        public string DateReleased { get; set; }

        public virtual Artist Artist { get; set; }
        public virtual ICollection<AlbumListAlbum> AlbumListAlbum { get; set; }
        public virtual ICollection<Review> Review { get; set; }
        public virtual ICollection<Track> Track { get; set; }
        public virtual ICollection<UserAlbumVote> UserAlbumVote { get; set; }
        public virtual ICollection<UserProfile> UserProfileRecommendedAlbum1Navigation { get; set; }
        public virtual ICollection<UserProfile> UserProfileRecommendedAlbum2Navigation { get; set; }
        public virtual ICollection<UserProfile> UserProfileRecommendedAlbum3Navigation { get; set; }
    }
}
