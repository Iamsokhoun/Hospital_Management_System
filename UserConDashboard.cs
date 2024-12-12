using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hospital_Management
{
    public partial class UserConDashboard : UserControl
    {
        public UserConDashboard()
        {
            InitializeComponent();
           
        }

        private void UserConDashboard_Load(object sender, EventArgs e)
        {
            Display();
            
        }
        public void RefreshData()
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)RefreshData);
                return;
            }
                Display();
        }
        public void Display()
        {

                int totalDoctor=DoctorDB.GetTotalDoctor();
                int activeDoctor=DoctorDB.GetActiveDoctor();
                int retiredDoctor=DoctorDB.GetRetiredDoctor();
                lblTotalDoctor.Text=Convert.ToString(totalDoctor);
                lblActiveDoctor.Text =Convert.ToString(activeDoctor);
                lblRetiredDoctor.Text= Convert.ToString(retiredDoctor);


                int totalPatient = PatientDB.GetTotalPatient();
                int activePatient = PatientDB.GetActivePatient();
                int dischargedPatient = PatientDB.GetDischargedPatient();
                lblTotalPatient.Text = Convert.ToString(totalPatient);
                lblActivePatient.Text = Convert.ToString(activePatient);
                lblDischargedPatient.Text = Convert.ToString(dischargedPatient);
                

                int totalRoom = RoomDB.GetTotalRoom();
                int availableRoom = RoomDB.GetAvailableRoom();
                int occupiedRoom = RoomDB.GetOccupiedRoom();
                lblTotalRoom.Text = Convert.ToString(totalRoom);
                lblAvailableRoom.Text = Convert.ToString(availableRoom);
                lblOccupiedRoom.Text = Convert.ToString(occupiedRoom);

        }
    }
}
