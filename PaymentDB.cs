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
    public static  class PaymentDB
    {
        public static bool Pay(Payment payment)
        {
            bool IsPay = false;
            string query = "Insert Into Payment (PatientID,PaymentDate,Amount,PaymentStatus)"+
                " Values ("+
                "@PatientID,"+
                "@PaymentDate,"+
                "@Amount,"+
                "@PaymentStatus)";
            SqlConnection con=DBConnection.getConnection();
            SqlCommand cmd=new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@PatientID", payment.PatientId);
            cmd.Parameters.AddWithValue("@PaymentDate", payment.Date);
            cmd.Parameters.AddWithValue("@Amount", payment.Amount);
            cmd.Parameters.AddWithValue("@PaymentStatus", payment.Status);
            try
            {
                con.Open();
                int effectrows = cmd.ExecuteNonQuery();
                if (effectrows > 0)
                {
                    IsPay = true;
                }
            }catch(SqlException ex)
            {
                MessageBox.Show(ex.Message,"Error Entry",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            return IsPay;
        }
        public static bool Update(Payment payment,string enterID)
        {
            bool result = false;
            string query = "Update Payment set " +
                 "PaymentDate=@PaymentDate," +
                "Amount=@Amount," +
                "PaymentStatus=@PaymentStatus" +
                " Where PatientID=@PatientID";
            SqlConnection con=DBConnection.getConnection();
            SqlCommand cmd=new SqlCommand( query,con);
            cmd.Parameters.AddWithValue("@PaymentDate", payment.Date);
            cmd.Parameters.AddWithValue("@Amount", payment.Amount);
            cmd.Parameters.AddWithValue("@PaymentStatus", payment.Status);
            cmd.Parameters.AddWithValue("@PatientID", enterID);
            try
            {
                con.Open();
                int effectrows = cmd.ExecuteNonQuery();
                if(effectrows > 0)
                {
                    result = true;
                }
            }catch( SqlException ex)
            {
                MessageBox.Show(ex.Message,"Error Entry",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            return result;
        }
        public static DataTable Search(string enterID)
        {
            SqlConnection con = DBConnection.getConnection();
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
             " WHERE Payment.PatientID=@PatientID";
                 
            //string query = "Select * From Payment where " + "PatientID=@PatientID";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@PatientID", enterID);
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
            String query = "Delete from Payment where BillID=@BillID";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@BillID", enterID);
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
        public static DataTable GetRoomAndBedID(string enterID)
        {
            string query = "Select RoomID,BedID From Patient where PatientID=@PatientID";
            SqlConnection con = DBConnection.getConnection();
            SqlCommand cmd=new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@PatientID", enterID);
            DataTable table=new DataTable();
            try
            {
                con.Open();
                 SqlDataReader data= cmd.ExecuteReader();
                if (data.HasRows)
                {
                    table.Load(data);
                }
                else
                {
                    table = null;
                }
            }catch (SqlException ex)
            {
                MessageBox.Show(ex.Message,"Error Entry",MessageBoxButtons.OK,MessageBoxIcon.Error); ;
            }
            return table;
        }
    }
}
