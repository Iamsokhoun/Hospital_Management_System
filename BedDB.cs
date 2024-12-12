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
    public static class BedDB
    {
        public static bool Insert(Bed bed)
        {
            bool IsInsert=false;
            SqlConnection con=DBConnection.getConnection();
            string query = "Insert INTO Bed (BedID,BedNO,CurStatus,RoomID) " +
                "Values " +"(@BedID,@BedNO,@CurStatus,@RoomID)";
            SqlCommand cmd=new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@BedID", bed.ID);
            cmd.Parameters.AddWithValue("@BedNO", bed.Bedno);
            cmd.Parameters.AddWithValue("@CurStatus", bed.Status);
            cmd.Parameters.AddWithValue("@RoomID", bed.RoomID);
            try
            {
                con.Open();
                int effectrows = cmd.ExecuteNonQuery();
                if (effectrows > 0)
                {
                    IsInsert = true;
                }
            }catch(SqlException ex)
            {
                MessageBox.Show(ex.Message,"Error Entry",MessageBoxButtons.OK,MessageBoxIcon.Error);

            }
            return IsInsert;
                
        }
        public static DataTable Search(string enterID)
        {
            SqlConnection con = DBConnection.getConnection();
            string query = "Select BedID,BedNO,CurStatus From Bed where " + "RoomID=@RoomID";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@RoomID",enterID);
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
        public static bool Delete(string enterID,string roomID)
        {
            bool IsDelete = false;
            SqlConnection con = DBConnection.getConnection();
            String query = "Delete from Bed where BedID=@BedID AND RoomID=@roomID";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@BedID", enterID);
            cmd.Parameters.AddWithValue("@roomID", roomID);
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
                MessageBox.Show(ex.Message, "Info Entry", MessageBoxButtons.OK, MessageBoxIcon.Error); ;
            }

            return IsDelete;

        }
        public static bool Update(Bed bed, string roomID,string bedID)
        {
            bool IsUpdate = false;
            SqlConnection con = DBConnection.getConnection();
            string query = "Update Bed Set " +
                " BedID=@BedID," +
                " BedNO=@BedNO," +
                " CurStatus=@CurStatus " +
                "where RoomID=@enterroom And BedID=@enterbed";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@BedID", bed.ID);
            cmd.Parameters.AddWithValue("@BedNO", bed.Bedno);
            cmd.Parameters.AddWithValue("@CurStatus", bed.Status);
            cmd.Parameters.AddWithValue("@enterroom", roomID);
            cmd.Parameters.AddWithValue("@enterbed", bedID);
            try
            {
                con.Open();
                int effectrows = cmd.ExecuteNonQuery();
                if (effectrows > 0)
                {
                    IsUpdate = true;
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Info Entry", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return IsUpdate;
        }
        public static void UpdateStatus(string status,string bed,string room)
        {
            SqlConnection con = DBConnection.getConnection();
            string query = "Update Bed set " +
                "CurStatus=@Status"+" where RoomID=@RoomID And BedID=@BedID";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Status", status);
            cmd.Parameters.AddWithValue("@BedID", bed);
            cmd.Parameters.AddWithValue("@RoomID", room);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public static int GetRecordCount(string roomid)
        {
            int counter = 0;
            string query = $"Select Count(*) from Bed where RoomID='{roomid}'";
            SqlConnection con = DBConnection.getConnection();
            SqlCommand cmd= new SqlCommand(query, con);
            try
            {
                con.Open();
                counter=(int)cmd.ExecuteScalar();

            }catch(SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            return counter;

        }
        public static int AreAllStatusSame(string enterID)
        {
            int result = 0;
            String query = "Select Count(CurStatus) From Bed where RoomID=@RoomID And CurStatus='Occupied'";
            //string query = $"Select Count(Distinct CurStatus) From Bed where RoomID='{enterID}'";
            SqlConnection con = DBConnection.getConnection();
            SqlCommand cmd=new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@RoomID", enterID);
            try
            {
                con.Open();
                result = (int)cmd.ExecuteScalar();
            }catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            return result;
        }
        public static bool IfBeddstatusOccupied(string bedID,string roomID)
        {   
            bool result = false;
            string query = "Select CurStatus from Bed where BedID=@BedID And RoomID=@RoomID";
            SqlConnection con = DBConnection.getConnection();
            SqlCommand cmd=new SqlCommand(query , con);
            cmd.Parameters.AddWithValue("@BedID", bedID);
            cmd.Parameters.AddWithValue("@RoomID", roomID);
            try
            {
                con.Open();
                string status=(string)cmd.ExecuteScalar();
                if (status == "Available")
                {
                    result = true;
                }
                
            }catch(SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            return result;
        }
        public static bool IfBedExist(string bed,string room)
        {
            bool result = false;
            string query = "Select COUNT(*) from Bed where BedID=@BedID And RoomID=@RoomID";
            SqlConnection con = DBConnection.getConnection();
            SqlCommand cmd= new SqlCommand(query , con);
            cmd.Parameters.AddWithValue("@BedID", bed);
            cmd.Parameters.AddWithValue("@RoomID", room);
            try
            {
                con.Open();
                int row = (int)cmd.ExecuteScalar();
                if (row > 0)
                {
                    result = true;
                }
            }catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            return result;
        }
        
    }
}
