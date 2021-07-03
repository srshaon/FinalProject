using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstTry
{
    public class Teacher
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public  string SalaryType { get; set; }
        public string Designation { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public List<Course> HandledCourses { get; set; }
    }
}
