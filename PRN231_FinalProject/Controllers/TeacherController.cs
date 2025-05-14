using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PRN231_FinalProject.Dtos;
using PRN231_FinalProject.Models;

namespace PRN231_FinalProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly FeedbackSystemContext _feedbackSystemContext;

        public TeacherController(FeedbackSystemContext feedbackSystemContext)
        {
            _feedbackSystemContext = feedbackSystemContext;
        }


        [Authorize]
        [HttpGet("getAllClass/{teacherId}")]
        public IActionResult GetAllClass(int teacherId)
        {
            try
            {
                if (teacherId <= 0)
                {
                    return BadRequest("TeacherId không hợp lệ.");
                }

                var data = _feedbackSystemContext.ClassAssignments
                    .Where(x => x.TeacherId == teacherId)
                    .Select(t => new
                    {
                        classId = t.ClassId,
                        className = t.Class.ClassName,
                        subjectId = t.SubjectId,
                        subjectName = t.Subject.SubjectName,
                        numberOfStudent = t.Class.StudentClasses.Count(),
                        hasActiveFeedback = _feedbackSystemContext.FeedbackForms
                        .Where(f => f.ClassId == t.ClassId &&
                                    f.SubjectId == t.SubjectId &&
                                    f.TeacherId == teacherId &&
                                    f.EndDate >= DateTime.Now)
                        .Any(f => f.IsActive == true) 

                    })
                    .ToList();

                if (!data.Any())
                {
                    return NotFound("Không có lớp nào được phân công cho giáo viên này.");
                }

                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Lỗi server: " + ex.Message);
            }
        }



        [HttpPost("assignFeedback")]
        public IActionResult AssignFeedback([FromBody] AssignFeedbackDto request)
        {
            try
            {
                var classAssignment = _feedbackSystemContext.ClassAssignments
                    .FirstOrDefault(ca => ca.ClassId == request.ClassId
                                       && ca.SubjectId == request.SubjectId
                                       && ca.TeacherId == request.TeacherId);

                if (classAssignment == null)
                {
                    return NotFound(new { message = "Class, Subject, or Teacher not found in assignments." });
                }

                DateTime startDate = DateTime.Now;
                DateTime endDate = startDate.AddMonths(1);

                bool hasActiveFeedback = _feedbackSystemContext.FeedbackForms.Any(f =>
                    f.ClassId == request.ClassId &&
                    f.SubjectId == request.SubjectId &&
                    f.TeacherId == request.TeacherId &&
                    (
                        (startDate >= f.StartDate && startDate <= f.EndDate) ||
                        (endDate >= f.StartDate && endDate <= f.EndDate) ||
                        (startDate <= f.StartDate && endDate >= f.EndDate) 
                    ));

                if (hasActiveFeedback)
                {
                    return BadRequest(new { message = "Lớp này đã có feedback đang hoạt động." });
                }
              
                var feedbackForm = new FeedbackForm
                {
                    ClassId = request.ClassId,
                    SubjectId = request.SubjectId,
                    TeacherId = request.TeacherId,
                    StartDate = startDate,
                    EndDate = endDate,
                    IsActive = true
                };

                _feedbackSystemContext.FeedbackForms.Add(feedbackForm);
                _feedbackSystemContext.SaveChanges();

                return Ok(new
                {
                    message = "Feedback form assigned successfully!",
                    startDate = startDate,
                    endDate = endDate
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }




    }
}
