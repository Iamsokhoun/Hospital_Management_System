using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management
{
    public class Payment
    {
        private string date;
        private string patientid;
        private float amount;
        private string status;
        public Payment() { }
      

        public string Date
        {
            get { return date; }
            set { date = value; }
        }

        public string PatientId
        {
            get { return patientid; }
            set { patientid = value; }
        }

        public float Amount
        {
            get { return amount; }
            set { amount = value; }
        }
        public string Status
        {
            get { return status; }
            set { status = value; }
        }
    }

}
