using System;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ATM_Console_App;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace ATM_Console_App
{
    public static class GenerateAccountNumber
    {
        public static string NewAccountNumber()
        {
            const string numberStatic = "230111";
            Random rand = new Random();
            string accId = "";
            for (int i = 0; i < 4; i++)
            {
                int randNumber = rand.Next(0, 9);
                accId += randNumber.ToString();
            }
            string UserAccountNumber = numberStatic + accId;
            return $"{UserAccountNumber}";
        }


    }
}