using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstTry
{
    public class Student
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string HomeTown { get; set; }

        public string UserName { get; set; }
        public string Password { get; set; }
        //public User User { get; set; }
        public List<CourseStudent> AssignedCourses { get; set; }
        public List<StudentAttendance> Attendances { get; set; }

    }
}
