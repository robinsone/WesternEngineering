namespace SeedingProgramV2
{
    partial class Form1
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uploadCSVFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshGridToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gradsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undergradsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.activeDirectoryUsersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cSVUsersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.directorySearcher1 = new System.DirectoryServices.DirectorySearcher();
            this.grdUsers = new System.Windows.Forms.DataGridView();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.progressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdUsers)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.viewToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(828, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uploadCSVFileToolStripMenuItem,
            this.refreshGridToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // uploadCSVFileToolStripMenuItem
            // 
            this.uploadCSVFileToolStripMenuItem.Name = "uploadCSVFileToolStripMenuItem";
            this.uploadCSVFileToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.U)));
            this.uploadCSVFileToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.uploadCSVFileToolStripMenuItem.Text = "Upload CSV File";
            this.uploadCSVFileToolStripMenuItem.Click += new System.EventHandler(this.uploadCSVFileToolStripMenuItem_Click);
            // 
            // refreshGridToolStripMenuItem
            // 
            this.refreshGridToolStripMenuItem.Name = "refreshGridToolStripMenuItem";
            this.refreshGridToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.refreshGridToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.refreshGridToolStripMenuItem.Text = "Refresh Grid";
            this.refreshGridToolStripMenuItem.Click += new System.EventHandler(this.refreshGridToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.Checked = true;
            this.viewToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gradsToolStripMenuItem,
            this.undergradsToolStripMenuItem,
            this.activeDirectoryUsersToolStripMenuItem,
            this.cSVUsersToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // gradsToolStripMenuItem
            // 
            this.gradsToolStripMenuItem.Checked = true;
            this.gradsToolStripMenuItem.CheckOnClick = true;
            this.gradsToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.gradsToolStripMenuItem.Name = "gradsToolStripMenuItem";
            this.gradsToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.gradsToolStripMenuItem.Text = "Grads";
            this.gradsToolStripMenuItem.Click += new System.EventHandler(this.gradsToolStripMenuItem_Click);
            // 
            // undergradsToolStripMenuItem
            // 
            this.undergradsToolStripMenuItem.Checked = true;
            this.undergradsToolStripMenuItem.CheckOnClick = true;
            this.undergradsToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.undergradsToolStripMenuItem.Name = "undergradsToolStripMenuItem";
            this.undergradsToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.undergradsToolStripMenuItem.Text = "Undergrads";
            this.undergradsToolStripMenuItem.Click += new System.EventHandler(this.undergradsToolStripMenuItem_Click);
            // 
            // activeDirectoryUsersToolStripMenuItem
            // 
            this.activeDirectoryUsersToolStripMenuItem.Checked = true;
            this.activeDirectoryUsersToolStripMenuItem.CheckOnClick = true;
            this.activeDirectoryUsersToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.activeDirectoryUsersToolStripMenuItem.Name = "activeDirectoryUsersToolStripMenuItem";
            this.activeDirectoryUsersToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.activeDirectoryUsersToolStripMenuItem.Text = "Active Directory Users";
            this.activeDirectoryUsersToolStripMenuItem.Click += new System.EventHandler(this.activeDirectoryUsersToolStripMenuItem_Click);
            // 
            // cSVUsersToolStripMenuItem
            // 
            this.cSVUsersToolStripMenuItem.Checked = true;
            this.cSVUsersToolStripMenuItem.CheckOnClick = true;
            this.cSVUsersToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cSVUsersToolStripMenuItem.Name = "cSVUsersToolStripMenuItem";
            this.cSVUsersToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.cSVUsersToolStripMenuItem.Text = "CSV Users";
            this.cSVUsersToolStripMenuItem.Click += new System.EventHandler(this.cSVUsersToolStripMenuItem_Click);
            // 
            // directorySearcher1
            // 
            this.directorySearcher1.ClientTimeout = System.TimeSpan.Parse("-00:00:01");
            this.directorySearcher1.ServerPageTimeLimit = System.TimeSpan.Parse("-00:00:01");
            this.directorySearcher1.ServerTimeLimit = System.TimeSpan.Parse("-00:00:01");
            // 
            // grdUsers
            // 
            this.grdUsers.BackgroundColor = System.Drawing.SystemColors.Control;
            this.grdUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdUsers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdUsers.Location = new System.Drawing.Point(0, 24);
            this.grdUsers.Name = "grdUsers";
            this.grdUsers.Size = new System.Drawing.Size(828, 531);
            this.grdUsers.StandardTab = true;
            this.grdUsers.TabIndex = 1;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.progressBar,
            this.lblStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 533);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(828, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // progressBar
            // 
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(100, 16);
            this.progressBar.Visible = false;
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 17);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(828, 555);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.grdUsers);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdUsers)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.DirectoryServices.DirectorySearcher directorySearcher1;
        private System.Windows.Forms.DataGridView grdUsers;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripMenuItem uploadCSVFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem refreshGridToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gradsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem undergradsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem activeDirectoryUsersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cSVUsersToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.ToolStripProgressBar progressBar;
    }
}

