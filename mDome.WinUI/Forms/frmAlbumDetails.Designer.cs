namespace mDome.WinUI.Forms
{
    partial class frmAlbumDetails
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
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dgvTracks = new System.Windows.Forms.DataGridView();
            this.TrackId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TrackName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TrackNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtAlbumName = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtDateReleased = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.pbAlbumPhoto = new System.Windows.Forms.PictureBox();
            this.txtImgPath = new System.Windows.Forms.TextBox();
            this.btnAddPhoto = new System.Windows.Forms.Button();
            this.btnAddTrack = new System.Windows.Forms.Button();
            this.btnSubmitAlbum = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.btnDeleteAlbum = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTracks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAlbumPhoto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Album Details";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Album Description";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "Album Name";
            // 
            // dgvTracks
            // 
            this.dgvTracks.AllowUserToAddRows = false;
            this.dgvTracks.AllowUserToDeleteRows = false;
            this.dgvTracks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTracks.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TrackId,
            this.TrackName,
            this.TrackNumber});
            this.dgvTracks.Location = new System.Drawing.Point(481, 13);
            this.dgvTracks.Name = "dgvTracks";
            this.dgvTracks.ReadOnly = true;
            this.dgvTracks.RowHeadersWidth = 51;
            this.dgvTracks.RowTemplate.Height = 24;
            this.dgvTracks.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTracks.Size = new System.Drawing.Size(312, 478);
            this.dgvTracks.TabIndex = 4;
            this.dgvTracks.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgvTracks_MouseDoubleClick);
            // 
            // TrackId
            // 
            this.TrackId.DataPropertyName = "TrackId";
            this.TrackId.HeaderText = "Track Id";
            this.TrackId.MinimumWidth = 6;
            this.TrackId.Name = "TrackId";
            this.TrackId.ReadOnly = true;
            this.TrackId.Visible = false;
            this.TrackId.Width = 125;
            // 
            // TrackName
            // 
            this.TrackName.DataPropertyName = "TrackName";
            this.TrackName.HeaderText = "Track Name";
            this.TrackName.MinimumWidth = 6;
            this.TrackName.Name = "TrackName";
            this.TrackName.ReadOnly = true;
            this.TrackName.Width = 125;
            // 
            // TrackNumber
            // 
            this.TrackNumber.DataPropertyName = "TrackNumber";
            this.TrackNumber.HeaderText = "Track Number";
            this.TrackNumber.MinimumWidth = 6;
            this.TrackNumber.Name = "TrackNumber";
            this.TrackNumber.ReadOnly = true;
            this.TrackNumber.Width = 125;
            // 
            // txtAlbumName
            // 
            this.txtAlbumName.Location = new System.Drawing.Point(16, 62);
            this.txtAlbumName.Name = "txtAlbumName";
            this.txtAlbumName.Size = new System.Drawing.Size(229, 22);
            this.txtAlbumName.TabIndex = 5;
            this.txtAlbumName.Validating += new System.ComponentModel.CancelEventHandler(this.txtAlbumName_Validating);
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(16, 118);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(229, 101);
            this.txtDescription.TabIndex = 6;
            // 
            // txtDateReleased
            // 
            this.txtDateReleased.Location = new System.Drawing.Point(16, 257);
            this.txtDateReleased.Name = "txtDateReleased";
            this.txtDateReleased.Size = new System.Drawing.Size(229, 22);
            this.txtDateReleased.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 236);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 17);
            this.label5.TabIndex = 7;
            this.label5.Text = "Date Released";
            // 
            // pbAlbumPhoto
            // 
            this.pbAlbumPhoto.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pbAlbumPhoto.Location = new System.Drawing.Point(16, 298);
            this.pbAlbumPhoto.Name = "pbAlbumPhoto";
            this.pbAlbumPhoto.Size = new System.Drawing.Size(140, 140);
            this.pbAlbumPhoto.TabIndex = 9;
            this.pbAlbumPhoto.TabStop = false;
            // 
            // txtImgPath
            // 
            this.txtImgPath.Location = new System.Drawing.Point(16, 491);
            this.txtImgPath.Name = "txtImgPath";
            this.txtImgPath.Size = new System.Drawing.Size(229, 22);
            this.txtImgPath.TabIndex = 10;
            // 
            // btnAddPhoto
            // 
            this.btnAddPhoto.Location = new System.Drawing.Point(16, 456);
            this.btnAddPhoto.Name = "btnAddPhoto";
            this.btnAddPhoto.Size = new System.Drawing.Size(94, 29);
            this.btnAddPhoto.TabIndex = 11;
            this.btnAddPhoto.Text = "Add Photo";
            this.btnAddPhoto.UseVisualStyleBackColor = true;
            this.btnAddPhoto.Click += new System.EventHandler(this.btnAddPhoto_Click);
            // 
            // btnAddTrack
            // 
            this.btnAddTrack.Enabled = false;
            this.btnAddTrack.Location = new System.Drawing.Point(481, 519);
            this.btnAddTrack.Name = "btnAddTrack";
            this.btnAddTrack.Size = new System.Drawing.Size(312, 35);
            this.btnAddTrack.TabIndex = 12;
            this.btnAddTrack.Text = "Add New Track";
            this.btnAddTrack.UseVisualStyleBackColor = true;
            this.btnAddTrack.Click += new System.EventHandler(this.btnAddTrack_Click);
            // 
            // btnSubmitAlbum
            // 
            this.btnSubmitAlbum.Location = new System.Drawing.Point(16, 519);
            this.btnSubmitAlbum.Name = "btnSubmitAlbum";
            this.btnSubmitAlbum.Size = new System.Drawing.Size(229, 35);
            this.btnSubmitAlbum.TabIndex = 13;
            this.btnSubmitAlbum.Text = "Submit";
            this.btnSubmitAlbum.UseVisualStyleBackColor = true;
            this.btnSubmitAlbum.Click += new System.EventHandler(this.btnSubmitAlbum_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // btnDeleteAlbum
            // 
            this.btnDeleteAlbum.Enabled = false;
            this.btnDeleteAlbum.Location = new System.Drawing.Point(275, 519);
            this.btnDeleteAlbum.Name = "btnDeleteAlbum";
            this.btnDeleteAlbum.Size = new System.Drawing.Size(171, 35);
            this.btnDeleteAlbum.TabIndex = 14;
            this.btnDeleteAlbum.Text = "Delete Album";
            this.btnDeleteAlbum.UseVisualStyleBackColor = true;
            this.btnDeleteAlbum.Click += new System.EventHandler(this.btnDeleteAlbum_Click);
            // 
            // frmAlbumDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 573);
            this.Controls.Add(this.btnDeleteAlbum);
            this.Controls.Add(this.btnSubmitAlbum);
            this.Controls.Add(this.btnAddTrack);
            this.Controls.Add(this.btnAddPhoto);
            this.Controls.Add(this.txtImgPath);
            this.Controls.Add(this.pbAlbumPhoto);
            this.Controls.Add(this.txtDateReleased);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.txtAlbumName);
            this.Controls.Add(this.dgvTracks);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Name = "frmAlbumDetails";
            this.Text = "frmAlbumDetails";
            this.Load += new System.EventHandler(this.frmAlbumDetails_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTracks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAlbumPhoto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgvTracks;
        private System.Windows.Forms.TextBox txtAlbumName;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.TextBox txtDateReleased;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pbAlbumPhoto;
        private System.Windows.Forms.TextBox txtImgPath;
        private System.Windows.Forms.Button btnAddPhoto;
        private System.Windows.Forms.Button btnAddTrack;
        private System.Windows.Forms.Button btnSubmitAlbum;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.DataGridViewTextBoxColumn TrackId;
        private System.Windows.Forms.DataGridViewTextBoxColumn TrackName;
        private System.Windows.Forms.DataGridViewTextBoxColumn TrackNumber;
        private System.Windows.Forms.Button btnDeleteAlbum;
    }
}