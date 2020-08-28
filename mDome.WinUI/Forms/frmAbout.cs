using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mDome.WinUI.Forms
{
    public partial class frmAbout : Form
    {
        public frmAbout()
        {
            InitializeComponent();
        }

        private void frmAbout_Load(object sender, EventArgs e)
        {
            Image aboutImg = Image.FromFile(Helper.GetImagePath("mDomeWP.jpg"));
            Image pbabt = Helper.ResizeImage(aboutImg, 790, 444);
            pbAbout.Image = pbabt;
        }
    }
}
