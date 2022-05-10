using AutoMapper;
using WebappAPI.Controllers;

namespace WebappAPI.Data.Persons
{
    public class PersonProfile : Profile
    {
        public PersonProfile()
        {
            CreateMap<CreatePersonRequest, Person>();
            CreateMap<PostPersonCommand, Person>();

            CreateMap<Person, GetPersonIdResult>().ForMember(g => g.GenderName, map => map.MapFrom(p => p.Gender.Name));

            CreateMap<UpdatePersonRequest, UpdatePersonResult>();
            CreateMap<Person, GetAllPersonsResult>().ForMember(g => g.GenderName, map => map.MapFrom(p => p.Gender.Name));

        }
    }
}
