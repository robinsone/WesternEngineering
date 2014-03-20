using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeedingProgramV2
{
    class ADUsers
    {
        private string _username;
        private string _firstName;
        private string _lastName;
        private string _middleName;
        private string _email;
        private string _password;
        private string _grad;
        private string _profilePath;
        private string _hdrive;
        private string _lastLogin;
        private string _old;
        private Boolean _existsInActiveDirectory;
        private Boolean _existsInCSVFile;
        

        //Contructors

        public ADUsers() { }

        public ADUsers(string UserName, string FirstName, string LastName, string MiddleName, string Grad, string Email, string ProfilePath, string HDrive, string LastLogin, string old, Boolean ExistsInActiveDirectory, Boolean ExistsInCSVFile)
        {
            this._username = UserName;
            this._firstName = FirstName;
            this._lastName = LastName;
            this._lastLogin = LastLogin;
            this._middleName = MiddleName;
            this._email = Email;
            this._profilePath = ProfilePath;
            this._lastLogin = LastLogin;
            this._hdrive = HDrive;
            this._old = old;
            this._grad = Grad;
            this._existsInActiveDirectory = ExistsInActiveDirectory;
            this._existsInCSVFile = ExistsInCSVFile;
        }

        //Getters

        public string Username
        {
            get { return _username; }
            set { _username = value; }
        }

        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }

        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        public string Grad
        {
            get { return _grad; }
            set { _grad = value; }
        }

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        public string MiddleName
        {
            get { return _middleName; }
            set { _middleName = value; }
        }

        public string ProfilePath
        {
            get { return _profilePath; }
            set { _profilePath = value; }
        }

        public string HDrive
        {
            get { return _hdrive; }
            set { _hdrive = value; }
        }

        public string LastLogin
        {
            get { return _lastLogin; }
            set { _lastLogin = value; }
        }

        public string Old
        {
            get { return _old; }
            set { _old = value; }
        }

        public Boolean ExistsInActiveDirectory
        {
            get { return _existsInActiveDirectory; }
            set { _existsInActiveDirectory = value; }
        }

        public Boolean ExistsInCSVFile
        {
            get { return _existsInCSVFile; }
            set { _existsInCSVFile = value; }
        }

    }
}
