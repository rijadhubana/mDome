namespace mDome.WinUI.Forms
{
    partial class frmPostDetails
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
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPostText = new System.Windows.Forms.RichTextBox();
            this.txtArtistSearch = new System.Windows.Forms.TextBox();
            this.cmbArtists = new System.Windows.Forms.ComboBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.chbGlobal = new System.Windows.Forms.CheckBox();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.pbPostPhoto = new System.Windows.Forms.PictureBox();
            this.btnAddPhoto = new System.Windows.Forms.Button();
            this.txtPhoto = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnAddPost = new System.Windows.Forms.Button();
            this.btnDeletePost = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.label7 = new System.Windows.Forms.Label();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pbPostPhoto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Post Details";
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(16, 59);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(291, 22);
            this.txtTitle.TabIndex = 1;
            this.txtTitle.Validating += new System.ComponentModel.CancelEventHandler(this.txtTitle_Validating);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Post Title";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "Post Text";
            // 
            // txtPostText
            // 
            this.txtPostText.Location = new System.Drawing.Point(16, 120);
            this.txtPostText.Name = "txtPostText";
            this.txtPostText.Size = new System.Drawing.Size(291, 170);
            this.txtPostText.TabIndex = 4;
            this.txtPostText.Text = "";
            this.txtPostText.Validating += new System.ComponentModel.CancelEventHandler(this.txtPostText_Validating);
            // 
            // txtArtistSearch
            // 
            this.txtArtistSearch.Location = new System.Drawing.Point(14, 388);
            this.txtArtistSearch.Name = "txtArtistSearch";
            this.txtArtistSearch.Size = new System.Drawing.Size(164, 22);
            this.txtArtistSearch.TabIndex = 5;
            // 
            // cmbArtists
            // 
            this.cmbArtists.FormattingEnabled = true;
            this.cmbArtists.Location = new System.Drawing.Point(15, 336);
            this.cmbArtists.Name = "cmbArtists";
            this.cmbArtists.Size = new System.Drawing.Size(291, 24);
            this.cmbArtists.TabIndex = 6;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(206, 387);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(101, 23);
            this.btnSearch.TabIndex = 7;
            this.btnSearch.Text = "Search Artist";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 318);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 17);
            this.label4.TabIndex = 8;
            this.label4.Text = "Related to artist";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 368);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(251, 17);
            this.label5.TabIndex = 9;
            this.label5.Text = "Search artist (result will appear above)";
            // 
            // chbGlobal
            // 
            this.chbGlobal.AutoSize = true;
            this.chbGlobal.Location = new System.Drawing.Point(16, 417);
            this.chbGlobal.Name = "chbGlobal";
            this.chbGlobal.Size = new System.Drawing.Size(103, 21);
            this.chbGlobal.TabIndex = 10;
            this.chbGlobal.Text = "Global Post";
            this.toolTip.SetToolTip(this.chbGlobal, "Making a post global will make it appear on every user\'s news feed ");
            this.chbGlobal.UseVisualStyleBackColor = true;
            // 
            // pbPostPhoto
            // 
            this.pbPostPhoto.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pbPostPhoto.Location = new System.Drawing.Point(431, 59);
            this.pbPostPhoto.Name = "pbPostPhoto";
            this.pbPostPhoto.Size = new System.Drawing.Size(180, 180);
            this.pbPostPhoto.TabIndex = 11;
            this.pbPostPhoto.TabStop = false;
            // 
            // btnAddPhoto
            // 
            this.btnAddPhoto.Location = new System.Drawing.Point(535, 252);
            this.btnAddPhoto.Name = "btnAddPhoto";
            this.btnAddPhoto.Size = new System.Drawing.Size(76, 23);
            this.btnAddPhoto.TabIndex = 15;
            this.btnAddPhoto.Text = "Add";
            this.btnAddPhoto.UseVisualStyleBackColor = true;
            this.btnAddPhoto.Click += new System.EventHandler(this.btnAddPhoto_Click);
            // 
            // txtPhoto
            // 
            this.txtPhoto.Location = new System.Drawing.Point(431, 281);
            this.txtPhoto.Name = "txtPhoto";
            this.txtPhoto.Size = new System.Drawing.Size(180, 22);
            this.txtPhoto.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(428, 255);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 17);
            this.label6.TabIndex = 13;
            this.label6.Text = "Post Photo";
            // 
            // btnAddPost
            // 
            this.btnAddPost.Location = new System.Drawing.Point(431, 345);
            this.btnAddPost.Name = "btnAddPost";
            this.btnAddPost.Size = new System.Drawing.Size(180, 40);
            this.btnAddPost.TabIndex = 16;
            this.btnAddPost.Text = "Add Post";
            this.btnAddPost.UseVisualStyleBackColor = true;
            this.btnAddPost.Click += new System.EventHandler(this.btnAddPost_Click);
            // 
            // btnDeletePost
            // 
            this.btnDeletePost.Enabled = false;
            this.btnDeletePost.Location = new System.Drawing.Point(431, 398);
            this.btnDeletePost.Name = "btnDeletePost";
            this.btnDeletePost.Size = new System.Drawing.Size(180, 40);
            this.btnDeletePost.TabIndex = 17;
            this.btnDeletePost.Text = "Delete Post";
            this.btnDeletePost.UseVisualStyleBackColor = true;
            this.btnDeletePost.Click += new System.EventHandler(this.btnDeletePost_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(428, 39);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(199, 17);
            this.label7.TabIndex = 18;
            this.label7.Text = "(picture bellow is resized to fit)";
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // frmPostDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(651, 443);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnDeletePost);
            this.Controls.Add(this.btnAddPost);
            this.Controls.Add(this.btnAddPhoto);
            this.Controls.Add(this.txtPhoto);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.pbPostPhoto);
            this.Controls.Add(this.chbGlobal);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.cmbArtists);
            this.Controls.Add(this.txtArtistSearch);
            this.Controls.Add(this.txtPostText);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.label1);
            this.Name = "frmPostDetails";
            this.Text = "frmPostDetails";
            this.Load += new System.EventHandler(this.frmPostDetails_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbPostPhoto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox txtPostText;
        private System.Windows.Forms.TextBox txtArtistSearch;
        private System.Windows.Forms.ComboBox cmbArtists;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chbGlobal;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.PictureBox pbPostPhoto;
        private System.Windows.Forms.Button btnAddPhoto;
        private System.Windows.Forms.TextBox txtPhoto;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnAddPost;
        private System.Windows.Forms.Button btnDeletePost;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}