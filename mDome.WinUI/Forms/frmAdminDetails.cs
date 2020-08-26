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
using static mDome.WinUI.Helper;

namespace mDome.WinUI.Forms
{
    public partial class frmAdminDetails : Form
    {
        private int? _adminId=null;
        private readonly APIService _adminService = new APIService("AdministratorLogin");
        public event EventHandler<object> refreshHandler;
        public frmAdminDetails(int? adminId=null)
        {
            _adminId = adminId;
            InitializeComponent();
        }

        private async void frmAdminDetails_Load(object sender, EventArgs e)
        {
            if (_adminId.HasValue)
            {
                btnAddNew.Enabled = false;
                var adm = await _adminService.GetById<Model.AdministratorLogin>(_adminId);
                txtName.Text = adm.AdminName;
                txtName.ReadOnly = true;
                txtPassword.Enabled = false;
                txtPasswordConfirm.Enabled = false;
                if (adm.AdminName == APIService.Username)
                    btnRemove.Enabled = false;
                else btnRemove.Enabled = true;
            }
        }

        private void txtName_Validating(object sender, CancelEventArgs e)
        {
            if (!_adminId.HasValue)
            {
                if (string.IsNullOrWhiteSpace(txtName.Text))
                {
                    errorProvider.SetError(txtName, "Required field");
                    e.Cancel = true;
                }
                else
                {
                    errorProvider.SetError(txtName, null);
                }
            }
            
        }

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            if (!_adminId.HasValue)
            {
                if (string.IsNullOrWhiteSpace(txtPassword.Text))
                {
                    errorProvider.SetError(txtPassword, "Required field");
                    e.Cancel = true;
                }
                else
                {
                    errorProvider.SetError(txtPassword, null);
                }
            }
        }

        private void txtPasswordConfirm_Validating(object sender, CancelEventArgs e)
        {
            if (!_adminId.HasValue)
            {
                if (string.IsNullOrWhiteSpace(txtPasswordConfirm.Text))
                {
                    errorProvider.SetError(txtPasswordConfirm, "Required field");
                    e.Cancel = true;
                }
                else
                {
                    errorProvider.SetError(txtPasswordConfirm, null);
                }
            }
        }

        private async void btnAddNew_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {
                AdminUpsertRequest request = new AdminUpsertRequest()
                {
                    AdminName = txtName.Text,
                    PasswordClear = txtPassword.Text,
                    PasswordClearConfirm = txtPasswordConfirm.Text
                };
                try
                {
                    await _adminService.Insert<Model.AdministratorLogin>(request);
                    refreshHandler?.Invoke(this, null);
                    MessageBox.Show("Task successful");

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
                this.Close();
            }
        }

        private async void btnRemove_Click(object sender, EventArgs e)
        {
            string promptValue = Prompt.ShowDialog("Are you sure you want to remove this administrator?" +
                " Type your password to confirm.", "Confirm");
            if (APIService.Password == promptValue)
            {
                await _adminService.Delete<Model.AdministratorLogin>(_adminId);
                refreshHandler?.Invoke(this, null);
                MessageBox.Show("Task successful");
                this.Close();
            }
            else MessageBox.Show("Password incorrect");
        }
    }
}
