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
using static mDome.WinUI.Helper;

namespace mDome.WinUI.Forms
{
    public partial class frmArtistDetails : Form
    {
        private readonly APIService _genreService = new APIService("Genre");
        private readonly APIService _artistService = new APIService("Artist");
        private readonly APIService _artistGenreService = new APIService("ArtistGenre");
        private readonly int? _id = null;
        public event EventHandler<object> refreshHandler;
        public event EventHandler<object> deleteHandlerArtist;
        public frmArtistDetails(int? id = null)
        {
            _id = id;
            InitializeComponent();
        }
        ArtistUpsertRequest requestHold = new ArtistUpsertRequest();
        private void btnAddPhoto_Click(object sender, EventArgs e)
        {
            var result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                var fileName = openFileDialog1.FileName;
                var file = File.ReadAllBytes(fileName);
                requestHold.ArtistPhoto = file;
                txtPhoto.Text = fileName;
                Image image = Image.FromFile(fileName);
                Image thumbImg = Helper.ResizeImage(image, 120, 120);
                byte[] arr = Helper.ImageToByteArray(thumbImg);
                requestHold.ArtistPhotoThumb = arr;
                pbPhoto.Image = thumbImg;
            }
        }

        private async void frmArtistDetails_Load(object sender, EventArgs e)
        {
            var genres = await _genreService.Get<List<Model.Genre>>(null);
            clbGenres.DataSource = genres;
            clbGenres.DisplayMember = "GenreName";
            if (_id.HasValue)
            {
                var artist = await _artistService.GetById<Model.Artist>(_id);
                txtArtistName.Text = artist.ArtistName;
                txtArtistBio.Text = artist.ArtistBio;
                txtMembers.Text = artist.ArtistMembers;
                pbPhoto.Image = Helper.ByteArrayToImage(artist.ArtistPhotoThumb);
                requestHold.ArtistPhoto = artist.ArtistPhoto;
                requestHold.ArtistPhotoThumb = artist.ArtistPhotoThumb;
                btnAlbums.Enabled = true;
                btnDeleteArtist.Enabled = true;
            }
        }

        private async void btnSubmit_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Submit Changes?",
                                    "Confirm",
                                    MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                if (this.ValidateChildren())
                {
                    var genres = clbGenres.CheckedItems.Cast<Model.Genre>().Select(x => x.GenreId).ToList();
                    var req = new ArtistUpsertRequest()
                    {
                        ArtistName = txtArtistName.Text,
                        ArtistBio = txtArtistBio.Text,
                        ArtistMembers = txtMembers.Text,
                        ArtistPhoto = requestHold.ArtistPhoto,
                        ArtistPhotoThumb = requestHold.ArtistPhotoThumb,
                        Genres = genres
                    };
                    if (req.ArtistPhoto == null)
                    {
                        Image placeholder = Image.FromFile(Helper.GetImagePath("placeholder.jpg"));
                        req.ArtistPhoto = Helper.ImageToByteArray(placeholder);
                        req.ArtistPhotoThumb = Helper.ImageToByteArray(Helper.ResizeImage(placeholder, 120, 120));
                    }
                    if (_id.HasValue)
                        await _artistService.Update<Model.Artist>(_id, req);
                    else
                    {
                        await _artistService.Insert<Model.Artist>(req);
                        refreshHandler?.Invoke(this, null);
                        MessageBox.Show("Task successful");
                        this.Close();
                    }
                    refreshHandler?.Invoke(this, null);
                    MessageBox.Show("Task successful");
                }
            }
               
        }

        private void txtArtistName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtArtistName.Text))
            {
                errorProvider.SetError(txtArtistName, "Required field");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtArtistName, null);
            }
        }

        private void btnAlbums_Click(object sender, EventArgs e)
        {
            frmAlbums frm = new frmAlbums(_id);
            frm.Show();
        }

        private void btnDeleteArtist_Click(object sender, EventArgs e)
        {
            string promptValue = Prompt.ShowDialog("Are you sure you want to remove this artist?" +
                " Type your password to confirm.", "Confirm");
            if (APIService.Password == promptValue)
            {
                deleteHandlerArtist?.Invoke(this, _id);
            }
            else MessageBox.Show("Password incorrect");
        }
    }
}
