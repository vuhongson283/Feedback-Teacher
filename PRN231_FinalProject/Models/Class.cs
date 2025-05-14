using System;
using System.Collections.Generic;

namespace PRN231_FinalProject.Models
{
    public partial class Class
    {
        public Class()
        {
            ClassAssignments = new HashSet<ClassAssignment>();
            FeedbackForms = new HashSet<FeedbackForm>();
            StudentClasses = new HashSet<StudentClass>();
        }

        public int ClassId { get; set; }
        public string ClassName { get; set; } = null!;
        public DateTime? CreatedAt { get; set; }

        public virtual ICollection<ClassAssignment> ClassAssignments { get; set; }
        public virtual ICollection<FeedbackForm> FeedbackForms { get; set; }
        public virtual ICollection<StudentClass> StudentClasses { get; set; }
    }
}
