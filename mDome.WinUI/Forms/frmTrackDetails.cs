using Flurl.Http;
using mDome.Model;
using mDome.Model.Requests;
using mDome.Model.YoutubeModels;
using Newtonsoft.Json;
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
    public partial class frmTrackDetails : Form
    {
        private readonly APIService _trackService = new APIService("Track");
        private readonly APIService _artistService = new APIService("Artist");
        private readonly YtService _ytService = new YtService();
        private readonly LyricsOvhService _lyricsOvhService = new LyricsOvhService();
        private readonly int? _trackId;
        private readonly int? _albumId;
        private readonly int? _artistId;
        private string _artistName;
        public event EventHandler<object> refreshHandler;
        public frmTrackDetails(int artistId,int albumId,int? trackId=null)
        {
            _artistId = artistId;
            _albumId = albumId;
            _trackId = trackId;
            InitializeComponent();
        }

        private void txtTrackName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTrackName.Text))
            {
                errorProvider.SetError(txtTrackName, "Required field");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtTrackName, null);
            }
        }
        TrackUpsertRequest hold = new TrackUpsertRequest();
        private async void frmTrackDetails_Load(object sender, EventArgs e)
        {
            var result = await _artistService.GetById<Model.Artist>(_artistId);
            _artistName = result.ArtistName;
            hold.AlbumId = (int)_albumId;
            if (_trackId.HasValue)
            {
                var thisTrack = await _trackService.GetById<Model.Track>(_trackId);
                txtTrackName.Text = thisTrack.TrackName;
                txtTrackNumber.Text = thisTrack.TrackNumber.ToString();
                txtLyrics.Text = thisTrack.TrackLyrics;
                txtYtid.Text = thisTrack.TrackYoutubeId;
                hold.TrackViews = thisTrack.TrackViews;
                hold.AlbumId = thisTrack.AlbumId;
                btnDelete.Enabled = true;
            }
        }
        private void SetPropertiesNull()
        {
            txtTrackName.Text = "";
            txtTrackNumber.Text = "";
            txtYtid.Text = "";
            txtLyrics.Text = "";
        }
        private async void btnFetch_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {
                try
                {
                    var result = await _ytService.Get<Root>(_artistName + " - " + txtTrackName.Text);
                    txtYtid.Text = result.items[0].id.videoId;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                
                try
                {
                    var lyricsResult = await _lyricsOvhService.Get<LyricsResponse>(_artistName, txtTrackName.Text);
                    txtLyrics.Text = lyricsResult.lyrics;
                }
                catch (FlurlHttpException ex)
                {
                    if (ex.Call.HttpStatus == System.Net.HttpStatusCode.NotFound)
                    {
                        txtLyrics.Text = "Lyrics not found.";
                    }
                }
                
            }
            else MessageBox.Show("Please enter the track name to fetch YouTube Id and lyrics");
        }

        private async void btnSubmitTrack_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {
                TrackUpsertRequest request = new TrackUpsertRequest()
                {
                    AlbumId = hold.AlbumId,
                    TrackName = txtTrackName.Text,
                    TrackLyrics = txtLyrics.Text,
                    TrackNumber = int.Parse(txtTrackNumber.Text),
                    TrackViews = hold.TrackViews,
                    TrackYoutubeId = txtYtid.Text
                };
                if (_trackId.HasValue)
                    await _trackService.Update<Model.Track>(_trackId, request);
                else
                {
                    request.TrackViews = 0;
                    await _trackService.Insert<Model.Track>(request);
                    SetPropertiesNull();
                }
                refreshHandler?.Invoke(this, null);
                MessageBox.Show("Task successful");
            }
            
        }

        private void txtTrackNumber_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtTrackNumber.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                txtTrackNumber.Text = txtTrackNumber.Text.Remove(txtTrackNumber.Text.Length - 1);
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Are you sure you want to delete this track ?",
                                     "Confirm",
                                     MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                await _trackService.Delete<Model.Track>(_trackId);
                refreshHandler?.Invoke(this, null);
                MessageBox.Show("Task successful");
                this.Close();
            }
          }


    }
}
