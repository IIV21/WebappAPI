using MediatR;

namespace WebappAPI.Data.Persons
{
    public class GetAllPersonsQuery : IRequest<List<Person>>
    {

    }
}
