using learn_Russian_API.Models.TeacherGroup.Create;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace learn_Russian_API.Presistence.Entities
{
    class TeacherGroupConfig : IEntityTypeConfiguration<TeacherGroup>
    {
        public TeacherGroupConfig()
            : base()
        {
          
                HasKey(tg => new { tg.TeacherId, tg.GroupId });
                HasOne<Teacher>()
                WithMany()
                HasForeignKey(t => t.TeacherId);
            modelBuilder.Entity<TeacherGroup>()
                .HasOne<Group>()
                .WithMany()
                .HasForeignKey(g => g.GroupId);               
        }

        public void Configure(EntityTypeBuilder<TeacherGroup> builder)
        {
            throw new System.NotImplementedException();
        }
    }
}