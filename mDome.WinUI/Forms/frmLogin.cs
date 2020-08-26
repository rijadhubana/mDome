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
    public partial class frmLogin : Form
    {
        private readonly APIService _adminService = new APIService("AdministratorLogin");
        public frmLogin()
        {
            InitializeComponent();
        }

        private void txtUsername_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                errorProvider.SetError(txtUsername, "Required field");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtUsername, null);
            }
        }

        private void txtPassword_Validating(object sender, CancelEventArgs e)
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

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                APIService.Username = txtUsername.Text;
                APIService.Password = txtPassword.Text;
                List<AdministratorLogin> list = await _adminService.Get<List<AdministratorLogin>>(new AdminSearchRequest()
                {
                     AdminName=txtUsername.Text
                });
                if (list.Count == 0)
                {
                    MessageBox.Show("Wrong username or password!");
                    APIService.Username = "";
                    APIService.Password = "";
                    return;
                }
                else
                {
                    var frmIndex = new frmIndex();
                    frmIndex.Show();
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Authentication", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
