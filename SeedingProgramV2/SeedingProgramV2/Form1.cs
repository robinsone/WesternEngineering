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
using System.Data.OleDb;
using System.DirectoryServices;
using System.Collections;

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
            progressBar.Style = ProgressBarStyle.Continuous;
            Users.Add(new ADUsers("erobin25", "Eric", "Robinson", "", "Undergrad", "erobin25@uwo.ca", "", "", "", "", true, false));
            Users.Add(new ADUsers("cpaquin2", "Chantal", "Robinson", "", "Undergrad", "erobin25@uwo.ca", "", "", "", "", true, false));
            Users.Add(new ADUsers("ckrik256", "Chris", "Kirk", "", "Grad", "erobin25@uwo.ca", "", "", "", "", true, false));
            Users.Add(new ADUsers("jdagget1", "James", "Dagget", "", "Undergrad", "erobin25@uwo.ca", "", "", "", "", true, false));

            GetActiveDirectoryStudents();
            ADUsers temp = Users.First(x => x.FirstName == "Eric");
            temp.ExistsInActiveDirectory = true;
            grdUsers.DataSource = Users;
            setRowAppearance();

        }

        private void GetActiveDirectoryStudents()
        {

            try
            {

                string DomainPath = "LDAP://192.168.0.111";
                DirectoryEntry searchRoot = new DirectoryEntry(DomainPath, "Administrator","4Sparta!");
                DirectorySearcher search = new DirectorySearcher(searchRoot);
                
                search.Filter = "(&(objectClass=user)(objectCategory=person))";
                //search.PropertiesToLoad.Add("samaccountname");
                //search.PropertiesToLoad.Add("mail"); //email
                //search.PropertiesToLoad.Add("usergroup");
                //search.PropertiesToLoad.Add("givenname");//first name
                //search.PropertiesToLoad.Add("lastname");//last name
                //search.PropertiesToLoad.Add("displayname");//full name
                //search.PropertiesToLoad.Add("userprinciplename"); //username
                //search.PropertiesToLoad.Add("profilepath");//first name
                //search.PropertiesToLoad.Add("homedirectory");//first name
                SearchResult result;
                SearchResultCollection resultCol = search.FindAll();
                if (resultCol != null)
                {
                    for (int counter = 0; counter < resultCol.Count; counter++)
                    {
                        string UserNameEmailString = string.Empty;
                        result = resultCol[counter];
                        if (result.Properties.Contains("samaccountname") && result.Properties.Contains("mail") && result.Properties.Contains("displayname"))
                        {
                            ADUsers objSurveyUsers = new ADUsers();
                            objSurveyUsers.Email = (String)result.Properties["mail"][0];
                            objSurveyUsers.FirstName = (String)result.Properties["givenname"][0];
                            objSurveyUsers.LastName = (String)result.Properties["cn"][0];
                            objSurveyUsers.MiddleName = (String)result.Properties["initials"][0];
                            objSurveyUsers.Username = (String)result.Properties["samaccountname"][0];
                            objSurveyUsers.ProfilePath = (String)result.Properties["profilepath"][0];
                            objSurveyUsers.HDrive = (String)result.Properties["homedirectory"][0];
                            objSurveyUsers.LastLogin =  result.Properties["lastlogon"][0].ToString();
                            objSurveyUsers.ExistsInActiveDirectory = true;
                            Users.Add(objSurveyUsers);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }
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

        public void SetStatusBarUpdateMethod(string msg, Color color)
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
                                user.Email = row[5] + "@uwo.ca";
                                user.ExistsInCSVFile = true;
                                user.Username = row[5];
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
