﻿using System;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;

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
        public int campus_id { get; set; }
        public string campus_loc { get; set; }

//------Food var ------///
public string food_name { get; set; }
public string food_category { get; set; }

      
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
            var cmd = Conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = "INSERT INTO admins(FName,LName,Email,Password,user_Status,campus_id) values(@FName,@LName,@Email,@Password,@user_Status,@campus_id)";
            cmd.Parameters.AddWithValue("@FName", FName);
            cmd.Parameters.AddWithValue("@LName", LName);
            cmd.Parameters.AddWithValue("@Email", Email);
            cmd.Parameters.AddWithValue("@Password", Password);
            cmd.Parameters.AddWithValue("@user_Status", user_Status);
            cmd.Parameters.AddWithValue("@campus_id", campus_id);
            cmd.ExecuteNonQuery();
        }



        //For login trying
        public bool UserExists()
        {
            var cmd = Conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = "SELECT FName,user_Status,campus_loc, campus.campus_id FROM admins join campus on campus.campus_id = admins.campus_id WHERE Email=@Email AND Password=@Password";
            cmd.Parameters.AddWithValue("@Email", Email);
            cmd.Parameters.AddWithValue("@Password", Password);
            // try
            using (var userDataReader = cmd.ExecuteReader())
            {
                if (userDataReader.Read())
                {
                    FName = userDataReader["FName"].ToString();
                    user_Status = userDataReader["user_Status"].ToString();
                    campus_loc = userDataReader["campus_loc"].ToString();
                    campus_id = int.Parse(userDataReader["campus_id"].ToString());
                    return true;
                }
            }
            return false;

        }
       
       public class Food {
         public string food_name;
         public string food_category;
         public int food_id;
        public int campus_id;

            public Food(int food_id,string food_name, string food_category, int campus_id)
            {
                this.food_name = food_name;
                this.food_category = food_category;
                this.food_id = food_id;
                this.campus_id = campus_id;
            }
        }

        //----------Foods-----------//
        public List<Food> GetFood()
        {
            //created list for Foods
            List<Food> foods = new List<Food>();
            var cmd = Conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = "SELECT food_id,food_name, food_category, campus_id FROM foods WHERE campus_id=@campus_id";
            cmd.Parameters.AddWithValue("@campus_id", campus_id);
            
            using (var dr = cmd.ExecuteReader())
            {
                while (dr.Read()) {
                    foods.Add(new Food(int.Parse(dr["food_id"].ToString()), dr["food_name"].ToString(),
                        dr["food_category"].ToString(), int.Parse(dr["campus_id"].ToString())));
                }
            }
            return foods;
        }

        //-----Adding Foods----//
       public void InsertFood()
        {
            var cmd = Conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = "INSERT INTO Foods(food_name,food_category,campus_id) values(@food_name,@food_category,@campus_id)";
            cmd.Parameters.AddWithValue("@food_name",food_name);
            cmd.Parameters.AddWithValue("@food_category",food_category);
            cmd.Parameters.AddWithValue("@campus_id", campus_id);
            cmd.ExecuteNonQuery();
        }
        
       
    }
 
             
      
}




//  cmd.ExecuteNonQuery();









//NOTE: cmd