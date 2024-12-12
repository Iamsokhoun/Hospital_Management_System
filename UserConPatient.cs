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
    public partial class UserConPatient : UserControl
    {
        public UserConPatient()
        {
            InitializeComponent();
            
        }
        private Patient patient;
        private EditBedStatus EditBed=new EditBedStatus();
        private Payment payment;
        private String PatientStatus=null;
        private void tabControl2_SelectedIndexChanged(object sender, EventArgs e)
        {
            TabControl tabControl = sender as TabControl;
            if (tabControl.SelectedTab == tabPage1)
            {
                String query = "Select * from Patient";
                Display(query, dataGridView1);
            }else if (tabControl.SelectedTab == tabPage2)
            {
                cboPtnGender.Items.Clear();
                cboPtnStatus.Items.Clear();
                cboPtnGender.Items.Add("Male");
                cboPtnGender.Items.Add("Female");
                cboPtnStatus.Items.Add("Active");
                cboPtnStatus.Items.Add("Discharged");
                cboPtnGender.SelectedIndex = -1;
                cboPtnStatus.SelectedIndex = -1;
                cboPtnStatus.SelectedIndexChanged += ComboBox_SelectedIndexChanged;


            }
            else if (tabControl.SelectedTab == tabPage3)
            {
                txtSearch.KeyDown -= new KeyEventHandler(Search_KeyDown);
                txtSearch.KeyDown += new KeyEventHandler(Search_KeyDown);
            }else if (tabControl.SelectedTab == tabPage4)
            {
                String query = "Select * from Patient";
                Display(query, dataGridView3);
                dataGridView3.CellClick += new DataGridViewCellEventHandler(dataGridView3_CellClick);
            }else if(tabControl.SelectedTab == tabPage5)
            {
                txtSearchToUpdate.KeyDown -= new KeyEventHandler(SearchToUpdate_KeyDown);
                txtSearchToUpdate.KeyDown += new KeyEventHandler(SearchToUpdate_KeyDown);
            }

        }
        private void ComboBox_SelectedIndexChanged(Object sender,EventArgs e)

        {
            ComboBox cmb= (ComboBox)sender;
            if (cboPtnStatus.SelectedItem!=null&&cboPtnStatus.SelectedItem == "Discharged")
            {
                txtPtnRoom.Enabled = false;
                txtBed.Enabled = false;
            }
            else
            {
                txtPtnRoom.Text = "";
                txtBed.Text = "";
                txtPtnRoom.Enabled = true;
                txtBed.Enabled = true;
            }
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
        private void ClearAdd()
        {
            txtPtnID.Text = "";
            txtPtnFirstName.Text = "";
            txtPtnLastName.Text = "";
            cboPtnGender.SelectedIndex=-1;
            txtPtnDisease.Text = "";
            txtPtnPhoneNumber.Text = "";
            txtPtnDateOFBirth.Text = "";
            txtPtnAddress.Text = "";
            txtPtnTreatBY.Text = "";
            cboPtnStatus.SelectedIndex= -1;
            txtPtnRoom.Text = "";
            txtBed.Text = "";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearAdd();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (IsValidateData())
            {
                if (cboPtnStatus.SelectedItem == "Active")
                {
                    bool ifRoomAvailable = RoomDB.IfRoomAvailable(txtPtnRoom.Text);
                    if (ifRoomAvailable)
                    {
                        bool IfBedStatusAvailable = BedDB.IfBeddstatusOccupied(txtBed.Text,txtPtnRoom.Text);
                        if (IfBedStatusAvailable)
                        {
                            patient = new Patient();
                            patient.Id = txtPtnID.Text;
                            patient.FirstName = txtPtnFirstName.Text;
                            patient.LastName = txtPtnLastName.Text;
                            string CurrentDate = DateTime.Now.ToString();
                            patient.RegisterDate = CurrentDate;
                            patient.Gender = cboPtnGender.SelectedItem.ToString();
                            patient.Disease = txtPtnDisease.Text;
                            patient.Contact = txtPtnPhoneNumber.Text;
                            patient.DateOfBirth = txtPtnDateOFBirth.Text;
                            patient.Address = txtPtnAddress.Text;
                            patient.TreatBy = txtPtnTreatBY.Text;
                            patient.Status = cboPtnStatus.SelectedItem.ToString();
                            patient.RoomNo = txtPtnRoom.Text;
                            patient.BedNo = txtBed.Text;
                            bool IsInsert = PatientDB.Insert(patient);
                            if (IsInsert)
                            {
                                payment = new Payment();
                                payment.PatientId = txtPtnID.Text;
                                payment.Date = Convert.ToString(DateTime.Now);
                                payment.Amount = 0;
                                payment.Status = "Unpaid";
                                PaymentDB.Pay(payment);
                                /*
                                if (IsPay)
                                { 
                                    MessageBox.Show("Payment insert successfully.", "Info Entry", MessageBoxButtons.OK, MessageBoxIcon.Information);                                 
                                }
                                else
                                {
                                    MessageBox.Show("Payment insert failed.", "Error Entry", MessageBoxButtons.OK, MessageBoxIcon.Error);

                                }
                                */
                                MessageBox.Show("Data insert successfully.", "Info Entry", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                BedDB.UpdateStatus("Occupied", txtBed.Text, txtPtnRoom.Text);
                                int OccupiedStatus = BedDB.AreAllStatusSame(txtPtnRoom.Text);
                                int BedInRoom = BedDB.GetRecordCount(txtPtnRoom.Text);
                                int roomCapacity = RoomDB.RoomCapacity(txtPtnRoom.Text);
                                if (BedInRoom == roomCapacity && BedInRoom==OccupiedStatus)
                                {
                                    RoomDB.RoomStatus("Occupied", txtPtnRoom.Text);
                                }
                                ClearAdd();
                                txtPtnID.Focus();
                                //MessageBox.Show(BedInRoom + "==" + roomCapacity + "&&" + SameStatus);
                            }
                            else
                            {
                                MessageBox.Show("Data insert failed.", "Info Entry", MessageBoxButtons.OK, MessageBoxIcon.Error);

                            }
                        }
                        else
                        {
                            MessageBox.Show("BedID " + txtBed.Text + " is not available.\n\nData insert failed.", "Error Entry", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }
                    }
                    else
                    {
                        MessageBox.Show("RoomID " + txtPtnRoom.Text + " is not available.\n\nData insert failed.", "Error Entry", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                else
                {
                    patient = new Patient();
                    patient.Id = txtPtnID.Text;
                    patient.FirstName = txtPtnFirstName.Text;
                    patient.LastName = txtPtnLastName.Text;
                    string CurrentDate = DateTime.Now.ToString();
                    patient.RegisterDate = CurrentDate;
                    patient.Gender = cboPtnGender.SelectedItem.ToString();
                    patient.Disease = txtPtnDisease.Text;
                    patient.Contact = txtPtnPhoneNumber.Text;
                    patient.DateOfBirth = txtPtnDateOFBirth.Text;
                    patient.Address = txtPtnAddress.Text;
                    patient.TreatBy = txtPtnTreatBY.Text;
                    patient.Status = cboPtnStatus.SelectedItem.ToString();
                    patient.RoomNo = null;
                    patient.BedNo = null;
                    bool IsInsert = PatientDB.Insert(patient);
                    if (IsInsert)
                    {
                        payment = new Payment();
                        payment.PatientId = txtPtnID.Text;
                        payment.Date = Convert.ToString(DateTime.Now);
                        payment.Amount = 0;
                        payment.Status = "Unpaid";
                        PaymentDB.Pay(payment);
                        /*
                        if (IsPay)
                        {
                            MessageBox.Show("Payment insert successfully.", "Info Entry", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Payment insert failed.", "Error Entry", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }
                        */
                        MessageBox.Show("Data insert successfully.", "Info Entry", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearAdd();
                        txtPtnID.Focus();
                        //MessageBox.Show(BedInRoom + "==" + roomCapacity + "&&" + SameStatus);
                    }
                    else
                    {
                        MessageBox.Show("Data insert failed.", "Info Entry", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                }
            }

        }
        private bool IsValidateData()
        {
            return Validation.IsPresent(txtPtnID, "PatientID") &&
                Validation.IsPresent(txtPtnFirstName, "FirstName") &&
                Validation.IsPresent(txtPtnLastName, "LastName") &&
                Validation.IsItemSelect(cboPtnGender, "Gender") &&
                Validation.IsPresent(txtPtnDisease, "Disease") &&
                Validation.IsPresent(txtPtnPhoneNumber, "Emergency Contact") &&
                Validation.IsPresent(txtPtnDateOFBirth, "Date Of Birth") &&
                Validation.IsPresent(txtPtnAddress, "Address") &&
                Validation.IsPresent(txtPtnTreatBY, "Treat By") &&
                Validation.IsItemSelect(cboPtnStatus, "Status") &&
                Validation.IsPresent(txtPtnRoom, "Room No") &&
                Validation.IsPresent(txtBed, "Ben No");
                    
        }
        private void Search_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Prevent the beep sound on Enter key
                string SearchID = txtSearch.Text;
                DataTable table = new DataTable();
                table = PatientDB.Search(SearchID);
                if (table != null)
                {
                    dataGridView2.DataSource = table;
                    MessageBox.Show("Data Search successfully.", "Info Entry", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("DoctorID " + SearchID + " is not found.", "Info Entry", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Check if the click is on a row, not the column header
            if (e.RowIndex >= 0)
            {
                
                DataGridViewRow row = dataGridView3.Rows[e.RowIndex];
                txtSearchToDelete.Text = row.Cells[0].Value.ToString();
                EditBed.RoomID = row.Cells[10].Value.ToString();
                EditBed.BedID= row.Cells[11].Value.ToString();
                PatientStatus = row.Cells[12].Value.ToString();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtSearchToDelete.Text == "" || txtSearchToDelete.Text == "Search")
            {
                MessageBox.Show("Please select or enter PatientID to delete.", "Info Entry", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string deleteID = txtSearchToDelete.Text;
                DialogResult result = MessageBox.Show("Are you sure you want to delete PatientID " + deleteID + "?\n" +
                    "Data will be deleted permanently.", "Conform Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    bool IsDelete = PatientDB.Delete(deleteID);
                    if (IsDelete)
                    {
                        MessageBox.Show("Data delete successfully.", "Info Entry", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (PatientStatus == "Active")
                        {
                            BedDB.UpdateStatus("Available", EditBed.BedID, EditBed.RoomID);
                            RoomDB.RoomStatus("Available", EditBed.RoomID);
                        }
                    }
                    else
                    {
                        MessageBox.Show("PatientID " + deleteID + " not found.\n" + "Data delete failed.", "Info Entry", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtSearchToDelete.Text = "";
                        txtSearchToDelete.Focus();
                    }
                }
            }
        }
        private void SearchToUpdate_KeyDown(Object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                string enterID = txtSearchToUpdate.Text;
                DataTable table = new DataTable();
                table = PatientDB.Search(enterID);
                if (table != null)
                {
                    cboPtnGender.Items.Clear();
                    cboPtnStatus.Items.Clear();
                    cboUpPntGender.Items.Add("Male");
                    cboUpPntGender.Items.Add("Female");
                    cboUpPntStatus.Items.Add("Active");
                    cboUpPntStatus.Items.Add("Discharged");
                    txtUpPntID.Text = table.Rows[0]["PatientID"].ToString();
                    txtUpPntFirstName.Text = table.Rows[0]["FirstName"].ToString();
                    txtUpPntLastName.Text = table.Rows[0]["LastName"].ToString();
                    string gender = table.Rows[0]["Gender"].ToString();
                    string status = table.Rows[0]["CurStatus"].ToString();
                    cboUpPntGender.SelectedItem = gender;
                    txtUpPntDisease.Text = table.Rows[0]["Disease"].ToString();
                    txtUpPntContact.Text = table.Rows[0]["Contact"].ToString();
                    txtUpPntDateOfBirth.Text = table.Rows[0]["DateOFBirth"].ToString();
                    txtUpPntAddress.Text = table.Rows[0]["CurAddress"].ToString();
                    txtUpPntTreatBy.Text = table.Rows[0]["TreatBY"].ToString();
                    cboUpPntStatus.SelectedItem = status;
                    txtUpPntRoomNO.Text = table.Rows[0]["RoomID"].ToString();
                    txtUpPntBedNO.Text = table.Rows[0]["BedID"].ToString();
                    EditBed.RoomID= table.Rows[0]["RoomID"].ToString();
                    EditBed.BedID= table.Rows[0]["BedID"].ToString();
                    cboUpPntStatus.Enabled = false;
                    patient = new Patient();
                    patient.Id=txtUpPntID.Text;
                    patient.FirstName=txtUpPntFirstName.Text;
                    patient.LastName =txtUpPntLastName.Text;
                    patient.Gender = gender;
                    patient.Disease=txtUpPntDisease.Text;
                    patient.Contact=txtUpPntContact.Text;
                    patient.DateOfBirth=txtUpPntDateOfBirth.Text;
                    patient.Address=txtUpPntAddress.Text;
                    patient.TreatBy=txtUpPntTreatBy.Text;
                    patient.Status=status;
                    patient.RoomNo=txtUpPntRoomNO.Text;
                    patient.BedNo=txtUpPntBedNO.Text;
                   
                }
                else
                {
                    MessageBox.Show("PatientID " + enterID + " not found.\n" +
                        "Please enter the correct data.", "Info Entry", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ClearUpdate();
                }
            }
        }
        private void ClearUpdate()
        {
            txtUpPntID.Text = "";
            txtUpPntFirstName.Text = "";
            txtUpPntLastName.Text = "";
            cboUpPntGender.SelectedIndex= -1;
            cboUpPntGender.Items.Clear();
            txtUpPntDisease.Text ="";
            txtUpPntContact.Text = "";
            txtUpPntDateOfBirth.Text = "";
            txtUpPntAddress.Text = "";
            txtUpPntTreatBy.Text = "";
            cboUpPntStatus.SelectedIndex = -1;
            cboUpPntStatus.Items.Clear();
            txtUpPntRoomNO.Text = "";
            txtUpPntBedNO.Text = "";
            txtSearchToUpdate.Text = "";
            txtSearchToUpdate.Focus();
        }

        private void btnCancelUpdate_Click(object sender, EventArgs e)
        {
            ClearUpdate();  
        }
        private bool textChange()
        {
            return patient.Id == txtUpPntID.Text &&
            patient.FirstName == txtUpPntFirstName.Text &&
            patient.LastName == txtUpPntLastName.Text &&
            patient.Gender == cboUpPntGender.SelectedItem.ToString() &&
            patient.Disease == txtUpPntDisease.Text &&
            patient.Contact == txtUpPntContact.Text &&
            patient.DateOfBirth == txtUpPntDateOfBirth.Text &&
            patient.Address == txtUpPntAddress.Text &&
            patient.TreatBy == txtUpPntTreatBy.Text &&
            patient.Status == cboUpPntStatus.SelectedItem.ToString() &&
            patient.RoomNo == txtUpPntRoomNO.Text &&
            patient.BedNo == txtUpPntBedNO.Text;
        }
        
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (textChange() != true)
            {
                if (patient.RoomNo != txtUpPntRoomNO.Text || patient.BedNo != txtUpPntBedNO.Text)
                {
                    if (IsValidat())
                    {
                        bool IsRoomExist=RoomDB.IfRoomExist(txtUpPntRoomNO.Text);
                        if (IsRoomExist)
                        {
                            bool IsRoomAvailable = RoomDB.IfRoomAvailable(txtUpPntRoomNO.Text);
                            if (IsRoomAvailable)
                            {
                                bool IsBedExist=BedDB.IfBedExist(txtUpPntBedNO.Text, txtUpPntRoomNO.Text);
                                if (IsBedExist)
                                {
                                    bool IsBedAvailable = BedDB.IfBeddstatusOccupied(txtUpPntBedNO.Text, txtUpPntRoomNO.Text);
                                    if (IsBedAvailable)
                                    {
                                        patient = new Patient();
                                        patient.Id = txtUpPntID.Text;
                                        patient.FirstName = txtUpPntFirstName.Text;
                                        patient.LastName = txtUpPntLastName.Text;
                                        patient.Gender = cboUpPntGender.SelectedItem.ToString();
                                        patient.Disease = txtUpPntDisease.Text;
                                        patient.Contact = txtUpPntContact.Text;
                                        patient.DateOfBirth = txtUpPntDateOfBirth.Text;
                                        patient.Address = txtUpPntAddress.Text;
                                        patient.TreatBy = txtUpPntTreatBy.Text;
                                        patient.Status = cboUpPntStatus.SelectedItem.ToString();
                                        patient.RoomNo = txtUpPntRoomNO.Text;
                                        patient.BedNo = txtUpPntBedNO.Text;
                                        bool IsUpdate = PatientDB.Update(patient, txtSearchToUpdate.Text);
                                        if (IsUpdate)
                                        {
                                            MessageBox.Show("Data update successfully.", "Info Entry", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            if (patient.RoomNo != EditBed.RoomID)
                                            {
                                                RoomDB.RoomStatus("Available", EditBed.RoomID);
                                                BedDB.UpdateStatus("Available", EditBed.BedID, EditBed.RoomID);
                                                BedDB.UpdateStatus("Occupied", patient.BedNo, patient.RoomNo);
                                                int roomCapacity = RoomDB.RoomCapacity(patient.RoomNo);
                                                int getAllBed = BedDB.GetRecordCount(patient.RoomNo);
                                                int OccupiedStatus = BedDB.AreAllStatusSame(patient.RoomNo);
                                                if (roomCapacity == getAllBed && getAllBed == OccupiedStatus)
                                                {
                                                    RoomDB.RoomStatus("Occupied", patient.RoomNo);
                                                }
                                            }
                                            if (patient.BedNo != EditBed.BedID)
                                            {
                                                BedDB.UpdateStatus("Available", EditBed.BedID, EditBed.RoomID);
                                                BedDB.UpdateStatus("Occupied", patient.BedNo, patient.RoomNo);
                                                int roomCapacity = RoomDB.RoomCapacity(patient.RoomNo);
                                                int getAllBed = BedDB.GetRecordCount(patient.RoomNo);
                                                int OccupiedStatus = BedDB.AreAllStatusSame(patient.RoomNo);
                                                if (roomCapacity == getAllBed && getAllBed == OccupiedStatus)
                                                {
                                                    RoomDB.RoomStatus("Occupied", patient.RoomNo);
                                                }
                                            }

                                            ClearUpdate();
                                            txtSearchToUpdate.Focus();
                                        }
                                        else
                                        {
                                            MessageBox.Show("Data update failed.", "Info Entry", MessageBoxButtons.OK, MessageBoxIcon.Error);

                                        }
                                    }
                                    else
                                    {
                                        string bedid = txtUpPntBedNO.Text;
                                        MessageBox.Show("BedID " + bedid + " is taken.\n\nData update failed.", "Error Entry", MessageBoxButtons.OK, MessageBoxIcon.Error);

                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Data update failed!\n\n"+
                                        "BedID " + txtUpPntBedNO.Text + " doesn't exist!", "Error Entry", MessageBoxButtons.OK, MessageBoxIcon.Error);

                                }

                            }

                            else
                            {
                                string roomid = txtUpPntRoomNO.Text;
                                MessageBox.Show("RoomID " + roomid + " is full.\n\nData Update failed.", "Error Entry", MessageBoxButtons.OK, MessageBoxIcon.Error);

                            }
                        }
                        else
                        {
                            MessageBox.Show("Data Update failed!\n\n"+
                                "RoomID " + txtUpPntRoomNO.Text + " doesn't exist!", "Error Entry", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }
                }
                else
                {
                    if (Validate())
                    {
                        patient = new Patient();
                        patient.Id = txtUpPntID.Text;
                        patient.FirstName = txtUpPntFirstName.Text;
                        patient.LastName = txtUpPntLastName.Text;
                        patient.Gender = cboUpPntGender.SelectedItem.ToString();
                        patient.Disease = txtUpPntDisease.Text;
                        patient.Contact = txtUpPntContact.Text;
                        patient.DateOfBirth = txtUpPntDateOfBirth.Text;
                        patient.Address = txtUpPntAddress.Text;
                        patient.TreatBy = txtUpPntTreatBy.Text;
                        patient.Status = cboUpPntStatus.SelectedItem.ToString();
                        patient.RoomNo = txtUpPntRoomNO.Text;
                        patient.BedNo = txtUpPntBedNO.Text;
                        bool IsUpdate = PatientDB.Update(patient, txtSearchToUpdate.Text);
                        if (IsUpdate)
                        {
                            MessageBox.Show("Data update successfully.", "Info Entry", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ClearUpdate();
                        }
                        else
                        {
                            MessageBox.Show("Data update failed.", "Info Entry", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Data update failed.\n\n"+
                                "It seems like you didn't change anything!\n\n"+
                                "Please make any change to update!","Error Entry",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool IsValidat()
        {
            return Validation.IsPresent(txtUpPntID, "PatientID") &&
                Validation.IsPresent(txtUpPntFirstName, "FirstName") &&
                Validation.IsPresent(txtUpPntLastName, "LastName") &&
                Validation.IsItemSelect(cboUpPntGender, "Gender") &&
                Validation.IsPresent(txtUpPntDisease, "Disease") &&
                Validation.IsPresent(txtUpPntContact, "Enmergency Contact") &&
                Validation.IsPresent(txtUpPntDateOfBirth, "Date Of Birth") &&
                Validation.IsPresent(txtUpPntAddress, "Address") &&
                Validation.IsPresent(txtUpPntTreatBy, "Treat By") &&
                Validation.IsItemSelect(cboUpPntStatus, "Status") &&
                Validation.IsPresent(txtUpPntRoomNO, "Room No") &&
                Validation.IsPresent(txtUpPntBedNO, "Bed No");
            
        }

        private void UserConPatient_Load(object sender, EventArgs e)
        {
            dataGridView1.RowsDefaultCellStyle.ForeColor = Color.Black;
            String query = "Select * from Patient";
            Display(query, dataGridView1);
        }
        public void RefreshData()
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)RefreshData);
                return;
            }
            dataGridView1.RowsDefaultCellStyle.ForeColor = Color.Black;
            String query = "Select * from Patient";
            Display(query, dataGridView1);
        }
    }
}
