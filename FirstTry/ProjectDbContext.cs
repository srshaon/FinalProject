using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstTry
{
    public class ProjectDbContext : DbContext
    {
        private readonly string _connectionString;
        private readonly string _assemblyName;

        public ProjectDbContext()
        {
            _connectionString = "Server = DESKTOP-HJM9K0J\\SQLEXPRESS; Database = CSharpB7; Trusted_Connection = True";
            _assemblyName = typeof(Program).Assembly.FullName;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Teacher>()
                .HasMany(p => p.HandledCourses)
                .WithOne(i => i.Teacher);

            builder.Entity<Course>()
                .HasMany(p => p.Classes)
                .WithOne(i => i.Course);

            builder.Entity<CourseStudent>()
                .HasKey(cs => new { cs.CourseID, cs.StudentID });


            builder.Entity<CourseStudent>()
                .HasOne(pc => pc.Course)
                .WithMany(p => p.EnrolledStudents)
                .HasForeignKey(pc => pc.CourseID);

            builder.Entity<CourseStudent>()
                .HasOne(pc => pc.Student)
                .WithMany(c => c.AssignedCourses)
                .HasForeignKey(pc => pc.StudentID);

            base.OnModelCreating(builder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            if (!dbContextOptionsBuilder.IsConfigured)
            {
                dbContextOptionsBuilder.UseSqlServer(
                    _connectionString,
                    m => m.MigrationsAssembly(_assemblyName));
            }

            base.OnConfiguring(dbContextOptionsBuilder);
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<ClassSchedule> classSchedules { get; set; }


    }
}
