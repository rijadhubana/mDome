namespace mDome.WinUI.Forms
{
    partial class frmAdministratorList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAdministratorList));
            this.dgvAdmins = new System.Windows.Forms.DataGridView();
            this.AdministratorId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AdministratorName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAdd = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtAdminSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAdmins)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvAdmins
            // 
            this.dgvAdmins.AllowUserToAddRows = false;
            this.dgvAdmins.AllowUserToDeleteRows = false;
            this.dgvAdmins.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAdmins.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.AdministratorId,
            this.AdministratorName});
            this.dgvAdmins.Location = new System.Drawing.Point(13, 74);
            this.dgvAdmins.Name = "dgvAdmins";
            this.dgvAdmins.ReadOnly = true;
            this.dgvAdmins.RowHeadersWidth = 51;
            this.dgvAdmins.RowTemplate.Height = 24;
            this.dgvAdmins.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAdmins.Size = new System.Drawing.Size(240, 364);
            this.dgvAdmins.TabIndex = 0;
            this.dgvAdmins.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgvAdmins_MouseDoubleClick);
            // 
            // AdministratorId
            // 
            this.AdministratorId.DataPropertyName = "AdministratorId";
            this.AdministratorId.HeaderText = "AdminId";
            this.AdministratorId.MinimumWidth = 6;
            this.AdministratorId.Name = "AdministratorId";
            this.AdministratorId.ReadOnly = true;
            this.AdministratorId.Visible = false;
            this.AdministratorId.Width = 125;
            // 
            // AdministratorName
            // 
            this.AdministratorName.DataPropertyName = "AdminName";
            this.AdministratorName.HeaderText = "Name";
            this.AdministratorName.MinimumWidth = 6;
            this.AdministratorName.Name = "AdministratorName";
            this.AdministratorName.ReadOnly = true;
            this.AdministratorName.Width = 125;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(13, 444);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(240, 31);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "Add New Administrator";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Administrators";
            // 
            // txtAdminSearch
            // 
            this.txtAdminSearch.Location = new System.Drawing.Point(13, 46);
            this.txtAdminSearch.Name = "txtAdminSearch";
            this.txtAdminSearch.Size = new System.Drawing.Size(146, 22);
            this.txtAdminSearch.TabIndex = 3;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(178, 38);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 30);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // frmAdministratorList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(276, 484);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtAdminSearch);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.dgvAdmins);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmAdministratorList";
            this.Text = "Administrator List";
            this.Load += new System.EventHandler(this.frmAdministratorList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAdmins)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvAdmins;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn AdministratorId;
        private System.Windows.Forms.DataGridViewTextBoxColumn AdministratorName;
        private System.Windows.Forms.TextBox txtAdminSearch;
        private System.Windows.Forms.Button btnSearch;
    }
}