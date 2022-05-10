using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebappAPI.Data.Grades
{
    public class ExamenGradeConfiguration : IEntityTypeConfiguration<ExamenGrade>
    {
        public void Configure(EntityTypeBuilder<ExamenGrade> builder)
        {
            builder.ToTable(nameof(ExamenGrade));
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Grade).IsRequired();
            builder.HasOne(x => x.Person).WithMany().HasForeignKey(x => x.PersonId);
            builder.HasOne(x => x.Course).WithMany().HasForeignKey(x => x.CourseId);
        }
    }
}
