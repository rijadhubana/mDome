namespace mDome.WinUI.Forms
{
    partial class frmArtistDetails
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmArtistDetails));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtArtistName = new System.Windows.Forms.TextBox();
            this.txtArtistBio = new System.Windows.Forms.TextBox();
            this.txtMembers = new System.Windows.Forms.TextBox();
            this.pbPhoto = new System.Windows.Forms.PictureBox();
            this.txtPhoto = new System.Windows.Forms.TextBox();
            this.btnAddPhoto = new System.Windows.Forms.Button();
            this.clbGenres = new System.Windows.Forms.CheckedListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnAlbums = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnDeleteArtist = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbPhoto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Artist Details";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(506, 172);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Artist Photo";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 242);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Members";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 106);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "Artist Bio";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 51);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 17);
            this.label5.TabIndex = 4;
            this.label5.Text = "Artist Name";
            // 
            // txtArtistName
            // 
            this.txtArtistName.Location = new System.Drawing.Point(16, 71);
            this.txtArtistName.Name = "txtArtistName";
            this.txtArtistName.Size = new System.Drawing.Size(268, 22);
            this.txtArtistName.TabIndex = 5;
            this.txtArtistName.Validating += new System.ComponentModel.CancelEventHandler(this.txtArtistName_Validating);
            // 
            // txtArtistBio
            // 
            this.txtArtistBio.Location = new System.Drawing.Point(16, 126);
            this.txtArtistBio.Multiline = true;
            this.txtArtistBio.Name = "txtArtistBio";
            this.txtArtistBio.Size = new System.Drawing.Size(279, 108);
            this.txtArtistBio.TabIndex = 6;
            // 
            // txtMembers
            // 
            this.txtMembers.Location = new System.Drawing.Point(16, 262);
            this.txtMembers.Multiline = true;
            this.txtMembers.Name = "txtMembers";
            this.txtMembers.Size = new System.Drawing.Size(279, 108);
            this.txtMembers.TabIndex = 7;
            // 
            // pbPhoto
            // 
            this.pbPhoto.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pbPhoto.Location = new System.Drawing.Point(580, 12);
            this.pbPhoto.Name = "pbPhoto";
            this.pbPhoto.Size = new System.Drawing.Size(140, 140);
            this.pbPhoto.TabIndex = 8;
            this.pbPhoto.TabStop = false;
            // 
            // txtPhoto
            // 
            this.txtPhoto.Location = new System.Drawing.Point(509, 192);
            this.txtPhoto.Name = "txtPhoto";
            this.txtPhoto.Size = new System.Drawing.Size(279, 22);
            this.txtPhoto.TabIndex = 9;
            // 
            // btnAddPhoto
            // 
            this.btnAddPhoto.Location = new System.Drawing.Point(693, 166);
            this.btnAddPhoto.Name = "btnAddPhoto";
            this.btnAddPhoto.Size = new System.Drawing.Size(95, 23);
            this.btnAddPhoto.TabIndex = 10;
            this.btnAddPhoto.Text = "Add";
            this.btnAddPhoto.UseVisualStyleBackColor = true;
            this.btnAddPhoto.Click += new System.EventHandler(this.btnAddPhoto_Click);
            // 
            // clbGenres
            // 
            this.clbGenres.FormattingEnabled = true;
            this.clbGenres.Location = new System.Drawing.Point(509, 247);
            this.clbGenres.Name = "clbGenres";
            this.clbGenres.Size = new System.Drawing.Size(279, 123);
            this.clbGenres.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(506, 227);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(98, 17);
            this.label6.TabIndex = 12;
            this.label6.Text = "Select Genres";
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(509, 389);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(279, 39);
            this.btnSubmit.TabIndex = 13;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btnAlbums
            // 
            this.btnAlbums.Enabled = false;
            this.btnAlbums.Location = new System.Drawing.Point(16, 389);
            this.btnAlbums.Name = "btnAlbums";
            this.btnAlbums.Size = new System.Drawing.Size(279, 39);
            this.btnAlbums.TabIndex = 14;
            this.btnAlbums.Text = "Albums";
            this.btnAlbums.UseVisualStyleBackColor = true;
            this.btnAlbums.Click += new System.EventHandler(this.btnAlbums_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // btnDeleteArtist
            // 
            this.btnDeleteArtist.Enabled = false;
            this.btnDeleteArtist.Location = new System.Drawing.Point(328, 389);
            this.btnDeleteArtist.Name = "btnDeleteArtist";
            this.btnDeleteArtist.Size = new System.Drawing.Size(153, 39);
            this.btnDeleteArtist.TabIndex = 15;
            this.btnDeleteArtist.Text = "Delete Artist";
            this.btnDeleteArtist.UseVisualStyleBackColor = true;
            this.btnDeleteArtist.Click += new System.EventHandler(this.btnDeleteArtist_Click);
            // 
            // frmArtistDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(802, 474);
            this.Controls.Add(this.btnDeleteArtist);
            this.Controls.Add(this.btnAlbums);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.clbGenres);
            this.Controls.Add(this.btnAddPhoto);
            this.Controls.Add(this.txtPhoto);
            this.Controls.Add(this.pbPhoto);
            this.Controls.Add(this.txtMembers);
            this.Controls.Add(this.txtArtistBio);
            this.Controls.Add(this.txtArtistName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmArtistDetails";
            this.Text = "Artist Details";
            this.Load += new System.EventHandler(this.frmArtistDetails_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbPhoto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtArtistName;
        private System.Windows.Forms.TextBox txtArtistBio;
        private System.Windows.Forms.TextBox txtMembers;
        private System.Windows.Forms.PictureBox pbPhoto;
        private System.Windows.Forms.TextBox txtPhoto;
        private System.Windows.Forms.Button btnAddPhoto;
        private System.Windows.Forms.CheckedListBox clbGenres;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnAlbums;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Button btnDeleteArtist;
    }
}