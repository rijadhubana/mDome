namespace mDome.WinUI.Forms
{
    partial class frmAlbums
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAlbums));
            this.dgvAlbums = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAlbumName = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnAddAlbum = new System.Windows.Forms.Button();
            this.AlbumId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AlbumName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AlbumGeneratedRating = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AlbumPhotoThumb = new System.Windows.Forms.DataGridViewImageColumn();
            this.DateReleased = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlbums)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvAlbums
            // 
            this.dgvAlbums.AllowUserToAddRows = false;
            this.dgvAlbums.AllowUserToDeleteRows = false;
            this.dgvAlbums.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAlbums.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.AlbumId,
            this.AlbumName,
            this.AlbumGeneratedRating,
            this.AlbumPhotoThumb,
            this.DateReleased});
            this.dgvAlbums.Location = new System.Drawing.Point(12, 188);
            this.dgvAlbums.Name = "dgvAlbums";
            this.dgvAlbums.ReadOnly = true;
            this.dgvAlbums.RowHeadersWidth = 51;
            this.dgvAlbums.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAlbums.Size = new System.Drawing.Size(888, 256);
            this.dgvAlbums.TabIndex = 0;
            this.dgvAlbums.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgvAlbums_MouseDoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Albums";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Album Name";
            // 
            // txtAlbumName
            // 
            this.txtAlbumName.Location = new System.Drawing.Point(16, 74);
            this.txtAlbumName.Multiline = true;
            this.txtAlbumName.Name = "txtAlbumName";
            this.txtAlbumName.Size = new System.Drawing.Size(225, 22);
            this.txtAlbumName.TabIndex = 3;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(16, 102);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(225, 37);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnAddAlbum
            // 
            this.btnAddAlbum.Location = new System.Drawing.Point(16, 145);
            this.btnAddAlbum.Name = "btnAddAlbum";
            this.btnAddAlbum.Size = new System.Drawing.Size(225, 37);
            this.btnAddAlbum.TabIndex = 5;
            this.btnAddAlbum.Text = "Add New Album";
            this.btnAddAlbum.UseVisualStyleBackColor = true;
            this.btnAddAlbum.Click += new System.EventHandler(this.btnAddAlbum_Click);
            // 
            // AlbumId
            // 
            this.AlbumId.DataPropertyName = "AlbumId";
            this.AlbumId.HeaderText = "AlbumId";
            this.AlbumId.MinimumWidth = 6;
            this.AlbumId.Name = "AlbumId";
            this.AlbumId.ReadOnly = true;
            this.AlbumId.Visible = false;
            this.AlbumId.Width = 125;
            // 
            // AlbumName
            // 
            this.AlbumName.DataPropertyName = "AlbumName";
            this.AlbumName.HeaderText = "Album Name";
            this.AlbumName.MinimumWidth = 6;
            this.AlbumName.Name = "AlbumName";
            this.AlbumName.ReadOnly = true;
            this.AlbumName.Width = 125;
            // 
            // AlbumGeneratedRating
            // 
            this.AlbumGeneratedRating.DataPropertyName = "AlbumGeneratedRating";
            this.AlbumGeneratedRating.HeaderText = "Album Rating";
            this.AlbumGeneratedRating.MinimumWidth = 6;
            this.AlbumGeneratedRating.Name = "AlbumGeneratedRating";
            this.AlbumGeneratedRating.ReadOnly = true;
            this.AlbumGeneratedRating.Width = 125;
            // 
            // AlbumPhotoThumb
            // 
            this.AlbumPhotoThumb.DataPropertyName = "AlbumPhotoThumb";
            this.AlbumPhotoThumb.HeaderText = "Album Photo";
            this.AlbumPhotoThumb.MinimumWidth = 6;
            this.AlbumPhotoThumb.Name = "AlbumPhotoThumb";
            this.AlbumPhotoThumb.ReadOnly = true;
            this.AlbumPhotoThumb.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.AlbumPhotoThumb.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.AlbumPhotoThumb.Width = 125;
            // 
            // DateReleased
            // 
            this.DateReleased.DataPropertyName = "DateReleased";
            this.DateReleased.HeaderText = "Date Released";
            this.DateReleased.MinimumWidth = 6;
            this.DateReleased.Name = "DateReleased";
            this.DateReleased.ReadOnly = true;
            this.DateReleased.Width = 125;
            // 
            // frmAlbums
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(912, 454);
            this.Controls.Add(this.btnAddAlbum);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtAlbumName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvAlbums);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmAlbums";
            this.Text = "Albums";
            this.Load += new System.EventHandler(this.frmAlbums_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlbums)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvAlbums;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAlbumName;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnAddAlbum;
        private System.Windows.Forms.DataGridViewTextBoxColumn AlbumId;
        private System.Windows.Forms.DataGridViewTextBoxColumn AlbumName;
        private System.Windows.Forms.DataGridViewTextBoxColumn AlbumGeneratedRating;
        private System.Windows.Forms.DataGridViewImageColumn AlbumPhotoThumb;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateReleased;
    }
}