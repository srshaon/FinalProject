using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstTry
{
    public class Course
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public decimal Fees { get; set; }
        public DateTime StartDate { get; set; }
        public int TeacherID { get; set; }
        public Teacher Teacher { get; set; }
        public List<CourseStudent> EnrolledStudents { get; set; }
        public List<ClassSchedule> Classes { get; set; }
        


    }
}
