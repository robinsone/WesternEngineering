using SeedingProgramV2.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeedingProgramV2
{
    public class ProgParams
    {

        public ProgParams() { }

        private string _ServerConnectionString;

        public string ServerConnectionString
        {
            get { return _ServerConnectionString; }
            set { _ServerConnectionString = value; }
        }

        private string _FolderPath;

        public string FolderPath
        {
            get { return _FolderPath; }
            set { _FolderPath = value; }
        }

        private Boolean _isSet = false;

        public Boolean IsSet
        {
            get { return _isSet; }
            set { _isSet = value; }
        }

        private string _UserAccount;

        public string UserAccount
        {
            get { return _UserAccount; }
            set { _UserAccount = value; }
        }

        private string _UserPassword;

        public string UserPassword
        {
            get { return _UserPassword; }
            set { _UserPassword = value; }
        }

        public string decryptedPassword(string encryptedString)
        {
            return Crypto.DecryptStringAES(encryptedString, "F32491AB72");
        }

        public string encryptPassword()
        {
            return Crypto.EncryptStringAES(this.UserPassword,"F32491AB72");
        }

        public void Save() {
            
            System.Xml.Serialization.XmlSerializer writer =
                new System.Xml.Serialization.XmlSerializer(typeof(ProgParams));

            System.IO.StreamWriter file = new System.IO.StreamWriter(AppDomain.CurrentDomain.BaseDirectory + 
                   @"..\..\xml\ProgParams.xml");
            this.UserPassword = this.encryptPassword();
            writer.Serialize(file, this);
            this.IsSet = true;
            file.Close();

        }

        public ProgParams Load()
        {
            System.Xml.Serialization.XmlSerializer reader =
            new System.Xml.Serialization.XmlSerializer(typeof(ProgParams));
            System.IO.StreamReader file = new System.IO.StreamReader(AppDomain.CurrentDomain.BaseDirectory +
                   @"..\..\xml\ProgParams.xml");
            ProgParams pparam = new ProgParams();
            try
            {
                pparam = (ProgParams)reader.Deserialize(file);
                pparam.IsSet = true;
                pparam.UserPassword =  pparam.decryptedPassword(pparam.UserPassword);
            }
            catch(Exception)
            {
                pparam.IsSet = false;
            }

            file.Close();
            return pparam;
        }
    }
}
