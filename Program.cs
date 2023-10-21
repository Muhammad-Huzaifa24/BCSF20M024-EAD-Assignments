using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Data;

namespace BCSF20M024_EAD_A5
{
    internal class Program
    {
        // connection string
        static readonly string  connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=AssignmentFive;Integrated Security=True;Connect Timeout=30;Encrypt=False;";
        static void Main(string[] args)
        {
            DriverFunction();         
        }

        // Driver function
        public static void DriverFunction()
        {
            string user_option; // handling main menu user option
            bool isExitInnerLoop = false; // for handling inner loop 
            while (true)
            {
                try
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine(" -------------");
                    Console.WriteLine(" | Main Menu |");
                    Console.WriteLine(" -------------\n");
                    Console.ResetColor();

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("</> Choose Option : \n");
                    Console.ResetColor();

                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine(" 1. SQL Data Reader");
                    Console.WriteLine(" 2. SQL Data Adapter");
                    Console.WriteLine(" 3. Exit");
                    Console.ResetColor();

                    user_option = Console.ReadLine();

                    switch (Convert.ToInt32(user_option))
                    {
                        case 1:
                            while (true)
                            {
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.WriteLine("\n----------------------------");
                                Console.WriteLine("|   Using SQL Data Reader  |");
                                Console.WriteLine("----------------------------\n");
                                Console.ResetColor();

                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine(" 1. Insert Record");
                                Console.WriteLine(" 2. Delete Record");
                                Console.WriteLine(" 3. View Record");
                                Console.WriteLine(" 4. Fetch Record by ID");
                                Console.WriteLine(" 5. Update Record");
                                Console.WriteLine(" 6. Switch to main menu");
                                Console.ResetColor();
                                try
                                {
                                    string option;

                                    Console.Write("\nSelect Option ");
                                    option = Console.ReadLine();
                                    switch (Convert.ToInt32(option))
                                    {
                                        case 1:
                                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                                            Console.WriteLine("\n-------------------");
                                            Console.WriteLine("| Insert a Record |");
                                            Console.WriteLine("-------------------\n");
                                            Console.ResetColor();

                                            UserInput(Convert.ToInt32(user_option));
                                            Console.ForegroundColor = ConsoleColor.Magenta;
                                            Console.WriteLine("inserting record . . .\n\n");
                                            Console.ResetColor();
                                            break;
                                        case 2:
                                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                                            Console.WriteLine("\n-------------------");
                                            Console.WriteLine("| Remove a Record |");
                                            Console.WriteLine("-------------------\n");
                                            Console.ResetColor();

                                            string emp_id = " ";
                                            bool isRemove = true;
                                            while (isRemove)
                                            {
                                                Console.Write("Enter employee id to remove ");
                                                try
                                                {
                                                    emp_id = Console.ReadLine();
                                                    if (string.IsNullOrWhiteSpace(emp_id) || Convert.ToInt32(emp_id) < 0)
                                                    {
                                                        Console.ForegroundColor = ConsoleColor.Red;
                                                        Console.WriteLine("Enter valid ID");
                                                        Console.ResetColor();
                                                    }
                                                    else { DeleteEmployeeUsingDataReader(Convert.ToInt32(emp_id)); isRemove = false; }
                                                }
                                                catch (Exception ex)
                                                {
                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                    Console.WriteLine($"{ex.Message}");
                                                    Console.ResetColor();
                                                }
                                            }
                                            break;


                                        case 3:
                                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                                            Console.WriteLine("\n----------------");
                                            Console.WriteLine("| View Records |");
                                            Console.WriteLine("----------------\n");
                                            Console.ResetColor();
                                            ReadAllEmployeesUsingDataReader();

                                            break;
                                        case 4:
                                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                                            Console.WriteLine("\n------------------");
                                            Console.WriteLine("| Fetch a Record |");
                                            Console.WriteLine("------------------\n");
                                            Console.ResetColor();
                                            string fetch_id = " ";
                                            bool isFetched = false;
                                            while (!isFetched)
                                            {
                                                Console.Write("Enter employee id to fetch data ");
                                                try
                                                {
                                                    fetch_id = Console.ReadLine();
                                                    if (string.IsNullOrWhiteSpace(fetch_id) || Convert.ToInt32(fetch_id) < 0)
                                                    {
                                                        Console.ForegroundColor = ConsoleColor.Red;
                                                        Console.WriteLine("Enter valid ID");
                                                        Console.ResetColor();
                                                    }
                                                    else { FetchRecordByIdUsingDataReader(Convert.ToInt32(fetch_id)); isFetched = true; }


                                                }
                                                catch (Exception ex)
                                                {
                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                    Console.WriteLine($"{ex.Message}");
                                                    Console.ResetColor();
                                                }
                                            }
                                            break;


                                        case 5:
                                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                                            Console.WriteLine("\n-------------------");
                                            Console.WriteLine("| Update a Record |");
                                            Console.WriteLine("-------------------\n");
                                            Console.ResetColor();

                                            string update_id = " ";
                                            bool isUpdate = false;
                                            while (!isUpdate)
                                            {
                                                Console.Write("Enter employee id to update data ");
                                                try
                                                {
                                                    update_id = Console.ReadLine();
                                                    if (string.IsNullOrWhiteSpace(update_id) || Convert.ToInt32(update_id) < 0)
                                                    {
                                                        Console.ForegroundColor = ConsoleColor.Red;
                                                        Console.WriteLine("Enter valid ID");
                                                        Console.ResetColor();
                                                    }
                                                    else { UpdateRecordUsingDataReader(Convert.ToInt32(update_id)); isUpdate = true; }


                                                }
                                                catch (Exception ex)
                                                {
                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                    Console.WriteLine($"{ex.Message}");
                                                    Console.ResetColor();
                                                }
                                            }
                                            break;
                                        case 6:
                                            Console.ForegroundColor = ConsoleColor.DarkGray;
                                            Console.WriteLine("switching to main menu . . .\n\n\n");
                                            Console.ResetColor();
                                            // Environment.Exit(0);
                                            isExitInnerLoop = true;
                                            break;
                                        default:
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.WriteLine("Wrong input");
                                            Console.ResetColor();
                                            break;
                                    }

                                }
                                catch (Exception ex)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine($"Error: {ex.Message}\n");
                                    Console.ResetColor();
                                }
                                if (isExitInnerLoop) // exit from the inner loop when user
                                                     // press option 6
                                    break;

                            }
                            break;

                        case 2:
                            while (true)
                            {
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.WriteLine("\n----------------------------");
                                Console.WriteLine("|   Using SQL Data Adapter  |");
                                Console.WriteLine("----------------------------\n");
                                Console.ResetColor();

                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine(" 1. Insert Record");
                                Console.WriteLine(" 2. Delete Record");
                                Console.WriteLine(" 3. View Record");
                                Console.WriteLine(" 4. Fetch Record by ID");
                                Console.WriteLine(" 5. Update Record");
                                Console.WriteLine(" 6. Switch to main menu");
                                Console.ResetColor();
                                try
                                {
                                    string option;

                                    Console.Write("\nSelect Option ");
                                    option = Console.ReadLine();
                                    switch (Convert.ToInt32(option))
                                    {
                                        case 1:
                                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                                            Console.WriteLine("\n-------------------");
                                            Console.WriteLine("| Insert a Record |");
                                            Console.WriteLine("-------------------\n");
                                            Console.ResetColor();

                                            UserInput(Convert.ToInt32(user_option));
                                            Console.ForegroundColor = ConsoleColor.Magenta;
                                            Console.WriteLine("inserting record . . .\n\n");
                                            Console.ResetColor();
                                            break;
                                        case 2:
                                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                                            Console.WriteLine("\n-------------------");
                                            Console.WriteLine("| Remove a Record |");
                                            Console.WriteLine("-------------------\n");
                                            Console.ResetColor();

                                            string emp_id = " ";
                                            bool isRemove = true;
                                            while (isRemove)
                                            {
                                                Console.Write("Enter employee id to remove ");
                                                try
                                                {
                                                    emp_id = Console.ReadLine();
                                                    if (string.IsNullOrWhiteSpace(emp_id) || Convert.ToInt32(emp_id) < 0)
                                                    {
                                                        Console.ForegroundColor = ConsoleColor.Red;
                                                        Console.WriteLine("Enter valid ID");
                                                        Console.ResetColor();
                                                    }
                                                    else { DeleteEmployeeUsingDataAdapter(Convert.ToInt32(emp_id)); isRemove = false; }
                                                }
                                                catch (Exception ex)
                                                {
                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                    Console.WriteLine($"{ex.Message}");
                                                    Console.ResetColor();
                                                }
                                            }
                                            break;


                                        case 3:
                                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                                            Console.WriteLine("\n----------------");
                                            Console.WriteLine("| View Records |");
                                            Console.WriteLine("----------------\n");
                                            Console.ResetColor();
                                            ReadAllEmployeesUsingDataAdapter();

                                            break;
                                        case 4:
                                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                                            Console.WriteLine("\n------------------");
                                            Console.WriteLine("| Fetch a Record |");
                                            Console.WriteLine("------------------\n");
                                            Console.ResetColor();
                                            string fetch_id = " ";
                                            bool isFetched = false;
                                            while (!isFetched)
                                            {
                                                Console.Write("Enter employee id to fetch data ");
                                                try
                                                {
                                                    fetch_id = Console.ReadLine();
                                                    if (string.IsNullOrWhiteSpace(fetch_id) || Convert.ToInt32(fetch_id) < 0)
                                                    {
                                                        Console.ForegroundColor = ConsoleColor.Red;
                                                        Console.WriteLine("Enter valid ID");
                                                        Console.ResetColor();
                                                    }
                                                    else { FetchRecordByIdUsingDataAdapter(Convert.ToInt32(fetch_id)); isFetched = true; }


                                                }
                                                catch (Exception ex)
                                                {
                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                    Console.WriteLine($"{ex.Message}");
                                                    Console.ResetColor();
                                                }
                                            }
                                            break;


                                        case 5:
                                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                                            Console.WriteLine("\n-------------------");
                                            Console.WriteLine("| Update a Record |");
                                            Console.WriteLine("-------------------\n");
                                            Console.ResetColor();

                                            string update_id = " ";
                                            bool isUpdate = false;
                                            while (!isUpdate)
                                            {
                                                Console.Write("Enter employee id to update data ");
                                                try
                                                {
                                                    update_id = Console.ReadLine();
                                                    if (string.IsNullOrWhiteSpace(update_id) || Convert.ToInt32(update_id) < 0)
                                                    {
                                                        Console.ForegroundColor = ConsoleColor.Red;
                                                        Console.WriteLine("Enter valid ID");
                                                        Console.ResetColor();
                                                    }
                                                    else { UpdateRecordUsingDataAdapter(Convert.ToInt32(update_id)); isUpdate = true; }


                                                }
                                                catch (Exception ex)
                                                {
                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                    Console.WriteLine($"{ex.Message}");
                                                    Console.ResetColor();
                                                }
                                            }
                                            break;
                                        case 6:
                                            Console.ForegroundColor = ConsoleColor.DarkGray;
                                            Console.WriteLine("switching to main menu . . .\n\n\n");
                                            Console.ResetColor();
                                            isExitInnerLoop = true;
                                            //Environment.Exit(0);
                                            break;
                                        default:
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.WriteLine("Wrong input");
                                            Console.ResetColor();
                                            break;
                                    }

                                }
                                catch (Exception ex)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine($"Error: {ex.Message}\n");
                                    Console.ResetColor();
                                }
                                if (isExitInnerLoop)
                                    break;
                            }
                            break;

                        case 3:
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.WriteLine("Exiting from a program\n\n");
                            Console.ResetColor();
                            Environment.Exit(0);
                            break;

                        default:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Wrong input");
                            Console.ResetColor();
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Error: {ex.Message}\n");
                    Console.ResetColor();
                }
            }
        }

        // user input function
        // insertion function call inside it with
        // condition 
        public static void UserInput(int option)
        {
            string firstName = " ", lastName = " ", email = " ", primaryPhone = " ", secondaryPhone = " ";

            // validate first Name
            do
            {
                try
                {
                    Console.Write("Enter first Name : ");
                    firstName = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(firstName))
                    {
                        Console.WriteLine("Error : Required filed\n");

                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }

            } while (string.IsNullOrEmpty(firstName));

            // validate last Name
            do
            {
                try
                {
                    Console.Write("Enter last Name : ");
                    lastName = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(lastName))
                    {
                        Console.WriteLine("Error : Required filed\n");

                    }
                }
                catch (FormatException ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            } while (string.IsNullOrEmpty(lastName));

            // validate email
            do
            {

                try
                {
                    Console.Write("Enter email : ");
                    email = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(email))
                    {
                        Console.WriteLine("Error : Required filed\n");

                    }
                    else if (!IsValidEmail(email))
                    {
                        Console.WriteLine("format should be abc@gmail.com\n");
                    }
                }
                catch (FormatException ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            } while (string.IsNullOrWhiteSpace(email) || !IsValidEmail(email));

            // validate primaryPhoneNumber
            do
            {
                try
                {
                    Console.Write("Enter primary phone number : ");
                    primaryPhone = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(primaryPhone))
                    {
                        Console.WriteLine("Error : Required filed\n");

                    }
                    else if (primaryPhone.Length != 11)
                    {
                        Console.WriteLine("Error : phone number must be 11 digit");
                    }
                }
                catch (FormatException ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            } while (string.IsNullOrWhiteSpace(primaryPhone) || primaryPhone.Length != 11);

            // validate secondaryPhoneNumber
            do
            {
                try
                {
                    Console.Write("Enter secondary phone number : ");
                    secondaryPhone = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(secondaryPhone))
                    {
                        break;

                    }
                    else if (secondaryPhone.Length != 11)
                    {
                        Console.WriteLine("Error : phone number must be 11 digit");
                    }
                }
                catch (FormatException ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            } while (secondaryPhone.Length != 11);


            // here we have all inputs, 
            // insert them into fields,
            // Condition for calling 
            // data reader and data adapter into
            // insertion function 

            if (option == 1)
            {
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                //Console.WriteLine("\ninsertion Using sql data reader\n");
                Console.ResetColor();
                InsertEmployeeUsingDataReader(firstName, lastName, email, primaryPhone, secondaryPhone, firstName + lastName, DateTime.Now, null, null);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                //Console.WriteLine("\ninsertion Using sql data adapter\n");
                Console.ResetColor();
                InsertEmployeeUsingDataAdapter(firstName, lastName, email, primaryPhone, secondaryPhone, firstName + lastName, DateTime.Now, null, null);
            }    
        }

        // validate email
        // helper function
        public static bool IsValidEmail(string email)
        {
            try
            {
                // Use a regular expression to validate the email format with @gmail.com
                return Regex.IsMatch(email, @"^\S+@gmail\.com$");
            }
            catch
            {
                return false;
            }
        }

        // read all records from db using sql data reader
        public static void ReadAllEmployeesUsingDataReader()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string selectQuery = "SELECT * FROM Employees";

                using (SqlCommand command = new SqlCommand(selectQuery, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        try
                        {
                            while (reader.Read())
                            {
                                Console.WriteLine("\n--------------------------------\n");
                                Console.WriteLine($" - ID:\t\t\t{reader["ID"]}\n - FirstName:      \t{reader["FirstName"]}\n - LastName:      \t{reader["LastName"]}\n" +
                                    $" - Email: \t\t{reader["Email"]}\n - PrimaryNumber: \t{reader["PrimaryPhoneNumber"]}\n" +
                                    $" - SecondaryNumber: \t{reader["SecondaryPhoneNumber"]}\n - CreatedBy:      \t{reader["CreatedBy"]}\n" +
                                    $" - CreatedOn:    \t{reader["CreatedOn"]}\n - ModifiedBy:      \t{reader["ModifiedBy"]}\n - ModifiedOn:      \t{reader["ModifiedOn"]}");

                            }
                            if (!reader.HasRows)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("No Records to view\n");
                                Console.ResetColor();
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"Error: {ex.Message}");
                            Console.ResetColor();
                        }
                    }
                }
            }
            Console.WriteLine("\n--------------------------------\n");

        }

        // insert a record into table using data reader
        public static void InsertEmployeeUsingDataReader(string firstName, string lastName, string email, string primaryPhoneNumber, string secondaryPhoneNumber, string createdBy, DateTime createdOn, string modifiedBy, DateTime? modifiedOn)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open(); // open connection

                string insertQuery = "INSERT INTO Employees (FirstName, LastName, Email, PrimaryPhoneNumber, SecondaryPhoneNumber, CreatedBy, CreatedOn, ModifiedBy, ModifiedOn) " +
                    "VALUES (@FirstName, @LastName, @Email, @PrimaryPhoneNumber, @SecondaryPhoneNumber, @CreatedBy, @CreatedOn, @ModifiedBy, @ModifiedOn)";

                using (SqlCommand command = new SqlCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@FirstName", firstName);
                    command.Parameters.AddWithValue("@LastName", lastName);
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@PrimaryPhoneNumber", primaryPhoneNumber);
                    command.Parameters.AddWithValue("@SecondaryPhoneNumber", (object)secondaryPhoneNumber ?? DBNull.Value);
                    command.Parameters.AddWithValue("@CreatedBy", createdBy);
                    command.Parameters.AddWithValue("@CreatedOn", createdOn);
                    command.Parameters.AddWithValue("@ModifiedBy", (object)modifiedBy ?? DBNull.Value);
                    command.Parameters.AddWithValue("@ModifiedOn", (object)modifiedOn ?? DBNull.Value);

                    command.ExecuteNonQuery();
                }
            }
        }

        // delete a record by id using sql data reader
        public static void DeleteEmployeeUsingDataReader(int employeeID)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string deleteQuery = "DELETE FROM Employees WHERE ID = @Id";

                using (SqlCommand command = new SqlCommand(deleteQuery, connection))
                {
                    command.Parameters.AddWithValue("@Id", employeeID);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Record deleted successfully.\n");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.ForegroundColor= ConsoleColor.Red;
                        Console.WriteLine("No record found with the provided ID.\n");
                        Console.ResetColor();
                    }
                }
            }
        }

        // fetch a record by id
        public static void FetchRecordByIdUsingDataReader(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string selectQuery = "SELECT * FROM Employees WHERE ID = @EmployeeID";

                using (SqlCommand command = new SqlCommand(selectQuery, connection))
                {
                    command.Parameters.AddWithValue("@EmployeeID", id);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Record found:");
                            Console.ResetColor();

                            Console.WriteLine("\n--------------------------------\n");
                            Console.WriteLine($" - ID:\t\t\t{reader["ID"]}\n - FirstName:      \t{reader["FirstName"]}\n - LastName:      \t{reader["LastName"]}\n" +
                                $" - Email: \t\t{reader["Email"]}\n - PrimaryNumber: \t{reader["PrimaryPhoneNumber"]}\n" +
                                $" - SecondaryNumber: \t{reader["SecondaryPhoneNumber"]}\n - CreatedBy:      \t{reader["CreatedBy"]}\n" +
                                $" - CreatedOn:    \t{reader["CreatedOn"]}\n - ModifiedBy:      \t{reader["ModifiedBy"]}\n - ModifiedOn:      \t{reader["ModifiedOn"]}");
                            Console.WriteLine("\n--------------------------------\n");
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("No record found with the provided ID.");
                            Console.ResetColor();
                        }
                    }
                }
            }
        }

        // update a record by id
        public static void UpdateRecordUsingDataReader(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string selectQuery = "SELECT * FROM Employees WHERE ID = @EmployeeID";

                using (SqlCommand selectCommand = new SqlCommand(selectQuery, connection))
                {
                    selectCommand.Parameters.AddWithValue("@EmployeeID", id);

                    using (SqlDataReader reader = selectCommand.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Existing record found, you can display it or modify it
                            string existingFirstName = reader["FirstName"].ToString();
                            string existingLastName = reader["LastName"].ToString();
                            string existingEmail = reader["Email"].ToString();
                            string existingPrimaryPhone = reader["PrimaryPhoneNumber"].ToString();
                            string existingSecondaryPhone = reader["SecondaryPhoneNumber"].ToString();

                            // Close the SqlDataReader to release the associated resources
                            reader.Close();

                            // Ask the user for updated values
                            Console.Write("Enter new First Name (Press Enter to keep existing value): ");
                            string newFirstName = Console.ReadLine();
                            if (string.IsNullOrWhiteSpace(newFirstName))
                            {
                                newFirstName = existingFirstName;
                            }

                            Console.Write("Enter new Last Name (Press Enter to keep existing value): ");
                            string newLastName = Console.ReadLine();
                            if (string.IsNullOrWhiteSpace(newLastName))
                            {
                                newLastName = existingLastName;
                            }

                            Console.Write("Enter new Email (Press Enter to keep existing value): ");
                            string newEmail = Console.ReadLine();
                            if (string.IsNullOrWhiteSpace(newEmail))
                            {
                                newEmail = existingEmail;
                            }

                            Console.Write("Enter new Primary Phone (Press Enter to keep existing value): ");
                            string newPrimaryPhone = Console.ReadLine();
                            if (string.IsNullOrWhiteSpace(newPrimaryPhone))
                            {
                                newPrimaryPhone = existingPrimaryPhone;
                            }

                            Console.Write("Enter new Secondary Phone (Press Enter to keep existing value): ");
                            string newSecondaryPhone = Console.ReadLine();
                            if (string.IsNullOrWhiteSpace(newSecondaryPhone))
                            {
                                newSecondaryPhone = existingSecondaryPhone;
                            }

                            // Update the record in the database
                            string updateQuery = "UPDATE Employees SET FirstName = @NewFirstName, LastName = @NewLastName, " +
                                                 "Email = @NewEmail, PrimaryPhoneNumber = @NewPrimaryPhone, " +
                                                 "SecondaryPhoneNumber = @NewSecondaryPhone WHERE ID = @EmployeeID";

                            using (SqlCommand updateCommand = new SqlCommand(updateQuery, connection))
                            {
                                updateCommand.Parameters.AddWithValue("@NewFirstName", newFirstName);
                                updateCommand.Parameters.AddWithValue("@NewLastName", newLastName);
                                updateCommand.Parameters.AddWithValue("@NewEmail", newEmail);
                                updateCommand.Parameters.AddWithValue("@NewPrimaryPhone", newPrimaryPhone);
                                updateCommand.Parameters.AddWithValue("@NewSecondaryPhone", newSecondaryPhone);
                                updateCommand.Parameters.AddWithValue("@EmployeeID", id);

                                int rowsAffected = updateCommand.ExecuteNonQuery();

                                if (rowsAffected > 0)
                                {
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("Record updated successfully.\n");
                                    Console.ResetColor();
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Record update failed.");
                                    Console.ResetColor();
                                }
                            }
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("No record found with the provided ID.");
                            Console.ResetColor();
                        }
                    }
                }
            }
        }




        // // insert a record into table using data adapter
        public static void InsertEmployeeUsingDataAdapter(string firstName, string lastName, string email, string primaryPhoneNumber, string secondaryPhoneNumber, string createdBy, DateTime createdOn, string modifiedBy, DateTime? modifiedOn)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open(); // Open connection

                string insertQuery = "INSERT INTO Employees (FirstName, LastName, Email, PrimaryPhoneNumber, SecondaryPhoneNumber, CreatedBy, CreatedOn, ModifiedBy, ModifiedOn) " +
                    "VALUES (@FirstName, @LastName, @Email, @PrimaryPhoneNumber, @SecondaryPhoneNumber, @CreatedBy, @CreatedOn, @ModifiedBy, @ModifiedOn)";

                using (SqlDataAdapter adapter = new SqlDataAdapter())
                {
                    adapter.InsertCommand = new SqlCommand(insertQuery, connection);
                    adapter.InsertCommand.Parameters.Add("@FirstName", SqlDbType.VarChar, 255, "FirstName");
                    adapter.InsertCommand.Parameters.Add("@LastName", SqlDbType.VarChar, 255, "LastName");
                    adapter.InsertCommand.Parameters.Add("@Email", SqlDbType.VarChar, 255, "Email");
                    adapter.InsertCommand.Parameters.Add("@PrimaryPhoneNumber", SqlDbType.VarChar, 20, "PrimaryPhoneNumber");
                    adapter.InsertCommand.Parameters.Add("@SecondaryPhoneNumber", SqlDbType.VarChar, 20, "SecondaryPhoneNumber");
                    adapter.InsertCommand.Parameters.Add("@CreatedBy", SqlDbType.VarChar, 255, "CreatedBy");
                    adapter.InsertCommand.Parameters.Add("@CreatedOn", SqlDbType.DateTime, 0, "CreatedOn");
                    adapter.InsertCommand.Parameters.Add("@ModifiedBy", SqlDbType.VarChar, 255, "ModifiedBy");
                    adapter.InsertCommand.Parameters.Add("@ModifiedOn", SqlDbType.DateTime, 0, "ModifiedOn");

                    // Create a new DataTable for the new record
                    DataTable newEmployee = new DataTable();
                    newEmployee.Columns.Add("FirstName");
                    newEmployee.Columns.Add("LastName");
                    newEmployee.Columns.Add("Email");
                    newEmployee.Columns.Add("PrimaryPhoneNumber");
                    newEmployee.Columns.Add("SecondaryPhoneNumber");
                    newEmployee.Columns.Add("CreatedBy");
                    newEmployee.Columns.Add("CreatedOn");
                    newEmployee.Columns.Add("ModifiedBy");
                    newEmployee.Columns.Add("ModifiedOn");

                    // Add the data for the new employee
                    DataRow newRow = newEmployee.NewRow();
                    newRow["FirstName"] = firstName;
                    newRow["LastName"] = lastName;
                    newRow["Email"] = email;
                    newRow["PrimaryPhoneNumber"] = primaryPhoneNumber;
                    newRow["SecondaryPhoneNumber"] = secondaryPhoneNumber;
                    newRow["CreatedBy"] = createdBy;
                    newRow["CreatedOn"] = createdOn;
                    newRow["ModifiedBy"] = modifiedBy;
                    newRow["ModifiedOn"] = modifiedOn;
                    newEmployee.Rows.Add(newRow);

                    // Use the SqlDataAdapter to insert the new employee record
                    adapter.Update(newEmployee);
                }
            }
        }

        // delete a record by id using sql data adapter
        public static void DeleteEmployeeUsingDataAdapter(int employeeID)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string deleteQuery = "DELETE FROM Employees WHERE ID = @ID";

                using (SqlDataAdapter adapter = new SqlDataAdapter())
                {
                    adapter.DeleteCommand = new SqlCommand(deleteQuery, connection);
                    adapter.DeleteCommand.Parameters.Add("@ID", SqlDbType.Int).Value = employeeID;

                    int rowsAffected = adapter.DeleteCommand.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Record deleted successfully.\n");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("No record found with the provided ID.\n");
                        Console.ResetColor();
                    }
                }
            }
        }

        // read all record from db using sql data adapter
        public static void ReadAllEmployeesUsingDataAdapter()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string selectQuery = "SELECT * FROM Employees";

                using (SqlDataAdapter adapter = new SqlDataAdapter(selectQuery, connection))
                {
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    if (dataTable.Rows.Count > 0)
                    {
                        foreach (DataRow row in dataTable.Rows)
                        {
                            Console.WriteLine("\n--------------------------------\n");
                            Console.WriteLine($" - ID:\t\t\t{row["ID"]}\n - FirstName:      \t{row["FirstName"]}\n - LastName:      \t{row["LastName"]}\n" +
                                $" - Email: \t\t{row["Email"]}\n - PrimaryNumber: \t{row["PrimaryPhoneNumber"]}\n" +
                                $" - SecondaryNumber: \t{row["SecondaryPhoneNumber"]}\n - CreatedBy:      \t{row["CreatedBy"]}\n" +
                                $" - CreatedOn:    \t{row["CreatedOn"]}\n - ModifiedBy:      \t{row["ModifiedBy"]}\n - ModifiedOn:      \t{row["ModifiedOn"]}");
                        }
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("No Records to view\n");
                        Console.ResetColor();
                    }
                }
            }
            Console.WriteLine("\n--------------------------------\n");
        }

        // fetch a record using data adapter
        public static void FetchRecordByIdUsingDataAdapter(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string selectQuery = "SELECT * FROM Employees WHERE ID = @ID";

                using (SqlDataAdapter adapter = new SqlDataAdapter())
                {
                    adapter.SelectCommand = new SqlCommand(selectQuery, connection);
                    adapter.SelectCommand.Parameters.AddWithValue("@ID", id);

                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    if (dataTable.Rows.Count > 0)
                    {
                        DataRow row = dataTable.Rows[0];

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Record found:");
                        Console.ResetColor();

                        Console.WriteLine("\n--------------------------------\n");
                        Console.WriteLine($" - ID:\t\t\t{row["ID"]}\n - FirstName:      \t{row["FirstName"]}\n - LastName:      \t{row["LastName"]}\n" +
                            $" - Email: \t\t{row["Email"]}\n - PrimaryNumber: \t{row["PrimaryPhoneNumber"]}\n" +
                            $" - SecondaryNumber: \t{row["SecondaryPhoneNumber"]}\n - CreatedBy:      \t{row["CreatedBy"]}\n" +
                            $" - CreatedOn:    \t{row["CreatedOn"]}\n - ModifiedBy:      \t{row["ModifiedBy"]}\n - ModifiedOn:      \t{row["ModifiedOn"]}");
                        Console.WriteLine("\n--------------------------------\n");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("No record found with the provided ID.");
                        Console.ResetColor();
                    }
                }
            }
        }

        // update a record using data adapter
        public static void UpdateRecordUsingDataAdapter(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string selectQuery = "SELECT * FROM Employees WHERE ID = @EmployeeID";

                using (SqlDataAdapter adapter = new SqlDataAdapter())
                {
                    adapter.SelectCommand = new SqlCommand(selectQuery, connection);
                    adapter.SelectCommand.Parameters.AddWithValue("@EmployeeID", id);

                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    if (dataTable.Rows.Count > 0)
                    {
                        DataRow row = dataTable.Rows[0];

                        // Extract existing values 
                        string existingFirstName = row.Field<string>("FirstName");
                        string existingLastName = row.Field<string>("LastName");
                        string existingEmail = row.Field<string>("Email");
                        string existingPrimaryPhone = row.Field<string>("PrimaryPhoneNumber");
                        string existingSecondaryPhone = row.Field<string>("SecondaryPhoneNumber");

                        // Ask the user for updated values
                        Console.Write("Enter new First Name (Press Enter to keep existing value): ");
                        string newFirstName = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(newFirstName))
                        {
                            newFirstName = existingFirstName;
                        }

                        Console.Write("Enter new Last Name (Press Enter to keep existing value): ");
                        string newLastName = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(newLastName))
                        {
                            newLastName = existingLastName;
                        }

                        Console.Write("Enter new Email (Press Enter to keep existing value): ");
                        string newEmail = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(newEmail))
                        {
                            newEmail = existingEmail;
                        }

                        Console.Write("Enter new Primary Phone (Press Enter to keep existing value): ");
                        string newPrimaryPhone = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(newPrimaryPhone))
                        {
                            newPrimaryPhone = existingPrimaryPhone;
                        }

                        Console.Write("Enter new Secondary Phone (Press Enter to keep existing value): ");
                        string newSecondaryPhone = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(newSecondaryPhone))
                        {
                            newSecondaryPhone = existingSecondaryPhone;
                        }

                        // Update the record in the database
                        string updateQuery = "UPDATE Employees SET FirstName = @NewFirstName, LastName = @NewLastName, " +
                                             "Email = @NewEmail, PrimaryPhoneNumber = @NewPrimaryPhone, " +
                                             "SecondaryPhoneNumber = @NewSecondaryPhone WHERE ID = @EmployeeID";

                        using (SqlCommand updateCommand = new SqlCommand(updateQuery, connection))
                        {
                            updateCommand.Parameters.AddWithValue("@NewFirstName", newFirstName);
                            updateCommand.Parameters.AddWithValue("@NewLastName", newLastName);
                            updateCommand.Parameters.AddWithValue("@NewEmail", newEmail);
                            updateCommand.Parameters.AddWithValue("@NewPrimaryPhone", newPrimaryPhone);
                            updateCommand.Parameters.AddWithValue("@NewSecondaryPhone", newSecondaryPhone);
                            updateCommand.Parameters.AddWithValue("@EmployeeID", id);

                            int rowsAffected = updateCommand.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("Record updated successfully.\n");
                                Console.ResetColor();
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Record update failed.");
                                Console.ResetColor();
                            }
                        }
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("No record found with the provided ID.");
                        Console.ResetColor();
                    }
                }
            }
        }




    }
}
