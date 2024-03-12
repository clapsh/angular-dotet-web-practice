using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3
{
    public class Test
    {
        public string ConnentionString { get; set; }
        
        public Test(string connectionString)
        {
            this.ConnentionString = connectionString;
        }

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnentionString);
        }
    }
}