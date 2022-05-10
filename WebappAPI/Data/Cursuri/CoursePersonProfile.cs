using AutoMapper;

namespace WebappAPI.Data.Cursuri
{
    public class CoursePersonProfile : Profile
    {
        public CoursePersonProfile()
        {
            CreateMap<CoursePerson, InsertCoursePerson>();
            CreateMap<InserCoursePersonResult, CoursePerson>();
        }
    }
}
