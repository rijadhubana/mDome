using mDome.Model;
using mDome.Model.Requests;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static mDome.WinUI.Helper;

namespace mDome.WinUI.Forms
{
    public partial class frmReviewDetails : Form
    {
        private int _reviewId;
        private int _thisUserId;
        private readonly APIService _reviewService = new APIService("Review");
        private readonly APIService _userService = new APIService("UserProfile");
        private readonly APIService _albumService = new APIService("Album");
        private readonly APIService _notificationService = new APIService("Notification");
        public frmReviewDetails(int id)
        {
            _reviewId = id;
            InitializeComponent();
        }

        private async void frmReviewDetails_Load(object sender, EventArgs e)
        {
            var thisReview = await _reviewService.GetById<Model.Review>(_reviewId);
            var thisAlbum = await _albumService.GetById<Model.Album>(thisReview.AlbumId);
            var thisUser = await _userService.GetById<Model.UserProfile>(thisReview.UserId);
            _thisUserId = thisUser.UserId;
            txtAlbumNameUsername.Text = thisAlbum.AlbumName + " : " + thisUser.Username;
            txtFav.Text = thisReview.FavouriteSongs;
            txtLeast.Text = thisReview.LeastFavouriteSongs;
            txtReviewText.Text = thisReview.ReviewText;
            txtRating.Text = thisReview.Rating.ToString();
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNotify.Text))
            {
                MessageBox.Show("Please leave a comment about the reason of deletion.");
                return;
            }
            string promptValue = Prompt.ShowDialog("Are you sure you want to remove this review?" +
                " Type your password to confirm.", "Confirm");
            if (APIService.Password == promptValue)
            {
                try
                {
                    await _reviewService.Delete<Model.Review>(_reviewId);
                    NotificationUpsertRequest requestAdd = new NotificationUpsertRequest()
                    {
                        UserId = _thisUserId,
                        NotifDateTime = DateTime.Now,
                        NotifText = txtNotify.Text
                    };
                    await _notificationService.Insert<Model.Notification>(requestAdd);
                    MessageBox.Show("Task successful");
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    this.Close();
                }
                
            }
            else MessageBox.Show("Password incorrect");
        }

    }
}
