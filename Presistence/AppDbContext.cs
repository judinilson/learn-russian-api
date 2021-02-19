

using learn_Russian_API.Models.Content.DemoContents;
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
        public DbSet<DemonstrationContents> DemonstrationContentses { get; set; }
        public DbSet<DemoContentsModel> DemoContentsModel { get; set; }
        public DbSet<TrainingContent> TrainingContents { get; set; }
        public DbSet<Training> Trainings { get; set; }
        public  DbSet<Answer> Answers { get; set; }
        public DbSet<Statistic> Statistics { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            
            //TRAINING 
            /*modelBuilder.Entity<Statistic>()
                .HasOne<User>()
                .WithMany()
                .HasForeignKey(u => u.UserId);*/

            modelBuilder.Entity<Content>()
                .HasOne<DemonstrationContents>()
                .WithMany()
                .HasForeignKey(c => c.DemonstrationContentID);
          
              
            modelBuilder.Entity<Content>()
                .HasOne<Category>()
                .WithMany()
                .HasForeignKey(c => c.categoryID);
        }
    }
}