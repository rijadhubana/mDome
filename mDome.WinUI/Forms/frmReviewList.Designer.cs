namespace mDome.WinUI.Forms
{
    partial class frmReviewList
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
            this.dgvReviews = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.cmbAlbums = new System.Windows.Forms.ComboBox();
            this.txtAlbumSearch = new System.Windows.Forms.TextBox();
            this.txtRatingFrom = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl = new System.Windows.Forms.Label();
            this.txtRatingTo = new System.Windows.Forms.TextBox();
            this.btnSearchReviews = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReviews)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvReviews
            // 
            this.dgvReviews.AllowUserToAddRows = false;
            this.dgvReviews.AllowUserToDeleteRows = false;
            this.dgvReviews.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReviews.Location = new System.Drawing.Point(13, 176);
            this.dgvReviews.Name = "dgvReviews";
            this.dgvReviews.ReadOnly = true;
            this.dgvReviews.RowHeadersWidth = 51;
            this.dgvReviews.RowTemplate.Height = 24;
            this.dgvReviews.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvReviews.Size = new System.Drawing.Size(775, 262);
            this.dgvReviews.TabIndex = 0;
            this.dgvReviews.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgvReviews_MouseDoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Reviews";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 128);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(258, 17);
            this.label5.TabIndex = 14;
            this.label5.Text = "Search album (result will appear above)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 17);
            this.label4.TabIndex = 13;
            this.label4.Text = "Related to album";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(191, 148);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(117, 23);
            this.btnSearch.TabIndex = 12;
            this.btnSearch.Text = "Search Album";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // cmbAlbums
            // 
            this.cmbAlbums.FormattingEnabled = true;
            this.cmbAlbums.Location = new System.Drawing.Point(17, 96);
            this.cmbAlbums.Name = "cmbAlbums";
            this.cmbAlbums.Size = new System.Drawing.Size(291, 24);
            this.cmbAlbums.TabIndex = 11;
            // 
            // txtAlbumSearch
            // 
            this.txtAlbumSearch.Location = new System.Drawing.Point(16, 148);
            this.txtAlbumSearch.Name = "txtAlbumSearch";
            this.txtAlbumSearch.Size = new System.Drawing.Size(147, 22);
            this.txtAlbumSearch.TabIndex = 10;
            // 
            // txtRatingFrom
            // 
            this.txtRatingFrom.Location = new System.Drawing.Point(416, 148);
            this.txtRatingFrom.Name = "txtRatingFrom";
            this.txtRatingFrom.Size = new System.Drawing.Size(95, 22);
            this.txtRatingFrom.TabIndex = 15;
            this.txtRatingFrom.Text = "0";
            this.txtRatingFrom.TextChanged += new System.EventHandler(this.txtRatingFrom_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(329, 153);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 17);
            this.label2.TabIndex = 16;
            this.label2.Text = "Rating from";
            // 
            // lbl
            // 
            this.lbl.AutoSize = true;
            this.lbl.Location = new System.Drawing.Point(517, 153);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(25, 17);
            this.lbl.TabIndex = 18;
            this.lbl.Text = "To";
            // 
            // txtRatingTo
            // 
            this.txtRatingTo.Location = new System.Drawing.Point(548, 148);
            this.txtRatingTo.Name = "txtRatingTo";
            this.txtRatingTo.Size = new System.Drawing.Size(95, 22);
            this.txtRatingTo.TabIndex = 17;
            this.txtRatingTo.Text = "5";
            this.txtRatingTo.TextChanged += new System.EventHandler(this.txtRatingTo_TextChanged);
            // 
            // btnSearchReviews
            // 
            this.btnSearchReviews.Location = new System.Drawing.Point(670, 138);
            this.btnSearchReviews.Name = "btnSearchReviews";
            this.btnSearchReviews.Size = new System.Drawing.Size(118, 33);
            this.btnSearchReviews.TabIndex = 19;
            this.btnSearchReviews.Text = "Search Reviews";
            this.btnSearchReviews.UseVisualStyleBackColor = true;
            this.btnSearchReviews.Click += new System.EventHandler(this.btnSearchReviews_Click);
            // 
            // frmReviewList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnSearchReviews);
            this.Controls.Add(this.lbl);
            this.Controls.Add(this.txtRatingTo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtRatingFrom);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.cmbAlbums);
            this.Controls.Add(this.txtAlbumSearch);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvReviews);
            this.Name = "frmReviewList";
            this.Text = "frmReviewList";
            this.Load += new System.EventHandler(this.frmReviewList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReviews)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvReviews;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ComboBox cmbAlbums;
        private System.Windows.Forms.TextBox txtAlbumSearch;
        private System.Windows.Forms.TextBox txtRatingFrom;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbl;
        private System.Windows.Forms.TextBox txtRatingTo;
        private System.Windows.Forms.Button btnSearchReviews;
    }
}