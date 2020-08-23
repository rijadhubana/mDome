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
            var id = dgvArtists.SelectedRows[0].Cells[0].Value;
            frmArtistDetails frm = new frmArtistDetails(int.Parse(id.ToString()));
            frm.Show();
        }

        private void btnAddArtist_Click(object sender, EventArgs e)
        {
            frmArtistDetails frm = new frmArtistDetails();
            frm.Show();
        }
    }
}
