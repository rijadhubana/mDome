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
    public partial class frmReport : Form
    {
        private readonly APIService _artistService = new APIService("Artist");
        public frmReport()
        {
            InitializeComponent();
        }

        private async void frmReport_Load(object sender, EventArgs e)
        {
            await LoadArtists();
            this.reportViewer.RefreshReport();
        }
        private async Task LoadArtists(string searchQuery="")
        {
            cmbArtists.DataSource = null;
            var result = await _artistService.Get<List<Model.Artist>>
                (new ArtistSearchRequest() { ArtistName = searchQuery });
            result.Insert(0, new Model.Artist() { ArtistId = 0 });
            cmbArtists.DataSource = result;
            cmbArtists.DisplayMember = "ArtistName";
            cmbArtists.ValueMember = "ArtistId";
        }
        private async void btnSearchArtist_Click(object sender, EventArgs e)
        {
            await LoadArtists(txtArtistSearch.Text);
        }

        private async void btnGenerateReport_Click(object sender, EventArgs e)
        {
            var idObj = cmbArtists.SelectedValue;
            if (int.TryParse(idObj.ToString(), out int id))
            {
                if (id == 0)
                {
                    MessageBox.Show("You must select an artist!");
                    return;
                }
                ArtistReportingModel artistReportingModel = await Helper.GenerateReport(id);
                reportBindingSource.DataSource = artistReportingModel;
                reportViewer.RefreshReport();
            }
        }
    }
}
