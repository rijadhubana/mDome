using mDome.Model;
using mDome.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mDome.MobileApp.Helper
{
    public static class GlobalMethods
    {
        private readonly static APIService _albumService = new APIService("Album");
        private readonly static APIService _trackService = new APIService("Track");
        private readonly static APIService _userAlbumVoteService = new APIService("UserAlbumVote");
        private readonly static APIService _reviewService = new APIService("Review");
        private readonly static APIService _userTrackVoteService = new APIService("UserTrackVote");
        private readonly static APIService _tracklistService = new APIService("Tracklist");
        private readonly static APIService _tracklistTrackService = new APIService("TracklistTrack");
        public static bool HasValue(this double value)
        {
            return !Double.IsNaN(value) && !Double.IsInfinity(value);
        }
        public static string GenerateUniqueId()
        {
            var newGuid = Guid.NewGuid();
            var messageID = Convert.ToBase64String(newGuid.ToByteArray());
            return messageID.Substring(0, 18);
        }
        public static async Task GenerateRating(int AlbumId)
        {
            Album thisAlbum = await _albumService.GetById<Album>(AlbumId);
            var albumVotes = await _userAlbumVoteService.Get<List<UserAlbumVote>>(new UserAlbumVoteSearchRequest() { AlbumId = AlbumId });
            var tracks = await _trackService.Get<List<Track>>(new TrackSearchRequest() { AlbumId = AlbumId });
            float albumLikesPercentage = (float)albumVotes.Where(a => a.Liked == true).Count() / albumVotes.Count();
            if (!HasValue(albumLikesPercentage))
                albumLikesPercentage = 1;
            int aggregateTrackLikes = 0;
            int aggregateVotes = 0;
            foreach (var item in tracks)
            {
                var trackVotes = await _userTrackVoteService.Get<List<UserTrackVote>>(new UserTrackVoteSearchRequest() { TrackId = item.TrackId });
                aggregateTrackLikes += trackVotes.Where(a => a.Liked == true).Count();
                aggregateVotes += trackVotes.Count();
            }
            float trackLikesPercentage = (float)aggregateTrackLikes / aggregateVotes;
            if (!HasValue(trackLikesPercentage))
                trackLikesPercentage = 1;
            var reviewsAlbum = await _reviewService.Get<List<Review>>(new ReviewSearchRequest() { AlbumId = AlbumId });
            int sumRatings = reviewsAlbum.Sum(a => a.Rating);
            float percentageReviews = (float)sumRatings / (reviewsAlbum.Count * 5);
            if (!HasValue(percentageReviews))
                percentageReviews = 1;
            double ratingCombined = (double)(percentageReviews + albumLikesPercentage + trackLikesPercentage) / 3;
            ratingCombined *= 5;
            string str = ratingCombined.ToString("0.0");
            ratingCombined = Double.Parse(str);
            AlbumUpsertRequest updatedAlbum = new AlbumUpsertRequest()
            {
                AlbumDescription = thisAlbum.AlbumDescription,
                AlbumGeneratedRating = ratingCombined,
                AlbumName = thisAlbum.AlbumName,
                AlbumPhoto = thisAlbum.AlbumPhoto,
                AlbumPhotoThumb = thisAlbum.AlbumPhotoThumb,
                ArtistId = thisAlbum.ArtistId,
                DateReleased = thisAlbum.DateReleased
            };
            await _albumService.Update<Model.Album>(AlbumId, updatedAlbum);
        }
        public static async Task IncreaseViewCountUpdateHistory(int trackId)
        {
            var thisTrack = await _trackService.GetById<Track>(trackId);
            var res = await _tracklistService.Get<List<Tracklist>>(new TracklistSearchRequest()
            {
                TracklistName = "History",
                UserId = APIService.loggedProfile.UserId
            });
            Tracklist history = res.FirstOrDefault();
            var res1 = await _tracklistTrackService.Get<List<TracklistTrack>>(new TracklistTrackSearchRequest()
            {
                TrackId = trackId,
                TracklistId = history.TracklistId
            });
            if (res1.Count==0)
            {
                await _tracklistTrackService.Insert<TracklistTrack>(new TracklistTrackUpsertRequest()
                {
                    TracklistId = history.TracklistId,
                    DateAdded = DateTime.Now,
                    TrackId = trackId
                });
                await _trackService.Update<Track>(trackId, new TrackUpsertRequest()
                {
                    AlbumId = thisTrack.AlbumId,
                    TrackLyrics = thisTrack.TrackLyrics,
                    TrackName = thisTrack.TrackName,
                    TrackNumber = thisTrack.TrackNumber,
                    TrackViews = thisTrack.TrackViews + 1,
                    TrackYoutubeId = thisTrack.TrackYoutubeId
                });
            }
            else
            {
                TimeSpan diff = (TimeSpan)(DateTime.Now - res1.FirstOrDefault().DateAdded);
                await _tracklistTrackService.Update<TracklistTrack>(0, new TracklistTrackUpsertRequest()
                {
                    DateAdded = DateTime.Now,
                    TrackId = trackId,
                    TracklistId = history.TracklistId
                });
                await _tracklistTrackService.Insert<TracklistTrack>(new TracklistTrackUpsertRequest()
                {
                    DateAdded = DateTime.Now,
                    TrackId = trackId,
                    TracklistId = history.TracklistId
                });
                if (diff.Days != 0)
                {
                    await _trackService.Update<Track>(trackId, new TrackUpsertRequest()
                    {
                        AlbumId = thisTrack.AlbumId,
                        TrackLyrics = thisTrack.TrackLyrics,
                        TrackName = thisTrack.TrackName,
                        TrackNumber = thisTrack.TrackNumber,
                        TrackViews = thisTrack.TrackViews + 1,
                        TrackYoutubeId = thisTrack.TrackYoutubeId
                    });
                }
               
            }
        }
    }
}
