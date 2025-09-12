
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Vulneratus.Web.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public string? Username { get; set; }
        [BindProperty]
        public string? Password { get; set; }

        public string? Message { get; set; }
        private readonly IConfiguration _configuration;

        public LoginModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void OnGet()
        {
        }

        public void OnPost()
        {
            // Insecure SQL query vulnerable to SQL Injection
            string connectionString = _configuration.GetConnectionString("ProdDb") ?? "";
            string query = $"SELECT COUNT(*) FROM Users WHERE Username = '{Username}' AND Password = '{Password}'";

            // This is a demo: do not use in production!
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand(query, connection))
            {
                connection.Open();
                int count = (int)command.ExecuteScalar();
                if (count > 0)
                {
                    Message = "Login successful!";
                }
                else
                {
                    Message = "Invalid username or password.";
                }
            }
        }
    }
}
