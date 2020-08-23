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

namespace mDome.WinUI.Forms
{
    public partial class frmReviewList : Form
    {
        private readonly APIService _reviewService = new APIService("Review");
        private readonly APIService _albumService = new APIService("Album");
        public frmReviewList()
        {
            InitializeComponent();
        }

        private async void frmReviewList_Load(object sender, EventArgs e)
        {
            await LoadAlbums();
            await LoadReviews(null, null, null);
        }
        private async Task LoadReviews(int? albumId=null,int? ratingFrom=null,int? ratingTo = null)
        {
            ReviewSearchRequest request = new ReviewSearchRequest()
            {
                AlbumId = albumId,
                RatingFrom = ratingFrom,
                RatingTo = ratingTo
            };
            if (albumId==null && ratingFrom==null && ratingTo==null)
            {
                var result = await _albumService.Get<List<Model.Review>>(null);
                if (result.Count == 0)
                dgvReviews.DataSource = result;
            }
            else
            {
                var result = await _albumService.Get<List<Model.Review>>(request);
                dgvReviews.DataSource = result;
            }
            
        }
        private async Task LoadAlbums(string searchQuery="")
        {
            cmbAlbums.DataSource = null;
            var result = await _albumService.Get<List<Model.Album>>
                (new AlbumSearchRequest() { AlbumName = searchQuery });
            result.Insert(0, new Model.Album() { AlbumId = 0 });
            cmbAlbums.DataSource = result;
            cmbAlbums.DisplayMember = "AlbumName";
            cmbAlbums.ValueMember = "AlbumId";
        }
        

        private void txtRatingFrom_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtRatingFrom.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                txtRatingFrom.Text = txtRatingFrom.Text.Remove(txtRatingFrom.Text.Length - 1);
            }
            if (!string.IsNullOrWhiteSpace(txtRatingFrom.Text))
                if (int.Parse(txtRatingFrom.Text) < 0 || int.Parse(txtRatingFrom.Text) > 5)
                {
                    MessageBox.Show("Please enter a valid number (0-5).");
                    txtRatingFrom.Text = txtRatingFrom.Text.Remove(txtRatingFrom.Text.Length - 1);
                }
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            await LoadAlbums(txtAlbumSearch.Text);
        }

        private async void btnSearchReviews_Click(object sender, EventArgs e)
        {
            int? ratingFrom = null;
            int? ratingTo = null;
            if (!string.IsNullOrWhiteSpace(txtRatingFrom.Text))
                ratingFrom = int.Parse(txtRatingFrom.Text);
            if (!string.IsNullOrWhiteSpace(lbl.Text))
                ratingTo = int.Parse(txtRatingTo.Text);
            var idObj = cmbAlbums.SelectedValue;
            if (int.TryParse(idObj.ToString(), out int id))
            {
                if (id == 0)
                    await LoadReviews(null, ratingFrom, ratingTo);
                else await LoadReviews(id, ratingFrom, ratingTo);
            }
        }

        private void txtRatingTo_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtRatingTo.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                txtRatingTo.Text = txtRatingTo.Text.Remove(txtRatingTo.Text.Length - 1);
            }
            if (!string.IsNullOrWhiteSpace(txtRatingTo.Text))
                if (int.Parse(txtRatingTo.Text)<0 || int.Parse(txtRatingTo.Text) > 5)
                {
                    MessageBox.Show("Please enter a valid number (0-5).");
                    txtRatingTo.Text = txtRatingTo.Text.Remove(txtRatingTo.Text.Length - 1);
                }
        }

        private void dgvReviews_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var id = dgvReviews.SelectedRows[0].Cells[0].Value;
            frmReviewDetails frm = new frmReviewDetails(int.Parse(id.ToString()));
            frm.Show();
        }
    }
}
