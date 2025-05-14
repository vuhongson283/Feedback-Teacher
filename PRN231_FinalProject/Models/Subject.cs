using System;
using System.Collections.Generic;

namespace PRN231_FinalProject.Models
{
    public partial class Subject
    {
        public Subject()
        {
            ClassAssignments = new HashSet<ClassAssignment>();
            FeedbackForms = new HashSet<FeedbackForm>();
        }

        public int SubjectId { get; set; }
        public string SubjectName { get; set; } = null!;
        public DateTime? CreatedAt { get; set; }

        public virtual ICollection<ClassAssignment> ClassAssignments { get; set; }
        public virtual ICollection<FeedbackForm> FeedbackForms { get; set; }
    }
}
