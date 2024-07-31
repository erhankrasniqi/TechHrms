using Microsoft.EntityFrameworkCore;
using TechHrms.Models;

namespace TechHrms.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Administration> Administrations { get; set; }
        public DbSet<ProjectManagment> ProjectManagments { get; set; }
        //public DbSet<EmployeeQualification> EmployeeQualifications { get; set; }
        //public DbSet<EmployeeSkill> EmployeeSkills { get; set; }
        //public DbSet<EmployeeWorkExperience> EmployeeWorkExperiences { get; set; }

        public AppDbContext()
        {
            //
        }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
            //
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
