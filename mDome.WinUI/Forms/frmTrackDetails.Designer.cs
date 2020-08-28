namespace mDome.WinUI.Forms
{
    partial class frmTrackDetails
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTrackDetails));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTrackName = new System.Windows.Forms.TextBox();
            this.txtTrackNumber = new System.Windows.Forms.TextBox();
            this.txtYtid = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnFetch = new System.Windows.Forms.Button();
            this.btnSubmitTrack = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.txtLyrics = new System.Windows.Forms.RichTextBox();
            this.btnDelete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Track Details";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Track Number";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Track Name";
            // 
            // txtTrackName
            // 
            this.txtTrackName.Location = new System.Drawing.Point(16, 66);
            this.txtTrackName.Name = "txtTrackName";
            this.txtTrackName.Size = new System.Drawing.Size(289, 22);
            this.txtTrackName.TabIndex = 3;
            this.txtTrackName.Validating += new System.ComponentModel.CancelEventHandler(this.txtTrackName_Validating);
            // 
            // txtTrackNumber
            // 
            this.txtTrackNumber.Location = new System.Drawing.Point(16, 111);
            this.txtTrackNumber.Name = "txtTrackNumber";
            this.txtTrackNumber.Size = new System.Drawing.Size(289, 22);
            this.txtTrackNumber.TabIndex = 4;
            this.txtTrackNumber.TextChanged += new System.EventHandler(this.txtTrackNumber_TextChanged);
            // 
            // txtYtid
            // 
            this.txtYtid.Location = new System.Drawing.Point(16, 156);
            this.txtYtid.Name = "txtYtid";
            this.txtYtid.Size = new System.Drawing.Size(289, 22);
            this.txtYtid.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 136);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(116, 17);
            this.label4.TabIndex = 5;
            this.label4.Text = "Track Youtube Id";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 181);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 17);
            this.label5.TabIndex = 7;
            this.label5.Text = "Track Lyrics";
            // 
            // btnFetch
            // 
            this.btnFetch.Location = new System.Drawing.Point(16, 362);
            this.btnFetch.Name = "btnFetch";
            this.btnFetch.Size = new System.Drawing.Size(289, 35);
            this.btnFetch.TabIndex = 9;
            this.btnFetch.Text = "Fetch Lyrics and Youtube Id";
            this.btnFetch.UseVisualStyleBackColor = true;
            this.btnFetch.Click += new System.EventHandler(this.btnFetch_Click);
            // 
            // btnSubmitTrack
            // 
            this.btnSubmitTrack.Location = new System.Drawing.Point(16, 444);
            this.btnSubmitTrack.Name = "btnSubmitTrack";
            this.btnSubmitTrack.Size = new System.Drawing.Size(289, 35);
            this.btnSubmitTrack.TabIndex = 10;
            this.btnSubmitTrack.Text = "Submit";
            this.btnSubmitTrack.UseVisualStyleBackColor = true;
            this.btnSubmitTrack.Click += new System.EventHandler(this.btnSubmitTrack_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // txtLyrics
            // 
            this.txtLyrics.Location = new System.Drawing.Point(16, 211);
            this.txtLyrics.Name = "txtLyrics";
            this.txtLyrics.Size = new System.Drawing.Size(289, 145);
            this.txtLyrics.TabIndex = 11;
            this.txtLyrics.Text = "";
            // 
            // btnDelete
            // 
            this.btnDelete.Enabled = false;
            this.btnDelete.Location = new System.Drawing.Point(16, 403);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(289, 35);
            this.btnDelete.TabIndex = 12;
            this.btnDelete.Text = "Remove This Track";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // frmTrackDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(317, 486);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.txtLyrics);
            this.Controls.Add(this.btnSubmitTrack);
            this.Controls.Add(this.btnFetch);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtYtid);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtTrackNumber);
            this.Controls.Add(this.txtTrackName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmTrackDetails";
            this.Text = "Track Details";
            this.Load += new System.EventHandler(this.frmTrackDetails_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTrackName;
        private System.Windows.Forms.TextBox txtTrackNumber;
        private System.Windows.Forms.TextBox txtYtid;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnFetch;
        private System.Windows.Forms.Button btnSubmitTrack;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.RichTextBox txtLyrics;
        private System.Windows.Forms.Button btnDelete;
    }
}