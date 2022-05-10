using Microsoft.EntityFrameworkCore;
using WebappAPI.Data.Cursuri;
using WebappAPI.Data.Genders;
using WebappAPI.Data.Grades;
using WebappAPI.Data.Persons;

namespace WebappAPI.Data
{
    public class UniversityDbContext : DbContext
    {
        public UniversityDbContext(DbContextOptions<UniversityDbContext> options): base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(UniversityDbContext).Assembly);
        }

        public DbSet<Person> Persons { get; set; } 

        public DbSet<Curs> Courses { get; set; }

        public DbSet<Gender> Genders { get; set; }

        public DbSet<CoursePerson> CoursePerson { get; set; }
        
        public DbSet<ExamenGrade> ExamenGrade { get; set; }

    }
}
