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
        

    }
}
