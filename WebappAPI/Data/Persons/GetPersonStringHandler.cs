using AutoMapper;
using MediatR;

namespace WebappAPI.Data.Persons
{
    public class GetPersonStringHandler : IRequestHandler<GetPersonStringQuery, string>
    {
        private readonly UniversityDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetPersonStringHandler(UniversityDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<string> Handle(GetPersonStringQuery request, CancellationToken cancellationToken)
        {
            string resultString = "The persons name is :" + request.Name + " The surname is: " + request.Surname + " The age is: " + request.Age;
            return resultString;
        }
    }
}
