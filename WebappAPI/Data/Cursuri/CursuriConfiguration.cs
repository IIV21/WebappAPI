using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebappAPI.Data.Cursuri
{
    public class CursuriConfiguration : IEntityTypeConfiguration<Curs>
    {
        public void Configure(EntityTypeBuilder<Curs> builder)
        {
            builder.ToTable(name: nameof(Curs));
            builder.HasKey(x => x.Id); 
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Active).IsRequired();
            //builder.HasOne(x => x.Gender).WithMany().HasForeignKey(x => x.GenderId);//FK catre Gender
        }
    }
}
