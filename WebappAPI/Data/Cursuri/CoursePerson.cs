
using WebappAPI.Data.Persons;

namespace WebappAPI.Data.Cursuri
{
    public class CoursePerson
    {
        public int Id { get; set; }
        public int? CourseId { get; set; }
        public int? PersonId { get; set; }
        public virtual Person Person { get; set; }
        public virtual Curs Course { get; set; }
    }
}
