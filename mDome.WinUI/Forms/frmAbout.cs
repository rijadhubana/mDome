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
    public partial class frmAbout : Form
    {
        public frmAbout()
        {
            InitializeComponent();
        }

        private void frmAbout_Load(object sender, EventArgs e)
        {
            Image aboutImg = Image.FromFile("C:\\Users\\rijad\\source\\repos\\mDome\\mDome.WinUI\\mDomeWP.jpg");
            Image pbabt = Helper.ResizeImage(aboutImg, 790, 444);
            pbAbout.Image = pbabt;
        }
    }
}
