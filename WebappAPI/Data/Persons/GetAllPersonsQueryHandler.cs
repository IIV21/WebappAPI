using MediatR;
using Microsoft.EntityFrameworkCore;

namespace WebappAPI.Data.Persons
{
    public class GetAllPersonsQueryHandler :IRequestHandler<GetAllPersonsQuery,List<Person>>
    {
        private readonly UniversityDbContext _dbContext;
        public GetAllPersonsQueryHandler(UniversityDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Person>> Handle(GetAllPersonsQuery request, CancellationToken cancellationToken)
        {
            var persons =  await _dbContext.Persons.ToListAsync();
            return persons;
        }
    }
}
