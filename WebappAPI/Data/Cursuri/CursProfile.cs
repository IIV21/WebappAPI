using AutoMapper;

namespace WebappAPI.Data.Cursuri
{
    public class CursProfile : Profile
    {
        public CursProfile()
        {
            CreateMap<Curs, GetAllCoursesResult>();
            CreateMap< Curs, GetCourseResult>();

            CreateMap<Curs, UpdateCoursesResult>();

            CreateMap<Curs,CreateCourseRequest>();
            CreateMap<CreateCourseResult, Curs>();
        }
    }
}
