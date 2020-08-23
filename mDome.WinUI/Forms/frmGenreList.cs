using mDome.Model.Requests;
using mDome.WinUI.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mDome.WinUI
{
    public partial class frmGenreList : Form
    {
        private readonly APIService _genreService = new APIService("Genre");
        public frmGenreList()
        {
            InitializeComponent();
        }


        private async void frmGenreList_Load(object sender, EventArgs e)
        {
            await LoadGenres("");
        }
        private async Task LoadGenres(string search)
        {
            GenreSearchRequest searchRequest = new GenreSearchRequest() { GenreName = search };
            var result = await _genreService.Get<List<Model.Genre>>(searchRequest);
            dgvGenres.AutoGenerateColumns = false;
            dgvGenres.DataSource = result;
        }

        private async void btnSearchGenres_Click(object sender, EventArgs e)
        {
            string query = txtGenreSearch.Text;
            await LoadGenres(query);
        }

        private void btnAddGenre_Click(object sender, EventArgs e)
        {
            frmGenreDetails frm = new frmGenreDetails();
            frm.Show();
        }

        private void dgvGenres_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var id = dgvGenres.SelectedRows[0].Cells[0].Value;
            frmGenreDetails frm = new frmGenreDetails(int.Parse(id.ToString()));
            frm.Show();
        }
    }
}
