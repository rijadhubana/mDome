namespace mDome.WinUI
{
    partial class frmIndex
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmIndex));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.dashboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mDatabaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.genresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.artistsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reviewsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.postsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.requestPanelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.administratorsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeCredentialsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dashboardToolStripMenuItem,
            this.mDatabaseToolStripMenuItem,
            this.usersToolStripMenuItem,
            this.settingsToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(845, 28);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "MenuStrip";
            // 
            // dashboardToolStripMenuItem
            // 
            this.dashboardToolStripMenuItem.Name = "dashboardToolStripMenuItem";
            this.dashboardToolStripMenuItem.Size = new System.Drawing.Size(96, 24);
            this.dashboardToolStripMenuItem.Text = "Dashboard";
            this.dashboardToolStripMenuItem.Click += new System.EventHandler(this.dashboardToolStripMenuItem_Click);
            // 
            // mDatabaseToolStripMenuItem
            // 
            this.mDatabaseToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.genresToolStripMenuItem,
            this.artistsToolStripMenuItem,
            this.reviewsToolStripMenuItem,
            this.postsToolStripMenuItem,
            this.reportsToolStripMenuItem});
            this.mDatabaseToolStripMenuItem.Name = "mDatabaseToolStripMenuItem";
            this.mDatabaseToolStripMenuItem.Size = new System.Drawing.Size(99, 24);
            this.mDatabaseToolStripMenuItem.Text = "mDatabase";
            // 
            // genresToolStripMenuItem
            // 
            this.genresToolStripMenuItem.Name = "genresToolStripMenuItem";
            this.genresToolStripMenuItem.Size = new System.Drawing.Size(145, 26);
            this.genresToolStripMenuItem.Text = "Genres";
            this.genresToolStripMenuItem.Click += new System.EventHandler(this.genresToolStripMenuItem_Click);
            // 
            // artistsToolStripMenuItem
            // 
            this.artistsToolStripMenuItem.Name = "artistsToolStripMenuItem";
            this.artistsToolStripMenuItem.Size = new System.Drawing.Size(145, 26);
            this.artistsToolStripMenuItem.Text = "Artists";
            this.artistsToolStripMenuItem.Click += new System.EventHandler(this.artistsToolStripMenuItem_Click);
            // 
            // reviewsToolStripMenuItem
            // 
            this.reviewsToolStripMenuItem.Name = "reviewsToolStripMenuItem";
            this.reviewsToolStripMenuItem.Size = new System.Drawing.Size(145, 26);
            this.reviewsToolStripMenuItem.Text = "Reviews";
            this.reviewsToolStripMenuItem.Click += new System.EventHandler(this.reviewsToolStripMenuItem_Click);
            // 
            // postsToolStripMenuItem
            // 
            this.postsToolStripMenuItem.Name = "postsToolStripMenuItem";
            this.postsToolStripMenuItem.Size = new System.Drawing.Size(145, 26);
            this.postsToolStripMenuItem.Text = "Posts";
            this.postsToolStripMenuItem.Click += new System.EventHandler(this.postsToolStripMenuItem_Click);
            // 
            // reportsToolStripMenuItem
            // 
            this.reportsToolStripMenuItem.Name = "reportsToolStripMenuItem";
            this.reportsToolStripMenuItem.Size = new System.Drawing.Size(145, 26);
            this.reportsToolStripMenuItem.Text = "Reports";
            this.reportsToolStripMenuItem.Click += new System.EventHandler(this.reportsToolStripMenuItem_Click);
            // 
            // usersToolStripMenuItem
            // 
            this.usersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.requestPanelToolStripMenuItem,
            this.userListToolStripMenuItem,
            this.administratorsToolStripMenuItem});
            this.usersToolStripMenuItem.Name = "usersToolStripMenuItem";
            this.usersToolStripMenuItem.Size = new System.Drawing.Size(58, 24);
            this.usersToolStripMenuItem.Text = "Users";
            // 
            // requestPanelToolStripMenuItem
            // 
            this.requestPanelToolStripMenuItem.Name = "requestPanelToolStripMenuItem";
            this.requestPanelToolStripMenuItem.Size = new System.Drawing.Size(189, 26);
            this.requestPanelToolStripMenuItem.Text = "Request Panel";
            this.requestPanelToolStripMenuItem.Click += new System.EventHandler(this.requestPanelToolStripMenuItem_Click);
            // 
            // userListToolStripMenuItem
            // 
            this.userListToolStripMenuItem.Name = "userListToolStripMenuItem";
            this.userListToolStripMenuItem.Size = new System.Drawing.Size(189, 26);
            this.userListToolStripMenuItem.Text = "User List";
            this.userListToolStripMenuItem.Click += new System.EventHandler(this.userListToolStripMenuItem_Click);
            // 
            // administratorsToolStripMenuItem
            // 
            this.administratorsToolStripMenuItem.Name = "administratorsToolStripMenuItem";
            this.administratorsToolStripMenuItem.Size = new System.Drawing.Size(189, 26);
            this.administratorsToolStripMenuItem.Text = "Administrators";
            this.administratorsToolStripMenuItem.Click += new System.EventHandler(this.administratorsToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changeCredentialsToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(76, 24);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // changeCredentialsToolStripMenuItem
            // 
            this.changeCredentialsToolStripMenuItem.Name = "changeCredentialsToolStripMenuItem";
            this.changeCredentialsToolStripMenuItem.Size = new System.Drawing.Size(220, 26);
            this.changeCredentialsToolStripMenuItem.Text = "Change Credentials";
            this.changeCredentialsToolStripMenuItem.Click += new System.EventHandler(this.changeCredentialsToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(220, 26);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 568);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStrip.Size = new System.Drawing.Size(845, 26);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "StatusStrip";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(49, 20);
            this.toolStripStatusLabel.Text = "Status";
            // 
            // frmIndex
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(845, 594);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmIndex";
            this.Text = "mDome";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion


        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ToolStripMenuItem mDatabaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem genresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem artistsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reviewsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem postsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem requestPanelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem userListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changeCredentialsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem administratorsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dashboardToolStripMenuItem;
    }
}



