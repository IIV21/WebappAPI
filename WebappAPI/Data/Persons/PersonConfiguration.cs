using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebappAPI.Data.Persons;

namespace WebappAPI.Data.Persons
{
    public class PersonConfiguration :IEntityTypeConfiguration<Person>
    {

        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.ToTable(name:nameof(Person)); // numele tabelei 
            builder.HasKey(x => x.Id); //id este PK
            builder.Property(x => x.Name).IsRequired();//Nume este Required, not null
            builder.Property(x=>x.Surname).IsRequired();//PRENume este Required, not null
            builder.HasOne(x=>x.Gender).WithMany().HasForeignKey(x=>x.GenderId);//FK catre Gender
        }
    }
}
