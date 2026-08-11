using System.Data;
using Microsoft.Data.SqlClient;

string connectionString =
    "Server=localhost;Database=StudentCoursePortal;Trusted_Connection=True;TrustServerCertificate=True;";

using SqlConnection connection = new SqlConnection(connectionString);

try
{
    connection.Open();

    Console.WriteLine("Connected to SQL Server successfully!");

    string query = "SELECT GETDATE()";

    using SqlCommand command = new SqlCommand(query, connection);

    object result = command.ExecuteScalar();

    Console.WriteLine("Server Date and Time: " + result);
}
catch (Exception ex)
{
    Console.WriteLine("Error: " + ex.Message);
}