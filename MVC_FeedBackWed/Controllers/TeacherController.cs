using Microsoft.AspNetCore.Mvc;

namespace MVC_FeedBackWed.Controllers
{
    [Route("Teacher")]
    public class TeacherController : BaseController
    {

        [Route("assignFeedback")]
        public IActionResult assignFeedback()
        {


            return View();
        }


        [Route("ClassesList")]
        public IActionResult ClassesList()
        {
            return View();
        }



        [Route("FeedbackListByClass")]
        public IActionResult FeedbackListByClass(int classId)
        {
            ViewBag.ClassId = classId;
            return View();
        }
    }
}
