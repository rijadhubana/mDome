using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace mDome.Model.Requests
{
    public class UserProfileUpsertRequest
    {
        [Required(AllowEmptyStrings =false)]
        public string Username { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string PasswordClearText { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string PasswordClearTextConfirm { get; set; }
        [Required(AllowEmptyStrings = false)]
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
        public bool? IsUpdateByAdmin { get; set; } = null;
        public string PwHash { get; set; } = "";
        public string PwSalt { get; set; } = "";
    }
}
