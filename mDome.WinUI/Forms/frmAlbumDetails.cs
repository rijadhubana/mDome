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
using static mDome.WinUI.Helper;

namespace mDome.WinUI.Forms
{
    public partial class frmAlbumDetails : Form
    {
        private readonly int? _albumId;
        private readonly int _artistId;
        private readonly APIService _albumService = new APIService("Album");
        private readonly APIService _trackService = new APIService("Track");
        public event EventHandler<object> refreshHandler;
        public frmAlbumDetails(int artistId,int? albumId = null)
        {
            _albumId = albumId;
            _artistId = artistId;
            InitializeComponent();
        }
        AlbumUpsertRequest hold = new AlbumUpsertRequest();
        private async void frmAlbumDetails_Load(object sender, EventArgs e)
        {
            if (_albumId.HasValue)
            {
                var thisAlbum = await _albumService.GetById<Model.Album>(_albumId);
                txtAlbumName.Text = thisAlbum.AlbumName;
                txtDescription.Text = thisAlbum.AlbumDescription;
                txtDateReleased.Text = thisAlbum.DateReleased;
                hold.AlbumPhoto = thisAlbum.AlbumPhoto;
                hold.AlbumPhotoThumb = thisAlbum.AlbumPhotoThumb;
                hold.AlbumGeneratedRating = thisAlbum.AlbumGeneratedRating;
                hold.ArtistId = thisAlbum.ArtistId;
                Image imgThumb = Helper.ByteArrayToImage(hold.AlbumPhotoThumb);
                pbAlbumPhoto.Image = Helper.ResizeImage(imgThumb, 120, 120);
                btnAddTrack.Enabled = true;
                await LoadTracks((int)_albumId);
                btnDeleteAlbum.Enabled = true;
            }
        }
        private async Task LoadTracks(int albumId)
        {
            var result = await _trackService.Get<List<Model.Track>>(new TrackSearchRequest()
            {
                AlbumId = albumId
            });
            dgvTracks.AutoGenerateColumns = false;
            dgvTracks.DataSource = result;
        }

        private void btnAddPhoto_Click(object sender, EventArgs e)
        {
            var result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                var fileName = openFileDialog.FileName;
                var file = File.ReadAllBytes(fileName);
                hold.AlbumPhoto = file;
                txtImgPath.Text = fileName;
                Image image = Image.FromFile(fileName);
                Image thumbImg = Helper.ResizeImage(image, 120, 120);
                byte[] arr = Helper.ImageToByteArray(thumbImg);
                hold.AlbumPhotoThumb = arr;
                pbAlbumPhoto.Image = thumbImg;
            }
        }

        private void txtAlbumName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAlbumName.Text))
            {
                errorProvider.SetError(txtAlbumName, "Required field");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtAlbumName, null);
            }
        }

        private async void btnSubmitAlbum_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Submit Changes?",
                                     "Confirm",
                                     MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                if (this.ValidateChildren())
                {
                    var req = new AlbumUpsertRequest()
                    {
                        ArtistId = _artistId,
                        AlbumDescription = txtDescription.Text,
                        AlbumName = txtAlbumName.Text,
                        AlbumPhoto = hold.AlbumPhoto,
                        AlbumPhotoThumb = hold.AlbumPhotoThumb,
                        DateReleased = txtDateReleased.Text
                    };
                    if (req.AlbumPhoto == null)
                    {
                        Image placeholder = Image.FromFile("C:\\Users\\rijad\\source\\repos\\mDome\\mDome.WinUI\\placeholder.jpg");
                        req.AlbumPhoto = Helper.ImageToByteArray(placeholder);
                        req.AlbumPhotoThumb = Helper.ImageToByteArray(Helper.ResizeImage(placeholder, 120, 120));
                    }
                    if (_albumId.HasValue)
                    {
                        await _albumService.Update<Model.Album>(_albumId, req);
                    }
                    else
                    {
                        req.AlbumGeneratedRating = 0;
                        await _albumService.Insert<Model.Album>(req);
                        refreshHandler?.Invoke(this, null);
                        MessageBox.Show("Task successful");
                        this.Close();
                    }
                    refreshHandler?.Invoke(this, null);
                    MessageBox.Show("Task successful");
                }
            }
            
        }

        private void btnAddTrack_Click(object sender, EventArgs e)
        {
            frmTrackDetails frm = new frmTrackDetails(_artistId, (int)_albumId, null);
            frm.refreshHandler += async (object s, object q) =>
            {
                await LoadTracks((int)_albumId);
            };
            frm.Show();
        }

        private void dgvTracks_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                var id = dgvTracks.SelectedRows[0].Cells[0].Value;
                frmTrackDetails frm = new frmTrackDetails((int)_artistId, (int)_albumId, int.Parse(id.ToString()));
                frm.refreshHandler += async (object s, object q) =>
                {
                    await LoadTracks((int)_albumId);
                };
                frm.Show();
            }
            catch (Exception)
            {
                MessageBox.Show("Item unavailable");
            }
            
        }

        private async void btnDeleteAlbum_Click(object sender, EventArgs e)
        {
            string promptValue = Prompt.ShowDialog("Are you sure you want to remove this album?" +
                " Type your password to confirm.", "Confirm");
            if (APIService.Password == promptValue)
            {
                await _albumService.Delete<Model.Album>(_albumId);
                refreshHandler?.Invoke(this, null);
                MessageBox.Show("Task successful");
                this.Close();
            }
            else MessageBox.Show("Password incorrect");
        }
    }
}
