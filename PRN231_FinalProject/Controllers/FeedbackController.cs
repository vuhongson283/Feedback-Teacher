using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PRN231_FinalProject.Models;
using PRN231_FinalProject.Dtos;
using Microsoft.EntityFrameworkCore;

namespace PRN231_FinalProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        private readonly FeedbackSystemContext _feedbackSystemContext;
        public FeedbackController(FeedbackSystemContext feedbackSystemContext)
        {
            _feedbackSystemContext = feedbackSystemContext;
        }

        [HttpGet("formInformation/{studentId}")]
        public IActionResult Get(int studentId) 
        {
            try
            {
                // Lấy ClassId của student
                var studentClass = _feedbackSystemContext.StudentClasses
                    .Where(sc => sc.StudentId == studentId)
                    .Select(sc => sc.ClassId)
                    .FirstOrDefault();

                if (studentClass == 0)
                {
                    return NotFound("Student not found or not assigned to any class.");
                }

                // Lấy thông tin feedback form của lớp này
                var feedbackForm = (from ff in _feedbackSystemContext.FeedbackForms
                                    join teacher in _feedbackSystemContext.Users on ff.TeacherId equals teacher.UserId
                                    join subject in _feedbackSystemContext.Subjects on ff.SubjectId equals subject.SubjectId
                                    where ff.ClassId == studentClass && ff.IsActive == true
                                    select new
                                    {
                                        ff.FormId,
                                        TeacherName = teacher.FullName,
                                        TeacherEmail = teacher.Email,
                                        SubjectName = subject.SubjectName,
                                        ff.ClassId,
                                        ff.StartDate,
                                        ff.EndDate
                                    })
                                    .FirstOrDefault();

                if (feedbackForm == null)
                {
                    return NotFound("No active feedback form found for this class.");
                }

                // Lấy danh sách câu hỏi từ database trước
                var questions = _feedbackSystemContext.FeedbackQuestions
                    .Select(q => new
                    {
                        q.QuestionId,
                        q.QuestionText
                    })
                    .ToList(); 

                
                var questionsWithOptions = questions.Select(q => new
                {
                    q.QuestionId,
                    q.QuestionText,
                    RadioOptions = new List<string> { "Poor", "Fair", "Good", "Excellent" }
                }).ToList();

                // Tạo kết quả cuối cùng
                var result = new
                {
                    feedbackForm.FormId,
                    feedbackForm.TeacherName,
                    feedbackForm.TeacherEmail,
                    feedbackForm.SubjectName,
                    feedbackForm.ClassId,
                    feedbackForm.StartDate,
                    feedbackForm.EndDate,
                    Questions = questionsWithOptions
                };

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("getFeedbackResponseByClass/{classId}")]
        public IActionResult GetFbRes(int classId)
        {
            try
            {
                var feedbackResponses = _feedbackSystemContext.FeedbackAnswers
                    .Where(fa => fa.Form.ClassId == classId)
                    .GroupBy(fa => new { fa.StudentId, fa.Student.FullName })
                    .Select(group => new
                    {
                        Student = "Student " + (group.Key.StudentId % 1000), // Ẩn danh sinh viên
                        Answers = group.OrderBy(fa => fa.QuestionId) // Sắp xếp theo câu hỏi
                                      .Select(fa => fa.Answer) // Lấy câu trả lời
                                      .ToList(),
                        SubmittedAt = group.Max(fa => fa.SubmittedAt) // Lấy thời gian nộp cuối cùng
                    })
                    .ToList();

                if (feedbackResponses.Count == 0)
                {
                    return NotFound("No feedback responses found for this class.");
                }

                return Ok(feedbackResponses);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }




        [HttpPost("doFeedback")]
        public IActionResult DoFeedback([FromBody] FeedbackRequestDto request)
        {
            try
            {
                
                var feedbackForm = _feedbackSystemContext.FeedbackForms
                    .FirstOrDefault(ff => ff.FormId == request.FormId && ff.IsActive == true);
                if (feedbackForm == null)
                {
                    return NotFound("Feedback form not found or is not active.");
                }

                
                var studentClass = _feedbackSystemContext.StudentClasses
                    .Any(sc => sc.StudentId == request.StudentId && sc.ClassId == feedbackForm.ClassId);
                if (!studentClass)
                {
                    return BadRequest("Student is not assigned to this class.");
                }

                
                var feedbackAnswers = request.Answers.Select(a => new FeedbackAnswer
                {
                    FormId = request.FormId,
                    StudentId = request.StudentId,
                    QuestionId = a.QuestionId,
                    
                    Answer = a.Answer,
                    SubmittedAt = DateTime.Now
                }).ToList();

                _feedbackSystemContext.FeedbackAnswers.AddRange(feedbackAnswers);
                _feedbackSystemContext.SaveChanges();

                return Ok(new
                {
                    Message = "Feedback submitted successfully.",
                    Questions = request.Answers.Select(a => new
                    {
                        a.QuestionId,
                        
                        a.Answer
                    })
                });

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("getFeedbackList/{studentId}")]
        public async Task<IActionResult> GetFeedbackList(int studentId)
        {
            try
            {
                var feedbackForms = await _feedbackSystemContext.FeedbackForms
                    .Where(f => f.Class.StudentClasses.Any(sc => sc.StudentId == studentId)) // Lấy feedback theo lớp học
                    .Where(f => !_feedbackSystemContext.FeedbackAnswers // Lọc ra các feedback mà sinh viên chưa làm
                        .Any(a => a.StudentId == studentId && a.FormId == f.FormId))
                    .Select(f => new
                    {
                        FeedbackFormId = f.FormId,
                        ClassName = f.Class.ClassName,
                        SubjectName = f.Subject.SubjectName,
                        TeacherName = f.Teacher.FullName,
                        StartDate = f.StartDate,
                        EndDate = f.EndDate,
                        IsActive = f.IsActive
                    })
                    .ToListAsync();

                if (!feedbackForms.Any())
                {
                    return NotFound("No pending feedback forms for this student.");
                }

                return Ok(feedbackForms);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }



    }



}
