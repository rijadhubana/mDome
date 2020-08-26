using mDome.Model;
using mDome.Model.Requests;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mDome.WinUI.Forms
{
    public partial class frmPostDetails : Form
    {
        private int? _postId = null;
        private readonly APIService _postService = new APIService("Post");
        private readonly APIService _artistService = new APIService("Artist");
        public event EventHandler<object> refreshHandler;
        public frmPostDetails(int? postId = null)
        {
            _postId = postId;
            InitializeComponent();
        }

        private async void frmPostDetails_Load(object sender, EventArgs e)
        {
            if (_postId.HasValue)
            {
                var result = await _postService.GetById<Model.Post>(_postId);
                txtTitle.Text = result.PostTitle;
                txtTitle.ReadOnly = true;
                txtPostText.Text = result.PostText;
                txtPostText.ReadOnly = true;
                btnAddPhoto.Enabled = false;
                btnAddPost.Enabled = false;
                btnSearch.Enabled = false;
                cmbArtists.Enabled = false;
                txtArtistSearch.ReadOnly = true;
                pbPostPhoto.Image = Helper.ResizeImage(Helper.ByteArrayToImage(result.PostPhoto), 180, 180);
                btnDeletePost.Enabled = true;
            }
            else
            {
                btnDeletePost.Enabled = false;
                await LoadArtists();
            }

        }
        private async Task LoadArtists(string searchQuery = "")
        {
            cmbArtists.DataSource = null;
            var result = await _artistService.Get<List<Model.Artist>>
                (new ArtistSearchRequest() { ArtistName = searchQuery });
            result.Insert(0, new Model.Artist() { ArtistId = 0 });
            cmbArtists.DataSource = result;
            cmbArtists.DisplayMember = "ArtistName";
            cmbArtists.ValueMember = "ArtistId";
        }
        PostUpsertRequest request = new PostUpsertRequest() { PostPhoto = null,AdminName=APIService.Username };

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            await LoadArtists(txtArtistSearch.Text);
        }

        private void btnAddPhoto_Click(object sender, EventArgs e)
        {
            var result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                var fileName = openFileDialog.FileName;
                var file = File.ReadAllBytes(fileName);
                request.PostPhoto = file;
                txtPhoto.Text = fileName;
                Image image = Image.FromFile(fileName);
                Image thumbImg = Helper.ResizeImage(image, 180, 180);
                pbPostPhoto.Image = thumbImg;
            }
        }

        private async void btnAddPost_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Submit post ?",
                                     "Confirm",
                                     MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                var idObj = cmbArtists.SelectedValue;
                if (int.TryParse(idObj.ToString(), out int id))
                {
                    if (id == 0 && chbGlobal.Checked == false)
                    {
                        MessageBox.Show("You must either make a post global, or assign it to an artist!");
                        return;
                    }
                    if (id == 0)
                        request.ArtistRelatedId = null;
                    else request.ArtistRelatedId = id;
                }
                if (this.ValidateChildren())
                {
                    request.IsGlobal = chbGlobal.Checked;
                    request.Opphoto = File.ReadAllBytes("C:\\Users\\rijad\\source\\repos\\mDome\\mDome.WinUI\\adminIcon.png");
                    if (request.PostPhoto == null)
                        request.PostPhoto = File.ReadAllBytes("C:\\Users\\rijad\\source\\repos\\mDome\\mDome.WinUI\\placeholder.jpg");
                    request.PostDateTime = DateTime.Now;
                    request.PostText = txtPostText.Text;
                    request.PostTitle = txtTitle.Text;
                    request.ReviewRelatedId = null;
                    request.UserRelatedId = null;
                    await _postService.Insert<Model.Post>(request);
                    MessageBox.Show("Task successful");
                    refreshHandler?.Invoke(this, null);
                    this.Close();
                }
            }

        }


        private void txtPostText_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPostText.Text))
            {
                errorProvider.SetError(txtPostText, "Required field");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtPostText, null);
            }
        }

        private void txtTitle_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                errorProvider.SetError(txtTitle, "Required field");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtTitle, null);
            }

        }

        private async void btnDeletePost_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Are you sure you want to delete this post ?",
                                     "Confirm",
                                     MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                try
                {
                    await _postService.Delete<Model.Post>(_postId);
                    MessageBox.Show("Task successful");
                    refreshHandler?.Invoke(this, null);
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    this.Close();
                }

            }
        }
    }
}
