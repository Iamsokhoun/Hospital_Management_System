using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hospital_Management
{
    public static class RoomDB
    {
        public static bool Insert(Room room)
        {
            bool IsInsert = false;
            string query = "INSERT INTO Room (RoomID, RoomName, RoomType, Capacity, CurStatus) " +
               "VALUES (@RoomID, @RoomName, @RoomType, @Capacity, @CurStatus)";

            SqlConnection con = DBConnection.getConnection();
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@RoomID", room.RoomID);
            cmd.Parameters.AddWithValue("@RoomName", room.Name);
            cmd.Parameters.AddWithValue("@RoomType", room.Roomtype);
            cmd.Parameters.AddWithValue("@Capacity", room.Capacity);
            cmd.Parameters.AddWithValue("@CurStatus", room.Status);
            try
            {
                con.Open();
                int effectrow = cmd.ExecuteNonQuery();
                if (effectrow > 0) {
                    IsInsert = true;
                }
            } catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Error Entry", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return IsInsert;
        }
        public static DataTable Search(string enterID)
        {
            SqlConnection con = DBConnection.getConnection();
            string query = "Select * From Room where " + "RoomID=@RoomID";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@RoomID", enterID);
            DataTable dataTable = new DataTable();
            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    dataTable.Load(reader);
                }
                else
                {
                    dataTable = null;
                }

            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Info Entry", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dataTable;
        }
        public static bool Delete(string enterID)
        {
            bool IsDelete = false;
            SqlConnection con = DBConnection.getConnection();
            String query = "Delete from Room where RoomID=@RoomID";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@RoomID", enterID);
            try
            {
                con.Open();
                int effectrows = cmd.ExecuteNonQuery();
                if (effectrows > 0)
                {
                    IsDelete = true;
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Room is being occupied by patients!", "Info Entry", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return IsDelete;

        }
        public static bool Update (Room room,string enterID)
        {
            bool IsUpdate=false;
            SqlConnection con = DBConnection.getConnection();
            string query = "Update Room Set " +
                "RoomID=@RoomID," +
                " RoomName=@RoomName," +
                " RoomType=@RoomType," +
                " Capacity= @Capacity," +
                " CurStatus=@CurStatus " +
                "where RoomID=@EnterID";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@RoomID", room.RoomID);
            cmd.Parameters.AddWithValue("@RoomName", room.Name);
            cmd.Parameters.AddWithValue("@RoomType", room.Roomtype);
            cmd.Parameters.AddWithValue("@Capacity", room.Capacity);
            cmd.Parameters.AddWithValue("@CurStatus", room.Status);
            cmd.Parameters.AddWithValue("@EnterID", enterID);
            try
            {
                con.Open();
                int effectrows = cmd.ExecuteNonQuery();
                if (effectrows > 0)
                {
                    IsUpdate = true;
                }
            }catch (SqlException ex)
            {
                MessageBox.Show(ex.Message,"Info Entry",MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
            return IsUpdate;
        }
        public static int RoomCapacity(string roomID)
        {
            int capacity = 0;
            string query = $"Select Capacity from Room where RoomID='{roomID}'";
            SqlConnection con = DBConnection.getConnection();
            SqlCommand cmd=new SqlCommand(query, con);
            try
            {
                con.Open();
                capacity = (int)cmd.ExecuteScalar();
            }catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            return capacity;
        }
        public static void RoomStatus(string status,string roomID)
        {
            bool IsUpdate = false;
            string query = "Update Room set CurStatus=@Status where RoomID=@RoomID";
            SqlConnection con = DBConnection.getConnection();
            SqlCommand cmd=new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Status", status);
            cmd.Parameters.AddWithValue("@RoomID", roomID);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
               
            }catch(SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }
        public static bool IfRoomAvailable(string roomID)
        {   
            bool result=false;
            string quety = "Select CurStatus from Room where RoomID=@RoomID";
            SqlConnection con=DBConnection.getConnection();
            SqlCommand cmd=new SqlCommand(quety, con);
            cmd.Parameters.AddWithValue("@RoomID", roomID);
            try
            {
                con.Open();
                string status = (string)cmd.ExecuteScalar();
                if(status=="Available")
                {
                    result = true;
                }
            }catch(SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            return result;
        }
        public static bool GetRoomStatus(string enterID)
        {
            bool result=false;
            string query = "Select CurStatus from Room where RoomID=@RoomID";
            SqlConnection con = DBConnection.getConnection();
            SqlCommand cmd= new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@RoomID", enterID);
            try
            {
                con.Open();
                string status = (string)cmd.ExecuteScalar();
                if (status == "Occupied")
                {
                    result = true;
                }
            }catch (SqlException ex)
            {
                MessageBox.Show(ex.Message,"Error Entry",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            return result;
        }
        public static int GetTotalRoom()
        {
            int count = 0;
            string query = "Select count(RoomID) from Room";
            SqlConnection con = DBConnection.getConnection();
            SqlCommand cmd = new SqlCommand(query, con);
            try
            {
                con.Open();
                count = (int)cmd.ExecuteScalar();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Error Entry", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return count;
        }
        public static int GetAvailableRoom()
        {
            int count = 0;
            string query = "Select count(CurStatus) from Room where CurStatus='Available'";
            SqlConnection con = DBConnection.getConnection();
            SqlCommand cmd = new SqlCommand(query, con);
            try
            {
                con.Open();
                count = (int)cmd.ExecuteScalar();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Error Entry", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return count;
        }
        public static int GetOccupiedRoom()
        {
            int count = 0;
            string query = "Select count(CurStatus) from Room where CurStatus='Occupied'";
            SqlConnection con = DBConnection.getConnection();
            SqlCommand cmd = new SqlCommand(query, con);
            try
            {
                con.Open();
                count = (int)cmd.ExecuteScalar();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Error Entry", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return count;
        }
        public static bool IfRoomExist(string Room)
        {
            bool result=false;
            string query = "Select COUNT(*) from Room where RoomID=@RoomID";
            SqlConnection con = DBConnection.getConnection();
            SqlCommand cmd= new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@RoomID", Room);
            try
            {
                con.Open();
                int row = (int)  cmd.ExecuteScalar();
                if (row > 0)
                {
                    result= true;
                }
            }catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Error Entry", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }

    }
    
}
