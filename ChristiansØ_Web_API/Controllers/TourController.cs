using Microsoft.AspNetCore.Mvc;
using System;
using System.Data;
using System.Net;
using System.Net.Http;
using System.Web;
using ChristiansØ_Web_API.Model;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;


namespace ChristiansØ_Web_API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TourController
    {
        
        private readonly IConfiguration _configuration;

        public TourController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        
        [HttpGet]
        [ActionName("GetTours")]
        public JsonResult GetTours()
        {
            string query = @"
                select idroutes, image, description, milestones, distance, time from tours
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
    }
}