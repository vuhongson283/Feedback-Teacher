using System;
using System.Collections.Generic;

namespace PRN231_FinalProject.Models
{
    public partial class ClassAssignment
    {
        public int AssignmentId { get; set; }
        public int ClassId { get; set; }
        public int SubjectId { get; set; }
        public int TeacherId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public virtual Class Class { get; set; } = null!;
        public virtual Subject Subject { get; set; } = null!;
        public virtual User Teacher { get; set; } = null!;
    }
}
