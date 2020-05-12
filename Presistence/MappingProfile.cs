using AutoMapper;
using learn_Russian_API.Models.Country.Create;
using learn_Russian_API.Models.Country.GetAlll;
using learn_Russian_API.Models.Country.GetById;
using learn_Russian_API.Models.Group.Create;
using learn_Russian_API.Models.Group.GetAll;
using learn_Russian_API.Models.Group.GetById;
using learn_Russian_API.Models.TeacherGroup.Create;
using learn_Russian_API.Models.Users.GlobalUser.Get;
using learn_Russian_API.Models.Users.GlobalUser.Update;
using learn_Russian_API.Models.Users.Student.Create;
using learn_Russian_API.Models.Users.Teacher.Create;
using learn_Russian_API.Presistence.Entities;

namespace learn_Russian_API.Presistence
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
           // CreateMap<User, User>();

            CreateMap<Country, CountryGetAllResponse>();
            CreateMap<Country, CountryGetById>();
            CreateMap<CountryCreateRequest, Country>();

            
            CreateMap<Group, GroupGetAllResponse>();
            CreateMap<Group, GroupGetById>();
            CreateMap<GroupCreateRequest, Group>();

            
            //CreateMap<Student, StudentGetAllResponse>();
           // CreateMap<Group, GroupGetById>();
            //CreateMap<studentCreateRequest, Student>();
            
            //CreateMap<Teacher, TeacherGetAllResponse>();
            // CreateMap<Group, GroupGetById>();
            //CreateMap<TeacherCreateRequest, Teacher>();

            CreateMap<TeacherGroupCreate, TeacherGroup>();
            CreateMap<TeacherGroup, TeacherGroup>();
            
            
            CreateMap<User, UserGetResponse>();
            CreateMap<User, UserTeacherGetResponse>();
            CreateMap<User, UserStudentGetResponse>();
            CreateMap<StudentUserCreateRequest, User>();
            CreateMap<TeacherUserCreateRequest, User>();
            CreateMap<UserUpdateRequest, User>();


        }
    }
}