using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hospital_Management
{
    public partial class UserConPayment : UserControl
    {
        public UserConPayment()
        {
            InitializeComponent();
        }
        private Payment payment;
        private EditBedStatus EditBed;
        private void tabControl5_SelectedIndexChanged(object sender, EventArgs e)
        {
            TabControl tabControl = sender as TabControl;
            if (tabControl.SelectedTab == tabPage1)
            {
                string query = "SELECT " +
                 " Payment.BillID," +
                 " Patient.PatientID," +
                 " Patient.FirstName," +
                 " Patient.LastName," +
                 " Payment.Amount," +
                 " Payment.PaymentDate," +
                 " Payment.PaymentStatus" +
                 " FROM Patient " +
              " JOIN" +
                  " Payment ON Patient.PatientID = Payment.PatientID" +
              " ORDER BY" +
                  " Patient.PatientID;";
                Display(query, dataGridView1);
            }else if(tabControl.SelectedTab == tabPage4)
            {
                txtSearch.KeyDown -= new KeyEventHandler(Search_KeyDown);
                txtSearch.KeyDown += new KeyEventHandler(Search_KeyDown);
            }else if (tabControl.SelectedTab == tabPage5)
            {
                string query = "SELECT " +
              " Payment.BillID," +
              " Patient.PatientID," +
              " Patient.FirstName," +
              " Patient.LastName," +
              " Payment.Amount," +
              " Payment.PaymentDate," +
              " Payment.PaymentStatus" +
              " FROM Patient " +
           " JOIN" +
               " Payment ON Patient.PatientID = Payment.PatientID" +
           " ORDER BY" +
               " Patient.PatientID;";
                Display(query, dataGridView3);
                dataGridView3.CellClick += new DataGridViewCellEventHandler(dataGridView3_CellClick);
            }
        }

    private void btnPay_Click(object sender, EventArgs e)
        {
            if (IsValidData()){
                payment = new Payment();
                payment.PatientId=txtPatientID.Text;
                payment.Date = Convert.ToString(DateTime.Now);
                payment.Amount=Convert.ToSingle(txtAmount.Text);
                payment.Status = "Paid";
                bool IsPay=PaymentDB.Update(payment,txtPatientID.Text);
                if (IsPay)
                {
                    PatientDB.UpdateState(txtPatientID.Text);
                    DataTable table=PaymentDB.GetRoomAndBedID(txtPatientID.Text);
                    if(table!=null&& table.Rows.Count > 0)
                    {
                        DataRow row = table.Rows[0];
                        EditBed=new EditBedStatus();
                        EditBed.BedID = row["BedID"].ToString();
                        EditBed.RoomID = row["RoomID"].ToString();
                        BedDB.UpdateStatus("Available", EditBed.BedID, EditBed.RoomID);
                        bool IsRoomOccupied = RoomDB.GetRoomStatus(EditBed.RoomID);
                        if (IsRoomOccupied)
                        {
                            RoomDB.RoomStatus("Available", EditBed.RoomID);
                        }

                    }
                    
                    MessageBox.Show("Payment has been updated successfully.", "Info Entry", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtPatientID.Text = "";
                    txtAmount.Text = "";
                    txtPatientID.Focus();
                }
                else
                {
                    MessageBox.Show("Payment update failed.", "Error Entry", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }
        private bool IsValidData()
        {
            return Validation.IsPresent(txtPatientID, "PatientID") &&
            Validation.IsPresent(txtAmount, "Amount");
        }
        private void Display(String query, DataGridView dataGridView)
        {
            SqlConnection con = DBConnection.getConnection();
            SqlDataAdapter adapter = new SqlDataAdapter(query, con);
            DataTable table = new DataTable();
            try
            {
                con.Open();
                adapter.Fill(table);
                dataGridView.DataSource = null;
                dataGridView.DataSource = table;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Entry", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Search_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Prevent the beep sound on Enter key
                DataTable table = new DataTable();
                string PatientID = txtSearch.Text;
                table = PaymentDB.Search(PatientID);
                if (table != null)
                {
                    dataGridView2.DataSource = table;
                    MessageBox.Show("Data Search successfully.", "Info Entry", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("PatientID " + PatientID + " is not found.", "Info Entry", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtPatientID.Text = "";
            txtAmount.Text = "";
            txtPatientID.Focus();
        }
        
        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Check if the click is on a row, not the column header
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView3.Rows[e.RowIndex];
                txtSearchToDelete.Text = row.Cells[0].Value.ToString();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtSearchToDelete.Text == "" || txtSearchToDelete.Text == "Search")
            {
                MessageBox.Show("Please select or enter BillID to delete.", "Info Entry", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string BillID = txtSearchToDelete.Text;
                DialogResult result = MessageBox.Show("Are you sure you want to delete BillID " + BillID + "?\n" +
                    "Data will be deleted permanently.", "Conform Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    bool IsDelete = PaymentDB.Delete(BillID);
                    if (IsDelete)
                    {
                        MessageBox.Show("Data delete successfully.", "Info Entry", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("BillID " + BillID + " not found.\n" + "Data delete failed.", "Info Entry", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtSearchToDelete.Text = "";
                        txtSearchToDelete.Focus();
                    }
                }
            }
        }

        private void UserConPayment_Load(object sender, EventArgs e)
        {
            string query = "SELECT " +
                " Payment.BillID," +
                " Patient.PatientID," +
                " Patient.FirstName," +
                " Patient.LastName," +
                " Payment.Amount," +
                " Payment.PaymentDate," +
                " Payment.PaymentStatus" +
                " FROM Patient " +
             " JOIN" +
                 " Payment ON Patient.PatientID = Payment.PatientID" +
             " ORDER BY" +
                 " Patient.PatientID;";
            Display(query, dataGridView1);
        }
        public void RefreshData()
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)RefreshData);
                return;
            }
            string query = "SELECT " +
                " Payment.BillID," +
                " Patient.PatientID," +
                " Patient.FirstName," +
                " Patient.LastName," +
                " Payment.Amount," +
                " Payment.PaymentDate," +
                " Payment.PaymentStatus" +
                " FROM Patient " +
             " JOIN" +
                 " Payment ON Patient.PatientID = Payment.PatientID" +
             " ORDER BY" +
                 " Patient.PatientID;";
            Display(query, dataGridView1);
        }
    }
}
