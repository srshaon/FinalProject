using System;
using System.Collections.Generic;

namespace FirstTry
{
    class Program
    {
        
        static void Main(string[] args)
        {
            

            //User userOne = new User { UserType = "Admin", UserName = "Admin", Password = "admin" };

            //context.Users.Add(userOne);

            //context.SaveChanges();

            Console.WriteLine("Enter Your UserName and Password");
            Console.Write("Username: ");
            var userName = Console.ReadLine();
            //Console.Write(userName);
            Console.Write("Password: ");
            Console.ReadLine();
            if (userName == "Admin")
            {
                int count = 1;
                for(int i = 0; i < count; i++)
                {
                    AdminOptions();
                    var selectedOption = Console.ReadLine();
                    if (selectedOption.ToLower() != "end" && selectedOption !=string.Empty)
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
                            AssignStudentsToACourse();
                        }
                        else if (selectedOption == "6")
                        {
                            AssignCoursesToAStudent();
                        }
                        else if (selectedOption == "7")
                        {
                            Console.WriteLine("Select a course from the list to schedule classes");
                            AssignClassesToACourse();
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
            Console.WriteLine("Type \"end\" to close the programe Or Select one from the list(enter number only) ");
            Console.WriteLine("1) Create a User");
            Console.WriteLine("2) Create a Teacher");
            Console.WriteLine("3) Create a Student");
            Console.WriteLine("4) Create a Course and Assigned it to a Teacher");
            Console.WriteLine("5) Enroll Students to a Course");
            Console.WriteLine("6) Assign Courses to a Student");
            Console.WriteLine("7) Assign Classes to a Course");
        }
        public static void CreateStudent()
        {
            var context = new ProjectDbContext();

            Student newStudent = new Student();

            Console.WriteLine("Enter student details");

            Console.Write("Student Name: ");
            var studentName = Console.ReadLine();
            Console.Write("Student Age: ");
            var studentAge = int.Parse(Console.ReadLine());
            Console.Write("Student Hometown: ");
            var studentHometown = Console.ReadLine();

            newStudent.Name = studentName;
            newStudent.Age = studentAge;
            newStudent.HomeTown = studentHometown;

            context.Students.Add(newStudent);

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
            Console.Write("StartDate: ");
            var StartDate = DateTime.Parse(Console.ReadLine());
            Console.Write("Assiged teacher's ID for the course: ");
            var TeacherID = int.Parse(Console.ReadLine());

            newCourse.Title = Title;
            newCourse.Fees = Fees;
            newCourse.StartDate = StartDate;
            newCourse.TeacherID = TeacherID;

            context.Courses.Add(newCourse);

            context.SaveChanges();

            Console.WriteLine("New Course Created and Assigned To A Teacher Successfully");

        }
        public static void CreateTeacher()
        {
            var context = new ProjectDbContext();

            Teacher newTeacher = new Teacher();

            Console.WriteLine("Enter Teacher details");

            Console.Write("Teacher Name: ");
            var teacherName = Console.ReadLine();
            Console.Write("Salary Type: ");
            var salaryType = Console.ReadLine();
            Console.Write("Teacher's Designation: ");
            var designation = Console.ReadLine();

            newTeacher.Name = teacherName;
            newTeacher.SalaryType = salaryType;
            newTeacher.Designation = designation;

            context.Teachers.Add(newTeacher);

            context.SaveChanges();

            Console.WriteLine("New Teacher Created Successfully");

        }

        public static void AssignStudentsToACourse()
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
            

            Console.WriteLine("Assiged a teacher's ID for the course or enter \"0\" to see all teacher's ID ");
            var userInput = int.Parse(Console.ReadLine());
            var TeacherID = 0;
            if (userInput == 0)
            {
                GetAllTeacher();
                Console.Write("Assiged teacher's ID for the course: ");
                TeacherID = int.Parse(Console.ReadLine());
            }
            else if(userInput>0)
            {
                TeacherID = userInput;
                Console.WriteLine("Assiged teacher's ID for the course: {0}", TeacherID);
            }
            

            newCourse.Title = Title;
            newCourse.Fees = Fees;
            newCourse.StartDate = StartDate;
            
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

                newStudent.Name = studentName;
                newStudent.Age = studentAge;
                newStudent.HomeTown = studentHometown;

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

            Student newStudent = new Student();

            Console.WriteLine("Enter Student details first:");

            Console.Write("Student Name: ");
            var studentName = Console.ReadLine();
            Console.Write("Student Age: ");
            var studentAge = int.Parse(Console.ReadLine());
            Console.Write("Student Hometown: ");
            var studentHometown = Console.ReadLine();

            newStudent.Name = studentName;
            newStudent.Age = studentAge;
            newStudent.HomeTown = studentHometown;

            newStudent.AssignedCourses = new List<CourseStudent>();

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

                Console.WriteLine("Assiged a teacher's ID for the course or enter \"0\" to see all teacher's ID ");
                var userInput = int.Parse(Console.ReadLine());
                var TeacherID = 0;
                if (userInput == 0)
                {
                    GetAllTeacher();
                    Console.Write("Assiged teacher's ID for the course: ");
                    TeacherID = int.Parse(Console.ReadLine());
                }
                else if (userInput > 0)
                {
                    TeacherID = userInput;
                    Console.WriteLine("Assiged teacher's ID for the course: {0}", TeacherID);
                }

                newCourse.Title = Title;
                newCourse.Fees = Fees;
                newCourse.StartDate = StartDate;
                newCourse.TeacherID = TeacherID;

                var assignCourse = new CourseStudent();
                assignCourse.Course = newCourse;
                assignCourse.EnrollmentDate = DateTime.Now;

                newStudent.AssignedCourses.Add(assignCourse);
                names[i] = Title;
                
            }


            context.Students.Add(newStudent);
            context.SaveChanges();

            foreach (string name in names)
            {
                Console.Write(name + ", ");
            }
            Console.WriteLine("sucessfully assigned to {0}", newStudent.Name);
        }

        public static void GetAllTeacher()
        {
            var context = new ProjectDbContext();

            foreach(var Teacher in context.Teachers)
            {
                Console.WriteLine("Teacher's ID: {0}, Teacher's Name: {1}",Teacher.ID,Teacher.Name );
            }
        }
        public static void AssignClassesToACourse()
        {
            var context = new ProjectDbContext();
            List<int> courseIDs = new List<int>();
            int serial = 1;
            foreach (var Course in context.Courses)
            {
                
                Console.WriteLine("{0}) Course ID: {1}, Course Title: {2}. Course Start Date: {3}", 
                    serial, Course.ID, Course.Title, Course.StartDate.ToShortDateString());

                courseIDs.Add(Course.ID);
                serial++;
            }
            var selectedCourse = int.Parse(Console.ReadLine());
            if (selectedCourse <= courseIDs.Count)
            {
                ClassSchedule newClassSchedule = new ClassSchedule();
                Console.WriteLine("Enter Class Date With Time");
                var classDateAndTime = DateTime.Parse(Console.ReadLine());
                var courseStartDate = context.Courses.Find(courseIDs[selectedCourse - 1]).StartDate;
                if (classDateAndTime > courseStartDate)
                {
                    newClassSchedule.ClassDate = classDateAndTime.ToLongDateString();
                    newClassSchedule.ClassStartTime = classDateAndTime.ToShortTimeString();
                    newClassSchedule.ClassEndTime = classDateAndTime.AddHours(2).ToShortTimeString();
                    newClassSchedule.CourseID = courseIDs[selectedCourse - 1];
                }
                Console.WriteLine($"So the next class of {context.Courses.Find(courseIDs[selectedCourse - 1]).Title}" +
                    $" will held on {newClassSchedule.ClassDate} from {newClassSchedule.ClassStartTime}" +
                    $" to {newClassSchedule.ClassEndTime}");
            }

        }
      
    }
}
