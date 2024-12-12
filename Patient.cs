using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management
{
    public class Patient:Person
    {
        private string registerDate;
        private string disease;
        private string treatBy;
        private string status;
        private string roomNo;
        private string bedNo;
        public string RegisterDate
        {
            get { return registerDate; }
            set { registerDate = value; }
        }
        public string Disease
        {
            get { return disease; }
            set { disease = value; }
        }
        public string TreatBy
        {
            get { return treatBy; }
            set { treatBy = value; }
        }

        public string Status
        {
            get { return status; }
            set { status = value; }
        }

        public string RoomNo
        {
            get { return roomNo; }
            set { roomNo = value; }
        }

        public string BedNo
        {
            get { return bedNo; }
            set { bedNo = value; }
        }
       

    }
}
