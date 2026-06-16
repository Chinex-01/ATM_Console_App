using System;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ATM_Console_App;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
namespace ATM_Console_App
{
    public class Customer
    {
        public string Name { get; set; }
        public string AccountNummber { get; set; }
        public int Pin { get; set; }
        public string Email { get; set; }
        public double amount { get; set; }
        public string phoneNumber { get; set; }
    }
}