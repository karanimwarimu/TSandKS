using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;

namespace ControllerDEMO.logic
{
    public class ControllerDemo
    {

        //public string connectionString = "Data Source=localhost;Initial Catalog=JOSHYTESTIMONYdatadb;Integrated Security=True";

        public string connectionString = ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString;
        public string generateCode()
        {
            string prefix = "L";
            DateTime now = DateTime.Now;

            string monthName = now.ToString("MMMM")[0].ToString(); // First letter of month
            string dayName = now.ToString("dddd")[0].ToString();   // First letter of day
            string date = now.ToString("dd");
            string suffix = "S";
            string baseID = $"{prefix}{monthName}{dayName}{date}{suffix}";
             //return baseID;

            string lastID = null;

            int nextNum = 1;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = " SELECT MAX(LeaveTypeID) FROM EmployeeLeaveTypes WHERE LeaveTypeID LIKE @prefix + '%'";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@prefix", baseID);

                    lastID = cmd.ExecuteScalar()?.ToString();
                }

            /*    if (!String.IsNullOrEmpty(lastID) && lastID.Length >= baseID.Length + 4)
                {
                    string numPart = lastID.Substring(baseID.Length);
                    if (int.TryParse(numPart, out int lastnum))
                        {
                        nextNum = lastnum + 1;
                    }

                } */
                if (!string.IsNullOrEmpty(lastID) && lastID.StartsWith(baseID))
                {
                    string numberPart = lastID.Substring(baseID.Length);
                    if (int.TryParse(numberPart, out int lastNum))
                        nextNum = lastNum + 1;
                }
            }

            return baseID + nextNum.ToString("D3");

        }
        
        public void saveLeaveTypeID ( string leaveTypeID)
        {

            using ( SqlConnection conn = new SqlConnection(connectionString)) 
            {
                conn.Open();

                string sql = @"INSERT INTO EmployeeLeaveTypes 
                                    (LeaveTypeID, LeaveTypeName, MaxDaysPerYear, CarryForwardAllowed, PaidLeave, RequiresApproval)
                               VALUES 
                                     (@ID, @Name, @MaxDays, @CarryForward, @Paid, @Approval)";


                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue ("@ID", leaveTypeID);
                    cmd.Parameters.AddWithValue("@Name", "Generated Type");
                    cmd.Parameters.AddWithValue("@MaxDays", "30");
                    cmd.Parameters.AddWithValue("@CarryForward", false);         // default setting
                    cmd.Parameters.AddWithValue("@Paid", false);                 // default setting
                    cmd.Parameters.AddWithValue("@Approval", false);

                   
                    cmd.ExecuteNonQuery();
                }


                conn.Close();
            }

           
        }

        public byte[] ImageToByteArray(Image image)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, image.RawFormat); // You can also use ImageFormat.Png
                return ms.ToArray();
            }
        }

        public void saveLeaveTypeImage(string leaveTypeID, byte[] imageBytes)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string sql = @"UPDATE EmployeeLeaveTypes 
                       SET ImageData = @ImageData 
                       WHERE LeaveTypeID = @ID";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@ID", leaveTypeID);
                    cmd.Parameters.Add("@ImageData", System.Data.SqlDbType.VarBinary).Value = (object)imageBytes ?? DBNull.Value;

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected == 0)
                    {
                        throw new Exception("No record found with the given LeaveTypeID.");
                    }
                }
            }
        }


        public void saveUploadedFile( string leaveTypeID , byte[] fileBytes)
        {
            using( SqlConnection conn = new SqlConnection( connectionString ))
            {
                conn.Open();

                string sql = @" UPDATE EmployeeLeaveTypes  SET FileData  = @fileDataAlt Where LeaveTypeID = @ID ";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@ID",leaveTypeID);
                    cmd.Parameters.AddWithValue("@FileDataAlt " , System.Data.SqlDbType.VarBinary).Value = (object)fileBytes ?? DBNull.Value ;

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected == 0)
                    {
                        throw new Exception("No record found with the given LeaveTypeID.");
                    }
                }
            }
        }
     
        public HttpContent CreatePdfContent(string filePath, out string filename, string formFieldName = "file")
        {
            if (!File.Exists(filePath))
                throw new FileNotFoundException("The specified PDF file does not exist.", filePath);

            filename = Path.GetFileName(filePath); // Now it’s actually used
            var fileStream = File.OpenRead(filePath);
            var fileContent = new StreamContent(fileStream);
            fileContent.Headers.ContentType = new MediaTypeHeaderValue("application/pdf");

            var multipart = new MultipartFormDataContent();
            multipart.Add(fileContent, formFieldName, filename);

            return multipart;
        }



    }
}
