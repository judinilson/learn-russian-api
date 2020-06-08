

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
        
        public DbSet<TeacherGroup> TeacherGroups { get; set; }
        public DbSet<User> Users { get; set; }
        
        public DbSet<Category> Categories { get; set; }
        
        public DbSet<Content> Contents { get; set; }
        public DbSet<DemostrationContents> DemostrationContentses { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            //CONTENT 
            modelBuilder.Entity<Content>()
                .HasOne<Category>()
                .WithMany()
                .HasForeignKey(t => t.categoryID);
           
                
        }
    }
}