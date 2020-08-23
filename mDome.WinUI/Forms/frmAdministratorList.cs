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
    public partial class frmAdministratorList : Form
    {
        private readonly APIService _adminService = new APIService("AdministratorLogin");
        public frmAdministratorList()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAdminDetails frm = new frmAdminDetails();
            frm.Show();
        }

        private async void frmAdministratorList_Load(object sender, EventArgs e)
        {
            var result = await _adminService.Get<List<Model.AdministratorLogin>>(null);
            dgvAdmins.AutoGenerateColumns = false;
            dgvAdmins.DataSource = result;
        }

        private void dgvAdmins_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var id = dgvAdmins.SelectedRows[0].Cells[0].Value;
            frmAdminDetails frm = new frmAdminDetails(int.Parse(id.ToString()));
            frm.Show();
        }
    }
}
