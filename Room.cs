using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management
{
    public class Room
    {
        private string id;
        private string name;
        private string type;
        private int capacity;
        private string status;
        public Room() { }
        public string RoomID
        {
            get { return id; }
            set { id = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Roomtype
        {
            get { return type; }
            set { type = value; }
        }

        public string Status
        {
            get { return status; }
            set { status = value; }
        }

        public int Capacity
        {
            get { return capacity; }
            set { capacity = value; }
        }
       
    }

}
