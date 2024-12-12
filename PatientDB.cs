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
    public static class PatientDB
    {
        public static bool Insert(Patient patient)
        {
            bool IsInsert=false;
           SqlConnection con=DBConnection.getConnection();
            string query = "INSERT INTO Patient" +
                 "(PatientID," +
                 "FirstName," +
                 "LastName," +
                 "RegisterDate," +
                 "Gender," +
                 "Disease," +
                 "Contact," +
                 "DateOFBirth," +
                 "CurAddress," +
                 "TreatBY," +
                 "CurStatus," +
                 "RoomID," +
                 "BedID)" +
                 "Values " +
                 "(@PatientID," +
                 "@FirstName," +
                 "@LastName," +
                 "@DateRegister," +
                 "@Gender," +
                 "@Disease," +
                 "@Contact," +
                 "@DateOFBirth," +
                 "@CurAddress," +
                 "@TreatBY," +
                 "@CurStatus," +
                 "@RoomID," +
                 "@BedID)";
            SqlCommand cmd=new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@PatientID", patient.Id);
            cmd.Parameters.AddWithValue("@FirstName", patient.FirstName);
            cmd.Parameters.AddWithValue("@LastName", patient.LastName);
            cmd.Parameters.AddWithValue("@DateRegister", patient.RegisterDate);
            cmd.Parameters.AddWithValue("@Gender", patient.Gender);
            cmd.Parameters.AddWithValue("@Disease", patient.Disease);
            cmd.Parameters.AddWithValue("@Contact", patient.Contact);
            cmd.Parameters.AddWithValue("@DateOFBirth", patient.DateOfBirth);
            cmd.Parameters.AddWithValue("@CurAddress", patient.Address);
            cmd.Parameters.AddWithValue("@TreatBY", patient.TreatBy);
            cmd.Parameters.AddWithValue("@CurStatus", patient.Status);
            cmd.Parameters.AddWithValue("@RoomID", patient.RoomNo ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@BedID", patient.BedNo ?? (object)DBNull.Value);
            try
            {
                con.Open();
                int effectrows = cmd.ExecuteNonQuery();
                if (effectrows > 0)
                {
                    IsInsert = true;
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message,"Error Entry",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            return IsInsert;
        }
      
        public static DataTable Search(string SearchID)
        {
            SqlConnection con = DBConnection.getConnection();
            string query = "Select * From Patient where " + "PatientID=@SearchID";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@SearchID", SearchID);
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
        public static bool Delete(string deleteID)
        {
            bool IsDelete = false;
            SqlConnection con = DBConnection.getConnection();
            String query = "Delete from Patient where PatientID=@EnterID";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@EnterID", deleteID);
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
        public static bool Update(Patient patient,string updateID)
        {
            bool IsUpdate = false;
            SqlConnection con = DBConnection.getConnection();
            string query = "Update Patient set " +
                 "PatientID=@PatientID," +
                 "FirstName=@FirstName," +
                 "LastName=@LastName," +
                 "Gender=@Gender," +
                 "Disease=@Disease," +
                 "Contact=@Contact," +
                 "DateOFBirth=@DateOFBirth," +
                 "CurAddress=@CurAddress," +
                 "TreatBY=@TreatBY," +
                 "CurStatus=@CurStatus," +
                 "RoomID=@RoomID," +
                 "BedID=@BedID" +
                " Where PatientID=@EnterID";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@PatientID", patient.Id);
            cmd.Parameters.AddWithValue("@FirstName", patient.FirstName);
            cmd.Parameters.AddWithValue("@LastName", patient.LastName);
            cmd.Parameters.AddWithValue("@Gender", patient.Gender);
            cmd.Parameters.AddWithValue("@Disease", patient.Disease);
            cmd.Parameters.AddWithValue("@Contact", patient.Contact);
            cmd.Parameters.AddWithValue("@DateOFBirth", patient.DateOfBirth);
            cmd.Parameters.AddWithValue("@CurAddress", patient.Address);
            cmd.Parameters.AddWithValue("@TreatBY", patient.TreatBy);
            cmd.Parameters.AddWithValue("@CurStatus", patient.Status);
            cmd.Parameters.AddWithValue("@RoomID", patient.RoomNo);
            cmd.Parameters.AddWithValue("@BedID", patient.BedNo);
            cmd.Parameters.AddWithValue("@EnterID", updateID);
            try
            {
                con.Open();
                int effectrows = cmd.ExecuteNonQuery();
                if (effectrows > 0)
                {
                    IsUpdate = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Entry", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return IsUpdate;
        }
        public static void UpdateState(string enterid)
        {
            SqlConnection con = DBConnection.getConnection();
            string query = "Update Patient set " +
                "CurStatus='Discharged' where PatientID=@PatientID";
            SqlCommand cmd=new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@PatientID", enterid);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }catch(SqlException)
            {
                
            }
        }
        public static int GetTotalPatient()
        {
            int count = 0;
            string query = "Select count(PatientID) from Patient";
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
        public static int GetActivePatient()
        {
            int count = 0;
            string query = "Select count(CurStatus) from Patient where CurStatus='Active'";
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
        public static int GetDischargedPatient()
        {
            int count = 0;
            string query = "Select count(CurStatus) from Patient where CurStatus='Discharged'";
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
        
      
    }
}
