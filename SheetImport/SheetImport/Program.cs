using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using CsvHelper;

namespace CsvToDatabase
{
    class Program
    {
        static void Main(string[] args)
        {
            string csvFilePath = "C:\\Users\\bstha\\Downloads\\KuralOviyam.xlsx - Sheet1.csv";
            string connectionString = "Server=THARUN_LENOVO;Database=Quotes;Trusted_Connection=True;TrustServerCertificate=True;";

            List<OldUser> oldUsers = ReadCsvFile(csvFilePath);
            InsertIntoDatabase(oldUsers, connectionString);

            Console.WriteLine("Data has been successfully inserted into the database.");
        }

        static List<OldUser> ReadCsvFile(string filePath)
        {
            List<OldUser> oldUsers = new List<OldUser>();

            using (var reader = new StreamReader(filePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                oldUsers = csv.GetRecords<OldUser>().ToList();
            }

            return oldUsers;
        }

        static void InsertIntoDatabase(List<OldUser> oldUsers, string connectionString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                foreach (var user in oldUsers)
                {
                    string query = "INSERT INTO OldUser (FirstName, LastName, PersonalEmail, Address1, Address2, City, State, Country, Pincode) " +
                                   "VALUES (@FirstName, @LastName, @PersonalEmail, @Address1, @Address2, @City, @State, @Country, @Pincode)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@FirstName", user.FirstName);
                        command.Parameters.AddWithValue("@LastName", user.LastName);
                        command.Parameters.AddWithValue("@PersonalEmail", user.PersonalEmail);
                        command.Parameters.AddWithValue("@Address1", user.Address1);
                        command.Parameters.AddWithValue("@Address2", user.Address2);
                        command.Parameters.AddWithValue("@City", user.City);
                        command.Parameters.AddWithValue("@State", user.State);
                        command.Parameters.AddWithValue("@Country", user.Country);
                        command.Parameters.AddWithValue("@Pincode", user.Pincode);

                        command.ExecuteNonQuery();
                    }
                }
            }
        }
    }

    public class OldUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PersonalEmail { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Pincode { get; set; }
    }
}