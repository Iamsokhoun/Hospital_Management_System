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
    public partial class UserConRoom : UserControl
    {
        public UserConRoom()
        {
            InitializeComponent();
        }
        private Room room;
        private void Room_Load(object sender, EventArgs e)
        {
            string query = "Select * from Room";
            Display(query, dataGridView1);
        }
        public void RefreshData()
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)RefreshData);
                return;
            }
            string query = "Select * from Room";
            Display(query, dataGridView1);
        }
        private void tabControl3_SelectedIndexChanged(object sender, EventArgs e)
        {
            TabControl tabControl = sender as TabControl;
            if (tabControl.SelectedTab == tabPage1)
            {
                string query = "Select * from Room";
                Display(query, dataGridView1);
            }
            else if (tabControl.SelectedTab == tabPage2)
            {

                string[] roomType = { "ICU", "General ward", "Private Room", "Operating Room" };
                cboRoomType.Items.Clear();
                foreach (string rooms in roomType)
                {
                    cboRoomType.Items.Add(rooms);
                }
                cboRoomType.SelectedIndex = -1;

            }
            else if (tabControl.SelectedTab == tabPage4)
            {
                txtSearch.KeyDown -= new KeyEventHandler(Search_KeyDown);
                txtSearch.KeyDown += new KeyEventHandler(Search_KeyDown);
            }
            else if (tabControl.SelectedTab == tabPage5)
            {
                string query = "Select * from Room";
                Display(query, dataGridView3);
                dataGridView3.CellClick += new DataGridViewCellEventHandler(dataGridView3_CellClick);

            }
            else if (tabControl.SelectedTab == tabPage6)
            {
                txtSearchToUpdate.KeyDown += new KeyEventHandler(SearchToUpdate_KeyDown);

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
            txtRoomID.Text = "";
            txtRoomName.Text = "";
            cboRoomType.SelectedIndex = -1;
            txtRoomCapacity.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ClearAdd();
        }
        private bool IsValidData()
        {
            return
            Validation.IsPresent(txtRoomID, "RoomID") &&
            Validation.IsPresent(txtRoomName, "RoomName") &&
            Validation.IsItemSelect(cboRoomType, "RoomType") &&
            Validation.IsPresent(txtRoomCapacity, "Capacity");
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (IsValidData())
            {
                room = new Room();
                room.RoomID = txtRoomID.Text;
                room.Name = txtRoomName.Text;
                room.Roomtype = cboRoomType.SelectedItem.ToString();
                room.Capacity = Convert.ToInt32(txtRoomCapacity.Text);
                room.Status = "Available";
                bool Isinsert = RoomDB.Insert(room);
                if (Isinsert)
                {
                    MessageBox.Show("Data insert successfully.", "Info Entry", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearAdd();

                }
                else
                {
                    MessageBox.Show("Data insert failed.", "Error Entry", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void Search_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Prevent the beep sound on Enter key
                string RoomID = txtSearch.Text;
                DataTable table = new DataTable();
                table = RoomDB.Search(RoomID);
                if (table != null)
                {
                    dataGridView2.DataSource = table;
                    MessageBox.Show("Data Search successfully.", "Info Entry", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("DoctorID " + RoomID + " is not found.", "Info Entry", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                MessageBox.Show("Please select or enter RoomID to delete.", "Info Entry", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                string roomID = txtSearchToDelete.Text;
                DialogResult result = MessageBox.Show("Are you sure you want to delete RoomID " + roomID + "?\n" +
                    "Data will be deleted permanently.", "Conform Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    bool IsDelete = RoomDB.Delete(roomID);
                    if (IsDelete)
                    {
                        MessageBox.Show("Data delete successfully.", "Info Entry", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("DoctorID " + roomID + " not found.\n" + "Data delete failed.", "Info Entry", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                string RoomID = txtSearchToUpdate.Text;
                DataTable table = new DataTable();
                table = RoomDB.Search(RoomID);
                if (table != null)
                {
                    string[] roomType = { "ICU", "General ward", "Private Room", "Operating Room" };
                    cboUpRoomType.Items.Clear();
                    foreach (string rooms in roomType)
                    {
                        cboUpRoomType.Items.Add(rooms);
                    }
                    cboUpRoomStatus.Items.Clear();
                    cboUpRoomStatus.Items.Add("Available");
                    cboUpRoomStatus.Items.Add("Occupied");
                    cboUpRoomStatus.Items.Add("Under maintenance");
                    string type = table.Rows[0]["RoomType"].ToString();
                    string status = table.Rows[0]["CurStatus"].ToString();
                    txtUpRoomID.Text = table.Rows[0]["RoomID"].ToString();
                    txtUpRoomName.Text = table.Rows[0]["RoomName"].ToString();
                    cboUpRoomType.SelectedItem = type;
                    txtUpRoomCapacity.Text = table.Rows[0]["Capacity"].ToString();
                    cboUpRoomStatus.SelectedItem = status;
                    room=new Room();
                    room.RoomID = txtUpRoomID.Text;
                    room.Name = txtUpRoomName.Text;
                    room.Roomtype = type;
                    room.Capacity = Convert.ToInt32(txtUpRoomCapacity.Text);
                    room.Status = status;
                }
                else
                {
                    MessageBox.Show("RoomID "+RoomID+" not found.","Error Entry",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    txtSearchToUpdate.Text = "";
                    txtSearchToUpdate.Focus();
                }
            }
        }
        private void ClearUpdate()
        {
            txtSearchToUpdate.Text = "";
            txtUpRoomID.Text = "";
            txtUpRoomName.Text = "";
            cboUpRoomType.SelectedIndex = -1;
            txtUpRoomCapacity.Text = "";
            cboUpRoomStatus.SelectedIndex = -1;
        }

        private void btnCancelUpdate_Click(object sender, EventArgs e)
        {
            ClearUpdate();
        }
        private bool IsValid()
        {
            return Validation.IsPresent(txtUpRoomID, "RoomID") &&
            Validation.IsPresent(txtUpRoomName, "RoomName") &&
            Validation.IsItemSelect(cboUpRoomType, "RoomType") &&
            Validation.IsPresent(txtUpRoomCapacity, "Capacity") &&
            Validation.IsInteger(txtUpRoomCapacity,"Capacity")&&
            Validation.IsItemSelect(cboUpRoomStatus, "Status");
            }
        private bool textChange()
        {
            return
                room.RoomID == txtUpRoomID.Text &&
                room.Name == txtUpRoomName.Text &&
                room.Roomtype == cboUpRoomType.SelectedItem.ToString() &&
                room.Capacity == Convert.ToInt32(txtUpRoomCapacity.Text) &&
                room.Status == cboUpRoomStatus.SelectedItem.ToString();
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (textChange()!=true)
            {
                if (room.Capacity == Convert.ToInt32(txtUpRoomCapacity.Text))
                {
                    if (IsValid())
                    {
                        room = new Room();
                        room.RoomID = txtUpRoomID.Text;
                        room.Name = txtUpRoomName.Text;
                        room.Roomtype = cboUpRoomType.SelectedItem.ToString();
                        room.Capacity = Convert.ToInt32(txtUpRoomCapacity.Text);
                        room.Status = cboUpRoomStatus.SelectedItem.ToString();
                        bool IsUpdate = RoomDB.Update(room, txtSearchToUpdate.Text);
                        if (IsUpdate)
                        {
                            MessageBox.Show("Data update successfully.", "Info Entry", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ClearUpdate();
                            txtSearchToUpdate.Focus();
                        }
                        else
                        {
                            MessageBox.Show("Data update failed.", "Info Entry", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    if(room.Capacity < Convert.ToInt32(txtUpRoomCapacity.Text))
                    {
                        bool isRoomAvailable = RoomDB.IfRoomAvailable(txtSearchToUpdate.Text);
                        if (isRoomAvailable)
                        {
                            room = new Room();
                            room.RoomID = txtUpRoomID.Text;
                            room.Name = txtUpRoomName.Text;
                            room.Roomtype = cboUpRoomType.SelectedItem.ToString();
                            room.Capacity = Convert.ToInt32(txtUpRoomCapacity.Text);
                            room.Status = cboUpRoomStatus.SelectedItem.ToString();
                            bool IsUpdate = RoomDB.Update(room, txtSearchToUpdate.Text);
                            if (IsUpdate)
                            {
                                MessageBox.Show("Data update successfully.", "Info Entry", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                            room = new Room();
                            room.RoomID = txtUpRoomID.Text;
                            room.Name = txtUpRoomName.Text;
                            room.Roomtype = cboUpRoomType.SelectedItem.ToString();
                            room.Capacity = Convert.ToInt32(txtUpRoomCapacity.Text);
                            room.Status = "Available";
                            bool IsUpdate = RoomDB.Update(room, txtSearchToUpdate.Text);
                            if (IsUpdate)
                            {
                                MessageBox.Show("Data update successfully.", "Info Entry", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                ClearUpdate();
                                txtSearchToUpdate.Focus();
                            }
                            else
                            {
                                MessageBox.Show("Data update failed.", "Info Entry", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    else
                    {
                        if (RoomDB.IfRoomAvailable(room.RoomID)!=true)
                        {
                            MessageBox.Show("The room is being taken!\n\n" +
                                            "You can't lower the capacity!\n\n" +
                                            "Data update failed!!", "Error Entry", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Data update failed!\n\n"+
                    "It seems like you didn't change anything.\n\n"+
                    "Please make any change to update!!", "Info Entry", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}
