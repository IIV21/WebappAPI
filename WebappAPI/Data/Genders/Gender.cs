namespace WebappAPI.Data.Genders
{
    public class Gender
    {
        public Gender(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
        public string Name { get; set; }
    }
}
