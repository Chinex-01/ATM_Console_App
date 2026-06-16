
using System;
using Microsoft.Data.SqlClient;

namespace ATM_Console_App
{
    public static class Services
    {
        public static void Service(string accountNumber)
        {
            string connectionString =
            @"Server=(localdb)\MSSQLLocalDB;Database=ATM_Console_App;Trusted_Connection=True;";

            double balance = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string getBalance =
                  "SELECT Balance FROM Atm_nonso WHERE Accountnumber=@acc";

                using (SqlCommand cmd = new SqlCommand(getBalance, connection))
                {
                    cmd.Parameters.AddWithValue("@acc", accountNumber);

                    object result = cmd.ExecuteScalar();

                    if (result != null)
                        balance = Convert.ToDouble(result);
                }


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
                        double amount = Convert.ToDouble(Console.ReadLine());

                        if (amount > 0 && amount % 1000 == 0)
                        {
                            balance += amount;

                            string query =
                            "UPDATE Atm_nonso SET Balance=@bal WHERE Accountnumber=@acc";

                            using (SqlCommand cmd = new SqlCommand(query, connection))
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
                        string query =
                        "SELECT Balance FROM Atm_nonso WHERE Accountnumber=@acc";
                        using (SqlCommand cmd = new SqlCommand(query, connection))
                        {
                            cmd.Parameters.AddWithValue("@acc", accountNumber);

                            balance = Convert.ToDouble(cmd.ExecuteScalar());

                            Console.WriteLine("Current Balance: " + balance);
                        }
                    }

                    else if (choice == 3)
                    {
                        Console.Write("Enter amount: ");
                        double amount = Convert.ToDouble(Console.ReadLine());

                        if (amount > 0 && amount % 1000 == 0 && amount <= balance)
                        {
                            balance -= amount;

                            string query =
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
                        Console.Write("Enter your old PIN: ");
                        string oldPin = Console.ReadLine();

                        Console.Write("Enter New PIN: ");
                        string newPin = Console.ReadLine();

                        Console.Write("Re-enter New PIN: ");
                        string newPin1 = Console.ReadLine();

                        Console.WriteLine();

                        if (newPin1 == newPin)
                        {
                            string query =
                            "UPDATE Atm_nonso SET Pin=@pin WHERE Accountnumber=@acc";

                            using (SqlCommand cmd = new SqlCommand(query, connection))
                            {
                                cmd.Parameters.AddWithValue("@pin", newPin);
                                cmd.Parameters.AddWithValue("@acc", accountNumber);

                                cmd.ExecuteNonQuery();
                            }

                            Console.WriteLine("PIN Updated Successfully");
                        }
                        else
                        {
                            Console.WriteLine("Both don't match");
                            Console.WriteLine("It wasn't updated");
                        }
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
                        string query =
                       "UPDATE Atm_nonso SET PhoneNumber=@phone WHERE Accountnumber=@acc";

                        using (SqlCommand cmd = new SqlCommand(query, connection))
                        {
                            cmd.Parameters.AddWithValue("@phone", newnum);
                            cmd.Parameters.AddWithValue("@acc", accountNumber);

                            cmd.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        Console.WriteLine(" Invalid number, Enter number from (1 - 4)");
                    }
                    Console.Write(" Do you want to do another service us (yes/no): ");
                    string answerr = Console.ReadLine();
                    if (answerr == "no")
                    {
                        Console.WriteLine(" Thank you for banking with us ");
                        Console.WriteLine(" Have a nice day!!");
                        break;
                    }

                }
            }
        }
    }
}