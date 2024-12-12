using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management
{
    public class Doctors:Person
    {
        private string professionalType;
        private string hiredDate;
        private float salary;
        private string status;
        public string ProfessionalType
        {
            get { return professionalType; }
            set { professionalType = value; }
        }
        public string Hireddate
        {
            get { return hiredDate; }
            set { hiredDate = value; }
        }
        public float Salary
        {
            get { return salary; }
            set { salary = value; }
        }
        public string Status
        {
            get { return status; }
            set { status = value; }
        }
    }

}
