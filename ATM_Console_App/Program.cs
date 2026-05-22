
using ATM_Console_App;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace nonso
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString =
             @"Server=(localdb)\MSSQLLocalDB;Database=ATM_Console_App;Trusted_Connection=True;";

            List<Customer> customers = new List<Customer>();
            Console.WriteLine(" Welcome to First bank!! ");
            Console.WriteLine(" Do you have an account with us ");
            Console.WriteLine("1. Yes");
            Console.WriteLine("2. No");
            int answer = Convert.ToInt32(Console.ReadLine());
            if (answer == 1)
            {

                Console.Write(" Enter your account number: ");
                string accountNumber = Console.ReadLine();


                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        // Open Connection
                        connection.Open();
                        string query = "SELECT * FROM Atm_nonso";

                        using (SqlCommand cmd = new SqlCommand(query, connection))
                        {
                            SqlDataReader dr = cmd.ExecuteReader();
                            while (dr.Read())
                            {
                                Customer customer = new Customer
                                {
                                    Name = dr["Name"].ToString(),
                                    AccountNummber = dr["AccountNumber"].ToString(),
                                    Pin = Convert.ToInt32(dr["Pin"].ToString()),
                                    Email = dr["Email"].ToString(),
                                    amount = Convert.ToDouble(dr["balance"].ToString()),
                                    phoneNumber = dr["phonenumber"].ToString()
                                };
                                customers.Add(customer);

                            }
                            dr.Close();
                        }
                    }
                }
                catch (Exception ex)
                {
                }

                Customer? Custoomer = null;
                foreach (var customer in customers)
                {
                    if (customer.AccountNummber.Trim() == accountNumber)
                    {
                        Custoomer = customer;
                        break;
                    }
                }
                if (Custoomer != null)
                {
                    Console.Write("Enter your 4-digit pin: ");
                    int password = Convert.ToInt32(Console.ReadLine());

                    if (Custoomer.Pin == password)
                    {
                        Console.WriteLine(" Login successful");
                        Console.WriteLine("welcome " + Custoomer.Name);
                        Services.Service(accountNumber);
                    }
                    else
                    {
                        Console.WriteLine(" Incorrect pin, try again");
                        Console.WriteLine(" Restart your app");
                        return;
                    }
                }
                else
                {
                    Console.WriteLine(" You don't have an account with us.");
                    Console.WriteLine(" Restart your app");
                    return;
                }
            }
            else if (answer == 2)
            {
                validation.good();
            }
            else
            {
                Console.WriteLine(" you entered a wrong input, restart and enter 1 or 2.");
                return;
            }
        }
    }
}