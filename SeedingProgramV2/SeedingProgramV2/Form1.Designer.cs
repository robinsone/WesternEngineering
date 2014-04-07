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
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uploadCSVFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshGridToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gradsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undergradsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.activeDirectoryUsersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cSVUsersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.actionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chooseOUToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addAllToADToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripComboBox1 = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripTextBox2 = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripComboBox2 = new System.Windows.Forms.ToolStripComboBox();
            this.applyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.directorySearcher1 = new System.DirectoryServices.DirectorySearcher();
            this.grdUsers = new System.Windows.Forms.DataGridView();
            this.GridContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addToADToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyInformationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.progressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.backupOldUsersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteBackupSelectedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdUsers)).BeginInit();
            this.GridContextMenu.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.actionsToolStripMenuItem,
            this.toolStripTextBox1,
            this.toolStripComboBox1,
            this.toolStripTextBox2,
            this.toolStripComboBox2,
            this.applyToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(899, 27);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uploadCSVFileToolStripMenuItem,
            this.refreshGridToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 23);
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
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 23);
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
            // actionsToolStripMenuItem
            // 
            this.actionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.chooseOUToolStripMenuItem,
            this.addAllToADToolStripMenuItem,
            this.backupOldUsersToolStripMenuItem,
            this.deleteBackupSelectedToolStripMenuItem});
            this.actionsToolStripMenuItem.Name = "actionsToolStripMenuItem";
            this.actionsToolStripMenuItem.Size = new System.Drawing.Size(59, 23);
            this.actionsToolStripMenuItem.Text = "Actions";
            // 
            // chooseOUToolStripMenuItem
            // 
            this.chooseOUToolStripMenuItem.Name = "chooseOUToolStripMenuItem";
            this.chooseOUToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.chooseOUToolStripMenuItem.Text = "Add Selected to AD";
            this.chooseOUToolStripMenuItem.Click += new System.EventHandler(this.chooseOUToolStripMenuItem_Click);
            // 
            // addAllToADToolStripMenuItem
            // 
            this.addAllToADToolStripMenuItem.Name = "addAllToADToolStripMenuItem";
            this.addAllToADToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.addAllToADToolStripMenuItem.Text = "Add All to AD";
            this.addAllToADToolStripMenuItem.Click += new System.EventHandler(this.addAllToADToolStripMenuItem_Click);
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.AutoSize = false;
            this.toolStripTextBox1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.toolStripTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.ReadOnly = true;
            this.toolStripTextBox1.Size = new System.Drawing.Size(100, 23);
            this.toolStripTextBox1.Text = "Grad OU:";
            this.toolStripTextBox1.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // toolStripComboBox1
            // 
            this.toolStripComboBox1.DropDownWidth = 125;
            this.toolStripComboBox1.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.toolStripComboBox1.MaxDropDownItems = 15;
            this.toolStripComboBox1.Name = "toolStripComboBox1";
            this.toolStripComboBox1.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.toolStripComboBox1.Size = new System.Drawing.Size(175, 23);
            // 
            // toolStripTextBox2
            // 
            this.toolStripTextBox2.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.toolStripTextBox2.Name = "toolStripTextBox2";
            this.toolStripTextBox2.ReadOnly = true;
            this.toolStripTextBox2.Size = new System.Drawing.Size(100, 23);
            this.toolStripTextBox2.Text = "Undergrad OU:";
            this.toolStripTextBox2.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // toolStripComboBox2
            // 
            this.toolStripComboBox2.Name = "toolStripComboBox2";
            this.toolStripComboBox2.Size = new System.Drawing.Size(205, 23);
            // 
            // applyToolStripMenuItem
            // 
            this.applyToolStripMenuItem.Name = "applyToolStripMenuItem";
            this.applyToolStripMenuItem.Size = new System.Drawing.Size(50, 23);
            this.applyToolStripMenuItem.Text = "Apply";
            this.applyToolStripMenuItem.Click += new System.EventHandler(this.applyToolStripMenuItem_Click);
            // 
            // directorySearcher1
            // 
            this.directorySearcher1.ClientTimeout = System.TimeSpan.Parse("-00:00:01");
            this.directorySearcher1.ServerPageTimeLimit = System.TimeSpan.Parse("-00:00:01");
            this.directorySearcher1.ServerTimeLimit = System.TimeSpan.Parse("-00:00:01");
            // 
            // grdUsers
            // 
            this.grdUsers.AllowUserToDeleteRows = false;
            this.grdUsers.AllowUserToResizeRows = false;
            this.grdUsers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.grdUsers.BackgroundColor = System.Drawing.SystemColors.Control;
            this.grdUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdUsers.ContextMenuStrip = this.GridContextMenu;
            this.grdUsers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdUsers.Location = new System.Drawing.Point(0, 27);
            this.grdUsers.Name = "grdUsers";
            this.grdUsers.ShowRowErrors = false;
            this.grdUsers.Size = new System.Drawing.Size(899, 528);
            this.grdUsers.StandardTab = true;
            this.grdUsers.TabIndex = 1;
            this.grdUsers.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.grdUsers_CellFormatting);
            this.grdUsers.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdUsers_CellMouseEnter);
            // 
            // GridContextMenu
            // 
            this.GridContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteToolStripMenuItem,
            this.addToADToolStripMenuItem,
            this.copyInformationToolStripMenuItem});
            this.GridContextMenu.Name = "GridContextMenu";
            this.GridContextMenu.Size = new System.Drawing.Size(173, 70);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.deleteToolStripMenuItem.Text = "Delete and Backup";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // addToADToolStripMenuItem
            // 
            this.addToADToolStripMenuItem.Name = "addToADToolStripMenuItem";
            this.addToADToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.addToADToolStripMenuItem.Text = "Add to AD";
            this.addToADToolStripMenuItem.Click += new System.EventHandler(this.addToADToolStripMenuItem_Click);
            // 
            // copyInformationToolStripMenuItem
            // 
            this.copyInformationToolStripMenuItem.Name = "copyInformationToolStripMenuItem";
            this.copyInformationToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.copyInformationToolStripMenuItem.Text = "Copy Information";
            this.copyInformationToolStripMenuItem.Click += new System.EventHandler(this.copyInformationToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.progressBar,
            this.lblStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 533);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(899, 22);
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
            // backupOldUsersToolStripMenuItem
            // 
            this.backupOldUsersToolStripMenuItem.Name = "backupOldUsersToolStripMenuItem";
            this.backupOldUsersToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.backupOldUsersToolStripMenuItem.Text = "Backup Old Users";
            this.backupOldUsersToolStripMenuItem.Click += new System.EventHandler(this.backupOldUsersToolStripMenuItem_Click);
            // 
            // deleteBackupSelectedToolStripMenuItem
            // 
            this.deleteBackupSelectedToolStripMenuItem.Name = "deleteBackupSelectedToolStripMenuItem";
            this.deleteBackupSelectedToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.deleteBackupSelectedToolStripMenuItem.Text = "Delete/Backup Selected";
            this.deleteBackupSelectedToolStripMenuItem.Click += new System.EventHandler(this.deleteBackupSelectedToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(899, 555);
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
            this.GridContextMenu.ResumeLayout(false);
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
        private System.Windows.Forms.ContextMenuStrip GridContextMenu;
        private System.Windows.Forms.ToolStripMenuItem actionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem chooseOUToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBox1;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox2;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBox2;
        private System.Windows.Forms.ToolStripMenuItem applyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addAllToADToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addToADToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyInformationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem backupOldUsersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteBackupSelectedToolStripMenuItem;
    }
}

