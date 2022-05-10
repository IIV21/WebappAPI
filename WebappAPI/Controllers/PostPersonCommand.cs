using MediatR;
using WebappAPI.Data.Persons;

namespace WebappAPI.Controllers
{
    public class PostPersonCommand : IRequest<Person>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int GenderId { get; set; }

        public PostPersonCommand(string personName, string personSurname, int genderId)
        {
            Name = personName;
            GenderId = genderId;
            Surname = personSurname;
        }
    }
}
