using mDome.Model;
using mDome.Model.Requests;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static mDome.WinUI.Helper;

namespace mDome.WinUI.Forms
{
    public partial class frmUserDetails : Form
    {
        private int _userId;
        public event EventHandler<object> refreshHandler;
        private readonly APIService _userService = new APIService("UserProfile");
        private UserProfile loadedProfile;
        public frmUserDetails(int userId)
        {
            InitializeComponent();
            _userId = userId;
        }
        private async void frmUserDetails_Load(object sender, EventArgs e)
        {
            var thisUser =await _userService.GetById<UserProfile>(_userId);
            loadedProfile = thisUser;
            txtAbout.Text = thisUser.About;
            txtUsername.Text = thisUser.Username;
            txtEmail.Text = thisUser.Email;
            txtDateRegistered.Text = thisUser.RegisteredAt.ToString();
            if (thisUser.SuspendedFlag==true)
            {
                txtSuspended.Text = "Yes";
                btnSuspend.Text = "Unsuspend User";
            }
            else
            {
                txtSuspended.Text = "No";
                btnSuspend.Text = "Suspend User";
            }
            pbWallpaper.Image = Helper.ResizeImage(Helper.ByteArrayToImage(thisUser.UserWallpaper), 160, 80);
            pbUserPhoto.Image = Helper.ResizeImage(Helper.ByteArrayToImage(thisUser.UserPhoto), 70, 70);
        }

        private async void btnSuspend_Click(object sender, EventArgs e)
        {
            string suspendText = "";
            if (txtSuspended.Text == "No")
                suspendText = "Are you sure you want to suspend the selected user?";
            else suspendText = "Are you sure you want to unsuspend the selected user?";
            var confirmResult = MessageBox.Show(suspendText,
                                    "Confirm",
                                    MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                UserProfileUpsertRequest request = new UserProfileUpsertRequest()
                {
                    About = loadedProfile.About,
                    Email = loadedProfile.Email,
                    IsUpdateByAdmin = true,
                    PasswordClearText = "abc",
                    PasswordClearTextConfirm = "abc",
                    PwHash = loadedProfile.PasswordHash,
                    PwSalt = loadedProfile.PasswordSalt,
                    RecommendedAlbum1 = loadedProfile.RecommendedAlbum1,
                    RecommendedAlbum2 = loadedProfile.RecommendedAlbum2,
                    RecommendedAlbum3 = loadedProfile.RecommendedAlbum3,
                    RecommendedArtist1 = loadedProfile.RecommendedArtist1,
                    RecommendedArtist2 = loadedProfile.RecommendedArtist2,
                    RecommendedArtist3 = loadedProfile.RecommendedArtist3,
                    RegisteredAt = loadedProfile.RegisteredAt,
                    Username = loadedProfile.Username,
                    UserPhoto = loadedProfile.UserPhoto,
                    UserWallpaper = loadedProfile.UserWallpaper
                };
                if (txtSuspended.Text == "No")
                {
                    request.SuspendedFlag = true;
                }
                else request.SuspendedFlag = false;
                await _userService.Update<UserProfile>(loadedProfile.UserId, request);
                MessageBox.Show("Task successful.");
                if (txtSuspended.Text == "No")
                {
                    txtSuspended.Text = "Yes";
                    btnSuspend.Text = "Unsuspend User";
                }
                else
                {
                    txtSuspended.Text = "No";
                    btnSuspend.Text = "Suspend User";
                }
                refreshHandler?.Invoke(this, null);
            }
               
        }

        private async void btnRecoverPassword_Click(object sender, EventArgs e)
        {
            string promptValue = Prompt.ShowDialog("Type in the new password for selected user", "Confirm");
            if (promptValue!="")
            {
                string pwsalt = GenerateSalt();
                string pwhash = GenerateHash(pwsalt, promptValue);
                UserProfileUpsertRequest request = new UserProfileUpsertRequest()
                {
                    About = loadedProfile.About,
                    Email = loadedProfile.Email,
                    IsUpdateByAdmin = true,
                    PasswordClearText = "abc",
                    PasswordClearTextConfirm = "abc",
                    PwSalt = pwsalt,
                    PwHash = pwhash,
                    RecommendedAlbum1 = loadedProfile.RecommendedAlbum1,
                    RecommendedAlbum2 = loadedProfile.RecommendedAlbum2,
                    RecommendedAlbum3 = loadedProfile.RecommendedAlbum3,
                    RecommendedArtist1 = loadedProfile.RecommendedArtist1,
                    RecommendedArtist2 = loadedProfile.RecommendedArtist2,
                    RecommendedArtist3 = loadedProfile.RecommendedArtist3,
                    RegisteredAt = loadedProfile.RegisteredAt,
                    Username = loadedProfile.Username,
                    UserPhoto = loadedProfile.UserPhoto,
                    UserWallpaper = loadedProfile.UserWallpaper
                };
                await _userService.Update<UserProfile>(loadedProfile.UserId, request);
                MessageBox.Show("Task successful.");
            }

        }
    }
}
