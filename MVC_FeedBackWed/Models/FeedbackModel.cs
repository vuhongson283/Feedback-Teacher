namespace MVC_FeedBackWed.Models
{
    public class FeedbackModel
    {
        public int FeedbackFormId { get; set; }
        public string ClassName { get; set; }
        public string SubjectName { get; set; }
        public string TeacherName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsActive { get; set; }
    }
}
