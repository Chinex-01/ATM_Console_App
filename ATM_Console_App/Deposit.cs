


using ATM_Console_App;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
namespace ATM_Console_App

{
    public static class Deposit
    {
        public static void deposit(string accountNumber)
        {
            string connectionString =
           @"Server=(localdb)\MSSQLLocalDB;Database=ATM_Console_App;Trusted_Connection=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                double balance = 0;
                Console.WriteLine(" It's advisable for you to deposit after opening an account ");
                Console.WriteLine(" Do you want to deposit (yes / no )");
                var answr = Console.ReadLine();

                if (answr == "yes")
                {
                    Console.Write(" Enter the amount you want to deposit ?: ");
                    double amount = Convert.ToDouble(Console.ReadLine());

                    if (amount > 0 && amount % 1000 == 0)
                    {
                        balance += amount;

                        Console.WriteLine(" deposit successfully");
                        string query =
                       "UPDATE Atm_nonso set balance = ISNULL(Balance, 0) + @amt  WHERE Accountnumber=@acc";
                        using (SqlCommand cmd = new SqlCommand(query, connection))
                        {
                            cmd.Parameters.AddWithValue("@acc", accountNumber);
                            cmd.Parameters.AddWithValue("@amt", amount);

                            balance = Convert.ToDouble(cmd.ExecuteScalar());

                            Console.WriteLine("Current Balance: " + amount);
                        }
                        Console.Write(" Do you want to do another service us (yes/no): ");
                        string answerr = Console.ReadLine();
                        if (answerr == "no")
                        {
                            Console.WriteLine(" Thank you for banking with us ");
                            Console.WriteLine(" Have a nice day!!");
                            return;
                        }
                        else
                        {
                            bool running = true;
                            while (running)
                            {
                                Console.WriteLine(" Which service do you want ");
                                Console.WriteLine("1 Deposit");
                                Console.WriteLine("2 Check Balance");
                                Console.WriteLine("3 Withdraw");
                                Console.WriteLine("4 Change PIN");
                                Console.WriteLine("5 Update Phone Number");


                                int choice = Convert.ToInt32(Console.ReadLine());


                                if (choice == 1)
                                {
                                    Console.Write("Enter amount: ");
                                    double amountt = Convert.ToDouble(Console.ReadLine());

                                    if (amountt > 0 && amountt % 1000 == 0)
                                    {

                                        balance += amountt;
                                        string dequery =
                                        "UPDATE Atm_nonso SET Balance=@bal   WHERE Accountnumber=@acc";

                                        using (SqlCommand cmd = new SqlCommand(dequery, connection))
                                        {
                                            cmd.Parameters.AddWithValue("@bal", balance);
                                            cmd.Parameters.AddWithValue("@acc", accountNumber);

                                            cmd.ExecuteNonQuery();
                                        }
                                        Console.WriteLine("Deposit Successful");
                                        Console.WriteLine("Current Balance: " + balance);
                                    }
                                    else
                                    {
                                        Console.WriteLine("Invalid Amount");
                                    }
                                }
                                else if (choice == 2)
                                {

                                    string balquery =
                                        "SELECT Balance FROM Atm_nonso WHERE Accountnumber=@acc";
                                    using (SqlCommand cmd = new SqlCommand(balquery, connection))
                                    {
                                        cmd.Parameters.AddWithValue("@acc", accountNumber);
                                        cmd.Parameters.AddWithValue("@amt", amount);

                                        balance = Convert.ToDouble(cmd.ExecuteScalar());

                                        Console.WriteLine("Current Balance: " + amount);
                                    }
                                }
                                else if (choice == 3)
                                {
                                    Console.Write("Enter amount: ");
                                    double amouunt = Convert.ToDouble(Console.ReadLine());

                                    if (amouunt > 0 && amouunt % 1000 == 0 && amouunt <= balance)
                                    {
                                        balance -= amouunt;
                                        string withquery =
                                        "UPDATE Atm_nonso SET Balance=@bal WHERE Accountnumber=@acc";

                                        using (SqlCommand cmd = new SqlCommand(query, connection))
                                        {
                                            cmd.Parameters.AddWithValue("@bal", balance);
                                            cmd.Parameters.AddWithValue("@acc", accountNumber);

                                            cmd.ExecuteNonQuery();
                                        }

                                        Console.WriteLine("Withdrawal Successful");
                                        Console.WriteLine("Current Balance: " + balance);
                                    }
                                    else
                                    {
                                        Console.WriteLine("Invalid Amount");
                                    }
                                }

                                else if (choice == 4)
                                {
                                    Console.Write("Enter New PIN: ");
                                    string newPin = Console.ReadLine();

                                    string changequery =
                                    "UPDATE Atm_nonso SET Pin=@pin WHERE Accountnumber=@acc";

                                    using (SqlCommand cmd = new SqlCommand(changequery, connection))
                                    {
                                        cmd.Parameters.AddWithValue("@pin", newPin);
                                        cmd.Parameters.AddWithValue("@acc", accountNumber);

                                        cmd.ExecuteNonQuery();
                                    }

                                    Console.WriteLine("PIN Updated Successfully");
                                }
                                else if (choice == 5)
                                {
                                    Console.Write(" Enter your old number: ");
                                    string oldnum = Console.ReadLine();

                                    Console.Write(" Enter your new number: ");
                                    string newnum = Console.ReadLine();

                                    Console.Write("Re-enter New Phone Number: ");
                                    string newnum1 = Console.ReadLine();

                                    Console.WriteLine(" ");
                                    if (newnum1 == newnum)
                                    {
                                        Console.WriteLine("Phone Number Updated Successfully");
                                    }
                                    else
                                    {
                                        Console.WriteLine(" Both don't match");
                                        Console.WriteLine(" it wasnt updated");
                                    }
                                    string numquery =
                                   "UPDATE Atm_nonso SET PhoneNumber=@phone WHERE Accountnumber=@acc";

                                    using (SqlCommand cmd = new SqlCommand(numquery, connection))
                                    {
                                        cmd.Parameters.AddWithValue("@phone", newnum);
                                        cmd.Parameters.AddWithValue("@acc", accountNumber);

                                        cmd.ExecuteNonQuery();
                                    }
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine(" Invalid number, Enter number from (1 - 4)");
                                }
                                Console.Write(" Do you want to do another service us (yes/no): ");
                                string answwerr = Console.ReadLine();
                                if (answwerr == "no")
                                {
                                    Console.WriteLine(" Thank you for banking with us ");
                                    Console.WriteLine(" Have a nice day!!");
                                    break;
                                }
                                else
                                {
                                    Services.Service(accountNumber);
                                }
                                break;

                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine(" invalid amount (must be in 1000 notes)");
                    }

                }
                else if (answr == "no")
                {
                    do
                    {
                        Console.WriteLine(" alright. Noted!! ");
                        Console.Write(" Do you want to do another service us (yes/no): ");
                        string answerr = Console.ReadLine();
                        if (answerr == "no")
                        {
                            Console.WriteLine(" Thank you for banking with us ");
                            Console.WriteLine(" Have a nice day!!");
                            break;
                        }
                        else
                        {
                            Services.Service(accountNumber);
                        }
                        break;
                    } while (answr == "no");
                }
                else
                {
                    Console.WriteLine(" Have a nice day!! ");

                }
                return;
            }
        }
    }
}