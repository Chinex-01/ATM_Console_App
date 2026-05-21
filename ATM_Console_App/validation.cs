
using System;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ATM_Console_App;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
namespace ATM_Console_App
{
    class validation
    {
        public static void good()
        {
            string Name;

            while (true)
            {
                Console.Write("Please enter your name: ");
                Name = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(Name))
                {
                    Console.WriteLine("Name cannot be empty.");
                    continue;
                }
                break;
            }
            string Email;
            while (true)
            {
                Console.Write("Please enter your email address: ");
                Email = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(Email))
                {
                    Console.WriteLine("Email cannot be empty.");
                    continue;
                }

                if (!Email.Contains("@"))
                {
                    Console.WriteLine("Invalid email. Email must contain @");
                    continue;
                }
                break;
            }
            //check is phone number is null or empty
            //check is phone nukber length is exactly 11 digits
            //check that phone number does not contain alphabet
            string phoneNumber;
            while (true)
            {
                Console.Write(" Enter your phone number: ");
              phoneNumber = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(phoneNumber))
                {
                    Console.WriteLine("Phone number cannot be empty.");
                    continue;
                }
                if (phoneNumber.Length != 11)
                {
                    Console.WriteLine("Phone number must be exactly 11 digits.");
                    continue;
                }
                break;
            }
            Console.Write(" Enter your BVN: ");
            string bvn = Console.ReadLine();
            try
            {
                Convert.ToInt64(bvn);
            }
            catch
            {
                Console.WriteLine("Invalid BVN format. Use numbers only.");
                return;
            }

            Console.Write(" Please create a pin: ");
            int password = 0;
            try
            {
                Convert.ToInt32(password);

            }
            catch
            {
                Console.WriteLine("Invalid PIN format. Use numbers only.");
                return;
            }
            string AccountNumber = GenerateAccountNumber.NewAccountNumber();
            Console.WriteLine();
            Console.WriteLine("Your new account Number: " + AccountNumber);
            Console.WriteLine();
            Console.WriteLine(" Registration successful!");
            Console.WriteLine();
            Customer newCustomer = new Customer
            {
                Name = Name,
                Email = Email,
                Pin = password,
                AccountNummber = AccountNumber,
                phoneNumber = phoneNumber,
                amount = 0
            };

            string connectionString =
         @"Server=(localdb)\MSSQLLocalDB;Database=ATM_Console_App;Trusted_Connection=True;";


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //open connection
                connection.Open();
                string query = "INSERT INTO Atm_nonso (Name, AccountNumber ,Email, pin , PhoneNumber , balance )" + "VALUES (@Name, @AccountNumber, @Email , @pin ,@phoneNumber, @amount )";


                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Name", newCustomer.Name);
                    cmd.Parameters.AddWithValue("@AccountNumber", newCustomer.AccountNummber);
                    cmd.Parameters.AddWithValue("@Email", newCustomer.Email);
                    cmd.Parameters.AddWithValue("@phoneNumber", newCustomer.phoneNumber);
                    cmd.Parameters.AddWithValue("@pin", newCustomer.Pin);
                    cmd.Parameters.AddWithValue("@amount", newCustomer.amount);


                    Console.WriteLine($"Name: {newCustomer.Name}");
                    Console.WriteLine($"Account Number: {newCustomer.AccountNummber}");
                    Console.WriteLine($"Email: {newCustomer.Email}");
                    Console.WriteLine($"Phone Number: {newCustomer.phoneNumber}");
                    Console.WriteLine($"Pin: {newCustomer.Pin}");
                    Console.WriteLine($"balance:{newCustomer.amount}");

                    cmd.ExecuteNonQuery();
                }
            }
            Console.WriteLine(" your information has been stored:");
            Console.WriteLine(" welcome " + Name + "!!");
            Console.Write("Enter your account number: ");
            string enteredaccountNumber = Console.ReadLine();
            if (enteredaccountNumber == AccountNumber)
            {
                bool isLoggedIn = false;
                while (true)
                {
                    Console.Write("Enter your PIN: ");

                    int enteredPin = Convert.ToInt32(Console.ReadLine());

                    if (enteredPin == password)
                    {
                        Console.WriteLine("Login successful! Welcome " + Name + "!!");
                        isLoggedIn = true;
                        Deposit.deposit(enteredaccountNumber);
                    }
                    else
                    {
                        Console.WriteLine("You entered a wrong PIN. Try again.");
                    }
                    break;
                }
            }
            else
            {
                Console.WriteLine("wrong pin, restart your app");
                return;
            }
        }
    }
}