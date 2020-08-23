using System;
using System.Collections.Generic;
using System.Text;

namespace mDome.Model
{
    public class UserProfile
    {
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
    }
}
