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
using System.Security.AccessControl;
using System.DirectoryServices.AccountManagement;
using System.Security.Principal;
using System.Reflection;
using JDStuart.DirectoryUtils;

namespace SeedingProgramV2
{
    public partial class MainApp : Form
    {
        private static SortableBindingList<ADUsers> Users = new SortableBindingList<ADUsers>();
        private static DirectoryInfo[] folders;
        private static ProgParams ProgParams = new ProgParams();

        public MainApp()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void loadProgParams()
        {
            ProgParams = ProgParams.Load();
            if (!ProgParams.IsSet)
            {
                Parameters frmParams = new Parameters();
                frmParams.ShowDialog();
                if (frmParams.DialogResult == DialogResult.OK)
                {
                    ProgParams = frmParams.getParams();
                }
            }
            
        }

        private void setContextMeny()
        {

        }

        private void AddColumns()
        {



            DataGridViewTextBoxColumn idColumn = new DataGridViewTextBoxColumn();
            idColumn.Name = "User Name";
            idColumn.DataPropertyName = "username";
            idColumn.ReadOnly = true;

            grdUsers.Columns.Add(idColumn);

            idColumn = new DataGridViewTextBoxColumn();
            idColumn.Name = "FirstName";
            idColumn.DataPropertyName = "FirstName";
            idColumn.ReadOnly = true;

            grdUsers.Columns.Add(idColumn);

            idColumn = new DataGridViewTextBoxColumn();
            idColumn.Name = "Middle Name";
            idColumn.DataPropertyName = "middleName";
            idColumn.ReadOnly = true;

            grdUsers.Columns.Add(idColumn);

            idColumn = new DataGridViewTextBoxColumn();
            idColumn.Name = "Last Name";
            idColumn.DataPropertyName = "Lastname";
            idColumn.ReadOnly = true;

            grdUsers.Columns.Add(idColumn);
            idColumn = new DataGridViewTextBoxColumn();
            idColumn.Name = "Email";
            idColumn.DataPropertyName = "Email";
            idColumn.ReadOnly = true;

            grdUsers.Columns.Add(idColumn);

            idColumn = new DataGridViewTextBoxColumn();
            idColumn.Name = "Grad";
            idColumn.DataPropertyName = "grad";
            idColumn.ReadOnly = true;

            grdUsers.Columns.Add(idColumn);

            idColumn = new DataGridViewTextBoxColumn();
            idColumn.Name = "Password";
            idColumn.DataPropertyName = "password";
            idColumn.ReadOnly = true;

            grdUsers.Columns.Add(idColumn);



            idColumn = new DataGridViewTextBoxColumn();
            idColumn.Name = "Profile Path";
            idColumn.DataPropertyName = "profilepath";
            idColumn.ReadOnly = true;

            grdUsers.Columns.Add(idColumn);

            idColumn = new DataGridViewTextBoxColumn();
            idColumn.Name = "H: Drive";
            idColumn.DataPropertyName = "hdrive";
            idColumn.ReadOnly = true;

            grdUsers.Columns.Add(idColumn);

            idColumn = new DataGridViewTextBoxColumn();
            idColumn.Name = "Last Logged";
            idColumn.DataPropertyName = "lastLogin";
            idColumn.ReadOnly = true;

            grdUsers.Columns.Add(idColumn);

            grdUsers.AutoResizeColumns();


        }

        private void GetActiveDirectoryOUs()
        {
            try
            {
                List<OU> grad = new List<OU>();
                List<OU> ugrad = new List<OU>();

                string DomainPath = "LDAP:// " + ProgParams.ServerConnectionString;
                DirectoryEntry searchRoot = new DirectoryEntry(DomainPath, ProgParams.UserAccount, ProgParams.UserPassword);
                DirectorySearcher search = new DirectorySearcher(searchRoot);

                search.Filter = "(objectCategory=organizationalUnit)";
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
                        result = resultCol[counter];
                        if (result.Path.Contains("ugrad") && result.Path.Contains("group"))
                        {
                            ugrad.Add(new OU((string)result.Properties["name"][0], result.Path));
                        }

                        else if (result.Path.Contains("grad") && result.Path.Contains("group"))
                        {
                            grad.Add(new OU((string)result.Properties["name"][0], result.Path));
                        }
                    }
                }

                if (grad.Count > 0 && ugrad.Count > 0)
                {
                    toolStripComboBox1.ComboBox.DataSource = grad;
                    toolStripComboBox1.ComboBox.DisplayMember = "name";

                    toolStripComboBox2.ComboBox.DataSource = ugrad;
                    toolStripComboBox2.ComboBox.DisplayMember = "name";
                }
            }
            catch (IOException)
            {
                MessageBox.Show("Could not receive the active directory users from server. Please make sure server is accessible from from this computer.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not receive the active directory users from server. Please make sure server is accessible from from this computer.");
            }
        }

        private void GetActiveDirectoryStudents()
        {

            try
            {

                string DomainPath = "LDAP:// " + ProgParams.ServerConnectionString;
                DirectoryEntry searchRoot = new DirectoryEntry(DomainPath, ProgParams.UserAccount, ProgParams.UserPassword);
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
                        if (result.Properties.Contains("samaccountname") && result.Properties.Contains("mail")
                            && result.Path.Contains("students"))
                        {
                            ADUsers objSurveyUsers = new ADUsers();
                            objSurveyUsers.Path = (string)result.Path;
                            objSurveyUsers.Sid = (byte[])result.Properties["objectSid"][0];
                            objSurveyUsers.Email = (String)result.Properties["mail"][0];
                            objSurveyUsers.FirstName = (String)result.Properties["givenname"][0];
                            objSurveyUsers.LastName = (String)result.Properties["sn"][0];
                            if (result.Properties.Contains("initials")) { objSurveyUsers.MiddleName = (String)result.Properties["initials"][0]; }
                            objSurveyUsers.Username = (String)result.Properties["samaccountname"][0];
                            objSurveyUsers.ProfilePath = (String)result.Properties["profilepath"][0];
                            objSurveyUsers.HDrive = (String)result.Properties["homedirectory"][0];
                            objSurveyUsers.LastLogin = DateTime.FromFileTime(Convert.ToInt64(result.Properties["lastlogon"][0].ToString()));
                            if (result.Path.Contains("ugrad"))
                            {
                                objSurveyUsers.Grad = "UGRD";
                            }
                            else
                            {
                                objSurveyUsers.Grad = "GRAD";
                            }
                            objSurveyUsers.ExistsInActiveDirectory = true;
                            if (objSurveyUsers != null)
                            {
                                Users.Add(objSurveyUsers);
                            }
                        }
                    }
                }
            }
            catch (IOException)
            {
                MessageBox.Show("Could not receive the active directory users from server. Please make sure server is accessible from from this computer.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not receive the active directory users from server. Please make sure server is accessible from from this computer.");

            }
        }

        private void RebindDataSource()
        {
            grdUsers.DataSource = "";
            grdUsers.DataSource = Users;
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
            if (Users.Count <= 0) { Users = new SortableBindingList<ADUsers>(); }

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

                                ADUsers alreadyexists = Users.FirstOrDefault<ADUsers>(x => x.Username == row[5]);
                                if (alreadyexists != null)
                                {
                                    Users.First<ADUsers>(x => x.Username == row[5]).ExistsInCSVFile = true;
                                }
                                else
                                {

                                    //output.AppendText(line + "\n");
                                    ADUsers user = new ADUsers();
                                    user.Password = row[0];
                                    user.Grad = row[1];
                                    user.LastName = row[2];
                                    user.FirstName = row[3];
                                    user.MiddleName = row[4];
                                    if (user.MiddleName.Length >= 6)
                                    {
                                        user.MiddleName = user.MiddleName.Substring(0, 1);
                                    }
                                    user.Email = row[5] + "@uwo.ca";
                                    user.ExistsInCSVFile = true;
                                    user.Username = row[5];
                                    Users.Add(user);
                                }
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

        private void applyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OU ugradOU = (OU)toolStripComboBox2.ComboBox.SelectedItem;
            OU gradOU = (OU)toolStripComboBox1.ComboBox.SelectedItem;
            foreach (ADUsers user in Users)
            {
                if (!user.ExistsInActiveDirectory)
                {
                    if (user.Grad == "UGRD")
                    {
                        int num = Convert.ToInt32(ugradOU.Name.Substring(5, ugradOU.Name.ToString().Length - 5));
                        user.HDrive = System.IO.Path.Combine(folders.First(x => x.FullName.Contains("es" + num.ToString())).FullName, "h");
                        user.HDrive = Path.Combine(user.HDrive, user.Username);
                        user.ProfilePath = System.IO.Path.Combine(folders.First(x => x.FullName.Contains("es" + num.ToString())).FullName, "p");
                        user.ProfilePath = Path.Combine(user.ProfilePath, user.Username);
                        user.Path = ugradOU.Path;
                        //user.ProfilePath = folders.First<DirectoryInfo>(x => x.FullName.Contains("es" + )) 
                    }
                    else
                    {
                        int num = Convert.ToInt32(gradOU.Name.Substring(5, gradOU.Name.ToString().Length - 5));
                        num = num + 30;
                        user.HDrive = System.IO.Path.Combine(folders.First(x => x.FullName.Contains("es" + num.ToString())).FullName, "h");
                        user.HDrive = Path.Combine(user.HDrive, user.Username);
                        user.ProfilePath = System.IO.Path.Combine(folders.First(x => x.FullName.Contains("es" + num.ToString())).FullName, "p");
                        user.ProfilePath = Path.Combine(user.ProfilePath, user.Username);
                        user.Path = gradOU.Path;
                    }
                }
            }

            RebindDataSource();
        }

        private void getSharedFolder()
        {
            //'System.IO.IOException' 
            try
            {
                UserImpersonation impersonator = new UserImpersonation();
                impersonator.impersonateUser(ProgParams.UserAccount, "", ProgParams.UserPassword); //No Domain is required


                DirectoryInfo directory = new DirectoryInfo(ProgParams.FolderPath);

                folders = directory.GetDirectories();
                impersonator.undoimpersonateUser();
            }
            catch (IOException)
            {
                MessageBox.Show("Could not receive the shared folders from server. Please make sure server is accessible from from this computer.");
            }
        }

        private void addPsHs()
        {
            UserImpersonation impersonator = new UserImpersonation();
            impersonator.impersonateUser(ProgParams.UserAccount, "", ProgParams.UserPassword); //No Domain is required


            DirectoryInfo directory = new DirectoryInfo(ProgParams.FolderPath);

            folders = directory.GetDirectories();

            foreach (DirectoryInfo folder in folders)
            {
                string h = System.IO.Path.Combine(folder.FullName, "h");
                string p = System.IO.Path.Combine(folder.FullName, "p");
                System.IO.Directory.CreateDirectory(p);
                System.IO.Directory.CreateDirectory(h);
            }
            impersonator.undoimpersonateUser();
        }

        private void grdUsers_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Example - Row formatting
            if (e.ColumnIndex == 0) // so this only runs once per row formatting
            {
                DataGridViewRow row = grdUsers.Rows[e.RowIndex];
                ADUsers temp = (ADUsers)grdUsers.Rows[e.RowIndex].DataBoundItem;
                if (temp != null)
                {
                    if (temp.ExistsInActiveDirectory)
                    {
                        row.DefaultCellStyle.BackColor = Color.Purple;
                        row.DefaultCellStyle.ForeColor = Color.White;
                    }

                    else if (temp.ExistsInCSVFile)
                    {
                        row.DefaultCellStyle.BackColor = Color.LightGray;
                        row.DefaultCellStyle.ForeColor = Color.Black;
                    }
                }
            }
        }

        private delegate void SomeFunctionDelegate();
        private SomeFunctionDelegate sfd;

        private void chooseOUToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sfd = new SomeFunctionDelegate(this.AddUsersAsync);
            sfd.BeginInvoke(null, null);
        }

        private void AddUsersAsync()
        {
            try
            {
                UserImpersonation impersonator = new UserImpersonation();
                impersonator.impersonateUser(ProgParams.UserAccount, "", ProgParams.UserPassword); //No Domain is required
                foreach (DataGridViewRow row in grdUsers.SelectedRows)
                {

                    ADUsers user = (ADUsers)row.DataBoundItem;
                    if (!user.ExistsInActiveDirectory)
                    {
                        if (user.ProfilePath != null && user.HDrive != null)
                        {
                            DirectoryEntry dirEntry = new DirectoryEntry(user.Path);
                            DirectoryEntry newUser = dirEntry.Children.Add("CN=" + user.Username, "user");
                            newUser.Properties["samAccountName"].Value = user.Username;
                            newUser.Properties["userprincipalname"].Value = user.Username + "@eng.western";
                            newUser.Properties["mail"].Value = user.Email;
                            newUser.Properties["givenname"].Value = user.FirstName;
                            newUser.Properties["sn"].Value = user.LastName;
                            newUser.Properties["initials"].Value = user.MiddleName;
                            newUser.Properties["profilepath"].Value = user.ProfilePath;
                            newUser.Properties["homedirectory"].Value = user.HDrive;
                            newUser.Properties["homeDrive"].Value = "H:";
                            newUser.Properties["displayname"].Value = user.FirstName + " " + user.LastName;
                            //newUser.Properties["name"].Value = user.FirstName + " " + user.MiddleName + " " + user.LastName;
                            newUser.Properties["scriptPath"].Value = "login.bat";

                            newUser.CommitChanges();
                            string oGUID = newUser.Guid.ToString();

                            newUser.Invoke("SetPassword", new object[] { user.Password });
                            newUser.Properties["pwdLastSet"].Value = "0";
                            newUser.Properties["displayname"].Value = user.FirstName + " " + user.LastName;
                            int val = (int)newUser.Properties["userAccountControl"].Value;
                            newUser.Properties["userAccountControl"].Value = val & ~0x2; //enable account
                            newUser.CommitChanges();
                            dirEntry.Close();
                            newUser.Close();
                            user.Sid = (byte[])newUser.Properties["objectSid"][0];
                            user.ExistsInActiveDirectory = true;
                            SetFolders(user);

                            row.Selected = false;
                        }
                        else
                        {
                            MessageBox.Show("Please set OU group for user");
                        }
                    }

                }


                MessageBox.Show("Users added to active directory successfully.");
                impersonator.undoimpersonateUser();
            }
            catch (System.DirectoryServices.DirectoryServicesCOMException E)
            {
                //DoSomethingwith --> E.Message.ToString();

            }
        }

        private void AddAllUsersAsync()
        {
            try
            {
                UserImpersonation impersonator = new UserImpersonation();
                impersonator.impersonateUser(ProgParams.UserAccount, "", ProgParams.UserPassword); //No Domain is required
                foreach (DataGridViewRow row in grdUsers.Rows)
                {

                    ADUsers user = (ADUsers)row.DataBoundItem;
                    if (user != null)
                    {
                        if (!user.ExistsInActiveDirectory)
                        {
                            if (user.ProfilePath != null && user.HDrive != null)
                            {
                                DirectoryEntry dirEntry = new DirectoryEntry(user.Path);
                                DirectoryEntry newUser = dirEntry.Children.Add("CN=" + user.Username, "user");
                                newUser.Properties["samAccountName"].Value = user.Username;
                                newUser.Properties["userprincipalname"].Value = user.Username + "@eng.western";
                                newUser.Properties["mail"].Value = user.Email;
                                newUser.Properties["givenname"].Value = user.FirstName;
                                newUser.Properties["sn"].Value = user.LastName;
                                newUser.Properties["initials"].Value = user.MiddleName;
                                newUser.Properties["profilepath"].Value = user.ProfilePath;
                                newUser.Properties["homedirectory"].Value = user.HDrive;
                                newUser.Properties["homeDrive"].Value = "H:";
                                newUser.Properties["displayname"].Value = user.FirstName + " " + user.LastName;
                                //newUser.Properties["name"].Value = user.FirstName + " " + user.MiddleName + " " + user.LastName;
                                newUser.Properties["scriptPath"].Value = "login.bat";

                                newUser.CommitChanges();
                                string oGUID = newUser.Guid.ToString();

                                newUser.Invoke("SetPassword", new object[] { user.Password });
                                newUser.Properties["pwdLastSet"].Value = "0";
                                newUser.Properties["displayname"].Value = user.FirstName + " " + user.LastName;
                                int val = (int)newUser.Properties["userAccountControl"].Value;
                                newUser.Properties["userAccountControl"].Value = val & ~0x2; //enable account
                                newUser.CommitChanges();
                                dirEntry.Close();
                                newUser.Close();
                                user.Sid = (byte[])newUser.Properties["objectSid"][0];
                                user.ExistsInActiveDirectory = true;
                                SetFolders(user);

                                row.Selected = false;
                            }
                            else
                            {
                                MessageBox.Show("Please set OU group for user");
                            }
                        }
                    }

                }


                MessageBox.Show("Users added to active directory successfully.");
                impersonator.undoimpersonateUser();
            }
            catch (System.DirectoryServices.DirectoryServicesCOMException E)
            {
                //DoSomethingwith --> E.Message.ToString();

            }
        }

        private void SetFolders(ADUsers user)
        {
            UserImpersonation impersonator = new UserImpersonation();
            impersonator.impersonateUser(ProgParams.UserAccount, "", ProgParams.UserPassword); //No Domain is required

            System.IO.Directory.CreateDirectory(user.HDrive);

            if (System.IO.Directory.Exists(user.HDrive))
            {

                DirectoryInfo diClientDirectory = new DirectoryInfo(user.HDrive);
                DirectorySecurity dsClientDirectory = diClientDirectory.GetAccessControl();
                SecurityIdentifier si = new SecurityIdentifier(user.Sid, 0);
                dsClientDirectory.AddAccessRule(new FileSystemAccessRule(si,
                    FileSystemRights.FullControl,
                    InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit,
                    PropagationFlags.None,
                    AccessControlType.Allow));
                diClientDirectory.SetAccessControl(dsClientDirectory);

            }

            System.IO.Directory.CreateDirectory(user.ProfilePath);
            if (System.IO.Directory.Exists(user.ProfilePath))
            {

                DirectoryInfo diClientDirectory = new DirectoryInfo(user.ProfilePath);
                DirectorySecurity dsClientDirectory = diClientDirectory.GetAccessControl();
                SecurityIdentifier si = new SecurityIdentifier(user.Sid, 0);
                dsClientDirectory.AddAccessRule(new FileSystemAccessRule(si,
                    FileSystemRights.FullControl,
                    InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit,
                    PropagationFlags.None,
                    AccessControlType.Allow));
                diClientDirectory.SetAccessControl(dsClientDirectory);

            }

            System.IO.Directory.CreateDirectory(user.ProfilePath + ".V2");
            if (System.IO.Directory.Exists(user.ProfilePath + ".V2"))
            {

                DirectoryInfo diClientDirectory = new DirectoryInfo(user.ProfilePath + ".V2");
                DirectorySecurity dsClientDirectory = diClientDirectory.GetAccessControl();
                SecurityIdentifier si = new SecurityIdentifier(user.Sid, 0);
                dsClientDirectory.AddAccessRule(new FileSystemAccessRule(si,
                    FileSystemRights.FullControl,
                    InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit,
                    PropagationFlags.None,
                    AccessControlType.Allow));
                diClientDirectory.SetAccessControl(dsClientDirectory);

            }

            impersonator.undoimpersonateUser();

        }

        private void addAllToADToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sfd = new SomeFunctionDelegate(this.AddAllUsersAsync);
            sfd.BeginInvoke(null, null);
        }

        private DataGridViewCellEventArgs mouseLocation;
        private void grdUsers_CellMouseEnter(object sender, DataGridViewCellEventArgs location)
        {
            mouseLocation = location;
        }

        private void addToADToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ADUsers user = (ADUsers)grdUsers.Rows[mouseLocation.RowIndex].DataBoundItem;
            UserImpersonation impersonator = new UserImpersonation();
            impersonator.impersonateUser(ProgParams.UserAccount, "", ProgParams.UserPassword); //No Domain is required
            if (!user.ExistsInActiveDirectory)
            {
                if (user.ProfilePath != null && user.HDrive != null)
                {
                    DirectoryEntry dirEntry = new DirectoryEntry(user.Path);
                    DirectoryEntry newUser = dirEntry.Children.Add("CN=" + user.Username, "user");
                    newUser.Properties["samAccountName"].Value = user.Username;
                    newUser.Properties["userprincipalname"].Value = user.Username + "@eng.western";
                    newUser.Properties["mail"].Value = user.Email;
                    newUser.Properties["givenname"].Value = user.FirstName;
                    newUser.Properties["sn"].Value = user.LastName;
                    newUser.Properties["initials"].Value = user.MiddleName;
                    newUser.Properties["profilepath"].Value = user.ProfilePath;
                    newUser.Properties["homedirectory"].Value = user.HDrive;
                    newUser.Properties["homeDrive"].Value = "H:";
                    newUser.Properties["displayname"].Value = user.FirstName + " " + user.LastName;
                    //newUser.Properties["name"].Value = user.FirstName + " " + user.MiddleName + " " + user.LastName;
                    newUser.Properties["scriptPath"].Value = "login.bat";

                    newUser.CommitChanges();
                    string oGUID = newUser.Guid.ToString();

                    newUser.Invoke("SetPassword", new object[] { user.Password });
                    newUser.Properties["pwdLastSet"].Value = "0";
                    newUser.Properties["displayname"].Value = user.FirstName + " " + user.LastName;
                    int val = (int)newUser.Properties["userAccountControl"].Value;
                    newUser.Properties["userAccountControl"].Value = val & ~0x2; //enable account
                    newUser.CommitChanges();
                    dirEntry.Close();
                    newUser.Close();
                    user.Sid = (byte[])newUser.Properties["objectSid"][0];
                    user.ExistsInActiveDirectory = true;
                    SetFolders(user);


                }
                else
                {
                    MessageBox.Show("Please set OU group for user");
                }
            }
            impersonator.undoimpersonateUser();

        }

        private void copyInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ADUsers user = (ADUsers)grdUsers.Rows[mouseLocation.RowIndex].DataBoundItem;
            string output = user.Username + ", " +
                user.FirstName + ", " +
                user.MiddleName + ", " +
                user.LastName + ", " +
                user.Email + ", " +
                user.Grad + ", " +
                user.ProfilePath + ", " +
                user.HDrive;
            Clipboard.SetText(output);

        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ADUsers user = (ADUsers)grdUsers.Rows[mouseLocation.RowIndex].DataBoundItem;
            UserImpersonation impersonator = new UserImpersonation();
            impersonator.impersonateUser(ProgParams.UserAccount, "", ProgParams.UserPassword); //No Domain is required
            if (user.ExistsInActiveDirectory)
            {
                if (user.ProfilePath != null && user.HDrive != null)
                {
                    string DomainPath = "LDAP:// " + ProgParams.ServerConnectionString;
                    DirectoryEntry searchRoot = new DirectoryEntry(DomainPath, ProgParams.UserAccount, ProgParams.UserPassword);
                    DirectorySearcher search = new DirectorySearcher(searchRoot);

                    search.Filter = "(&(objectClass=user)(objectCategory=person)(CN=" + user.Username + "))";
                    SearchResult result;
                    SearchResultCollection resultCol = search.FindAll();
                    if (resultCol != null)
                    {
                        for (int counter = 0; counter < resultCol.Count; counter++)
                        {
                            string UserNameEmailString = string.Empty;
                            result = resultCol[counter];
                            if (result != null)
                            {
                                if (result.Properties.Contains("samaccountname") && result.Properties.Contains("mail") && result.Path.Contains("students"))
                                {
                                    string parentOU = user.Path.Replace("CN=" + user.Username + ",", "");
                                    DirectoryEntry de = new DirectoryEntry(parentOU);
                                    de.Children.Remove(result.GetDirectoryEntry());
                                    searchRoot.CommitChanges();
                                    moveFolderToBackup(user);
                                    Users.Remove(user);
                                    grdUsers.Refresh();
                                }
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please set OU group for user");
                }
            }
            impersonator.undoimpersonateUser();
        }

        private void moveFolderToBackup(ADUsers user)
        {
            UserImpersonation impersonator = new UserImpersonation();
            impersonator.impersonateUser(ProgParams.UserAccount, "", ProgParams.UserPassword);//No Domain is required
            try
            {

                string dest = @"\\192.168.0.111\backups\" + user.Username;
                System.IO.Directory.CreateDirectory(dest);
                System.IO.Directory.CreateDirectory(dest + "\\HDrive");
                System.IO.Directory.CreateDirectory(dest + "\\Profile");
                System.IO.Directory.CreateDirectory(dest + "\\ProfileV2");
                //System.IO.Directory.Move(user.HDrive, dest);

                //System.IO.Directory.CreateDirectory(destDirName);

                DirectoryInfo sourceDir = new DirectoryInfo(user.HDrive);
                DirectoryInfo destDir = new DirectoryInfo(dest + "\\HDrive");

                //Copy the files in the current directory.
                FileInfo[] files = sourceDir.GetFiles();
                foreach (FileInfo file in files)
                {
                    string newPath = Path.Combine(dest + "\\HDrive", file.Name);
                    file.CopyTo(newPath);
                }

                //Copy all sub directories.
                DirectoryInfo[] subDirs = sourceDir.GetDirectories();
                foreach (DirectoryInfo subDir in subDirs)
                {
                    string newPath = Path.Combine(dest + "\\HDrive", subDir.Name);
                    JDStuart.DirectoryUtils.Directory.Move(subDir.FullName, newPath);
                }

                System.IO.Directory.Delete(user.HDrive, true);



                sourceDir = new DirectoryInfo(user.ProfilePath);
                destDir = new DirectoryInfo(dest + "\\Profile");
                //Copy the files in the current directory.
                files = sourceDir.GetFiles();
                foreach (FileInfo file in files)
                {
                    string newPath = Path.Combine(dest + "\\Profile", file.Name);
                    file.CopyTo(newPath);
                }

                //Copy all sub directories.
                subDirs = sourceDir.GetDirectories();
                foreach (DirectoryInfo subDir in subDirs)
                {
                    string newPath = Path.Combine(dest + "\\Profile", subDir.Name);
                    JDStuart.DirectoryUtils.Directory.Move(subDir.FullName, newPath);
                }

                System.IO.Directory.Delete(user.ProfilePath, true);

                sourceDir = new DirectoryInfo(user.ProfilePath + ".V2");
                destDir = new DirectoryInfo(dest + "\\ProfileV2");

                //Copy the files in the current directory.
                files = sourceDir.GetFiles();
                foreach (FileInfo file in files)
                {
                    string newPath = Path.Combine(dest + "\\ProfileV2", file.Name);
                    file.CopyTo(newPath);
                }

                //Copy all sub directories.
                subDirs = sourceDir.GetDirectories();
                foreach (DirectoryInfo subDir in subDirs)
                {
                    string newPath = Path.Combine(dest + "\\ProfileV2", subDir.Name);
                    JDStuart.DirectoryUtils.Directory.Move(subDir.FullName, newPath);
                }

                System.IO.Directory.Delete(user.ProfilePath + ".V2", true);

                //System.IO.Directory.Move(user.ProfilePath, dest);
                //System.IO.Directory.Move(user.ProfilePath + ".V2", dest);
            }
            catch (Exception) { }
            impersonator.undoimpersonateUser();

        }

        private void backupOldUsersToolStripMenuItem_Click(object sender, EventArgs e)
        {

            UserImpersonation impersonator = new UserImpersonation();
            impersonator.impersonateUser(ProgParams.UserAccount, "", ProgParams.UserPassword); //No Domain is required
            foreach (DataGridViewRow row in grdUsers.Rows)
            {
                ADUsers user = (ADUsers)row.DataBoundItem;
                //string readableLastLogon = DateTime.FromFileTime(Convert.ToInt64(user.LastLogin)).ToString();
                if (user != null)
                {
                    int months = Math.Abs((DateTime.Now.Month - user.LastLogin.Month) + 12 * (DateTime.Now.Year - user.LastLogin.Year));
                    if (months >= 18 && months <= 4000)
                    {
                        if (user.ExistsInActiveDirectory)
                        {
                            if (user.ProfilePath != null && user.HDrive != null)
                            {
                                string DomainPath = "LDAP:// " + ProgParams.ServerConnectionString;
                                DirectoryEntry searchRoot = new DirectoryEntry(DomainPath, ProgParams.UserAccount, ProgParams.UserPassword);
                                DirectorySearcher search = new DirectorySearcher(searchRoot);

                                search.Filter = "(&(objectClass=user)(objectCategory=person)(CN=" + user.Username + "))";
                                SearchResult result;
                                SearchResultCollection resultCol = search.FindAll();
                                if (resultCol != null)
                                {
                                    for (int counter = 0; counter < resultCol.Count; counter++)
                                    {
                                        string UserNameEmailString = string.Empty;
                                        result = resultCol[counter];
                                        if (result.Properties.Contains("samaccountname") && result.Properties.Contains("mail") && result.Path.Contains("students"))
                                        {
                                            string parentOU = user.Path.Replace("CN=" + user.Username + ",", "");
                                            DirectoryEntry de = new DirectoryEntry(parentOU);
                                            de.Children.Remove(result.GetDirectoryEntry());
                                            searchRoot.CommitChanges();
                                            moveFolderToBackup(user);
                                            Users.Remove(user);

                                        }
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("Please set OU group for user");
                            }

                        }
                    }
                }
            }
            grdUsers.Refresh();
            impersonator.undoimpersonateUser();
        }

        private void deleteBackupSelectedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserImpersonation impersonator = new UserImpersonation();
            impersonator.impersonateUser(ProgParams.UserAccount, "", ProgParams.UserPassword); //No Domain is required
            foreach (DataGridViewRow row in grdUsers.SelectedRows)
            {
                ADUsers user = (ADUsers)row.DataBoundItem;
                //string readableLastLogon = DateTime.FromFileTime(Convert.ToInt64(user.LastLogin)).ToString();
                if (user != null)
                {

                    if (user.ExistsInActiveDirectory)
                    {
                        if (user.ProfilePath != null && user.HDrive != null)
                        {
                            string DomainPath = "LDAP:// " + ProgParams.ServerConnectionString;
                            DirectoryEntry searchRoot = new DirectoryEntry(DomainPath, ProgParams.UserAccount, ProgParams.UserPassword);
                            DirectorySearcher search = new DirectorySearcher(searchRoot);

                            search.Filter = "(&(objectClass=user)(objectCategory=person)(CN=" + user.Username + "))";
                            SearchResult result;
                            SearchResultCollection resultCol = search.FindAll();
                            if (resultCol != null)
                            {
                                for (int counter = 0; counter < resultCol.Count; counter++)
                                {
                                    string UserNameEmailString = string.Empty;
                                    result = resultCol[counter];
                                    if (result.Properties.Contains("samaccountname") && result.Properties.Contains("mail") && result.Path.Contains("students"))
                                    {
                                        string parentOU = user.Path.Replace("CN=" + user.Username + ",", "");
                                        DirectoryEntry de = new DirectoryEntry(parentOU);
                                        de.Children.Remove(result.GetDirectoryEntry());
                                        searchRoot.CommitChanges();
                                        moveFolderToBackup(user);
                                        Users.Remove(user);

                                    }
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Please set OU group for user");
                        }

                    }
                }

            }


            grdUsers.Refresh();
            impersonator.undoimpersonateUser();
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Parameters frmParams = new Parameters();
            frmParams.ShowDialog();
            if (frmParams.DialogResult == DialogResult.OK)
            {
                ProgParams = frmParams.getParams();
            }
        }

        private void connectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //addPsHs();
            clearForm();
            loadProgParams();
            grdUsers.AutoGenerateColumns = false;
            progressBar.Style = ProgressBarStyle.Continuous;

            GetActiveDirectoryStudents();
            getSharedFolder();
            GetActiveDirectoryOUs();
            grdUsers.DataSource = Users;
            setContextMeny();
            AddColumns();
            //setRowAppearance();
        }

        private void clearForm()
        {
            Users.Clear();
            grdUsers.DataSource = "";
            
        }
    }
}
