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
using System.Net;

namespace mDome.WinUI.Forms
{
    public partial class frmAlbums : Form
    {
        private readonly int? _artistId;
        private readonly APIService _albumService = new APIService("Album");
        public frmAlbums(int? id)
        {
            _artistId = id;
            InitializeComponent();
        }

        private async void frmAlbums_Load(object sender, EventArgs e)
        {
            await LoadAlbums();
        }

        private async Task LoadAlbums(string name="")
        {
            var result = await _albumService.Get<List<Model.Album>>(new AlbumSearchRequest()
            {
                AlbumName = name,
                ArtistId = (int)_artistId
            });
            dgvAlbums.AutoGenerateColumns = false;
            dgvAlbums.DataSource = result;
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            await LoadAlbums(txtAlbumName.Text);
        }

        private void btnAddAlbum_Click(object sender, EventArgs e)
        {
            frmAlbumDetails frm = new frmAlbumDetails((int)_artistId);
            frm.refreshHandler += async (object s, object q) =>
            {
                await LoadAlbums("");
            };
            frm.Show();
        }

        private void dgvAlbums_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            { 
            var id = dgvAlbums.SelectedRows[0].Cells[0].Value;
            frmAlbumDetails frm = new frmAlbumDetails((int)_artistId,int.Parse(id.ToString()));
            frm.refreshHandler += async (object s, object q) =>
            {
                await LoadAlbums("");
            };
            frm.Show();
            }
            catch (Exception)
            {
                MessageBox.Show("Item unavailable");
            }
        }
    }
}
