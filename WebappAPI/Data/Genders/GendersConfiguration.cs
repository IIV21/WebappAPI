using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebappAPI.Data.Genders;

namespace WebappAPI.Data.Genders
{
    public class PersonConfiguration : IEntityTypeConfiguration<Gender>
    {

        public void Configure(EntityTypeBuilder<Gender> builder)
        {
            builder.ToTable(name: nameof(Gender));
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired();
            builder.HasData(Data.GetData());
        }
    }
}
