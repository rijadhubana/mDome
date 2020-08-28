using mDome.Model;
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
    public partial class frmUserList : Form
    {
        private readonly APIService _userService = new APIService("UserProfile");
        public frmUserList()
        {
            InitializeComponent();
        }

        private async void frmUserList_Load(object sender, EventArgs e)
        {
            await LoadUsers();
        }
        private async Task LoadUsers(string searchQuery="")
        {
            var allUsers = await _userService.Get<List<UserProfile>>(null);
            if (searchQuery != "")
                allUsers = allUsers.Where(a => a.Username.ToLower().StartsWith(searchQuery.ToLower())).ToList();
            dgvUsers.AutoGenerateColumns = false;
            dgvUsers.DataSource = allUsers;

        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            await LoadUsers(txtUserSearch.Text);
        }

        private void dgvUsers_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                var id = dgvUsers.SelectedRows[0].Cells[0].Value;
                frmUserDetails frm = new frmUserDetails(int.Parse(id.ToString()));
                frm.refreshHandler += async (object s, object q) =>
                {
                    await LoadUsers();
                };
                frm.Show();
            }
            catch (Exception)
            {
                MessageBox.Show("Item unavailable");
            }
        }
    }
}
