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
    public partial class frmChangeCredentials : Form
    {
        AdministratorLogin _thisAdmin;
        private readonly APIService _adminService = new APIService("AdministratorLogin");
        public frmChangeCredentials()
        {
            InitializeComponent();
        }

        private async void frmChangeCredentials_Load(object sender, EventArgs e)
        {
            var result = await _adminService.Get<List<Model.AdministratorLogin>>(
                new AdminSearchRequest() { AdminName = APIService.Username });
            _thisAdmin = result.First();
            txtName.Text = _thisAdmin.AdminName;
        }

        private async void btnSubmit_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren() && txtOldPass.Text==APIService.Password)
            {
                AdminUpsertRequest request = new AdminUpsertRequest()
                {
                    AdminName = txtName.Text,
                    PasswordClear = txtNewPass.Text,
                    PasswordClearConfirm = txtNewPassConfirm.Text
                };
                try
                {
                    await _adminService.Update<Model.AdministratorLogin>(_thisAdmin.AdministratorId,request);
                    MessageBox.Show("Task successful");
                    APIService.Username = request.AdminName;
                    APIService.Password = request.PasswordClear;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                this.Close();

            }
        }

        private void txtName_Validating(object sender, CancelEventArgs e)
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

        private void txtOldPass_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtOldPass.Text))
            {
                errorProvider.SetError(txtOldPass, "Required field");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtOldPass, null);
            }
        }

        private void txtNewPass_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNewPass.Text))
            {
                errorProvider.SetError(txtNewPass, "Required field");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtNewPass, null);
            }
        }

        private void txtNewPassConfirm_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNewPassConfirm.Text))
            {
                errorProvider.SetError(txtNewPassConfirm, "Required field");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtNewPassConfirm, null);
            }
        }
    }
}
