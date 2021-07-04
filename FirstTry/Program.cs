using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FirstTry
{
    class Program
    {
        
        static void Main(string[] args)
        {
            var context = new ProjectDbContext();

            //User userOne = new User { UserType = "Admin", UserName = "Admin", Password = "admin" };

            //context.Users.Add(userOne);

            //context.SaveChanges();
            //string tikmark = ((char)0x221A).ToString();
            //Console.WriteLine(tikmark);

            Console.WriteLine("Enter your UserName and Password to log in.");
            Console.Write("Username: ");
            var userName = Console.ReadLine();
            
            Console.Write("Password: ");
            var userPassword = Console.ReadLine();
            string userType = string.Empty;
            int userID = 0;
            foreach(User u in context.Users)
            {
                if(userName == u.UserName && userPassword == u.Password)
                {
                    Console.WriteLine("{0} login successfull",u.UserType);
                    userType = u.UserType;
                    userID = u.ID;
                    break;
                }
            }
            context.SaveChanges();
            if (userType == "Admin")
            {
                int count = 1;
                for(int i = 0; i < count; i++)
                {
                    AdminOptions();
                    var selectedOption = Console.ReadLine();
                    if (selectedOption.ToLower() != "logout" && selectedOption !=string.Empty)
                    {
                        if (selectedOption == "1")
                        {
                            CreateUser();
                        }
                        else if (selectedOption == "2")
                        {
                            CreateTeacher();
                            
                        }
                        else if (selectedOption == "3")
                        {
                            CreateStudent();
                        }
                        else if (selectedOption == "4")
                        {
                            CreateCourse();
                        }
                        else if (selectedOption == "5")
                        {
                            EnrollStudentsToACourse();
                        }
                        else if (selectedOption == "6")
                        {
                            AssignCoursesToAStudent();
                        }
                        else if (selectedOption == "7")
                        {
                            Console.WriteLine("Select a course from the list to schedule classes");
                            ScheduleClassesForACourse();
                            //GetClassesList();
                        }
                        count++;
                    }
                    else
                    {
                        break;
                    }
                    
                }
                
                
                

            }
            else if(userType == "Student")
            {
                var studentId = 0;
                foreach (Student s in context.Students)
                {
                    if (userName == s.UserName)
                    {
                        studentId = s.ID;
                        break;
                    }
                }
                
                int count = 1;
                for (int i = 0; i < count; i++)
                {
                    StudentOptions();
                    var studentInput = Console.ReadLine();
                    if (studentInput.ToLower() != "logout" && studentInput != string.Empty)
                    {
                        if (studentInput == "1")
                        {
                            GetSchedules(studentId);
                        }
                        else if (studentInput == "2")
                        {
                            
                            GiveAttendance(studentId);
                            
                            
                        }
                        count++;
                    }
                    else
                    {
                        break;
                    }
                }
                
                    
            }
            else if(userType == "Teacher")
            {
                var teacherId = 0;
                foreach (Teacher t in context.Teachers)
                {
                    if (userName == t.UserName)
                    {
                        teacherId = t.ID;
                        break;
                    }
                }
                int count = 1;
                for (int i = 0; i < count; i++)
                {
                    TeacherOptions();
                    var teacherInput = Console.ReadLine();
                    if (teacherInput.ToLower() != "logout" && teacherInput != string.Empty)
                    {
                        if (teacherInput == "1")
                        {
                            GetSchedules(teacherId);
                        }
                        else if (teacherInput == "2")
                        {
                            Console.WriteLine("Enter a student id to check: ");
                            var studentID = int.Parse(Console.ReadLine());
                            CheckAttendance(studentID);


                        }
                        count++;
                    }
                    else
                    {
                        break;
                    }
                }
                
            }

        }
        public static void AdminOptions()
        {
            Console.WriteLine("Type \"logout\" to close the programe Or Select one from the list(enter number only) ");
            Console.WriteLine("1) Create a User");
            Console.WriteLine("2) Create a Teacher");
            Console.WriteLine("3) Create a Student");
            Console.WriteLine("4) Create a Course and Assigned it to a Teacher");
            Console.WriteLine("5) Enroll Students to a Course");
            Console.WriteLine("6) Assign Courses to a Student");
            Console.WriteLine("7) Schedule Classes for a Course");
        }
        public static void StudentOptions()
        {
            Console.WriteLine();
            Console.WriteLine("Type \"logout\" to close the programe Or Select One from the list");
            Console.WriteLine("1) Watch upcoming schedules of classes");
            Console.WriteLine("2) Give Attendance");
        }
        public static void TeacherOptions()
        {
            Console.WriteLine();
            Console.WriteLine("Type \"logout\" to close the programe Or Select One from the list");
            Console.WriteLine("1) Watch upcoming schedules of classes");
            Console.WriteLine("2) Check Student Attendance");
        }
        public static void CreateStudent()
        {
            var context = new ProjectDbContext();

            Student newStudent = new Student();
            User newUser = new User();

            Console.WriteLine("Enter student details");

            Console.Write("Student Name: ");
            var studentName = Console.ReadLine();
            Console.Write("Student Age: ");
            var studentAge = int.Parse(Console.ReadLine());
            Console.Write("Student Hometown: ");
            var studentHometown = Console.ReadLine();
            //Console.Write("Student log in UserName: ");
            int loopLimit = 1;
            var userName = string.Empty;
            //foreach (User user in context.Users)
            //{
            //    if(userName == user.UserName)
            //    {
            //        Console.WriteLine("Username taken. Try again.");
            //        userName = string.Empty;
            //        loopLimit++;
            //        break;
            //    }
            //}
            for (int i = 0; i < loopLimit; i++)
            {
                Console.Write("Student log in UserName: ");

                userName = Console.ReadLine();
                foreach (User user in context.Users)
                {
                    if (userName == user.UserName)
                    {
                        Console.WriteLine("Username taken. Try again.");
                        loopLimit++;
                        break;
                    }
                }
            }
            //if(userName == string.Empty)
            //{
                
            //}

            Console.Write("Student log in Password: ");
            var password = Console.ReadLine();

            newStudent.Name = studentName;
            newStudent.Age = studentAge;
            newStudent.HomeTown = studentHometown;
            newStudent.UserName = userName;
            newStudent.Password = password;

            context.Students.Add(newStudent);

            newUser.UserType = "Student";
            newUser.UserName = userName;
            newUser.Password = password;

            context.Users.Add(newUser);

            context.SaveChanges();

            Console.WriteLine("Student Created Successfully");
            

        }
        public static void CreateUser()
        {
            var context = new ProjectDbContext();

            User newUser = new User();

            Console.WriteLine("Enter User details");

            Console.Write("UserType: ");
            var UserType = Console.ReadLine();
            Console.Write("UserName: ");
            var UserName = Console.ReadLine();
            Console.Write("Password: ");
            var Password = Console.ReadLine();

            newUser.UserType = UserType;
            newUser.UserName = UserName;
            newUser.Password = Password;

            context.Users.Add(newUser);

            context.SaveChanges();
            Console.WriteLine("New User Created Successfully");

        }
        public static void CreateCourse()
        {
            var context = new ProjectDbContext();

            Course newCourse = new Course();

            Console.WriteLine("Enter Course details");

            Console.Write("Title: ");
            var Title = Console.ReadLine();
            Console.Write("Fees: ");
            var Fees = decimal.Parse(Console.ReadLine());
            Console.Write("Number of classes in the course: ");
            var classTotal = int.Parse(Console.ReadLine());
            Console.Write("StartDate: ");
            var StartDate = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Assign a teacher's ID for the course or enter \"0\" to see all teacher's ID ");
            var userInput = int.Parse(Console.ReadLine());
            var TeacherID = 0;
            if (userInput == 0)
            {
                GetAllTeacher();
                Console.Write("Assigned teacher's ID for the course: ");
                TeacherID = int.Parse(Console.ReadLine());
            }
            else if (userInput > 0)
            {
                TeacherID = userInput;
                Console.WriteLine("Assigned teacher's ID for the course: {0}", TeacherID);
            }

            newCourse.Title = Title;
            newCourse.Fees = Fees;
            newCourse.StartDate = StartDate;
            newCourse.TeacherID = TeacherID;
            newCourse.NumberOfClasses = classTotal;

            context.Courses.Add(newCourse);

            context.SaveChanges();

            Console.WriteLine("New Course Created and Assigned To A Teacher Successfully");

        }
        public static void CreateTeacher()
        {
            var context = new ProjectDbContext();

            Teacher newTeacher = new Teacher();

            User newUser = new User();

            Console.WriteLine("Enter Teacher details");

            Console.Write("Teacher Name: ");
            var teacherName = Console.ReadLine();
            Console.Write("Salary Type: ");
            var salaryType = Console.ReadLine();
            Console.Write("Teacher's Designation: ");
            var designation = Console.ReadLine();

            int loopLimit = 1;
            var userName = string.Empty;

            for (int i = 0; i < loopLimit; i++)
            {
                Console.Write("Teacher log in UserName: ");

                userName = Console.ReadLine();
                foreach (User user in context.Users)
                {
                    if (userName == user.UserName)
                    {
                        Console.WriteLine("Username taken. Try again.");
                        loopLimit++;
                        break;
                    }
                }
            }

            Console.Write("Teacher log in Password: ");
            var password = Console.ReadLine();

            newTeacher.Name = teacherName;
            newTeacher.SalaryType = salaryType;
            newTeacher.Designation = designation;
            newTeacher.UserName = userName;
            newTeacher.Password = password;

            context.Teachers.Add(newTeacher);

            newUser.UserType = "Teacher";
            newUser.UserName = userName;
            newUser.Password = password;

            context.Users.Add(newUser);

            context.SaveChanges();

            Console.WriteLine("New Teacher Created Successfully");

        }

        public static void EnrollStudentsToACourse()
        {
            var context = new ProjectDbContext();

            Course newCourse = new Course();

            Console.WriteLine("Enter Course details first:");

            Console.Write("Title: ");
            var Title = Console.ReadLine();
            Console.Write("Fees: ");
            var Fees = decimal.Parse(Console.ReadLine());
            Console.Write("StartDate: ");
            var StartDate = DateTime.Parse(Console.ReadLine());
            Console.Write("Number of classes in the course: ");
            var classTotal = int.Parse(Console.ReadLine());


            Console.WriteLine("Assign a teacher's ID for the course or enter \"0\" to see all teacher's ID ");
            var userInput = int.Parse(Console.ReadLine());
            var TeacherID = 0;
            if (userInput == 0)
            {
                GetAllTeacher();
                Console.Write("Assigned teacher's ID for the course: ");
                TeacherID = int.Parse(Console.ReadLine());
            }
            else if(userInput>0)
            {
                TeacherID = userInput;
                Console.WriteLine("Assigned teacher's ID for the course: {0}", TeacherID);
            }
            

            newCourse.Title = Title;
            newCourse.Fees = Fees;
            newCourse.StartDate = StartDate;
            newCourse.NumberOfClasses = classTotal;
            newCourse.TeacherID = TeacherID;

            newCourse.EnrolledStudents = new List<CourseStudent>();


            Console.WriteLine("Enter the number of students to assign in the course ");
            int numberofStudents = int.Parse(Console.ReadLine());
            string[] names = new string[numberofStudents];
            for(int i = 0; i < numberofStudents; i++)
            {
                Student newStudent = new Student();
                Console.WriteLine("Enter student{0} details",i+1);
                Console.Write("Student Name: ");
                var studentName = Console.ReadLine();
                Console.Write("Student Age: ");
                var studentAge = int.Parse(Console.ReadLine());
                Console.Write("Student Hometown: ");
                var studentHometown = Console.ReadLine();
                int loopLimit = 1;
                var userName = string.Empty;
                for (int k = 0; k < loopLimit; k++)
                {
                    Console.Write("Student log in UserName: ");

                    userName = Console.ReadLine();
                    foreach (User user in context.Users)
                    {
                        if (userName == user.UserName)
                        {
                            Console.WriteLine("Username taken. Try again.");
                            loopLimit++;
                            break;
                        }
                    }
                }

                Console.Write("Student log in Password: ");
                var password = Console.ReadLine();

                newStudent.Name = studentName;
                newStudent.Age = studentAge;
                newStudent.HomeTown = studentHometown;
                newStudent.UserName = userName;
                newStudent.Password = password;

                User newUser = new User();
                newUser.UserType = "Student";
                newUser.UserName = userName;
                newUser.Password = password;

                context.Users.Add(newUser);

                var assignStudent = new CourseStudent();
                assignStudent.Student = newStudent;
                assignStudent.EnrollmentDate = DateTime.Now;

                newCourse.EnrolledStudents.Add(assignStudent);
                names[i] = studentName;
            }

            
            context.Courses.Add(newCourse);
            context.SaveChanges();

            foreach(string name in names)
            {
                Console.Write(name+ ", ");
            }
            Console.WriteLine("sucessfully enrolled in {0}",newCourse.Title);
        }

        public static void AssignCoursesToAStudent()
        {
            var context = new ProjectDbContext();

            User newUser = new User();

            Student newStudent = new Student();



            Console.WriteLine("Enter Student details first:");

            Console.Write("Student Name: ");
            var studentName = Console.ReadLine();
            Console.Write("Student Age: ");
            var studentAge = int.Parse(Console.ReadLine());
            Console.Write("Student Hometown: ");
            var studentHometown = Console.ReadLine();

            int loopLimit = 1;
            var userName = string.Empty;

            for (int i = 0; i < loopLimit; i++)
            {
                Console.Write("Student log in UserName: ");

                userName = Console.ReadLine();
                foreach (User user in context.Users)
                {
                    if (userName == user.UserName)
                    {
                        Console.WriteLine("Username taken. Try again.");
                        loopLimit++;
                        break;
                    }
                }
            }

            Console.Write("Student log in Password: ");
            var password = Console.ReadLine();

            newStudent.Name = studentName;
            newStudent.Age = studentAge;
            newStudent.HomeTown = studentHometown;
            newStudent.UserName = userName;
            newStudent.Password = password;

            newStudent.AssignedCourses = new List<CourseStudent>();

            newUser.UserType = "Student";
            newUser.UserName = userName;
            newUser.Password = password;

            Console.WriteLine("Enter the number of Courses to be assigned to the student ");
            int numberofCoursess = int.Parse(Console.ReadLine());
            string[] names = new string[numberofCoursess];
            for (int i = 0; i < numberofCoursess; i++)
            {
                Course newCourse = new Course();
                Console.WriteLine("Enter course{0} details", i + 1);
                Console.Write("Title: ");
                var Title = Console.ReadLine();
                Console.Write("Fees: ");
                var Fees = decimal.Parse(Console.ReadLine());
                Console.Write("StartDate: ");
                var StartDate = DateTime.Parse(Console.ReadLine());
                Console.Write("Number of classes in the course: ");
                var classTotal = int.Parse(Console.ReadLine());

                Console.WriteLine("Assign a teacher's ID for the course or enter \"0\" to see all teacher's ID ");
                var userInput = int.Parse(Console.ReadLine());
                var TeacherID = 0;
                if (userInput == 0)
                {
                    GetAllTeacher();
                    Console.Write("Assigned teacher's ID for the course: ");
                    TeacherID = int.Parse(Console.ReadLine());
                }
                else if (userInput > 0)
                {
                    TeacherID = userInput;
                    Console.WriteLine("Assigned teacher's ID for the course: {0}", TeacherID);
                }

                newCourse.Title = Title;
                newCourse.Fees = Fees;
                newCourse.StartDate = StartDate;
                newCourse.TeacherID = TeacherID;
                newCourse.NumberOfClasses = classTotal;

                var assignCourse = new CourseStudent();
                assignCourse.Course = newCourse;
                assignCourse.EnrollmentDate = DateTime.Now;

                newStudent.AssignedCourses.Add(assignCourse);
                names[i] = Title;
                
            }


            context.Students.Add(newStudent);

            context.Users.Add(newUser);

            

            foreach (string name in names)
            {
                Console.Write(name + ", ");
            }
            Console.WriteLine("sucessfully assigned to {0}", newStudent.Name);
            context.SaveChanges();
        }

        public static void GetAllTeacher()
        {
            var context = new ProjectDbContext();

            foreach(var Teacher in context.Teachers)
            {
                Console.WriteLine("Teacher's ID: {0}, Teacher's Name: {1}",Teacher.ID,Teacher.Name );
            }
        }
        public static void ScheduleClassesForACourse()
        {
            var context = new ProjectDbContext();
            List<int> courseIDs = new List<int>();
            int serial = 1;
            foreach (var Course in context.Courses)
            {
                
                Console.WriteLine("{0}) Course ID: {1}, Course Title: {2}, Course Start Date: {3}", 
                    serial, Course.ID, Course.Title, Course.StartDate.ToShortDateString());

                courseIDs.Add(Course.ID);
                serial++;
            }
            var selectedCourse = int.Parse(Console.ReadLine());
            if (selectedCourse <= courseIDs.Count)
            {
                int count = 0;
                foreach (ClassSchedule cs in context.ClassSchedules)
                {
                    if (cs.CourseID == courseIDs[selectedCourse - 1])
                    {
                        count++;
                    }
                }
                
                if (count < context.Courses.Find(courseIDs[selectedCourse - 1]).NumberOfClasses)
                {
                    ClassSchedule newClassSchedule = new ClassSchedule();

                    Console.WriteLine("Enter Class Date With Time");
                    var classDateAndTime = DateTime.Parse(Console.ReadLine());
                    var courseStartDate = context.Courses.Find(courseIDs[selectedCourse - 1]).StartDate;
                    if (classDateAndTime > courseStartDate)
                    {
                        var condition = 0;
                        var getSchedules = context.ClassSchedules.Where(x => x.CourseID == courseIDs[selectedCourse - 1]).ToList();
                        foreach (ClassSchedule cs in getSchedules)
                        {
                            if (classDateAndTime.Date == DateTime.Parse(cs.ClassDate).Date)
                            {
                                Console.WriteLine("There is already a class scheduled on this day");
                                condition++;
                                break;
                            }
                            
                        }
                        if (condition == 0)
                        {
                            newClassSchedule.ClassDate = classDateAndTime.ToLongDateString();
                            newClassSchedule.ClassStartTime = classDateAndTime.ToShortTimeString();
                            newClassSchedule.ClassEndTime = classDateAndTime.AddHours(2).ToShortTimeString();
                            newClassSchedule.CourseID = courseIDs[selectedCourse - 1];

                            context.ClassSchedules.Add(newClassSchedule);

                            Console.WriteLine($"So class {count + 1} of {context.Courses.Find(courseIDs[selectedCourse - 1]).Title}" +
                            $" will held on {newClassSchedule.ClassDate} from {newClassSchedule.ClassStartTime}" +
                            $" to {newClassSchedule.ClassEndTime}");
                        }
                        //foreach(ClassSchedule cs in context.ClassSchedules)
                        //{
                        //    if (cs.CourseID == courseIDs[selectedCourse - 1])
                        //    {

                        //    }
                        //}
                        //newClassSchedule.ClassDate = classDateAndTime.ToLongDateString();
                        //newClassSchedule.ClassStartTime = classDateAndTime.ToShortTimeString();
                        //newClassSchedule.ClassEndTime = classDateAndTime.AddHours(2).ToShortTimeString();
                        //newClassSchedule.CourseID = courseIDs[selectedCourse - 1];

                        //context.ClassSchedules.Add(newClassSchedule);

                        //Console.WriteLine($"So class {count + 1} of {context.Courses.Find(courseIDs[selectedCourse - 1]).Title}" +
                        //$" will held on {newClassSchedule.ClassDate} from {newClassSchedule.ClassStartTime}" +
                        //$" to {newClassSchedule.ClassEndTime}");
                    }
                    else
                    {
                        Console.WriteLine("Wrong Input");
                        Console.WriteLine("Schedule class date has to be greater than course start date");
                    }
                }
                else
                {
                    Console.WriteLine("This course already has all classes scheduled");
                }
            }

            context.SaveChanges();

        }

        
        public static void GetSchedules(int id)
        {
            var context = new ProjectDbContext();
            
            //var getStudent = context.Students.Find(id);
            var getStudent = context.Students.Where(x => x.ID == id).Include("AssignedCourses").ToList();
            int[]  coursesID = new int[getStudent[0].AssignedCourses.Count];
            string[] coursesName = new string[getStudent[0].AssignedCourses.Count];
            //List<string> classSchedules = new List<string>(); 

            int index = 0;
            foreach (CourseStudent cs in getStudent[0].AssignedCourses)
            {

                coursesID[index]=cs.CourseID;
                index++;
            }
            index = 0;
            foreach(int cid in coursesID)
            {
                foreach(Course c in context.Courses)
                {
                    if (cid == c.ID)
                    {
                        coursesName[index] = c.Title;
                        index++;
                        break;
                    }
                }
            }
            index = 0;
            
            if (coursesName.Length < 0)
            {
                Console.WriteLine("You haven't enrolled in any course");
            }
            else
            {
                Console.WriteLine("Select a course to see schedules");
                
                for (int i = 0; i < coursesName.Length; i++)
                {
                    Console.WriteLine($"{i + 1}) {coursesName[i]}");
                }
                var selectedCourse = int.Parse(Console.ReadLine())-1;
                var selectedCourseID = coursesID[selectedCourse];
                var classCount = GetCourses(selectedCourseID);
                if (classCount > 0)
                {
                    foreach (ClassSchedule cs in context.ClassSchedules)
                    {
                        if (selectedCourseID == cs.CourseID)
                        {


                            {
                                var dateOne = DateTime.Now;
                                var dateTwo = DateTime.Parse(cs.ClassDate);
                                //dateTwo.AddHours(DateTime.TryParseExact(cs.ClassStartTime, "hh:mm:ss tt"));
                                if (dateOne.Date <= dateTwo.Date)
                                    Console.WriteLine(cs.ClassDate + " " + cs.ClassStartTime);
                            }
                        


                        }
                    }
                }
                else
                {
                    Console.WriteLine("No Scheduled class for this course");
                }


            }
            
            
            
            
        }
        public static int GetCourses(int id)
        {
            var context = new ProjectDbContext();
            
            var getCourse = context.Courses.Where(x => x.ID == id).Include("Classes").ToList();
            var x = getCourse[0].Classes.Count;
            return x;
        }
        public static void GiveAttendance(int id)
        {
            var context = new ProjectDbContext();

            //var getStudent = context.Students.Find(id);
            var getStudent = context.Students.Where(x => x.ID == id).Include("AssignedCourses").ToList();
            int[] coursesID = new int[getStudent[0].AssignedCourses.Count];
            string[] coursesName = new string[getStudent[0].AssignedCourses.Count];
            //List<string> classSchedules = new List<string>(); 

            int index = 0;
            foreach (CourseStudent cs in getStudent[0].AssignedCourses)
            {

                coursesID[index] = cs.CourseID;
                index++;
            }
            index = 0;
            foreach (int cid in coursesID)
            {
                foreach (Course c in context.Courses)
                {
                    if (cid == c.ID)
                    {
                        coursesName[index] = c.Title;
                        index++;
                        break;
                    }
                }
            }
            index = 0;

            if (coursesName.Length < 0)
            {
                Console.WriteLine("You haven't enrolled in any course");
            }
            else
            {

                Console.WriteLine("Selected a course to give attendance: ");
                for (int i = 0; i < coursesName.Length; i++)
                {
                    Console.WriteLine($"{i + 1}) {coursesName[i]}");
                }
                
                var selectedCourse = int.Parse(Console.ReadLine()) - 1;
                var selectedCourseID = coursesID[selectedCourse];
                foreach (Course c in context.Courses)
                {
                    if (selectedCourseID == c.ID)
                    {
                        
                        SortedList<DateTime, string> classDates = new SortedList<DateTime,string>();
                        SortedList<DateTime, int> classScheduleIDs = new SortedList<DateTime, int>();
                        var context2 = new ProjectDbContext();
                        var getCourse = context2.Courses.Where(x => x.ID == selectedCourseID).Include("Classes").ToList();
                        var classCount = getCourse[0].Classes.Count;
                        if (classCount == 0)
                        {
                            Console.WriteLine("No scheduled class for this course");
                        }
                        else 
                        {
                            foreach (ClassSchedule cs in getCourse[0].Classes)
                            {
                                if (DateTime.Now.Date <= DateTime.Parse(cs.ClassDate).Date)
                                    classDates.Add(DateTime.Parse(cs.ClassDate), cs.ClassStartTime);
                                classScheduleIDs.Add(DateTime.Parse(cs.ClassDate), cs.ID);
                            }

                            foreach (DateTime d in classDates.Keys)
                            {
                                if (d.Date == DateTime.Now.Date)
                                {
                                    var stringStartTime = d.ToShortDateString() + " " + classDates.GetValueOrDefault(d);
                                    var startTime = DateTime.Parse(stringStartTime);
                                    //var stringEndTime = cs.ClassDate + " " + cs.ClassEndTime;
                                    //var endTime = DateTime.Parse(stringEndTime);

                                    if (DateTime.Now > startTime && DateTime.Now < startTime.AddHours(2))
                                    {

                                        Console.WriteLine("Attendance Done");
                                        var context3 = new ProjectDbContext();
                                        var newAttendance = new StudentAttendance();

                                        newAttendance.StudentID = id;
                                        newAttendance.AttendanceDate = DateTime.Now;
                                        newAttendance.ClassScheduleID = classScheduleIDs.GetValueOrDefault(d);

                                        context3.StudentAttendances.Add(newAttendance);
                                        context3.SaveChanges();




                                    }
                                    else if (DateTime.Now < startTime)
                                    {
                                        Console.WriteLine("Class haven't started yet");

                                    }
                                    else if (DateTime.Now > startTime.AddHours(2))
                                    {
                                        Console.WriteLine("Class ended");
                                    }
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("No scheduled class today");
                                    break;
                                }

                            }
                        }
                        

                    }
                }

            }
        }

        public static void CheckAttendance(int id)
        {

            var context = new ProjectDbContext();
            var getAttendance = context.StudentAttendances.Where(x => x.StudentID == id).ToList();
            List<String> classDates = new List<String>();
            foreach (StudentAttendance sa in getAttendance)
            {
                classDates.Add(getAttendance[0].AttendanceDate.ToLongDateString());
            }
            var getCourse = context.Students.Where(x => x.ID == id).Include("AssignedCourses").ToList();
            int[] coursesID = new int[getCourse[0].AssignedCourses.Count];
            string[] coursesName = new string[getCourse[0].AssignedCourses.Count];
            //List<string> classSchedules = new List<string>(); 

            int index = 0;
            foreach (CourseStudent cs in getCourse[0].AssignedCourses)
            {

                coursesID[index] = cs.CourseID;
                index++;
            }
            index = 0;
            foreach (int cid in coursesID)
            {
                foreach (Course c in context.Courses)
                {
                    if (cid == c.ID)
                    {
                        coursesName[index] = c.Title;
                        index++;
                        break;
                    }
                }
            }
            index = 0;
            if (coursesName.Length < 0)
            {
                Console.WriteLine("Student haven't enrolled in any course");
            }
            else
            {
                Console.WriteLine("Select a course to see attendances");

                for (int i = 0; i < coursesName.Length; i++)
                {
                    Console.WriteLine($"{i + 1}) Course Title: {coursesName[i]}, Course ID: {coursesID[i]}");
                }
                var selectedCourse = int.Parse(Console.ReadLine()) - 1;
                var selectedCourseID = coursesID[selectedCourse];
                List<String> classScheduleDates = new List<String>();
                var classCount = GetCourses(selectedCourseID);
                if (classCount > 0)
                {
                    foreach (ClassSchedule cs in context.ClassSchedules)
                    {
                        if (selectedCourseID == cs.CourseID)
                        {

                            classScheduleDates.Add(cs.ClassDate);

                        }
                    }
                }
                else
                {
                    Console.WriteLine("No Scheduled class for this course");
                }
                string tikMark = ((char)0x221A).ToString();
                
                foreach (string classToCheck in classScheduleDates)
                {
                    if(DateTime.Parse(classToCheck).Date<= DateTime.Now.Date)
                    {
                        foreach (string attendenClass in classDates)
                        {
                            if (classToCheck == attendenClass)
                            {
                                Console.WriteLine($"student has attended the class " +
                                    $"{classScheduleDates.IndexOf(classToCheck) + 1} held on {classToCheck} " +
                                    $"{tikMark}");
                            }
                            else
                            {
                                Console.WriteLine($"student hasn't attended the class " +
                                    $"{classScheduleDates.IndexOf(classToCheck) + 1} " +
                                    $"held on {classToCheck} X");
                            }
                        }
                    }
                    
                }



            }

           

        }
        
        public static void GetSchedulesForTeacher(int id)
        {
            var context = new ProjectDbContext();
            var getCourse = context.Courses.Where(x => x.ID == id).Include("Classes").ToList();
            List<String> getClassSchedules = new List<string>();
            foreach(ClassSchedule cs in getCourse[0].Classes)
            {
                if (DateTime.Parse(cs.ClassDate).Date >= DateTime.Now.Date)
                {
                    getClassSchedules.Add(cs.ClassDate + " " + cs.ClassStartTime);
                }
            }
            for(int i = 0; i < getClassSchedules.Count; i++)
            {
                Console.WriteLine(getClassSchedules[i]);
            }

        }

    }
}
