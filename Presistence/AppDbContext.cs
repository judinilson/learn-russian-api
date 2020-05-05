

using learn_Russian_API.Models.Country.Create;
using learn_Russian_API.Models.Group;
using learn_Russian_API.Models.TeacherGroup.Create;
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
        
        public DbSet<TeacherGroup> TeacherGroups { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<User> Users { get; set; }
        
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // student
            modelBuilder.Entity<Student>()
                .HasIndex(i => new { i.CountryId, i.TeacherGroupId,i.userId})
                .IsUnique();
            modelBuilder.Entity<Student>()
                .HasOne<Country>()
                .WithMany()
                .HasForeignKey(c => c.CountryId);
            
            modelBuilder.Entity<Student>()
                .HasOne<TeacherGroup>()
                .WithMany()
                .HasForeignKey(tg => tg.TeacherGroupId);
            
            modelBuilder.Entity<Student>()
                .HasOne<User>()
                .WithMany()
                .HasForeignKey(u => u.userId);

            
            //teacher
            modelBuilder.Entity<Teacher>()
                .HasIndex(i => new {i.userId})
                .IsUnique();
            modelBuilder.Entity<Teacher>()
                .HasOne<User>()
                .WithMany()
                .HasForeignKey(u => u.userId);

            // teacher group 
            modelBuilder.Entity<TeacherGroup>()
                    .HasOne<Teacher>()
                    .WithMany()
                    .HasForeignKey(t => t.TeacherId);
            modelBuilder.Entity<TeacherGroup>()
                .HasOne<Group>()
                .WithMany()
                .HasForeignKey(g => g.GroupId);
                

        }
    }
}