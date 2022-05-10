using AutoMapper;
using MediatR;
using WebappAPI.Data;
using WebappAPI.Data.Persons;

namespace WebappAPI.Controllers
{
    public class PostPersonCommandHandler : IRequestHandler<PostPersonCommand, Person>
    {
        public readonly UniversityDbContext _dbContext;
        public readonly IMapper _mapper;

        public PostPersonCommandHandler(IMapper mapper,UniversityDbContext dbContext)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<Person> Handle(PostPersonCommand request, CancellationToken cancellationToken)
        {
            var person = _mapper.Map<Person>(request);
            _dbContext.Persons.Add(person);
            _dbContext.SaveChanges();
             return person;
        }
    }
}
