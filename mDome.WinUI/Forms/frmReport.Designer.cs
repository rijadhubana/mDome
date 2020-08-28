namespace mDome.WinUI.Forms
{
    partial class frmReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReport));
            this.cmbArtists = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtArtistSearch = new System.Windows.Forms.TextBox();
            this.btnSearchArtist = new System.Windows.Forms.Button();
            this.btnGenerateReport = new System.Windows.Forms.Button();
            this.reportViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.reportBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbArtists
            // 
            this.cmbArtists.FormattingEnabled = true;
            this.cmbArtists.Location = new System.Drawing.Point(17, 60);
            this.cmbArtists.Name = "cmbArtists";
            this.cmbArtists.Size = new System.Drawing.Size(268, 24);
            this.cmbArtists.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(213, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Select artist to generate a report";
            // 
            // txtArtistSearch
            // 
            this.txtArtistSearch.Location = new System.Drawing.Point(16, 109);
            this.txtArtistSearch.Name = "txtArtistSearch";
            this.txtArtistSearch.Size = new System.Drawing.Size(269, 22);
            this.txtArtistSearch.TabIndex = 3;
            // 
            // btnSearchArtist
            // 
            this.btnSearchArtist.Location = new System.Drawing.Point(291, 95);
            this.btnSearchArtist.Name = "btnSearchArtist";
            this.btnSearchArtist.Size = new System.Drawing.Size(147, 37);
            this.btnSearchArtist.TabIndex = 4;
            this.btnSearchArtist.Text = "Search For Artists";
            this.btnSearchArtist.UseVisualStyleBackColor = true;
            this.btnSearchArtist.Click += new System.EventHandler(this.btnSearchArtist_Click);
            // 
            // btnGenerateReport
            // 
            this.btnGenerateReport.Location = new System.Drawing.Point(641, 94);
            this.btnGenerateReport.Name = "btnGenerateReport";
            this.btnGenerateReport.Size = new System.Drawing.Size(147, 37);
            this.btnGenerateReport.TabIndex = 5;
            this.btnGenerateReport.Text = "Generate Report";
            this.btnGenerateReport.UseVisualStyleBackColor = true;
            this.btnGenerateReport.Click += new System.EventHandler(this.btnGenerateReport_Click);
            // 
            // reportViewer
            // 
            this.reportViewer.Location = new System.Drawing.Point(17, 138);
            reportDataSource.Name = "DataSet1";
            reportDataSource.Value = this.reportBindingSource;
            this.reportViewer.LocalReport.DataSources.Add(reportDataSource);
            this.reportViewer.LocalReport.ReportEmbeddedResource = "mDome.WinUI.ArtistReport.rdlc";
            this.reportViewer.Name = "reportViewer";
            this.reportViewer.ServerReport.BearerToken = null;
            this.reportViewer.Size = new System.Drawing.Size(772, 441);
            this.reportViewer.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Reports";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(271, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "(search for artists and select them above)";
            // 
            // frmReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 591);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.reportViewer);
            this.Controls.Add(this.btnGenerateReport);
            this.Controls.Add(this.btnSearchArtist);
            this.Controls.Add(this.txtArtistSearch);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbArtists);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmReport";
            this.Text = "Reports";
            this.Load += new System.EventHandler(this.frmReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.reportBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox cmbArtists;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtArtistSearch;
        private System.Windows.Forms.Button btnSearchArtist;
        private System.Windows.Forms.Button btnGenerateReport;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.BindingSource reportBindingSource;
    }
}