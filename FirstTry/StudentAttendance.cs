using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstTry
{
    public class StudentAttendance
    {
        public int ClassScheduleID { get; set; }
        public ClassSchedule ClassSchedule { get; set; }
        public int StudentID { get; set; }
        public Student Student { get; set; }
        public DateTime AttendanceDate { get; set; }
        
    }
}
