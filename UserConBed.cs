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

namespace Hospital_Management
{
    public partial class UserConBed : UserControl
    {
        public UserConBed()
        {
            InitializeComponent();   
        }

        private Bed bed;

        private void tabControl4_SelectedIndexChanged(object sender, EventArgs e)
        {
            TabControl tabControl = sender as TabControl;
            if (tabControl.SelectedTab == tabPage1)
            {
                txtSearchToPrint.KeyDown -= new KeyEventHandler(Search_KeyDown);
                txtSearchToPrint.KeyDown += new KeyEventHandler(Search_KeyDown);
            }
            else if(tabControl.SelectedTab == tabPage5) 
            {
                txtSearchToDelete.KeyDown -= new KeyEventHandler(SearchToDelete_KeyDown);
                txtSearchToDelete.KeyDown += new KeyEventHandler(SearchToDelete_KeyDown);
                dataGridView3.CellClick += new DataGridViewCellEventHandler(dataGridView3_CellClick);
            }else if (tabControl.SelectedTab == tabPage6)
            {
                cboUpStatus.Items.Clear();
                cboUpStatus.Items.Add("Available");
                cboUpStatus.Items.Add("Occupied");
                cboUpStatus.Items.Add("Under Maintenance");
                cboUpStatus.SelectedIndex = -1;
            }
        }
        private void Search_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Prevent the beep sound on Enter key
                DataTable table = new DataTable();
                string bedID = txtSearchToPrint.Text;
                table = BedDB.Search(bedID);
                if (table != null)
                {
                    dataGridView1.DataSource = table;
                   // MessageBox.Show("Data Search successfully.", "Info Entry", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("RoomID " + bedID + " is not found.", "Info Entry", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (IsValidData())
            {
                int BedInRoom=BedDB.GetRecordCount(txtRoomID.Text);
                int roomCapacity = RoomDB.RoomCapacity(txtRoomID.Text);
                if (BedInRoom < roomCapacity)
                {
                    bed = new Bed();
                    bed.RoomID = txtRoomID.Text;
                    bed.ID = txtBedID.Text;
                    bed.Bedno = txtBedNo.Text;
                    bed.Status = "Available";
                    bool IsInsert = BedDB.Insert(bed);
                    if (IsInsert)
                    {
                        MessageBox.Show("Data insert successfully", "Info Entry", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearAdd();
                        txtRoomID.Focus();
                    }
                    else
                    {
                        MessageBox.Show("Data insert failed", "Info Entry", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("The Room is full.\nIt can hold only " + roomCapacity + " beds","Error Entry", MessageBoxButtons.OK, MessageBoxIcon.Error); ;
                }
            }
                                
        }
        private void ClearAdd()
        {
            txtRoomID.Text = "";
            txtBedID.Text = "";
            txtBedNo.Text = "";
        }
        private bool IsValidData()
        {
            return Validation.IsPresent(txtRoomID, "RoomID") &&
                Validation.IsPresent(txtBedID, "BedID") &&
                Validation.IsPresent(txtBedNo, "BedNO");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ClearAdd();
        }
        private void SearchToDelete_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Prevent the beep sound on Enter key
                DataTable table = new DataTable();
                string roomID = txtSearchToDelete.Text;
                table = BedDB.Search(roomID);
                if (table != null)
                {
                    bed=new Bed();
                    bed.RoomID = roomID;
                    dataGridView3.DataSource = table;
                    MessageBox.Show("Data Search successfully.", "Info Entry", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtSearchToDelete.Text = "";
                    txtSearchToDelete.Focus();
                }
                else
                {
                    MessageBox.Show("RoomID " +roomID + " is not found.", "Info Entry", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSearchToDelete.Text = "";
                    txtSearchToDelete.Focus();
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtSearchToDelete.Text == "" || txtSearchToDelete.Text == "Search")
            {
                MessageBox.Show("Please select or enter BedID to delete.", "Info Entry", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                string bedID = txtSearchToDelete.Text;
                DialogResult result = MessageBox.Show("Are you sure you want to delete BedID " + bedID + "?\n" +
                    "Data will be deleted permanently.", "Conform Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    bool IsDelete = BedDB.Delete(bedID,bed.RoomID);
                    if (IsDelete)
                    {
                        MessageBox.Show("Data delete successfully.", "Info Entry", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("RoomID " + bedID + " not found.\n" + "Data delete failed.", "Info Entry", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtSearchToDelete.Text = "";
                        txtSearchToDelete.Focus();
                    }
                }
            }
        }
        private void ClearUpdate()
        {
            txtUpRoomID.Text = "";
            txtUpBedID.Text = "";
            txtUpBedNO.Text = "";
            cboUpStatus.SelectedIndex=-1;
        }

        private void btnCancelUpdate_Click(object sender, EventArgs e)
        {
            ClearUpdate();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (IsValid())
            {
                bed=new Bed();
                bed.RoomID=txtUpRoomID.Text;
                bed.ID=txtUpBedID.Text;
                bed.Bedno=txtUpBedNO.Text;
                bed.Status=cboUpStatus.SelectedItem.ToString();
                bool IsUpdate = BedDB.Update(bed, txtUpRoomID.Text, txtUpBedID.Text);
                if (IsUpdate)
                {
                    if (cboUpStatus.SelectedItem == "Available")
                    {
                        RoomDB.RoomStatus("Available", txtUpRoomID.Text);
                    }
                    else
                    {
                        int capacity=RoomDB.RoomCapacity(txtUpRoomID.Text);
                        int allBed=BedDB.GetRecordCount(txtUpRoomID.Text);
                        if (capacity == allBed)
                        {
                            RoomDB.RoomStatus("Occupied", txtUpRoomID.Text);
                        }
                    }
                    MessageBox.Show("Data update successfully.","Info Entry",MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearUpdate();
                    txtUpRoomID.Focus();
                }
                else
                {
                    MessageBox.Show("Data update failed.", "Info Entry", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private bool IsValid()
        {
            return Validation.IsPresent(txtUpRoomID, "RoomID") &&
            Validation.IsPresent(txtUpBedID, "BedID") &&
            Validation.IsPresent(txtUpBedNO, "BedNO") &&
            Validation.IsItemSelect(cboUpStatus, "Status");
        }

        private void UserConBed_Load(object sender, EventArgs e)
        {
            txtSearchToPrint.KeyDown += new KeyEventHandler(Search_KeyDown);
        }

       
    }
}
