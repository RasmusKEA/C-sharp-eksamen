using System;
using System.Data;
using System.Net;
using System.Net.Http;
using System.Web;
using ChristiansØ_Web_API.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;

namespace ChristiansØ_Web_API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController
    {
        private readonly IConfiguration _configuration;

        public UserController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        [ActionName("GetUsers")]
        public JsonResult GetUsers()
        {
            string query = @"
                select userid, username, fullname, password from usertable
                ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("UserAppCon");
            MySqlDataReader myReader;
            using (MySqlConnection mycon = new MySqlConnection(sqlDataSource))
            {
                mycon.Open();
                using(MySqlCommand mySqlCommand = new MySqlCommand(query, mycon))
                {
                    myReader = mySqlCommand.ExecuteReader();
                    table.Load(myReader);
                    
                    myReader.Close();
                    mycon.Close();
                }
            }
            return new JsonResult(table);
        }

        [HttpPost]
        [ActionName("PostUser")]
        public JsonResult PostUser(User user)
        {
            string query = @"insert into usertable (username, fullname, password) values (@Username, @FullName, @Password)";
            
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("UserAppCon");
            MySqlDataReader myReader;
            using (MySqlConnection mycon = new MySqlConnection(sqlDataSource))
            {
                mycon.Open();
                using(MySqlCommand mySqlCommand = new MySqlCommand(query, mycon))
                {
                    mySqlCommand.Parameters.AddWithValue("@Username", user.Username);
                    mySqlCommand.Parameters.AddWithValue("@FullName", user.FullName);
                    mySqlCommand.Parameters.AddWithValue("@Password", user.Password);
                    
                    myReader = mySqlCommand.ExecuteReader();
                    table.Load(myReader);
                    
                    myReader.Close();
                    mycon.Close();
                }
            }
            return new JsonResult("Added Successfully");
        }
        
        [HttpPut]
        [ActionName("PutUser")]
        public JsonResult PutUser(User user)
        {
            string query = @"update usertable
                            set username = @Username
                            where userid = @UserId";
            
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("UserAppCon");
            MySqlDataReader myReader;
            using (MySqlConnection mycon = new MySqlConnection(sqlDataSource))
            {
                mycon.Open();
                using(MySqlCommand mySqlCommand = new MySqlCommand(query, mycon))
                {
                    mySqlCommand.Parameters.AddWithValue("@Userid", user.UserId);
                    mySqlCommand.Parameters.AddWithValue("@Username", user.Username);
                    
                    myReader = mySqlCommand.ExecuteReader();
                    table.Load(myReader);
                    
                    myReader.Close();
                    mycon.Close();
                }
            }
            return new JsonResult("Updated Successfully");
        }
        
        [HttpDelete("{id}")]
        [ActionName("DeleteUser")]
        public JsonResult DeleteUser(int id)
        {
            string query = @"delete from usertable
                            where userid = @UserId";
            
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("UserAppCon");
            MySqlDataReader myReader;
            using (MySqlConnection mycon = new MySqlConnection(sqlDataSource))
            {
                mycon.Open();
                using(MySqlCommand mySqlCommand = new MySqlCommand(query, mycon))
                {
                    mySqlCommand.Parameters.AddWithValue("@UserId", id);

                    myReader = mySqlCommand.ExecuteReader();
                    table.Load(myReader);
                    
                    myReader.Close();
                    mycon.Close();
                }
            }
            return new JsonResult("Deleted Successfully");
        }
        
        [HttpPost]
        [ActionName("VerifyUser")]
        public ActionResult VerifyUser(User user)
        {
            string query = @"SELECT EXISTS(SELECT * FROM usertable WHERE username = @Username and password = @Password) AS Verified";
            string result = "";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("UserAppCon");
            MySqlDataReader myReader;
            using (MySqlConnection mycon = new MySqlConnection(sqlDataSource))
            {
                mycon.Open();
                using(MySqlCommand mySqlCommand = new MySqlCommand(query, mycon))
                {
                    mySqlCommand.Parameters.AddWithValue("@Username", user.Username);
                    mySqlCommand.Parameters.AddWithValue("@Password", user.Password);
                    
                    result = mySqlCommand.ExecuteScalar().ToString();

                    myReader = mySqlCommand.ExecuteReader();
                    table.Load(myReader);
                    
                    myReader.Close();
                    mycon.Close();
                }
            }

            if (result.Equals("1"))
            {
                return new StatusCodeResult(200);
            }
            return new StatusCodeResult(400);
        }
    }
}