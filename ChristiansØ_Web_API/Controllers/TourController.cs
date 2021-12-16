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
                select idroutes, image, description, milestones, distance, time, name from tours
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
        
        [HttpGet("{id}")]
        [ActionName("GetTour")]
        public JsonResult GetTour(int id)
        {
            string query = @"
                select idroutes, image, description, milestones, distance, time, name from tours WHERE idroutes = @id
                ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("UserAppCon");
            MySqlDataReader myReader;
            using (MySqlConnection mycon = new MySqlConnection(sqlDataSource))
            {
                mycon.Open();
                using(MySqlCommand mySqlCommand = new MySqlCommand(query, mycon))
                {
                    mySqlCommand.Parameters.AddWithValue("@id", id);

                    myReader = mySqlCommand.ExecuteReader();
                    table.Load(myReader);
                    
                    myReader.Close();
                    mycon.Close();
                }
            }
            return new JsonResult(table);
        }
        
        [HttpDelete("{id}")]
        [ActionName("DeleteTour")]
        public ActionResult DeleteTour(int id)
        {
            string query = @"delete from tours
                            where idroutes = @id";
            
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("UserAppCon");
            MySqlDataReader myReader;
            using (MySqlConnection mycon = new MySqlConnection(sqlDataSource))
            {
                mycon.Open();
                using(MySqlCommand mySqlCommand = new MySqlCommand(query, mycon))
                {
                    mySqlCommand.Parameters.AddWithValue("@id", id);

                    myReader = mySqlCommand.ExecuteReader();
                    table.Load(myReader);
                    
                    myReader.Close();
                    mycon.Close();
                }
            }
            return new StatusCodeResult(202);
        }
        
        [HttpPost]
        [ActionName("CreateTour")]
        public ActionResult CreateTour(Tour tour)
        {
            string query = @"insert into tours (image, description, milestones, distance, time, name) values (@Image, @Description, @Milestones, @Distance, @Time, @Name)";
            
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("UserAppCon");
            MySqlDataReader myReader;
            using (MySqlConnection mycon = new MySqlConnection(sqlDataSource))
            {
                mycon.Open();
                using(MySqlCommand mySqlCommand = new MySqlCommand(query, mycon))
                {
                    mySqlCommand.Parameters.AddWithValue("@Image", tour.Image);
                    mySqlCommand.Parameters.AddWithValue("@Description", tour.Description);
                    mySqlCommand.Parameters.AddWithValue("@Milestones", tour.Milestones);
                    mySqlCommand.Parameters.AddWithValue("@Distance", tour.Distance);
                    mySqlCommand.Parameters.AddWithValue("@Time", tour.Time);
                    mySqlCommand.Parameters.AddWithValue("@Name", tour.Name);
                    
                    myReader = mySqlCommand.ExecuteReader();
                    table.Load(myReader);
                    
                    myReader.Close();
                    mycon.Close();
                }
            }
            return new StatusCodeResult(200);
        }
        
        [HttpPut]
        [ActionName("PutTour")]
        public JsonResult PutTour(Tour tour)
        {
            string query = @"update tours
                            set image = @Image, description = @Description, milestones = @Milestones, distance = @Distance, time = @Time, name = @Name
                            where idroutes = @IdRoutes";
            
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("UserAppCon");
            MySqlDataReader myReader;
            using (MySqlConnection mycon = new MySqlConnection(sqlDataSource))
            {
                mycon.Open();
                using(MySqlCommand mySqlCommand = new MySqlCommand(query, mycon))
                {
                    mySqlCommand.Parameters.AddWithValue("@IdRoutes", tour.IdRoutes);
                    mySqlCommand.Parameters.AddWithValue("@Image", tour.Image);
                    mySqlCommand.Parameters.AddWithValue("@Description", tour.Description);
                    mySqlCommand.Parameters.AddWithValue("@Milestones", tour.Milestones);
                    mySqlCommand.Parameters.AddWithValue("@Distance", tour.Distance);
                    mySqlCommand.Parameters.AddWithValue("@Time", tour.Time);
                    mySqlCommand.Parameters.AddWithValue("@Name", tour.Name);
                    
                    myReader = mySqlCommand.ExecuteReader();
                    table.Load(myReader);
                    
                    myReader.Close();
                    mycon.Close();
                }
            }
            return new JsonResult("Updated Successfully");
        }
        
    }
}