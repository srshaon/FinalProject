﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstTry
{
    public class CourseStudent
    {
        public int CourseID { get; set; }
        public Course Course { get; set; }
        public int StudentID { get; set; }
        public Student Student { get; set; }
        
        public DateTime EnrollmentDate { get; set; } 
    }
}
