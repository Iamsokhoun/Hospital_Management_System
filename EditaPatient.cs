using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management
{
    public  class EditePatient
    {
        private string status;
        public EditePatient() { }
        public string Status
        {
            get { return status; }
            set { status = value; }
        }
    }
}
