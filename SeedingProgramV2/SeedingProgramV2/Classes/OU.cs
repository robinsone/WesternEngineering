using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeedingProgramV2
{
    public class OU
    {
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        private string _path;

        public string Path
        {
            get { return _path; }
            set { _path = value; }
        }

        public OU() { }

        public OU(string name, string path)
        {
            this.Name = name;
            this.Path = path;
        }

    }
}
