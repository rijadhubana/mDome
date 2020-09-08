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

namespace mDome.WinUI.Forms
{

    public partial class frmArtistList : Form
    {
        private readonly APIService _genreService = new APIService("Genre");
        private readonly APIService _artistGenreService = new APIService("ArtistGenre");
        private readonly APIService _artistService = new APIService("Artist");
        public frmArtistList()
        {
            InitializeComponent();
        }

        private async void frmArtistList_Load(object sender, EventArgs e)
        {
            await LoadGenres();
            await LoadArtists();
        }

        private async Task LoadGenres()
        {
            var result = await _genreService.Get<List<Model.Genre>>(null);
            result.Insert(0, new Model.Genre() { GenreId=0 });
            cmbGenre.DataSource = result;
            cmbGenre.DisplayMember = "GenreName";
            cmbGenre.ValueMember = "GenreId";
        }
        private async Task LoadArtists(int genreId = 0,string search="")
        {
            List<Model.Artist> artistList = await _artistService.Get<List<Model.Artist>>(null);
            if (genreId!=0)
            {
                var genreArtistList = await _artistGenreService.Get<List<Model.ArtistGenre>>(new ArtistGenreSearchRequest()
                {
                    GenreId = (int)genreId
                });
                foreach (var item in artistList.ToList())
                {
                    bool found = false;
                    foreach (var x in genreArtistList.ToList())
                    {
                        if (x.ArtistId == item.ArtistId)
                            found = true;
                    }
                    if (found == false)
                        artistList.Remove(item);
                }
            }
            if (!string.IsNullOrWhiteSpace(search))
            {
                artistList = artistList.Where(a => a.ArtistName.StartsWith(search)).ToList();
            }
            dgvArtists.DataSource = artistList;
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            var idObj = cmbGenre.SelectedValue;
            if (idObj!=null)
            {
                if (int.TryParse(idObj.ToString(), out int id))
                {
                    await LoadArtists(id, txtNameSearch.Text);
                }
            }
            else await LoadArtists(0,txtNameSearch.Text);
        }

        private void dgvArtists_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            { 
            var id = dgvArtists.SelectedRows[0].Cells[0].Value;
            frmArtistDetails frm = new frmArtistDetails(int.Parse(id.ToString()));
            frm.refreshHandler += async (object s, object q) =>
            {
                await LoadArtists(0,"");
            };
            frm.deleteHandlerArtist += async (object s, object q) =>
            {
                frm.Close();
                int _id = (int)q;
                try
                {
                    List<Artist> allArtists = await _artistService.Get<List<Artist>>(null);
                    allArtists.Remove(allArtists.Where(a => a.ArtistId == _id).First());
                    dgvArtists.DataSource = allArtists;
                    await _artistService.Delete<Model.Artist>(_id);
                    MessageBox.Show("Artist successfully deleted");
                }
                catch (Exception)
                {
                    MessageBox.Show("Error, please close all other windows that have any relation to artist.");
                }

            };
            frm.Show();
            }
            catch (Exception)
            {
                MessageBox.Show("Item unavailable");
            }
}

        private void btnAddArtist_Click(object sender, EventArgs e)
        {
            frmArtistDetails frm = new frmArtistDetails();
            frm.refreshHandler += async (object s, object q) =>
            {
                await LoadArtists(0, "");
            };
            
            frm.Show();
        }
    }
}
