namespace mDome.WinUI.Forms
{
    partial class frmPostsList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPostsList));
            this.dgvPosts = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbArtists = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbUser = new System.Windows.Forms.ComboBox();
            this.chbGlobal = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnAddPost = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.PostId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PostTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PostDateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PostPhoto = new System.Windows.Forms.DataGridViewImageColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPosts)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPosts
            // 
            this.dgvPosts.AllowUserToAddRows = false;
            this.dgvPosts.AllowUserToDeleteRows = false;
            this.dgvPosts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPosts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PostId,
            this.PostTitle,
            this.PostDateTime,
            this.PostPhoto});
            this.dgvPosts.Location = new System.Drawing.Point(13, 232);
            this.dgvPosts.Name = "dgvPosts";
            this.dgvPosts.ReadOnly = true;
            this.dgvPosts.RowHeadersWidth = 51;
            this.dgvPosts.RowTemplate.Height = 24;
            this.dgvPosts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPosts.Size = new System.Drawing.Size(775, 316);
            this.dgvPosts.TabIndex = 0;
            this.dgvPosts.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgvPosts_MouseDoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Posts";
            // 
            // cmbArtists
            // 
            this.cmbArtists.FormattingEnabled = true;
            this.cmbArtists.Location = new System.Drawing.Point(16, 110);
            this.cmbArtists.Name = "cmbArtists";
            this.cmbArtists.Size = new System.Drawing.Size(237, 24);
            this.cmbArtists.TabIndex = 2;
            this.cmbArtists.SelectedIndexChanged += new System.EventHandler(this.cmbArtists_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Related To Artist";
            // 
            // cmbUser
            // 
            this.cmbUser.FormattingEnabled = true;
            this.cmbUser.Location = new System.Drawing.Point(16, 170);
            this.cmbUser.Name = "cmbUser";
            this.cmbUser.Size = new System.Drawing.Size(237, 24);
            this.cmbUser.TabIndex = 4;
            this.cmbUser.SelectedIndexChanged += new System.EventHandler(this.cmbUser_SelectedIndexChanged);
            // 
            // chbGlobal
            // 
            this.chbGlobal.AutoSize = true;
            this.chbGlobal.Location = new System.Drawing.Point(16, 201);
            this.chbGlobal.Name = "chbGlobal";
            this.chbGlobal.Size = new System.Drawing.Size(85, 21);
            this.chbGlobal.TabIndex = 5;
            this.chbGlobal.Text = "Is Global";
            this.chbGlobal.UseVisualStyleBackColor = true;
            this.chbGlobal.CheckedChanged += new System.EventHandler(this.chbGlobal_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 150);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Related To User";
            // 
            // btnAddPost
            // 
            this.btnAddPost.Location = new System.Drawing.Point(551, 191);
            this.btnAddPost.Name = "btnAddPost";
            this.btnAddPost.Size = new System.Drawing.Size(237, 35);
            this.btnAddPost.TabIndex = 7;
            this.btnAddPost.Text = "Add New Post";
            this.btnAddPost.UseVisualStyleBackColor = true;
            this.btnAddPost.Click += new System.EventHandler(this.btnAddPost_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(183, 17);
            this.label4.TabIndex = 8;
            this.label4.Text = "Search Related Parameters";
            // 
            // PostId
            // 
            this.PostId.DataPropertyName = "PostId";
            this.PostId.HeaderText = "PostId";
            this.PostId.MinimumWidth = 6;
            this.PostId.Name = "PostId";
            this.PostId.ReadOnly = true;
            this.PostId.Visible = false;
            this.PostId.Width = 125;
            // 
            // PostTitle
            // 
            this.PostTitle.DataPropertyName = "PostTitle";
            this.PostTitle.HeaderText = "Post Title";
            this.PostTitle.MinimumWidth = 6;
            this.PostTitle.Name = "PostTitle";
            this.PostTitle.ReadOnly = true;
            this.PostTitle.Width = 125;
            // 
            // PostDateTime
            // 
            this.PostDateTime.DataPropertyName = "PostDateTime";
            this.PostDateTime.HeaderText = "Post Date";
            this.PostDateTime.MinimumWidth = 6;
            this.PostDateTime.Name = "PostDateTime";
            this.PostDateTime.ReadOnly = true;
            this.PostDateTime.Width = 125;
            // 
            // PostPhoto
            // 
            this.PostPhoto.DataPropertyName = "PostPhoto";
            this.PostPhoto.HeaderText = "Post Photo";
            this.PostPhoto.MinimumWidth = 6;
            this.PostPhoto.Name = "PostPhoto";
            this.PostPhoto.ReadOnly = true;
            this.PostPhoto.Width = 125;
            // 
            // frmPostsList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 560);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnAddPost);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.chbGlobal);
            this.Controls.Add(this.cmbUser);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbArtists);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvPosts);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmPostsList";
            this.Text = "Post List";
            this.Load += new System.EventHandler(this.frmPostsList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPosts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPosts;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbArtists;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbUser;
        private System.Windows.Forms.CheckBox chbGlobal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnAddPost;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewTextBoxColumn PostId;
        private System.Windows.Forms.DataGridViewTextBoxColumn PostTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn PostDateTime;
        private System.Windows.Forms.DataGridViewImageColumn PostPhoto;
    }
}