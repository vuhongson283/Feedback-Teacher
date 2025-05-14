using System;
using System.Collections.Generic;

namespace PRN231_FinalProject.Models
{
    public partial class StudentClass
    {
        public int StudentClassId { get; set; }
        public int StudentId { get; set; }
        public int ClassId { get; set; }

        public virtual Class Class { get; set; } = null!;
        public virtual User Student { get; set; } = null!;
    }
}
