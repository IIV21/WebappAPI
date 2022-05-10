using AutoMapper;

namespace WebappAPI.Data.Cursuri
{
    public class CursProfile : Profile
    {
        public CursProfile()
        {
            CreateMap<Curs, GetAllCoursesResult>();
            CreateMap< Curs, GetCourseResult>();

            CreateMap<CoursePerson, GetByCourseIdQueryResult>().ForMember(x => x.PersonName, map => map.MapFrom(p => p.Person.Name))
                                                               .ForMember(x=>x.GenderName, map=> map.MapFrom(p=>p.Person.Gender.Name))
                                                               .ForMember(x=>x.PersonSurname, map=>map.MapFrom(p=>p.Person.Surname))
                                                               .ForMember(x=>x.CourseName, map=> map.MapFrom(p=>p.Course.Name));

            CreateMap<Curs, UpdateCoursesResult>();

            CreateMap<Curs,CreateCourseRequest>();
            CreateMap<CreateCourseResult, Curs>();
        }
    }
}
