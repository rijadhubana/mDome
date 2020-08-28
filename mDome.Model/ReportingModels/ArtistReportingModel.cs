using System;
using System.Collections.Generic;
using System.Text;

namespace mDome.Model
{
    public class ArtistReportingModel
    {
        public string ArtistName { get; set; }
        public string ArtistGenresInString { get; set; }
        public string ArtistAlbumsCombinedLikes { get; set; }
        public string ArtistFollowersNumber { get; set; }
        public string ReviewNumberCombined { get; set; }
        public string ArtistCombinedRatingPercent { get; set; }
        public string MostPopularAlbumByViews { get; set; }
        public string BestRatedAlbum { get; set; }
        public string TracksCombinedLikes { get; set; }
        public string MostViewedTrack { get; set; }
        public string MostLikedTrack { get; set; }
        public string TracklistedNumber { get; set; }
        public string AlbumListedNumber { get; set; }
        public string CombinedViews { get; set; }
        public string ArtistTimesFeaturedOnProfile { get; set; }
        public string AlbumsTimesFeaturedOnProfile { get; set; }
    }
}
