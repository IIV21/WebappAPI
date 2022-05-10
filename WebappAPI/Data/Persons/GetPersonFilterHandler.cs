using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace WebappAPI.Data.Persons
{
    public class GetPersonFilterHandler : IRequestHandler<GetPersonFilterQuery, GetPersonIdResult>
    {
        private readonly IMapper _mapper;
        private readonly UniversityDbContext _dbContext;

        public GetPersonFilterHandler(UniversityDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<GetPersonIdResult> Handle(GetPersonFilterQuery request, CancellationToken cancellationToken)
        {
            var person = await _dbContext.Persons.Include(x => x.Gender).Where(x => x.Id == request.Id).FirstOrDefaultAsync();
            var personCopy = _mapper.Map<GetPersonIdResult>(person);
                return personCopy;
        }
    }
}
