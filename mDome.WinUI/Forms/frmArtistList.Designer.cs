namespace mDome.WinUI.Forms
{
    partial class frmArtistList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmArtistList));
            this.dgvArtists = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNameSearch = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbGenre = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnAddArtist = new System.Windows.Forms.Button();
            this.ArtistId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ArtistName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ArtistMembers = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ArtistPhotoThumb = new System.Windows.Forms.DataGridViewImageColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArtists)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvArtists
            // 
            this.dgvArtists.AllowUserToAddRows = false;
            this.dgvArtists.AllowUserToDeleteRows = false;
            this.dgvArtists.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvArtists.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ArtistId,
            this.ArtistName,
            this.ArtistMembers,
            this.ArtistPhotoThumb});
            this.dgvArtists.GridColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvArtists.Location = new System.Drawing.Point(12, 249);
            this.dgvArtists.Name = "dgvArtists";
            this.dgvArtists.ReadOnly = true;
            this.dgvArtists.RowHeadersWidth = 100;
            this.dgvArtists.RowTemplate.Height = 24;
            this.dgvArtists.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvArtists.Size = new System.Drawing.Size(962, 309);
            this.dgvArtists.TabIndex = 0;
            this.dgvArtists.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgvArtists_MouseDoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Artists";
            // 
            // txtNameSearch
            // 
            this.txtNameSearch.Location = new System.Drawing.Point(84, 46);
            this.txtNameSearch.Name = "txtNameSearch";
            this.txtNameSearch.Size = new System.Drawing.Size(253, 22);
            this.txtNameSearch.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Name";
            // 
            // cmbGenre
            // 
            this.cmbGenre.FormattingEnabled = true;
            this.cmbGenre.Location = new System.Drawing.Point(84, 99);
            this.cmbGenre.Name = "cmbGenre";
            this.cmbGenre.Size = new System.Drawing.Size(253, 24);
            this.cmbGenre.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Genre";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(15, 144);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(322, 40);
            this.btnSearch.TabIndex = 6;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnAddArtist
            // 
            this.btnAddArtist.Location = new System.Drawing.Point(15, 190);
            this.btnAddArtist.Name = "btnAddArtist";
            this.btnAddArtist.Size = new System.Drawing.Size(322, 40);
            this.btnAddArtist.TabIndex = 7;
            this.btnAddArtist.Text = "Add New Artist";
            this.btnAddArtist.UseVisualStyleBackColor = true;
            this.btnAddArtist.Click += new System.EventHandler(this.btnAddArtist_Click);
            // 
            // ArtistId
            // 
            this.ArtistId.DataPropertyName = "ArtistId";
            this.ArtistId.HeaderText = "ArtistId";
            this.ArtistId.MinimumWidth = 6;
            this.ArtistId.Name = "ArtistId";
            this.ArtistId.ReadOnly = true;
            this.ArtistId.Visible = false;
            this.ArtistId.Width = 125;
            // 
            // ArtistName
            // 
            this.ArtistName.DataPropertyName = "ArtistName";
            this.ArtistName.HeaderText = "Artist Name";
            this.ArtistName.MinimumWidth = 6;
            this.ArtistName.Name = "ArtistName";
            this.ArtistName.ReadOnly = true;
            this.ArtistName.Width = 125;
            // 
            // ArtistMembers
            // 
            this.ArtistMembers.DataPropertyName = "ArtistMembers";
            this.ArtistMembers.HeaderText = "Members";
            this.ArtistMembers.MinimumWidth = 6;
            this.ArtistMembers.Name = "ArtistMembers";
            this.ArtistMembers.ReadOnly = true;
            this.ArtistMembers.Width = 125;
            // 
            // ArtistPhotoThumb
            // 
            this.ArtistPhotoThumb.DataPropertyName = "ArtistPhotoThumb";
            this.ArtistPhotoThumb.HeaderText = "Artist Photo";
            this.ArtistPhotoThumb.MinimumWidth = 6;
            this.ArtistPhotoThumb.Name = "ArtistPhotoThumb";
            this.ArtistPhotoThumb.ReadOnly = true;
            this.ArtistPhotoThumb.Width = 125;
            // 
            // frmArtistList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(986, 570);
            this.Controls.Add(this.btnAddArtist);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbGenre);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNameSearch);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvArtists);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmArtistList";
            this.Text = "Artists";
            this.Load += new System.EventHandler(this.frmArtistList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvArtists)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvArtists;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNameSearch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbGenre;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnAddArtist;
        private System.Windows.Forms.DataGridViewTextBoxColumn ArtistId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ArtistName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ArtistMembers;
        private System.Windows.Forms.DataGridViewImageColumn ArtistPhotoThumb;
    }
}