using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
namespace Hospital_Management
{
    public partial class UserConDoctor : UserControl
    {
        public UserConDoctor()
        {
            InitializeComponent();
        }
        private Doctors doctor;
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            TabControl tabControl = sender as TabControl;
            if (tabControl.SelectedTab == tabPage1)
            {
                ExecuteDoctorDisplay();
            }
             else if (tabControl.SelectedTab == tabPage2)
            {
                cboProfessionalType.Items.Clear();
                cboDocGender.Items.Clear();
                cboDocGender.Items.Add("Male");
                cboDocGender.Items.Add("Female");
                cboProfessionalType.Items.Add("Doctor");
                cboProfessionalType.Items.Add("Nurse");
                cboDocGender.SelectedIndex = -1;
                cboProfessionalType.SelectedIndex = -1;
            } else if (tabControl.SelectedTab == tabPage3)
            {
                txtSearch.KeyDown -= new KeyEventHandler(Search_KeyDown);
                txtSearch.KeyDown += new KeyEventHandler(Search_KeyDown);
            }else if (tabControl.SelectedTab == tabPage4)
            {
                String query = "Select * From Doctor";
                Display(query, dataGridView3);
                dataGridView3.CellClick += new DataGridViewCellEventHandler(dataGridView3_CellClick);
            }else if(tabControl.SelectedTab == tabPage5)
            {
                txtSearchToUpdate.KeyDown -= new KeyEventHandler(SearchToUpdate_KeyDown);
                txtSearchToUpdate.KeyDown += new KeyEventHandler(SearchToUpdate_KeyDown);
             
            }
        }
        public void ExecuteDoctorDisplay()
        {
          
            String sqlquery = "Select * From Doctor";
            Display(sqlquery, dataGridView1);
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            
            if (IsValideDataToAdd())
            {
                doctor = new Doctors();
                doctor.Id = txtDocID.Text;
                doctor.FirstName = txtDocfirstName.Text;
                doctor.LastName = txtDocLastName.Text;
                doctor.Gender = cboDocGender.SelectedItem.ToString();
                doctor.ProfessionalType = cboProfessionalType.SelectedItem.ToString();
                doctor.Hireddate=txtDocHiredDate.Text;
                doctor.Salary = Convert.ToSingle(txtDoctorSalary.Text);
                doctor.Contact = txtDoccContact.Text;
                doctor.Address = txtDocAddress.Text;
                doctor.DateOfBirth = txtDateOFBirth.Text;
                doctor.Status = "Active";
                bool IsInsert=DoctorDB.AddDoctor(doctor);
                if (IsInsert) {
                    MessageBox.Show("Data Insert successfully", "Info Entry", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearAdd();
                }
                else
                {
                    MessageBox.Show("Data Insert failed","Info Entry",MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        
        private bool IsValideDataToAdd()
        {

            return Validation.IsPresent(txtDocID, "DoctorID") &&
                   Validation.IsPresent(txtDocfirstName, "FirstName") &&
                   Validation.IsPresent(txtDocLastName, "LastName") &&
                   Validation.IsItemSelect(cboDocGender, "Gender") &&
                   Validation.IsItemSelect(cboProfessionalType, "ProfessionalTyp") &&
                   Validation.IsPresent(txtDocHiredDate, "Hired Date") &&
                   Validation.IsPresent(txtDoctorSalary, "Salary") &&
                   Validation.IsFloat(txtDoctorSalary, "Salary") &&
                   Validation.IsPresent(txtDoccContact, "Contact") &&
                   Validation.IsPresent(txtDocAddress, "Address") &&
                   Validation.IsPresent(txtDateOFBirth, "Date Of Birth");
        }
        private void ClearAdd()
        {
            txtDocID.Text="";
            txtDocfirstName.Text="";
            txtDocLastName.Text = "";
            cboDocGender.SelectedIndex = -1;
            cboProfessionalType.SelectedIndex = -1;
            txtDocHiredDate.Text = "";
            txtDoctorSalary.Text = "";
            txtDoccContact.Text = "";
            txtDocAddress.Text = "";
            txtDateOFBirth.Text = "";
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearAdd();
        }
        private void Search_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Prevent the beep sound on Enter key
                string DoctorID=txtSearch.Text;
                DataTable table = new DataTable();
                table=DoctorDB.Search(DoctorID);
                if (table != null)
                {
                    dataGridView2.DataSource = table;
                    MessageBox.Show("Data Search successfully.", "Info Entry", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("DoctorID "+DoctorID + " is not found.", "Info Entry", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
       private void Display(String query,DataGridView dataGridView)
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
                MessageBox.Show(ex.Message,"Error Entry",MessageBoxButtons.OK, MessageBoxIcon.Error);   
            }
        }

        private void btnDeleteDoctor_Click(object sender, EventArgs e)
        {
            if (txtSearchToDelete.Text == "" || txtSearchToDelete.Text == "Search")
            {
                MessageBox.Show("Please select or enter DoctorID to delete.", "Info Entry", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                string DoctorID = txtSearchToDelete.Text;
                DialogResult result = MessageBox.Show("Are you sure you want to delete DoctorID " + DoctorID + "?\n" +
                    "Data will be deleted permanently.", "Conform Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    bool IsDelete = DoctorDB.Delete(DoctorID);
                    if (IsDelete)
                    {
                        MessageBox.Show("Data delete successfully.", "Info Entry", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("DoctorID " + DoctorID + " not found.\n" + "Data delete failed.", "Info Entry", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtSearchToDelete.Text = "";
                        txtSearchToDelete.Focus();
                    }
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
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (textChange() != true)
            {
                if (IsValideDataToUpdate())
                {

                    doctor = new Doctors();
                    doctor.Id = txtUpDocID.Text;
                    doctor.FirstName = txtUpDocFirstName.Text;
                    doctor.LastName = txtUpDocLastName.Text;
                    doctor.Gender = cboUpDocGender.SelectedItem.ToString();
                    doctor.ProfessionalType = cboUpProfessionalType.SelectedItem.ToString();
                    doctor.Hireddate = txtUpDocHiredDate.Text;
                    doctor.Salary = Convert.ToSingle(txtUpDocSalary.Text);
                    doctor.Contact = txtUpDocContact.Text;
                    doctor.Address = txtUpDocAddress.Text;
                    doctor.DateOfBirth = txtUpDocDateofBirth.Text;
                    doctor.Status = cboUpDocStatus.SelectedItem.ToString();
                    string DoctorID = txtSearchToUpdate.Text;
                    bool IsUpdate = DoctorDB.UpdateDoctor(doctor, DoctorID);
                    if (IsUpdate)
                    {
                        MessageBox.Show("Data update successfully", "Info Entry", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearUpdate();
                    }
                    else
                    {
                        MessageBox.Show("Data update failed", "Info Entry", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }
            else
            {
                MessageBox.Show("Data update failed.\n\n" +
                                "It seems like you didn't change anything!\n\n"+
                                "Please make any change to update!", "Info Entry", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool textChange()
        {

            return doctor.Id == txtUpDocID.Text &&
            doctor.FirstName == txtUpDocFirstName.Text &&
            doctor.LastName == txtUpDocLastName.Text &&
            doctor.Gender == cboUpDocGender.SelectedItem.ToString() &&
            doctor.ProfessionalType == cboUpProfessionalType.SelectedItem.ToString() &&
            doctor.Hireddate == txtUpDocHiredDate.Text &&
            doctor.Salary == Convert.ToSingle(txtUpDocSalary.Text) &&
            doctor.Contact == txtUpDocContact.Text &&
            doctor.Address == txtUpDocAddress.Text &&
            doctor.DateOfBirth == txtUpDocDateofBirth.Text&&
            doctor.Status == cboUpDocStatus.SelectedItem.ToString();
            
        }
        private bool IsValideDataToUpdate()
        {
            return Validation.IsPresent(txtUpDocID, "DoctorID") &&
                   Validation.IsPresent(txtUpDocFirstName, "FirstName") &&
                   Validation.IsPresent(txtUpDocLastName, "LastName") &&
                   Validation.IsItemSelect(cboUpDocGender, "Gender") &&
                   Validation.IsItemSelect(cboUpProfessionalType, "ProfessionalTyp") &&
                   Validation.IsPresent(txtUpDocHiredDate, "Hired Date") &&
                   Validation.IsPresent(txtUpDocSalary, "Salary") &&
                   Validation.IsFloat(txtUpDocSalary, "Salary") &&
                   Validation.IsPresent(txtUpDocContact, "Contact") &&
                   Validation.IsPresent(txtUpDocAddress, "Address") &&
                   Validation.IsPresent(txtUpDocDateofBirth, "Date Of Birth") &&
                   Validation.IsItemSelect(cboUpDocStatus, "Status");
        }
        private void SearchToUpdate_KeyDown(Object sender,KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                string DoctorID=txtSearchToUpdate.Text;
                DataTable table= new DataTable();
                table=DoctorDB.Search(DoctorID);
                if (table != null)
                {
                    cboUpProfessionalType.Items.Clear();
                    cboUpDocGender.Items.Clear();
                    cboUpDocStatus.Items.Clear();
                    cboUpDocGender.Items.Add("Male");
                    cboUpDocGender.Items.Add("Female");
                    cboUpProfessionalType.Items.Add("Doctor");
                    cboUpProfessionalType.Items.Add("Nurse");
                    cboUpDocStatus.Items.Add("Active");
                    cboUpDocStatus.Items.Add("Retired");
                    String gender= table.Rows[0]["Gender"].ToString();
                    String Professional= table.Rows[0]["ProfessionalType"].ToString();
                    String Status= table.Rows[0]["CurStatus"].ToString();
                    txtUpDocID.Text = table.Rows[0]["DoctorID"].ToString();
                    txtUpDocFirstName.Text= table.Rows[0]["FirstName"].ToString();
                    txtUpDocLastName.Text = table.Rows[0]["LastName"].ToString();
                    cboUpDocGender.SelectedItem = gender;
                    cboUpProfessionalType.SelectedItem = Professional;
                    txtUpDocHiredDate.Text = table.Rows[0]["HiredDate"].ToString();
                    txtUpDocSalary.Text = table.Rows[0]["Salary"].ToString();
                    txtUpDocContact.Text = table.Rows[0]["Contact"].ToString();
                    txtUpDocAddress.Text = table.Rows[0]["CurAddress"].ToString();
                    txtUpDocDateofBirth.Text = table.Rows[0]["DateOFBirth"].ToString();
                    cboUpDocStatus.SelectedItem = Status;
                    doctor=new Doctors();
                    doctor.Id=txtUpDocID.Text;
                    doctor.FirstName=txtUpDocFirstName.Text;
                    doctor.LastName=txtUpDocLastName.Text;
                    doctor.Gender=gender;
                    doctor.ProfessionalType = Professional;
                    doctor.Hireddate = txtUpDocHiredDate.Text;
                    doctor.Salary = Convert.ToSingle(txtUpDocSalary.Text);
                    doctor.Contact = txtUpDocContact.Text;
                    doctor.Address = txtUpDocAddress.Text;
                    doctor.DateOfBirth = txtUpDocDateofBirth.Text;
                    doctor.Status= Status;

                }
                else
                {
                    MessageBox.Show("DoctorID " + DoctorID + " not found.\n"+
                        "Please enter the correct data.", "Info Entry", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ClearUpdate();
                }
            }
        }
        private void ClearUpdate()
        {
            txtSearchToUpdate.Text = "";
            txtSearchToUpdate.Focus();
            txtUpDocID.Text = "";
            txtUpDocFirstName.Text = "";
            txtUpDocLastName.Text = "";
            cboUpDocGender.SelectedIndex = -1;
            cboUpProfessionalType.SelectedIndex = -1;
            txtUpDocHiredDate.Text = "";
            txtUpDocSalary.Text = "";
            txtUpDocContact.Text = "";
            txtUpDocAddress.Text = "";
            txtUpDocDateofBirth.Text = "";
            cboUpDocStatus.SelectedIndex = -1;

        }

        private void tbnCancelUpdate_Click(object sender, EventArgs e)
        {
            ClearUpdate();
        }

        private void UserConDoctor_Load(object sender, EventArgs e)
        {
            dataGridView1.RowsDefaultCellStyle.ForeColor = Color.Black;
            ExecuteDoctorDisplay();
        }
        public void RefreshData()
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)RefreshData);
                return;
            }
            ExecuteDoctorDisplay();
        }
    }
}
    