using Microsoft.EntityFrameworkCore;


namespace DBexam.Models
{
    public class UniversityContext: DbContext
    {
        public DbSet<Department> DepartmentSet { get; set; }
        public DbSet<Student> StudentSet { get; set; }
        public DbSet<Lecture> LectureSet { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlServer($"Server=localhost;Database=StudentInfoSystem;Trusted_Connection=True;MultipleActiveResultSets=True");
    }
}
