using WebappAPI.Data.Genders;

namespace WebappAPI.Data.Persons
{
    public class Person
    {
        public int Id { get; set; }
        public string? Name { get; set; }    
        public string? Surname { get; set; }
        public int? GenderId { get; set; }
        public virtual Gender Gender { get; set; }

    }
}
