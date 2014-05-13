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
        private static @params _Params;

        public @params Params
        {
            get { return _Params; }
            set { _Params = value; }
        }

        public Parameters()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Params.ServerConnectionString = txtConnectionString.Text;

            
            this.DialogResult = DialogResult.OK;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
