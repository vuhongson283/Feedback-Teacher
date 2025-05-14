using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using MVC_FeedBackWed.Models;
using System.Net;
namespace MVC_FeedBackWed.Controllers
{
    [Route("Student")]
    
    public class StudentController : BaseController
    {
        private readonly HttpClient _httpClient;

        public StudentController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        [Route("ClassInformation")]
        public IActionResult ClassInformation()
        {
            return View();
        }


        [Route("FeedbackForm")]
        public async Task<IActionResult> FeedBackForm(int studentId, int formId)
        {
            int? sessionStudentId = HttpContext.Session.GetInt32("UserId");

            
            if (sessionStudentId == null || sessionStudentId != studentId)
            {
                return RedirectToAction("Login", "Login");
            }

            
            var response = await _httpClient.GetAsync($"https://localhost:7087/api/Feedback/getFeedbackList/{studentId}");
            if (!response.IsSuccessStatusCode)
            {
                return RedirectToAction("FeedbackList");
            }

            var result = await response.Content.ReadAsStringAsync();
            var feedbackList = JsonConvert.DeserializeObject<List<FeedbackModel>>(result) ?? new List<FeedbackModel>();

            
            if (!feedbackList.Any(f => f.FeedbackFormId == formId))
            {
                return RedirectToAction("FeedbackList"); 
            }

            ViewBag.StudentId = studentId;
            ViewBag.FormId = formId;
            return View();
        }






        [Route("feedbackList")]
        public async Task<IActionResult> FeedbackList()
        {
            int? studentId = HttpContext.Session.GetInt32("UserId");
            if (studentId == null)
            {
                return RedirectToAction("Login", "Login");
            }

            var response = await _httpClient.GetAsync($"https://localhost:7087/api/Feedback/getFeedbackList/{studentId}");
            if (!response.IsSuccessStatusCode)
            {
                ViewBag.Message = "No Feedback!";
                return View(new List<FeedbackModel>()); 
            }

            var result = await response.Content.ReadAsStringAsync();
            Console.WriteLine("API Response: " + result);

            var feedbackList = JsonConvert.DeserializeObject<List<FeedbackModel>>(result) ?? new List<FeedbackModel>();

            if (!feedbackList.Any())
            {
                ViewBag.Message = "Bạn đã hoàn thành tất cả Feedback!";
            }

            return View(feedbackList);
        }



    }

}
