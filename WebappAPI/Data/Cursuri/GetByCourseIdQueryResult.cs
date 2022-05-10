namespace WebappAPI.Data.Cursuri
{
    public class GetByCourseIdQueryResult
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public int PersonId { get; set; }
        public string PersonName { get; set; }
        public string PersonSurname { get; set; }
        public string GenderName { get; set; }
        public string CourseName { get; set; }

    }
}
