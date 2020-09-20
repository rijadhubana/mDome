using mDome.Model;
using mDome.Model.Requests;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mDome.WinUI.Forms
{
    public partial class frmDashboard : Form
    {
        private readonly APIService _trackService = new APIService("Track");
        private readonly APIService _userTrackVote = new APIService("UserTrackVote");
        private readonly APIService _userProfileService = new APIService("UserProfile");
        private readonly APIService _loginLogTableService = new APIService("LoginLogTable");
        private readonly APIService _reviewService = new APIService("Review");
        public frmDashboard()
        {
            InitializeComponent();
        }

        private async void frmDashboard_Load(object sender, EventArgs e)
        {
            Image loginImg = Image.FromFile(Helper.GetImagePath("loginIcon.png"));
            Image pbloginImg = Helper.ResizeImage(loginImg, 75,75);
            pbLogins.Image = pbloginImg;
            var logins = await _loginLogTableService.Get<List<LoginLogTable>>(null);
            int number = logins.Where(a => a.DateOfLogin.Day == DateTime.Now.Day &&
            a.DateOfLogin.Month == DateTime.Now.Month && a.DateOfLogin.Year == DateTime.Now.Year).ToList().Count();
            txtLogins.Text = number.ToString();
            Image usersImg = Image.FromFile(Helper.GetImagePath("profile.png"));
            Image pbusersImg = Helper.ResizeImage(usersImg, 75, 75);
            pbUsers.Image = pbusersImg;
            var users = await _userProfileService.Get<List<UserProfile>>(null);
            txtUsers.Text = users.Count.ToString();
            Image songsListenedImg = Image.FromFile(Helper.GetImagePath("songgray.png"));
            Image pbSongsListenedImg = Helper.ResizeImage(songsListenedImg, 75, 75);
            pbSongsListened.Image = pbSongsListenedImg;
            var songs = await _trackService.Get<List<Track>>(null);
            int numberOfViews = (int)songs.Sum(a =>a.TrackViews);
            txtSongsListened.Text = numberOfViews.ToString();
            Image reviewsImg = Image.FromFile(Helper.GetImagePath("reviewIcon.png"));
            Image pbReviewsImg = Helper.ResizeImage(reviewsImg, 75, 75);
            pbReviews.Image = pbReviewsImg;
            var reviews = await _reviewService.Get<List<Review>>(null);
            txtReviews.Text = reviews.Count.ToString();
            Image songsLikedImg = Image.FromFile(Helper.GetImagePath("alreadyliked.png"));
            Image pbsongsLikedImg = Helper.ResizeImage(songsLikedImg, 75, 75);
            pbSongsLiked.Image = pbsongsLikedImg;
            var likes = await _userTrackVote.Get<List<UserTrackVote>>(new UserTrackVoteSearchRequest() { Liked = true });
            txtSongsLiked.Text = likes.Count.ToString();
            Image newUsers = Image.FromFile(Helper.GetImagePath("profilegreen.png"));
            Image pbnewUsersImg = Helper.ResizeImage(newUsers, 75, 75);
            pbNewUsers.Image = pbnewUsersImg;
            int numberOfNewUsers = users.Where(a => a.RegisteredAt.Value.Year == DateTime.Now.Year && a.RegisteredAt.Value.Month == DateTime.Now.Month).Count();
            txtNewUsers.Text = numberOfNewUsers.ToString();
        }
    }
}
