namespace mDome.WinUI.Forms
{
    partial class frmReviewDetails
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReviewDetails));
            this.label1 = new System.Windows.Forms.Label();
            this.txtAlbumNameUsername = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtReviewText = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtLeast = new System.Windows.Forms.TextBox();
            this.txtFav = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtRating = new System.Windows.Forms.TextBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.txtNotify = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Review Details";
            // 
            // txtAlbumNameUsername
            // 
            this.txtAlbumNameUsername.Location = new System.Drawing.Point(16, 60);
            this.txtAlbumNameUsername.Name = "txtAlbumNameUsername";
            this.txtAlbumNameUsername.ReadOnly = true;
            this.txtAlbumNameUsername.Size = new System.Drawing.Size(364, 22);
            this.txtAlbumNameUsername.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(181, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Album name and username";
            // 
            // txtReviewText
            // 
            this.txtReviewText.Location = new System.Drawing.Point(16, 116);
            this.txtReviewText.Name = "txtReviewText";
            this.txtReviewText.ReadOnly = true;
            this.txtReviewText.Size = new System.Drawing.Size(364, 177);
            this.txtReviewText.TabIndex = 3;
            this.txtReviewText.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Review text";
            // 
            // txtLeast
            // 
            this.txtLeast.Location = new System.Drawing.Point(16, 365);
            this.txtLeast.Name = "txtLeast";
            this.txtLeast.ReadOnly = true;
            this.txtLeast.Size = new System.Drawing.Size(364, 22);
            this.txtLeast.TabIndex = 5;
            // 
            // txtFav
            // 
            this.txtFav.Location = new System.Drawing.Point(16, 320);
            this.txtFav.Name = "txtFav";
            this.txtFav.ReadOnly = true;
            this.txtFav.Size = new System.Drawing.Size(364, 22);
            this.txtFav.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 300);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Favourite songs";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 345);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(144, 17);
            this.label5.TabIndex = 8;
            this.label5.Text = "Least favourite songs";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 390);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 17);
            this.label6.TabIndex = 9;
            this.label6.Text = "Rating";
            // 
            // txtRating
            // 
            this.txtRating.Location = new System.Drawing.Point(16, 410);
            this.txtRating.Name = "txtRating";
            this.txtRating.ReadOnly = true;
            this.txtRating.Size = new System.Drawing.Size(364, 22);
            this.txtRating.TabIndex = 10;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(16, 520);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(364, 40);
            this.btnDelete.TabIndex = 11;
            this.btnDelete.Text = "Delete Review and Notify User";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 435);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(159, 17);
            this.label7.TabIndex = 12;
            this.label7.Text = "Notification text for User";
            // 
            // txtNotify
            // 
            this.txtNotify.Location = new System.Drawing.Point(16, 456);
            this.txtNotify.Multiline = true;
            this.txtNotify.Name = "txtNotify";
            this.txtNotify.Size = new System.Drawing.Size(364, 58);
            this.txtNotify.TabIndex = 13;
            // 
            // frmReviewDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(392, 572);
            this.Controls.Add(this.txtNotify);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.txtRating);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtFav);
            this.Controls.Add(this.txtLeast);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtReviewText);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtAlbumNameUsername);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmReviewDetails";
            this.Text = "Review Details";
            this.Load += new System.EventHandler(this.frmReviewDetails_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtAlbumNameUsername;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox txtReviewText;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtLeast;
        private System.Windows.Forms.TextBox txtFav;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtRating;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtNotify;
    }
}