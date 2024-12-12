using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management
{
    public class EditBedStatus
    {
        private string roomid;
        private string bedid;
        public EditBedStatus() { }
        public string RoomID{
            get { return roomid; }
            set { roomid = value; }
        }
        public string BedID
        {
            get { return bedid; }
            set { bedid = value; }
        }
    }
}
