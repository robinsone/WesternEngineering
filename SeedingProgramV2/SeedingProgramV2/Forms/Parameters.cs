using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SeedingProgramV2
{
    public partial class Parameters : Form
    {
       
        public ProgParams ProgParams = new ProgParams();

        public Parameters()
        {
            InitializeComponent();
        }

        public Parameters(SeedingProgramV2.ProgParams AppProgParams)
        {
            ProgParams = AppProgParams;
            txtConnectionString.Text = ProgParams.ServerConnectionString;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.ProgParams.Save();
            this.DialogResult = DialogResult.OK;
        }

        public ProgParams getParams()
        {
            return this.ProgParams;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void txtConnectionString_TextChanged(object sender, EventArgs e)
        {
            this.ProgParams.ServerConnectionString = txtConnectionString.Text;
        }

        private void txtSharedFolder_TextChanged(object sender, EventArgs e)
        {
            this.ProgParams.FolderPath = txtSharedFolder.Text;
        }

        private void Parameters_Load(object sender, EventArgs e)
        {
            ProgParams = this.ProgParams.Load();
            txtConnectionString.Text = ProgParams.ServerConnectionString;
            txtSharedFolder.Text = ProgParams.FolderPath;
            txtAdminPassword.Text = ProgParams.UserPassword;
            txtAdminAccount.Text = ProgParams.UserAccount;
        }

        private void txtAdminAccount_TextChanged(object sender, EventArgs e)
        {
            this.ProgParams.UserAccount = txtAdminAccount.Text;
        }

        private void txtAdminPassword_TextChanged(object sender, EventArgs e)
        {
            this.ProgParams.UserPassword = txtAdminPassword.Text;
        }

        private void txtBackupFolder_TextChanged(object sender, EventArgs e)
        {
            this.ProgParams.BackupFolder = txtBackupFolder.Text;
        }

        
    }
}
