using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace MVC_FeedBackWed.Controllers
{
    
    public class LoginController : BaseController
    {
        private readonly HttpClient _httpClient;

        public LoginController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        [Route("")]
        [Route("login")]
        [HttpGet]
        
        public IActionResult Login()
        {
           
            return View();
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(string email, string password)
        {
            var loginData = new { email, password };
            var content = new StringContent(JsonConvert.SerializeObject(loginData),Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("https://localhost:7087/api/Auth/login", content);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                dynamic jsonData = JsonConvert.DeserializeObject(result);

                string token = jsonData.token;
                string role = jsonData.role;
                string fullName = jsonData.fullName;
                int userId = jsonData.userId;
                HttpContext.Session.SetInt32("UserId", userId);
                HttpContext.Session.SetString("fullName", fullName);

                HttpContext.Session.SetString("Token", token);
                HttpContext.Session.SetString("Role", role);
                if (role == "Student")
                {
                    return RedirectToAction("feedbackList", "Student");
                }
                else
                {
                    return RedirectToAction("ClassesList", "Teacher");
                }
                
            }
            else
            {
                ViewBag.Error = "Invalid email or password.";
                return View();
            }
        }


        [HttpPost]
        [Route("logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear(); 
            return RedirectToAction("Login", "Login"); // Chuyển hướng về trang login
        }

    }
}
