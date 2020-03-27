

using learn_Russian_API.Models.Country.Create;
using learn_Russian_API.Models.Group;
using learn_Russian_API.Models.Users.Student.Create;
using learn_Russian_API.Models.Users.Teacher.Create;
using learn_Russian_API.Presistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace learn_Russian_API.Presistence
{
    public class AppDbContext :DbContext
    {
        public AppDbContext(DbContextOptions options):base(options){}
        
        public  DbSet<Country>Countries { get; set; }
        public DbSet<Group> Groups { get; set; }
        public  DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); 
        }
    }
}