using MediatR;

namespace WebappAPI.Data.Cursuri
{
    public class GetByCourseIdQuery : IRequest<List<GetByCourseIdQueryResult>>
    {
        public int Id { get; set; }

        public GetByCourseIdQuery(int id)
        {
            Id = id;
        }
    }
}
