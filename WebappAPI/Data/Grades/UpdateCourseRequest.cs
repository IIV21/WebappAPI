namespace WebappAPI.Data.Grades
{
    public class UpdateCourseRequest
    {
        public int CourseId { get; set; }
        public int PersonId { get; set; }
        public int Grade { get; set; }
    }
}
