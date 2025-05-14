using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PRN231_FinalProject.Models;

namespace PRN231_FinalProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly FeedbackSystemContext _feedbackSystemContext;
        public StudentController(FeedbackSystemContext feedbackSystemContext)
        {
            _feedbackSystemContext = feedbackSystemContext;
        }

        [HttpGet("allStudent")]
        public IActionResult Get()
        {
            try
            {
                var data = _feedbackSystemContext.StudentClasses
                 .Include(sc => sc.Student)  
                 .Include(sc => sc.Class)    
                 .Select(sc => new
                 {
                     StudentId = sc.Student.UserId,
                     FullName = sc.Student.FullName,
                     Email = sc.Student.Email,
                     ClassId = sc.Class.ClassId,
                     ClassName = sc.Class.ClassName
                 })
                 .ToList();
                return Ok(data);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpGet("getClassInformation/{studentId}")]
        public IActionResult GetClassInformation(int studentId)
        {
            try
            {
                var data = _feedbackSystemContext.StudentClasses
                    .Where(sc => sc.StudentId == studentId)
                    .Select(sc => new
                    {
                        ClassId = sc.Class.ClassId,
                        ClassName = sc.Class.ClassName,
                        TeacherName = _feedbackSystemContext.ClassAssignments
                            .Where(ca => ca.ClassId == sc.ClassId)
                            .Select(ca => ca.Teacher.FullName)
                            .FirstOrDefault(),
                        SubjectName = _feedbackSystemContext.ClassAssignments
                            .Where(ca => ca.ClassId == sc.ClassId)
                            .Select(ca => ca.Subject.SubjectName)
                            .FirstOrDefault(),
                        StudentCount = sc.Class.StudentClasses.Count()
                    })
                    .FirstOrDefault();

                if (data == null)
                {
                    return NotFound("Không tìm thấy thông tin lớp học cho sinh viên này.");
                }

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
