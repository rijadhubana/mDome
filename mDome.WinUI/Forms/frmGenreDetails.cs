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
    public partial class frmGenreDetails : Form
    {
        private readonly APIService _genreService = new APIService("Genre");
        private int? _genreId;
        public event EventHandler<object> refreshHandler;
        public frmGenreDetails(int? id = null)
        {
            InitializeComponent();
            _genreId = id;
        }

        private async void frmGenreDetails_Load(object sender, EventArgs e)
        {
            if (_genreId.HasValue)
            {
                var selectedGenre = await _genreService.GetById<Model.Genre>(_genreId);
                txtGenreName.Text = selectedGenre.GenreName;
                txtGenreDesc.Text = selectedGenre.GenreDescription;
                btnDeleteGenre.Enabled = true;
            }
        }

        private void txtGenreName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtGenreName.Text))
            {
                errorProvider.SetError(txtGenreName, "Required field");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtGenreName, null);
            }
        }

        private async void btnSubmit_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {
                GenreUpsertRequest request = new GenreUpsertRequest()
                {
                    GenreName = txtGenreName.Text,
                    GenreDescription = txtGenreDesc.Text
                };
                if (_genreId.HasValue)
                {
                    await _genreService.Update<Model.Genre>(_genreId, request);
                }
                else await _genreService.Insert<Model.Genre>(request);
                refreshHandler?.Invoke(this, null);
                MessageBox.Show("Task successful");
            }
        }

        private async void btnDeleteGenre_Click(object sender, EventArgs e)
        {
            string promptValue = Prompt.ShowDialog("Are you sure you want to remove this genre?" +
                " Type your password to confirm.", "Confirm");
            if (APIService.Password == promptValue)
            {
                await _genreService.Delete<Model.Genre>(_genreId);
                refreshHandler?.Invoke(this, null);
                MessageBox.Show("Task successful");
                this.Close();
            }
            else MessageBox.Show("Password incorrect");
        }
    }
}
