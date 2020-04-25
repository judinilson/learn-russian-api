using AutoMapper;
using DefaultNamespace;
using learn_Russian_API.Models.Country.Create;
using learn_Russian_API.Models.Country.GetAlll;
using learn_Russian_API.Models.Country.GetById;
using learn_Russian_API.Models.Group;
using learn_Russian_API.Models.Group.Create;
using learn_Russian_API.Models.Group.GetAll;
using learn_Russian_API.Models.Group.GetById;
using learn_Russian_API.Models.Users.Student.Create;
using learn_Russian_API.Models.Users.Teacher.Create;
using learn_Russian_API.Models.Users.Teacher.GetAll;
using learn_Russian_API.Presistence.Entities;

namespace learn_Russian_API.Presistence
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Country, CountryGetAllResponse>();
            CreateMap<Country, CountryGetById>();
            CreateMap<CountryCreateRequest, Country>();

            
            CreateMap<Group, GroupGetAllResponse>();
            CreateMap<Group, GroupGetById>();
            CreateMap<GroupCreateRequest, Group>();

            
            CreateMap<Student, StudentGetAllResponse>();
           // CreateMap<Group, GroupGetById>();
            CreateMap<studentCreateRequest, Student>();
            
            CreateMap<Teacher, TeacherGetAllResponse>();
            // CreateMap<Group, GroupGetById>();
            CreateMap<TeacherCreateRequest, Teacher>();
        }
    }
}