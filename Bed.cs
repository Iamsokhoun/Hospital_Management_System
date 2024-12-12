using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management
{
    public class Bed
    {
        private string id;
        private string roomid;
        private string bedno;
        private string status;
        public Bed() { }
        public string ID{
            get { return id; }
            set {  id = value; }
        }
        public string RoomID
        {
            get { return roomid; }
            set { roomid = value; }
        }
        public string Bedno
        {
            get { return bedno; }
            set { bedno = value; }
        }
        public string Status
        {
            get { return status; }
            set { status = value; }
        }

    }
}
