namespace WebappAPI.Data.Persons
{
    public class CreatePersonRequest
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int GenderId { get; set; }
    }
}
