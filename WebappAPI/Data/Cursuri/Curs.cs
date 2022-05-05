using WebappAPI.Data.Persons;

namespace WebappAPI.Data.Cursuri
{
    public class Curs
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
        public virtual ICollection<CoursePerson> CoursePersons { get; set; }
    }
}
