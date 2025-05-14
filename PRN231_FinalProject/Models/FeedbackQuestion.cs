using System;
using System.Collections.Generic;

namespace PRN231_FinalProject.Models
{
    public partial class FeedbackQuestion
    {
        public FeedbackQuestion()
        {
            FeedbackAnswers = new HashSet<FeedbackAnswer>();
        }

        public int QuestionId { get; set; }
        public string QuestionText { get; set; } = null!;

        public virtual ICollection<FeedbackAnswer> FeedbackAnswers { get; set; }
    }
}
