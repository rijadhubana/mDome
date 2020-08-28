using mDome.Model;
using mDome.Model.Requests;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mDome.WinUI
{
    public class Helper
    {
        public static Bitmap ResizeImage(Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }
        public static byte[] ImageToByteArray(Image x)
        {
            ImageConverter _imageConverter = new ImageConverter();
            byte[] xByte = (byte[])_imageConverter.ConvertTo(x, typeof(byte[]));
            return xByte;
        }
        public static Image ByteArrayToImage(byte[] array)
        {
            using (var ms = new MemoryStream(array))
            {
                return Image.FromStream(ms);
            }
        }
        public static string GetImagePath(string imgName)
        {
            string exeFile = (new System.Uri(Assembly.GetEntryAssembly().CodeBase)).AbsolutePath;
            string exeDir = Path.GetDirectoryName(exeFile);
            string fullPath = Path.Combine(exeDir, "..\\..\\"+imgName);
            return fullPath;
        }
        public static class Prompt
        {
            public static string ShowDialog(string text, string caption)
            {
                Form prompt = new Form()
                {
                    Width = 500,
                    Height = 150,
                    FormBorderStyle = FormBorderStyle.FixedDialog,
                    Text = caption,
                    StartPosition = FormStartPosition.CenterScreen
                };
                Label textLabel = new Label() { Left = 50, Top = 20, Text = text, Width=400 };
                TextBox textBox = new TextBox() { Left = 50, Top = 50, Width = 400,PasswordChar='*' };
                Button confirmation = new Button() { Text = "Ok", Left = 350, Width = 100, Top = 70, DialogResult = DialogResult.OK };
                confirmation.Click += (sender, e) => { prompt.Close(); };
                prompt.Controls.Add(textBox);
                prompt.Controls.Add(confirmation);
                prompt.Controls.Add(textLabel);
                prompt.AcceptButton = confirmation;

                return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : "";
            }
        }
        private readonly static APIService _artistService = new APIService("Artist");
        private readonly static APIService _genreService = new APIService("Genre");
        private readonly static APIService _artistGenreService = new APIService("ArtistGenre");
        private readonly static APIService _albumService = new APIService("Album");
        private readonly static APIService _trackService = new APIService("Track");
        private readonly static APIService _reviewService = new APIService("Review");
        private readonly static APIService _userAlbumVoteService = new APIService("UserAlbumVote");
        private readonly static APIService _userFollowsArtist = new APIService("UserFollowsArtist");
        private readonly static APIService _userTrackVote = new APIService("UserTrackVote");
        private readonly static APIService _albumListAlbum = new APIService("AlbumListAlbum");
        private readonly static APIService _tracklistTrack = new APIService("TracklistTrack");
        private readonly static APIService _userService = new APIService("UserProfile");
        private static async Task<int> NumberOfRecommendedAlbumTimes(int albumId)
        {
            var allUsers = await _userService.Get<List<UserProfile>>(null);
            int sum = 0;
            sum += allUsers.Where(a => a.RecommendedAlbum1 == albumId).Count();
            sum += allUsers.Where(a => a.RecommendedAlbum2 == albumId).Count();
            sum += allUsers.Where(a => a.RecommendedAlbum3 == albumId).Count();
            return sum;
        }
        private static async Task<int> NumberOfRecommendedArtistTimes(int artistId)
        {
            var allUsers = await _userService.Get<List<UserProfile>>(null);
            int sum = 0;
            sum += allUsers.Where(a => a.RecommendedArtist1 == artistId).Count();
            sum += allUsers.Where(a => a.RecommendedArtist2 == artistId).Count();
            sum += allUsers.Where(a => a.RecommendedArtist3 == artistId).Count();
            return sum;
        }
        public static async Task<ArtistReportingModel> GenerateReport(int artistId)
        {
            
            ArtistReportingModel thisReportingModel = new ArtistReportingModel();
            var thisArtist = await _artistService.GetById<Artist>(artistId);
            thisReportingModel.ArtistName = thisArtist.ArtistName;
            var allGenres = await _genreService.Get<List<Genre>>(null);
            var allArtistGenres = await _artistGenreService.Get<List<ArtistGenre>>(
                new ArtistGenreSearchRequest() { ArtistId = artistId });
            string genresStr = "";
            foreach (var x in allArtistGenres)
            {
                genresStr += allGenres.Where(a => a.GenreId == x.GenreId).Select(a => a.GenreName).FirstOrDefault();
                if (x != allArtistGenres.ElementAt(allArtistGenres.Count - 1))
                    genresStr += ", ";
            }
            thisReportingModel.ArtistGenresInString = genresStr;
            var albumsByArtist = await _albumService.Get<List<Album>>(new AlbumSearchRequest() { ArtistId = artistId });
            int albumSumLikes = 0;
            int albumNumberFeatured = 0;
            int albumListedNumbers = 0;
            int reviewsNumber = 0;
            //album related queries
            List<Track> allTracksFromArtist = new List<Track>();
            List<Tuple<string, int>> AlbumNamePlusViews = new List<Tuple<string, int>>();
            foreach (var item in albumsByArtist)
            {
                var albumLikes = await _userAlbumVoteService.Get<List<UserAlbumVote>>(new UserAlbumVoteSearchRequest()
                {
                    AlbumId = item.AlbumId, Liked=true
                });
                albumSumLikes += albumLikes.Count;
                var tracksFromAlbum = await _trackService.Get<List<Track>>(new TrackSearchRequest()
                {
                    AlbumId = item.AlbumId
                });
                albumNumberFeatured += await NumberOfRecommendedAlbumTimes(item.AlbumId);
                AlbumNamePlusViews.Add(new Tuple<string, int>(item.AlbumName, (int)tracksFromAlbum.Sum(a => a.TrackViews)));
                allTracksFromArtist.AddRange(tracksFromAlbum);
                var inAlbumLists = await _albumListAlbum.Get<List<AlbumListAlbum>>(new AlbumListAlbumSearchRequest() { AlbumId = item.AlbumId });
                albumListedNumbers += inAlbumLists.Count;
                var reviews = await _reviewService.Get<List<Review>>(new ReviewSearchRequest()
                {
                    AlbumId = item.AlbumId
                });
                reviewsNumber += reviews.Count;
            }
            AlbumNamePlusViews.Sort((x, y) => y.Item2.CompareTo(x.Item2));
            if (AlbumNamePlusViews.Count != 0)
                thisReportingModel.MostPopularAlbumByViews = AlbumNamePlusViews.First().Item1;
            thisReportingModel.AlbumListedNumber = albumListedNumbers.ToString();
            thisReportingModel.ArtistAlbumsCombinedLikes = albumSumLikes.ToString();
            thisReportingModel.AlbumsTimesFeaturedOnProfile = albumNumberFeatured.ToString();
            thisReportingModel.ReviewNumberCombined = reviewsNumber.ToString();
            if (albumsByArtist.Count!=0)
                thisReportingModel.BestRatedAlbum = albumsByArtist.OrderByDescending(a => a.AlbumGeneratedRating).First().AlbumName;
            //track related queries
            int tracksLikes = 0;
            int tracklistedNumber = 0;
            List<Tuple<string, int>> TrackNamePlusLikes = new List<Tuple<string, int>>();
            foreach (var item in allTracksFromArtist)
            {
                var likesForTrack = await _userTrackVote.Get<List<UserTrackVote>>(new UserTrackVoteSearchRequest() { TrackId = item.TrackId, Liked = true });
                tracksLikes += likesForTrack.Count;
                TrackNamePlusLikes.Add(new Tuple<string, int>(item.TrackName, likesForTrack.Count));
                var tracklistedNumberTrack = await _tracklistTrack.Get<List<TracklistTrack>>(new TracklistTrackSearchRequest()
                {
                    TrackId = item.TrackId
                });
                tracklistedNumber += tracklistedNumberTrack.Count;
            }
            TrackNamePlusLikes.Sort((x, y) => y.Item2.CompareTo(x.Item2));
            if (TrackNamePlusLikes.Count != 0)
                thisReportingModel.MostLikedTrack = TrackNamePlusLikes.First().Item1;
            thisReportingModel.TracksCombinedLikes = tracksLikes.ToString();
            thisReportingModel.TracklistedNumber = tracklistedNumber.ToString();
            if (allTracksFromArtist.Count!=0)
                thisReportingModel.MostViewedTrack = allTracksFromArtist.OrderByDescending(a => a.TrackViews).First().TrackName;
            thisReportingModel.CombinedViews = ((int)allTracksFromArtist.Sum(a => a.TrackViews)).ToString();
            thisReportingModel.ArtistTimesFeaturedOnProfile = (await NumberOfRecommendedArtistTimes(artistId)).ToString();
            var followers = await _userFollowsArtist.Get<List<UserFollowsArtist>>(new UserFollowsArtistSearchRequest()
            {
                ArtistId = artistId
            });
            thisReportingModel.ArtistFollowersNumber = followers.Count.ToString();
            double rating = (double)albumsByArtist.Sum(a => a.AlbumGeneratedRating);
            rating /= albumsByArtist.Count;
            rating *= 20;
            string ratingStr = rating.ToString("0.0");
            thisReportingModel.ArtistCombinedRatingPercent = ratingStr;
            return thisReportingModel;
        }
    }
}
