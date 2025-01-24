using Microsoft.AspNetCore.Mvc;
using FunRunEventApp.Models;
using Microsoft.Data.SqlClient;

namespace FunRunEventApp.Controllers
{
    public class RegistrationController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Submit(RegistrationModel model)
        {
            if (ModelState.IsValid)
            {
                // Logic to save data (e.g., to a database) can go here
                SqlConnection conn = new SqlConnection("Data Source=tp-l14g3;Initial Catalog=FunRun;Integrated Security=True;Trust Server Certificate=True");
                SqlCommand cmd = new SqlCommand("INSERT INTO registrations (FullName, Email, ContactNumber, Age, Gender, Category, TShirtSize, EmergencyContactName, EmergencyContactNumber) VALUES (@FullName, @Email, @ContactNumber, @Age, @Gender, @Category, @TShirtSize, @EmergencyContactName, @EmergencyContactNumber)", conn);
                conn.Open();

                cmd.Parameters.AddWithValue("@FullName", model.FullName);
                cmd.Parameters.AddWithValue("@Email", model.Email);
                cmd.Parameters.AddWithValue("@ContactNumber", model.ContactNumber);
                cmd.Parameters.AddWithValue("@Age", model.Age);
                cmd.Parameters.AddWithValue("@Gender", model.Gender);
                cmd.Parameters.AddWithValue("@Category", model.Category);
                cmd.Parameters.AddWithValue("@TShirtSize", model.TShirtSize);
                cmd.Parameters.AddWithValue("@EmergencyContactName", model.EmergencyContactName);
                cmd.Parameters.AddWithValue("@EmergencyContactNumber", model.EmergencyContactNumber);

                cmd.ExecuteNonQuery();
                conn.Close();

                // Redirect to a thank-you page or confirmation message.
                return RedirectToAction("ThankYou");
            }

            return View("Index", model); // Return the form with validation errors.
        }

        public IActionResult Registrants()
        {
            // Connect to the database and retrieve the data
            SqlConnection conn = new SqlConnection("Data Source=tp-l14g3;Initial Catalog=FunRun;Integrated Security=True;Trust Server Certificate=True");
            SqlCommand cmd = new SqlCommand("SELECT * FROM registrations", conn);

            conn.Open();

            SqlDataReader reader = cmd.ExecuteReader();
            RegistrationModel model = new RegistrationModel();

            List<RegistrationModel> registrants = new List<RegistrationModel>();

            // Read the data and store it in the list of RegistrationModel objects
            while (reader.Read())
            {
                registrants.Add(new RegistrationModel
                {
                    FullName = reader["FullName"].ToString(),
                    Email = reader["Email"].ToString(),
                    ContactNumber = reader["ContactNumber"].ToString(),
                    Age = Convert.ToInt16(reader["Age"]),
                    Gender = reader["Gender"].ToString(),
                    Category = reader["Category"].ToString(),
                    TShirtSize = reader["TShirtSize"].ToString(),
                    EmergencyContactName = reader["EmergencyContactName"].ToString(),
                    EmergencyContactNumber = reader["EmergencyContactNumber"].ToString(),
                });
            }
            // always close the connection
            conn.Close();
            return View(registrants);
        }

        public IActionResult ThankYou()
        {
            return View();
        }
    }
}
    
