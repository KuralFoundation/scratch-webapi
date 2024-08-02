using Microsoft.Data.SqlClient;


namespace ScratchWebApi
{
    public class QuotesRepository
    {
        private readonly string _connectionString;

        public QuotesRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<QuoteEntity> GetAllQuotes()
        {
            var quotes = new List<QuoteEntity>();

            // Create a connection to the database
            using (var connection = new SqlConnection(_connectionString))
            {
                try
                {
                    // Open the connection
                    connection.Open();

                    // Create a command to execute the query
                    using (var command = new SqlCommand("SELECT * FROM dbo.Quotes", connection))
                    {
                        // Execute the command and read the results
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Create a new Quote object and populate it with data
                                var quote = new QuoteEntity
                                {
                                    QuoteID = reader.GetInt32(0), // Assuming QuoteID is the first column
                                    Quote = reader.GetString(1), // Assuming QuoteText is the second column
                                };

                                // Add the Quote object to the list
                                quotes.Add(quote);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Handle exceptions (log the error, rethrow it, etc.)
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }
            }

            // Return the list of quotes
            return quotes;
        }
    }
}
