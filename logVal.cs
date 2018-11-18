using System;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace UVI_Dining.Models
{
    public class logVal
    {
        public MySqlConnection Conn;
        public string FName { get; set; }
        public string LName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string user_Status { get; set; }
        public string campus_loc { get; set; }
        object obj;
        public logVal()
        {

            string myConnectionString;

            myConnectionString = "server=127.0.0.1;uid=root;" +
                "pwd=123@Godisgood;database=UVI_Dining";


            //Rhonda connection 
            //myConnectionString = "server=127.0.0.1;uid=root;" +
            //  "pwd=PUTyourDBpassword;database=UVI_Dining";

            try
            {
                Conn = new MySqlConnection(myConnectionString);
                Conn.Open();
            }
            catch (MySqlException ex)
            {

            }

        }

        public void Admin_login()
        {
            //  var campus_loc = Request.Form["Name"];

            var cmd = Conn.CreateCommand() as MySqlCommand;
            // MySqlCommand cmdd = new MySqlCommand("SELECT campus", Conn);
            cmd.CommandText = "INSERT INTO admins(FName,LName,Email,Password,user_Status,campus_id) values(@FName,@LName,@Email,@Password,@user_Status,1)";
            cmd.Parameters.AddWithValue("@FName", FName);
            cmd.Parameters.AddWithValue("@LName", LName);
            cmd.Parameters.AddWithValue("@Email", Email);
            cmd.Parameters.AddWithValue("@Password", Password);
            cmd.Parameters.AddWithValue("@user_Status", user_Status);



            //cmd.CommandType = System.Data.CommandType.StoredProcedure;
            //cmd.CommandText = @"INSERT INTO campus(campus_loc) values(@01);";
            //cmd.Parameters.AddWithValue("@01", campus_loc);
            //cmd.ExecuteNonQuery();
            // cmd.CommandText = @"INSERT INTO admins(FName,LName,Email,Password,user_Status,campus_id) values('Ufish','Ucat','qt@yahoo.com','123po','student',2)";
            // cmd.CommandText = @"INSERT INTO admins(FName,LName,Email,Password,user_Status,campus_id) values(@FName,@LName,@Email,@Password,@user_Status,@campus_id)";
            // cmd.Parameters.AddWithValue("@FName", FName);
            //cmd.Parameters.AddWithValue("@LName", LName);
            // cmd.Parameters.AddWithValue("@Email", Email);
            //cmd.Parameters.AddWithValue("@Password", Password);
            //cmd.Parameters.AddWithValue("@user_Status", status);
            //cmd.Parameters.AddWithValue("@campus_id", campus_loc);
            cmd.ExecuteNonQuery();

        }



        //For login trying
        public bool UserExists()
        {
            var cmd = Conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = "SELECT FName,campus_loc FROM admins join campus on campus.campus_id = admins.campus_id WHERE Email=@Email AND Password=@Password";
            cmd.Parameters.AddWithValue("@Email", Email);
            cmd.Parameters.AddWithValue("@Password", Password);

            // try
            using (var userDataReader = cmd.ExecuteReader())
            {
                if (userDataReader.Read())
                {
                    FName = userDataReader["FName"].ToString();
                    campus_loc = userDataReader["campus_loc"].ToString();
                    return true;
                }
            }
            return false;

        }
    }
}



//  cmd.ExecuteNonQuery();









//NOTE: cmd