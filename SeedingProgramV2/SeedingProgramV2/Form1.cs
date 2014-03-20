using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Timers;

namespace SeedingProgramV2
{
    public partial class Form1 : Form
    {
        private static SortableBindingList<ADUsers> Users = new SortableBindingList<ADUsers>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            Users.Add(new ADUsers("erobin25", "Eric", "Robinson", "", "Undergrad", "erobin25@uwo.ca", "", "", "", "", true, false));
            Users.Add(new ADUsers("cpaquin2", "Chantal", "Robinson", "", "Undergrad", "erobin25@uwo.ca", "", "", "", "", true, false));
            Users.Add(new ADUsers("ckrik256", "Chris", "Kirk", "", "Grad", "erobin25@uwo.ca", "", "", "", "", true, false));
            Users.Add(new ADUsers("jdagget1", "James", "Dagget", "", "Undergrad", "erobin25@uwo.ca", "", "", "", "", true, false));
            Users.Add(new ADUsers("dexodus4", "Draktyr", "Exodus", "", "Grad", "erobin25@uwo.ca", "", "", "", "", false, true));
            ADUsers temp = Users.First(x => x.FirstName == "Eric");
            ADUsers temp2 = Users.First(x => x.FirstName == "Draktyr");
            temp.ExistsInActiveDirectory = true;
            temp2.ExistsInCSVFile = true;
            grdUsers.DataSource = Users;
            setRowAppearance();

        }

        private void RebindDataSource()
        {
            grdUsers.DataSource = "";
            grdUsers.DataSource = Users;
            setRowAppearance();
        }

        private void setRowAppearance()
        {
            foreach (DataGridViewRow row in grdUsers.Rows)
            {
                ADUsers temp = (ADUsers)row.DataBoundItem;
                if (temp != null)
                {
                    if (temp.ExistsInActiveDirectory)
                    {
                        row.DefaultCellStyle.BackColor = Color.Purple;
                        row.DefaultCellStyle.ForeColor = Color.White;
                    }

                    if (temp.ExistsInCSVFile)
                    {
                        row.DefaultCellStyle.BackColor = Color.LightGray;
                        row.DefaultCellStyle.ForeColor = Color.Black;
                    }
                }

            }

        }

        private void refreshGridToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RebindDataSource();
        }

        private void gradsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem mi = (ToolStripMenuItem)sender;
            CurrencyManager currencyManager1 = (CurrencyManager)BindingContext[grdUsers.DataSource];
            currencyManager1.SuspendBinding();
            if (mi.Checked)
            {
                foreach (DataGridViewRow row in grdUsers.Rows)
                {
                    ADUsers temp = (ADUsers)row.DataBoundItem;
                    if (temp != null)
                    {
                        if (temp.Grad.ToLower() == "grad")
                        {
                            row.Visible = true;
                        }
                    }
                }
            }
            else
            {
                foreach (DataGridViewRow row in grdUsers.Rows)
                {
                    ADUsers temp = (ADUsers)row.DataBoundItem;
                    if (temp != null)
                    {
                        if (temp.Grad.ToLower() == "grad")
                        {
                            row.Visible = false;
                        }
                    }
                }
            }
            currencyManager1.ResumeBinding();
        }

        private void undergradsToolStripMenuItem_Click(object sender, EventArgs e)
        {

            ToolStripMenuItem mi = (ToolStripMenuItem)sender;
            CurrencyManager currencyManager1 = (CurrencyManager)BindingContext[grdUsers.DataSource];
            currencyManager1.SuspendBinding();
            if (mi.Checked)
            {

                foreach (DataGridViewRow row in grdUsers.Rows)
                {
                    ADUsers temp = (ADUsers)row.DataBoundItem;
                    if (temp != null)
                    {
                        if (temp.Grad.ToLower() == "undergrad")
                        {

                            row.Visible = true;


                        }
                    }
                }
            }
            else
            {
                foreach (DataGridViewRow row in grdUsers.Rows)
                {
                    ADUsers temp = (ADUsers)row.DataBoundItem;
                    if (temp != null)
                    {
                        if (temp.Grad.ToLower() == "undergrad")
                        {
                            row.Visible = false;
                        }
                    }
                }
            }
            currencyManager1.ResumeBinding();
        }

        private void activeDirectoryUsersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem mi = (ToolStripMenuItem)sender;
            CurrencyManager currencyManager1 = (CurrencyManager)BindingContext[grdUsers.DataSource];
            currencyManager1.SuspendBinding();
            if (mi.Checked)
            {

                foreach (DataGridViewRow row in grdUsers.Rows)
                {
                    ADUsers temp = (ADUsers)row.DataBoundItem;
                    if (temp != null)
                    {
                        if (temp.ExistsInActiveDirectory)
                        {

                            row.Visible = true;


                        }
                    }
                }
            }
            else
            {
                foreach (DataGridViewRow row in grdUsers.Rows)
                {
                    ADUsers temp = (ADUsers)row.DataBoundItem;
                    if (temp != null)
                    {
                        if (temp.ExistsInActiveDirectory)
                        {
                            row.Visible = false;
                        }
                    }
                }
            }
            currencyManager1.ResumeBinding();
        }

        private void cSVUsersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem mi = (ToolStripMenuItem)sender;
            CurrencyManager currencyManager1 = (CurrencyManager)BindingContext[grdUsers.DataSource];
            currencyManager1.SuspendBinding();
            if (mi.Checked)
            {

                foreach (DataGridViewRow row in grdUsers.Rows)
                {
                    ADUsers temp = (ADUsers)row.DataBoundItem;
                    if (temp != null)
                    {
                        if (temp.ExistsInCSVFile)
                        {

                            row.Visible = true;


                        }
                    }
                }
            }
            else
            {
                foreach (DataGridViewRow row in grdUsers.Rows)
                {
                    ADUsers temp = (ADUsers)row.DataBoundItem;
                    if (temp != null)
                    {
                        if (temp.ExistsInCSVFile)
                        {
                            row.Visible = false;
                        }
                    }
                }
            }
            currencyManager1.ResumeBinding();
        }

        delegate void SetStatusBarUpdate(string msg, Color color);

        public void SetStatusBarUpdateMethod(string msg,Color color)
        {
            lblStatus.Text = msg;
            statusStrip1.BackColor = color;
        }


        private void StatusBarUpdate(string statusText, Color color)
        {
            //Parallel.Invoke(() =>
            //    {
            //        this.Invoke(new SetStatusBarUpdate(SetStatusBarUpdateMethod), new object { statusText, color });
            //        var aTimer = new System.Timers.Timer(5000);
            //        aTimer.Elapsed += new ElapsedEventHandler((object source, ElapsedEventArgs e) =>
            //            {
            //                this.Invoke(new SetStatusBarUpdate(SetStatusBarUpdateMethod), new object { "", Color.LightGray });
            //            });
            //        aTimer.Enabled = true;
            //    }); //close parallel.invoke


        }


        private void uploadCSVFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Show the dialog and get result.
            OpenFileDialog openfile = new OpenFileDialog();
            DialogResult result = (openfile.ShowDialog());
            if (result == DialogResult.OK) // Test result.
            {

                FileInfo file = new FileInfo(openfile.FileName);
                if (file.Extension == ".csv")
                {
                    try
                    {
                        using (StreamReader readFile = new StreamReader(file.FullName))
                        {
                            string line;
                            string[] row;
                            int i = 0;
                            while ((line = readFile.ReadLine()) != null)
                            {
                                if (i == 0)
                                {
                                    i++;
                                    continue;
                                }

                                row = line.Split(',');
                                //output.AppendText(line + "\n");
                                ADUsers user = new ADUsers();
                                user.Password = row[0];
                                user.Grad = row[1];
                                user.LastName = row[2];
                                user.FirstName = row[3];
                                user.MiddleName = row[4];
                                user.Email = row[5];
                                user.ExistsInCSVFile = true;
                                user.Username = row[5].Substring(0, row[5].IndexOf("@"));
                                Users.Add(user);
                                //parsedData.Add(row);
                            }
                        }
                    }
                    catch (Exception es)
                    {
                        MessageBox.Show(es.Message);
                    }
                }
                else
                {
                    StatusBarUpdate("Incorrect file type.", Color.Red);
                }
            }
            RebindDataSource();
        }

    }
}
