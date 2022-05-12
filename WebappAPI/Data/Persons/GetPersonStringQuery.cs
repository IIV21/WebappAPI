using MediatR;

namespace WebappAPI.Data.Persons
{
    public class GetPersonStringQuery : IRequest<string>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }

        public GetPersonStringQuery(string name, string surname, int age)
        {
            Name = name;
            Age = age;
            Surname = surname;
        }
    }
}
