using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstTry
{
    public class ClassSchedule
    {
        public int ID { get; set; }
        public string ClassTime { get; set; }
        public int CourseID { get; set; }
        public Course Course { get; set; }
    }
}
