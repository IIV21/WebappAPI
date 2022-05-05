using WebappAPI.Data.Genders;

namespace WebappAPI.Data.Persons
{
    public class GetAllPersonsResult
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int GenderId { get; set; }
        public string GenderName { get; set; }

    }
}
