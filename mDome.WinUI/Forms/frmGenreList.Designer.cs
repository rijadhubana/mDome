namespace mDome.WinUI
{
    partial class frmGenreList
    {
        private const string V = "frmGenreList";

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGenreList));
            this.lblGenres = new System.Windows.Forms.Label();
            this.dgvGenres = new System.Windows.Forms.DataGridView();
            this.GenreId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GenreName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GenreDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtGenreSearch = new System.Windows.Forms.TextBox();
            this.btnAddGenre = new System.Windows.Forms.Button();
            this.btnSearchGenres = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGenres)).BeginInit();
            this.SuspendLayout();
            // 
            // lblGenres
            // 
            this.lblGenres.AutoSize = true;
            this.lblGenres.Location = new System.Drawing.Point(159, 9);
            this.lblGenres.Name = "lblGenres";
            this.lblGenres.Size = new System.Drawing.Size(55, 17);
            this.lblGenres.TabIndex = 0;
            this.lblGenres.Text = "Genres";
            // 
            // dgvGenres
            // 
            this.dgvGenres.AllowUserToAddRows = false;
            this.dgvGenres.AllowUserToDeleteRows = false;
            this.dgvGenres.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGenres.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.GenreId,
            this.GenreName,
            this.GenreDescription});
            this.dgvGenres.Location = new System.Drawing.Point(12, 104);
            this.dgvGenres.Name = "dgvGenres";
            this.dgvGenres.ReadOnly = true;
            this.dgvGenres.RowHeadersWidth = 51;
            this.dgvGenres.RowTemplate.Height = 24;
            this.dgvGenres.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvGenres.Size = new System.Drawing.Size(434, 310);
            this.dgvGenres.TabIndex = 1;
            this.dgvGenres.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgvGenres_MouseDoubleClick);
            // 
            // GenreId
            // 
            this.GenreId.DataPropertyName = "GenreId";
            this.GenreId.HeaderText = "Genre Id";
            this.GenreId.MinimumWidth = 6;
            this.GenreId.Name = "GenreId";
            this.GenreId.ReadOnly = true;
            this.GenreId.Visible = false;
            this.GenreId.Width = 125;
            // 
            // GenreName
            // 
            this.GenreName.DataPropertyName = "GenreName";
            this.GenreName.HeaderText = "Genre Name";
            this.GenreName.MinimumWidth = 6;
            this.GenreName.Name = "GenreName";
            this.GenreName.ReadOnly = true;
            this.GenreName.Width = 125;
            // 
            // GenreDescription
            // 
            this.GenreDescription.DataPropertyName = "GenreDescription";
            this.GenreDescription.HeaderText = "Genre Description";
            this.GenreDescription.MinimumWidth = 6;
            this.GenreDescription.Name = "GenreDescription";
            this.GenreDescription.ReadOnly = true;
            this.GenreDescription.Width = 125;
            // 
            // txtGenreSearch
            // 
            this.txtGenreSearch.Location = new System.Drawing.Point(13, 53);
            this.txtGenreSearch.Name = "txtGenreSearch";
            this.txtGenreSearch.Size = new System.Drawing.Size(295, 22);
            this.txtGenreSearch.TabIndex = 2;
            // 
            // btnAddGenre
            // 
            this.btnAddGenre.Location = new System.Drawing.Point(13, 431);
            this.btnAddGenre.Name = "btnAddGenre";
            this.btnAddGenre.Size = new System.Drawing.Size(433, 44);
            this.btnAddGenre.TabIndex = 4;
            this.btnAddGenre.Text = "Add New Genre";
            this.btnAddGenre.UseVisualStyleBackColor = true;
            this.btnAddGenre.Click += new System.EventHandler(this.btnAddGenre_Click);
            // 
            // btnSearchGenres
            // 
            this.btnSearchGenres.Location = new System.Drawing.Point(328, 52);
            this.btnSearchGenres.Name = "btnSearchGenres";
            this.btnSearchGenres.Size = new System.Drawing.Size(118, 23);
            this.btnSearchGenres.TabIndex = 5;
            this.btnSearchGenres.Text = "Search";
            this.btnSearchGenres.UseVisualStyleBackColor = true;
            this.btnSearchGenres.Click += new System.EventHandler(this.btnSearchGenres_Click);
            // 
            // frmGenreList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(458, 486);
            this.Controls.Add(this.btnSearchGenres);
            this.Controls.Add(this.btnAddGenre);
            this.Controls.Add(this.txtGenreSearch);
            this.Controls.Add(this.dgvGenres);
            this.Controls.Add(this.lblGenres);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmGenreList";
            this.Text = "Genre List";
            this.Load += new System.EventHandler(this.frmGenreList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGenres)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblGenres;
        private System.Windows.Forms.DataGridView dgvGenres;
        private System.Windows.Forms.TextBox txtGenreSearch;
        private System.Windows.Forms.Button btnAddGenre;
        private System.Windows.Forms.Button btnSearchGenres;
        private System.Windows.Forms.DataGridViewTextBoxColumn GenreId;
        private System.Windows.Forms.DataGridViewTextBoxColumn GenreName;
        private System.Windows.Forms.DataGridViewTextBoxColumn GenreDescription;
    }
}