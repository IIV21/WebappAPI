namespace WebappAPI.Data.Grades
{
    public class PostGradeRequest
    {
        public int CourseId { get; set; }
        public int PersonId { get; set; }
        public int Grade { get; set; }
    }
}
