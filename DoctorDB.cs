using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hospital_Management
{
    public static class DoctorDB
    {
        public static bool AddDoctor(Doctors doctor)
        {
            bool Isinsert = false;
            SqlConnection con=DBConnection.getConnection();
            String Insert = "INSERT INTO Doctor(" +
                "DoctorID," +
                "FirstName," +
                "LastName," +
                "Gender," +
                "ProfessionalType," +
                "HiredDate," +
                "Salary," +
                "Contact," +
                "CurAddress," +
                "DateOFBirth," +
                "CurStatus)" +
                "Values(" +
                "@DoctorID," +
                "@FirstName," +
                "@LastName," +
                "@Gender," +
                "@ProfessionalType," +
                "@HiredDate," +
                "@Salary," +
                "@Contact," +
                "@CurAddress," +
                "@DateOFBirth," +
                "@CurStatus)";

            SqlCommand cmd=new SqlCommand(Insert, con);
            cmd.Parameters.AddWithValue("@DoctorID", doctor.Id);
            cmd.Parameters.AddWithValue("@FirstName", doctor.FirstName);
            cmd.Parameters.AddWithValue("@LastName",doctor.LastName);
            cmd.Parameters.AddWithValue("@Gender", doctor.Gender);
            cmd.Parameters.AddWithValue("@ProfessionalType", doctor.ProfessionalType);
            cmd.Parameters.AddWithValue("@HiredDate", doctor.Hireddate);
            cmd.Parameters.AddWithValue("@Salary", doctor.Salary);
            cmd.Parameters.AddWithValue("@Contact", doctor.Contact);
            cmd.Parameters.AddWithValue("@CurAddress", doctor.Address);
            cmd.Parameters.AddWithValue("@DateOFBirth", doctor.DateOfBirth);
            cmd.Parameters.AddWithValue("@CurStatus", doctor.Status);
            try
            {
                con.Open();
                int result=cmd.ExecuteNonQuery();
                if (result > 0)
                {
                    Isinsert = true;
                }

            }catch(Exception ex)
            {
                 MessageBox.Show(ex.Message, "Error Entry", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                
            }
            finally { 
                con.Close(); 
            }
            return Isinsert;
        }
        public static DataTable Search(string DoctorID)
        {
            SqlConnection con = DBConnection.getConnection();
            string query = "Select * From Doctor where " + "DoctorID=@SearchID";
            SqlCommand cmd=new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@SearchID", DoctorID);
            DataTable dataTable= new DataTable();
            try
            {
                con.Open();
                SqlDataReader reader=cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    dataTable.Load(reader); 
                }
                else
                {
                    dataTable = null;
                }

            }catch(SqlException ex)
            {
                MessageBox.Show(ex.Message, "Info Entry", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dataTable;
        }
        public static bool Delete(string DoctorID)
        {
            bool IsDelete=false;
            SqlConnection con= DBConnection.getConnection();
            String query = "Delete from Doctor where DoctorID=@EnterID";
            SqlCommand cmd=new SqlCommand(query,con);
            cmd.Parameters.AddWithValue("@EnterID", DoctorID);
            try
            {
                con.Open();
                int effectrows=cmd.ExecuteNonQuery();
                if (effectrows > 0)
                {
                    IsDelete = true;
                }
            }catch(SqlException ex)
            {
                MessageBox.Show(ex.Message, "Info Entry", MessageBoxButtons.OK, MessageBoxIcon.Error); ;
            }

            return IsDelete;

        }
        public static bool UpdateDoctor(Doctors doctor,string EnterID)
        {
            bool IsUpdate=false;
            SqlConnection con= DBConnection.getConnection();
            String query = "UPDATE Doctor SET" +
                " DoctorID=@DoctorID," +
                "FirstName=@FirstName," +
                "LastName=@LastName," +
                "Gender=@Gender," +
                "ProfessionalType=@ProfessionalType," +
                "HiredDate=@HiredDate," +
                "Salary=@Salary," +
                "Contact=@Contact," +
                "CurAddress=@CurAddress," +
                "DateOFBirth=@DateOFBirth," +
                "CurStatus=@CurStatus " +
                "Where DoctorID=@ID";
               
            SqlCommand cmd= new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@DoctorID", doctor.Id);
            cmd.Parameters.AddWithValue("@FirstName", doctor.FirstName);
            cmd.Parameters.AddWithValue("@LastName", doctor.LastName);
            cmd.Parameters.AddWithValue("@Gender", doctor.Gender);
            cmd.Parameters.AddWithValue("@ProfessionalType", doctor.ProfessionalType);
            cmd.Parameters.AddWithValue("@HiredDate", doctor.Hireddate);
            cmd.Parameters.AddWithValue("@Salary", doctor.Salary);
            cmd.Parameters.AddWithValue("@Contact", doctor.Contact);
            cmd.Parameters.AddWithValue("@CurAddress", doctor.Address);
            cmd.Parameters.AddWithValue("@DateOFBirth", doctor.DateOfBirth);
            cmd.Parameters.AddWithValue("@CurStatus", doctor.Status);
            cmd.Parameters.AddWithValue("@ID", EnterID);
            try
            {
                con.Open();
                int effectrows=cmd.ExecuteNonQuery();
                if (effectrows > 0)
                {
                    IsUpdate = true;
                }
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Entry", MessageBoxButtons.OK, MessageBoxIcon.Error); ;
            }
            return IsUpdate;
        }
       
        public static int GetTotalDoctor()
        {
            int count=0;
                string query = "Select count(DoctorID) from Doctor";
                SqlConnection con=DBConnection.getConnection();
                SqlCommand cmd=new SqlCommand(query, con);
                try
                {
                    con.Open();
                    count=(int)cmd.ExecuteScalar();
                }catch(SqlException ex)
                {
                    MessageBox.Show(ex.Message,"Error Entry",MessageBoxButtons.OK, MessageBoxIcon.Error); 
                }
            return count;
        }
        public static int GetActiveDoctor() {
            int count = 0;
            string query = "Select count(CurStatus) from Doctor where CurStatus='Active'";
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
        public static int GetRetiredDoctor()
        {
            int count = 0;
            string query = "Select count(CurStatus) from Doctor where CurStatus='Retired'";
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
