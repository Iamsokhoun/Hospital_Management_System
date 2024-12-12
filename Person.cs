using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management
{
     public abstract class Person
    {
        private string id;
        private string firstName;
        private string lastName;
        private string gender;
        private string dateOfBirth;
        private string contact;
        private string address;
        public string Id
        {
            get { return id; }
            set { id = value; }
        }
        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }
        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }
        public string Gender
        {
            get { return gender; }
            set { gender = value; }
        }
        public string DateOfBirth
        {
            get { return dateOfBirth; }
            set { dateOfBirth = value; }
        }
        public string Contact
        {
            get { return contact; }
            set { contact = value; }
        }
        public string Address
        {
            get { return address; }
            set { address = value; }
        }
    }
}
