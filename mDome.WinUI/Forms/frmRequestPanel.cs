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
    public partial class frmRequestPanel : Form
    {
        private readonly APIService _requestService = new APIService("Request");
        public frmRequestPanel()
        {
            InitializeComponent();
        }

        private async void frmRequestPanel_Load(object sender, EventArgs e)
        {
            await LoadRequests("");
        }
        private async Task LoadRequests(string search="")
        {
            var result = await _requestService.Get<List<Model.Request>>
                (new RequestSearchRequest() { RequestText = search });
            dgvRequests.AutoGenerateColumns = false;
            dgvRequests.DataSource = result;
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            await LoadRequests(txtSearch.Text);
        }

        private async void dgvRequests_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var id = dgvRequests.SelectedRows[0].Cells[0].Value;
            var selectedRequest = await _requestService.GetById<Model.Request>(int.Parse(id.ToString()));
            frmRequestDetails frm = new frmRequestDetails(selectedRequest);
            frm.Show();
        }
    }
}
