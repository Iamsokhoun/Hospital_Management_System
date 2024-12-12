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
    public partial class frmHomeScreen : Form
    {
        
        public frmHomeScreen()
        {
            InitializeComponent();       
        }

        private void lblExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void btnDoctor_Click(object sender, EventArgs e)
        {
            userConDashboard1.Visible = false;
            userConDoctor1.Visible = true;
            userConPatient1.Visible = false;
            userConRoom1.Visible = false;
            userConPayment1.Visible = false;
            btnDashboard.BackColor = Color.FromArgb(33,11,97);
            btnDoctor.BackColor = Color.FromArgb(75, 8, 138);
            btnPatient.BackColor = Color.FromArgb(33, 11, 97);
            btnRoom.BackColor = Color.FromArgb(33, 11, 97);
            btnBed.BackColor = Color.FromArgb(33, 11, 97);
            btnPayment.BackColor = Color.FromArgb(33, 11, 97);
            btnExit.BackColor = Color.FromArgb(33, 11, 97);
            UserConDoctor doctor=userConDoctor1 as UserConDoctor;
            if (doctor != null)
            {
                doctor.RefreshData();
            }
           
        }

        private void btnPatient_Click(object sender, EventArgs e)
        {
            userConDashboard1.Visible = false;
            userConDoctor1.Visible = false;
            userConPatient1.Visible = true;
            userConRoom1.Visible = false;
            userConBed1.Visible = false;
            userConPayment1.Visible = false;
            btnPatient.BackColor = Color.FromArgb(75, 8, 138);
            btnDashboard.BackColor = Color.FromArgb(33, 11, 97);
            btnDoctor.BackColor = Color.FromArgb(33, 11, 97);
            btnRoom.BackColor = Color.FromArgb(33, 11, 97);
            btnBed.BackColor = Color.FromArgb(33, 11, 97);
            btnPayment.BackColor = Color.FromArgb(33, 11, 97);
            btnExit.BackColor = Color.FromArgb(33, 11, 97);
            UserConPatient patient=userConPatient1 as UserConPatient;
            if (patient != null)
            {
                patient.RefreshData();
            }

        }

        private void frmHomeScreen_Load(object sender, EventArgs e)
        {

        }

        private void btnRoom_Click(object sender, EventArgs e)
        {
            userConDashboard1.Visible = false;
            userConDoctor1.Visible = false;
            userConPatient1.Visible = false;
            userConBed1.Visible = false;
            userConRoom1.Visible = true;
            userConPayment1.Visible = false;
            btnRoom.BackColor = Color.FromArgb(75, 8, 138);
            btnDashboard.BackColor = Color.FromArgb(33, 11, 97);
            btnDoctor.BackColor = Color.FromArgb(33, 11, 97);
            btnPatient.BackColor = Color.FromArgb(33, 11, 97);
            btnBed.BackColor = Color.FromArgb(33, 11, 97);
            btnPayment.BackColor = Color.FromArgb(33, 11, 97);
            btnExit.BackColor = Color.FromArgb(33, 11, 97);
            UserConRoom room=userConRoom1 as UserConRoom;
            if(room!= null)
            {
                room.RefreshData();
            }
            
        }

        private void btnPayment_Click(object sender, EventArgs e)
        {
            userConDashboard1.Visible = false;
            userConDoctor1.Visible = false;
            userConPatient1.Visible = false;
            userConRoom1.Visible = false;
            userConBed1.Visible = false;
            userConPayment1.Visible = true;
            btnPayment.BackColor = Color.FromArgb(75,8, 138);
            btnDashboard.BackColor = Color.FromArgb(33, 11, 97);
            btnDoctor.BackColor = Color.FromArgb(33, 11, 97);
            btnPatient.BackColor = Color.FromArgb(33, 11, 97);
            btnRoom.BackColor = Color.FromArgb(33, 11, 97);
            btnBed.BackColor = Color.FromArgb(33, 11, 97);
            btnExit.BackColor = Color.FromArgb(33, 11, 97);
            UserConPayment payment= userConPayment1 as UserConPayment;
            if (payment != null)
            {
                payment.RefreshData();
            }
            
        }

        

        private void btnBed_Click(object sender, EventArgs e)
        {
            userConDashboard1.Visible = false;
            userConDoctor1.Visible = false;
            userConPatient1.Visible = false;
            userConRoom1.Visible = false;
            userConPayment1.Visible = false;
            userConBed1.Visible = true;
            btnBed.BackColor = Color.FromArgb(75, 8, 138);
            btnDashboard.BackColor = Color.FromArgb(33, 11, 97);
            btnDoctor.BackColor = Color.FromArgb(33, 11, 97);
            btnPatient.BackColor = Color.FromArgb(33, 11, 97);
            btnRoom.BackColor = Color.FromArgb(33, 11, 97);
            btnPayment.BackColor = Color.FromArgb(33, 11, 97);
            btnExit.BackColor = Color.FromArgb(33, 11, 97);
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            userConDashboard1.Visible = true;
            userConDoctor1.Visible = false;
            userConPatient1.Visible = false;
            userConRoom1.Visible = false;
            userConPayment1.Visible = false;
            userConBed1.Visible = false;
            btnDashboard.BackColor = Color.FromArgb(75, 8, 138);
            btnDoctor.BackColor = Color.FromArgb(33, 11, 97);
            btnPatient.BackColor = Color.FromArgb(33,11, 97);
            btnRoom.BackColor = Color.FromArgb(33, 11, 97);
            btnBed.BackColor = Color.FromArgb(33, 11, 97);
            btnPayment.BackColor = Color.FromArgb(33, 11, 97);
            btnExit.BackColor = Color.FromArgb(33, 11, 97);
            UserConDashboard dashboard=userConDashboard1 as UserConDashboard;
            if (dashboard != null)
            {
                dashboard.RefreshData();
            }
        }
    }
}
