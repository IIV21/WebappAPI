using MediatR;

namespace WebappAPI.Data.Persons
{
    public class GetPersonFilterQuery : IRequest<GetPersonIdResult>
    {
        public int Id { get; set; }
        public GetPersonFilterQuery(int id)
        {
            Id = id;
        }
    }
}
