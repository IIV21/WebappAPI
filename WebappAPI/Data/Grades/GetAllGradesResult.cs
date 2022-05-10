namespace WebappAPI.Data.Grades
{
    public class GetAllGradesResult
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public int PersonId { get; set; }
        public float Grade { get; set; }
    }
}
