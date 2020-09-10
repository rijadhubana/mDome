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
    public partial class frmPostsList : Form
    {
        private readonly APIService _artistService = new APIService("Artist");
        private readonly APIService _userService = new APIService("UserProfile");
        private readonly APIService _postService = new APIService("Post");
        private int? _artistId = null;
        private int? _userId = null;
        public bool? _chbChecked = false;
        public frmPostsList()
        {
            InitializeComponent();
        }

        private async void frmPostsList_Load(object sender, EventArgs e)
        {
            await LoadArtists();
            await LoadUsers();
            await LoadPosts(_artistId,_userId,_chbChecked);
        }
        private async Task LoadArtists()
        {
            var result = await _artistService.Get<List<Model.Artist>>(null);
            result.Insert(0, new Model.Artist() { ArtistId = 0 });
            cmbArtists.DataSource = result;
            cmbArtists.DisplayMember = "ArtistName";
            cmbArtists.ValueMember = "ArtistId";
        }
        private async Task LoadUsers()
        {
            var result = await _userService.Get<List<Model.UserProfile>>(null);
            result.Insert(0, new Model.UserProfile { UserId = 0 });
            cmbUser.DataSource = result;
            cmbUser.DisplayMember = "Username";
            cmbUser.ValueMember = "UserId";
        }
        private async Task LoadPosts(int? artistId = null, int? userId=null, bool? chbChecked=null)
        {
            if (artistId==null && userId==null && chbChecked==null)
            {
                var result = _postService.Get<List<Model.Post>>(null);
                dgvPosts.DataSource = result;
            }
            else
            {
                var result = await _postService.Get<List<Model.Post>>(new PostSearchRequest()
                { ArtistRelatedId = artistId, IsGlobal = chbChecked, UserRelatedId = userId });
                dgvPosts.DataSource = result;
            }
            
        }
        private async void cmbArtists_SelectedIndexChanged(object sender, EventArgs e)
        {
            var idObj = cmbArtists.SelectedValue;
            if (int.TryParse(idObj.ToString(), out int id))
            {
                if (id != 0)
                    _artistId = id;
                else _artistId = null;
                await LoadPosts(_artistId,_userId,_chbChecked);
            }
        }

        private async void cmbUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            var idObj = cmbUser.SelectedValue;
            if (int.TryParse(idObj.ToString(), out int id))
            {
                if (id != 0)
                    _userId = id;
                else _userId = null;
                await LoadPosts(_artistId, _userId, _chbChecked);
            }
        }

        private async void chbGlobal_CheckedChanged(object sender, EventArgs e)
        {
            _chbChecked = chbGlobal.Checked;
            await LoadPosts(_artistId, _userId, _chbChecked);
        }

        private void btnAddPost_Click(object sender, EventArgs e)
        {
            frmPostDetails frm = new frmPostDetails();
            frm.refreshHandler += async (object s, object q) =>
            {
                await LoadPosts(_artistId,_userId,_chbChecked);
            };
            frm.Show();
        }

        private void dgvPosts_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                var id = dgvPosts.SelectedRows[0].Cells[0].Value;
                frmPostDetails frm = new frmPostDetails(int.Parse(id.ToString()));
                frm.refreshHandler += async (object s, object q) =>
                {
                    await LoadPosts(_artistId, _userId, _chbChecked);
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
