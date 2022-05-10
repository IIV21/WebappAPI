namespace WebappAPI.Data.Cursuri
{
    public class GetCourseResult
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
        public virtual ICollection<CoursePerson> CoursePersons { get; set; }
    }
}
