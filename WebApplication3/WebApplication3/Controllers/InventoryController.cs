using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

using WebApplication3.Models;
using WebApplication3.Services;

namespace WebApplication3.Controllers
{
    [Route("v1/")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        //dependency Injection
        private readonly IConfiguration _configuration;

        private readonly IInventoryServices _services;

        public InventoryController(IInventoryServices services, IConfiguration configuration)
        {
            _services = services;
            _configuration = configuration;
        }

        [HttpPost]
        [Route("AddItems")]
        public ActionResult<string> AddItems([FromForm] string userId, [FromForm] string userName)
        {
            string query = @"
                insert into sienna.user (userId, userName) values
                    (@userId, @userName)
            ";
           

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("ItemAppConnection");
            MySqlDataReader myReader;
            using(MySqlConnection myConn = new MySqlConnection(sqlDataSource)){
                
                myConn.Open();
                using(MySqlCommand myCommand = new MySqlCommand(query, myConn)){
                    myCommand.Parameters.AddWithValue("@userId", int.Parse(userId));
                    myCommand.Parameters.AddWithValue("@userName", userName);


                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myConn.Close();
                }
            }
            /*
            var newItems = _services.AddItems(items);

            Console.WriteLine(newItems);
            if(newItems == null)
            {
                return NotFound();
            }*/
            return new JsonResult(userName);
        }
        
        [HttpGet]
        [Route("AddItems")]
        public JsonResult GetItems()
        {
            string query = @"
                select * from sienna.user
            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("ItemAppConnection");
            MySqlDataReader myReader;
            using(MySqlConnection myConn = new MySqlConnection(sqlDataSource)){
                myConn.Open();
                using(MySqlCommand myCommand = new MySqlCommand(query, myConn)){
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myConn.Close();
                }
            }
            Console.WriteLine(table);

            return new JsonResult(table);

        }
    }
}