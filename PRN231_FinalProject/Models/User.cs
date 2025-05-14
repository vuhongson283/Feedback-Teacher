using System;
using System.Collections.Generic;

namespace PRN231_FinalProject.Models
{
    public partial class User
    {
        public User()
        {
            ClassAssignments = new HashSet<ClassAssignment>();
            FeedbackAnswers = new HashSet<FeedbackAnswer>();
            FeedbackForms = new HashSet<FeedbackForm>();
            StudentClasses = new HashSet<StudentClass>();
        }

        public int UserId { get; set; }
        public string FullName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public string Role { get; set; } = null!;
        public DateTime? CreatedAt { get; set; }

        public virtual ICollection<ClassAssignment> ClassAssignments { get; set; }
        public virtual ICollection<FeedbackAnswer> FeedbackAnswers { get; set; }
        public virtual ICollection<FeedbackForm> FeedbackForms { get; set; }
        public virtual ICollection<StudentClass> StudentClasses { get; set; }
    }
}
