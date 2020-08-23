namespace mDome.WinUI.Forms
{
    partial class frmRequestPanel
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
            this.dgvRequests = new System.Windows.Forms.DataGridView();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.RequestId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RequestText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NameOfUser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RequestDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRequests)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvRequests
            // 
            this.dgvRequests.AllowUserToAddRows = false;
            this.dgvRequests.AllowUserToDeleteRows = false;
            this.dgvRequests.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRequests.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RequestId,
            this.RequestText,
            this.NameOfUser,
            this.RequestDate});
            this.dgvRequests.Location = new System.Drawing.Point(13, 86);
            this.dgvRequests.Name = "dgvRequests";
            this.dgvRequests.ReadOnly = true;
            this.dgvRequests.RowHeadersWidth = 51;
            this.dgvRequests.RowTemplate.Height = 24;
            this.dgvRequests.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRequests.Size = new System.Drawing.Size(775, 352);
            this.dgvRequests.TabIndex = 0;
            this.dgvRequests.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgvRequests_MouseDoubleClick);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(13, 44);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(188, 22);
            this.txtSearch.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Request Panel";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(219, 44);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(102, 23);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // RequestId
            // 
            this.RequestId.DataPropertyName = "RequestId";
            this.RequestId.HeaderText = "RequestId";
            this.RequestId.MinimumWidth = 6;
            this.RequestId.Name = "RequestId";
            this.RequestId.ReadOnly = true;
            this.RequestId.Visible = false;
            this.RequestId.Width = 125;
            // 
            // RequestText
            // 
            this.RequestText.DataPropertyName = "RequestText";
            this.RequestText.HeaderText = "Request Text";
            this.RequestText.MinimumWidth = 6;
            this.RequestText.Name = "RequestText";
            this.RequestText.ReadOnly = true;
            this.RequestText.Width = 400;
            // 
            // NameOfUser
            // 
            this.NameOfUser.DataPropertyName = "NameOfUser";
            this.NameOfUser.HeaderText = "Name of User";
            this.NameOfUser.MinimumWidth = 6;
            this.NameOfUser.Name = "NameOfUser";
            this.NameOfUser.ReadOnly = true;
            this.NameOfUser.Width = 125;
            // 
            // RequestDate
            // 
            this.RequestDate.DataPropertyName = "RequestDate";
            this.RequestDate.HeaderText = "Request Date";
            this.RequestDate.MinimumWidth = 6;
            this.RequestDate.Name = "RequestDate";
            this.RequestDate.ReadOnly = true;
            this.RequestDate.Width = 125;
            // 
            // frmRequestPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.dgvRequests);
            this.Name = "frmRequestPanel";
            this.Text = "frmRequestPanel";
            this.Load += new System.EventHandler(this.frmRequestPanel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRequests)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvRequests;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DataGridViewTextBoxColumn RequestId;
        private System.Windows.Forms.DataGridViewTextBoxColumn RequestText;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameOfUser;
        private System.Windows.Forms.DataGridViewTextBoxColumn RequestDate;
    }
}