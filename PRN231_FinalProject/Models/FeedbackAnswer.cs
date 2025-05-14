using System;
using System.Collections.Generic;

namespace PRN231_FinalProject.Models
{
    public partial class FeedbackAnswer
    {
        public int AnswerId { get; set; }
        public int FormId { get; set; }
        public int StudentId { get; set; }
        public int QuestionId { get; set; }
        public string Answer { get; set; } = null!;
        public DateTime? SubmittedAt { get; set; }

        public virtual FeedbackForm Form { get; set; } = null!;
        public virtual FeedbackQuestion Question { get; set; } = null!;
        public virtual User Student { get; set; } = null!;
    }
}
