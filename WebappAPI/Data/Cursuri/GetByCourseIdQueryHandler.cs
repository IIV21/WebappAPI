using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace WebappAPI.Data.Cursuri
{
    public class GetByCourseIdQueryHandler : IRequestHandler<GetByCourseIdQuery, List<GetByCourseIdQueryResult>>
    {
        private readonly UniversityDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetByCourseIdQueryHandler(UniversityDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<List<GetByCourseIdQueryResult>> Handle(GetByCourseIdQuery request, CancellationToken cancellationToken)
        {
            var items =await _dbContext.CoursePerson.Include(x=>x.Person).ThenInclude(x=>x.Gender).Include(x=>x.Course)
                                .Where(x=>x.CourseId == request.Id).ToListAsync();
            var itemsCopy = _mapper.Map<List<GetByCourseIdQueryResult>>(items);
            return itemsCopy;
        }
    }
}
