using WebappAPI.Data.Cursuri;
using WebappAPI.Data.Persons;

namespace WebappAPI.Data.Grades
{
    public class ExamenGrade
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public int PersonId { get; set; }
        public float Grade { get; set; }
        public virtual Curs Course { get; set; }
        public virtual Person Person { get; set; }
    }
}
