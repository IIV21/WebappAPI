using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebappAPI.Data.Cursuri
{
    public class CoursePersonConfiguration : IEntityTypeConfiguration<CoursePerson>
    {
        public void Configure(EntityTypeBuilder<CoursePerson> builder)
        {
            builder.ToTable(name: nameof(CoursePerson));
            builder.HasKey(x => x.Id);
            builder.Property(x => x.CourseId);
            builder.Property(x => x.PersonId);
        }

    }
}
