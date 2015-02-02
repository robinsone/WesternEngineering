using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Security.AccessControl;
using System.Security.Principal;

namespace BulkRemoveUserPermissions
{
    class Program
    {
        public static DirectoryInfo[] folders;

        static void Main(string[] args)
        {
            string folder;
            string user;
            
            do { Console.WriteLine("Please enter a directory to remove permissions from sub-folders."); folder = Console.ReadLine(); } while (folder == "");
            GetSubdirectories(folder);
            RemoveInheritence();
            RemoveAccount();
            //do { Console.WriteLine("Pease enter user or group you want removed from these folders"); user = Console.ReadLine(); } while (folder == "");


        }

        static void RemoveAccount()
        {
            foreach (DirectoryInfo folder in folders)
            {
                var accountToRemove = "BUILTIN\\Users";
                var security = folder.GetAccessControl();
                var rules = security.GetAccessRules(true, true, typeof(NTAccount));

                foreach (FileSystemAccessRule rule in rules)
                {
                    if (rule.IdentityReference.Value == accountToRemove)
                    {
                        security.RemoveAccessRuleSpecific(rule);
                        folder.SetAccessControl(security);
                    }

                }
            }
        }

        static void RemoveInheritence()
        {
            //below command turns off inheritence and copies inherited aces to the object.
            foreach (DirectoryInfo folder in folders)
            {
              
            DirectorySecurity dSec = folder.GetAccessControl();
                dSec.SetAccessRuleProtection(true, true);
                folder.SetAccessControl(dSec);
            }
        }

        static void GetSubdirectories(string path)
        {
            DirectoryInfo directory = new DirectoryInfo(path);
            folders = directory.GetDirectories();

            foreach (DirectoryInfo folder in folders)
                Console.WriteLine(folder.Name);
        }
    }
}
