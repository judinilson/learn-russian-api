using AutoMapper;
using DefaultNamespace;
using learn_Russian_API.Models.Category.Create;
using learn_Russian_API.Models.Category.GetAll;
using learn_Russian_API.Models.Category.Update;
using learn_Russian_API.Models.Content.Create;
using learn_Russian_API.Models.Content.DemoContents;
using learn_Russian_API.Models.Content.GetAll;
using learn_Russian_API.Models.Country.Create;
using learn_Russian_API.Models.Country.GetAlll;
using learn_Russian_API.Models.Country.GetById;
using learn_Russian_API.Models.Group.Create;
using learn_Russian_API.Models.Group.GetAll;
using learn_Russian_API.Models.Group.GetById;
using learn_Russian_API.Models.Statistic.Create;
using learn_Russian_API.Models.Statistic.GetAll;
using learn_Russian_API.Models.TeacherGroup.Create;
using learn_Russian_API.Models.TrainingContent.Create;
using learn_Russian_API.Models.TrainingContent.GetAll;
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
            
           //country
            CreateMap<Country, CountryGetAllResponse>();
            CreateMap<Country, CountryGetById>();
            CreateMap<CountryCreateRequest, Country>();

            //group
            CreateMap<Group, GroupGetAllResponse>();
            CreateMap<Group, GroupGetById>();
            CreateMap<GroupCreateRequest, Group>();

            
         
            //teacher group
            CreateMap<TeacherGroupCreate, TeacherGroup>();
            CreateMap<TeacherGroup, TeacherGroup>();
            
            //user
            CreateMap<User, UserGetResponse>();
            CreateMap<User, UserTeacherGetResponse>();
            CreateMap<User, UserStudentGetResponse>();
            CreateMap<StudentUserCreateRequest, User>();
            CreateMap<TeacherUserCreateRequest, User>();
            CreateMap<UserUpdateRequest, User>();
            //CreateMap<UserUpdateStudentRequest, User>();
            
            //category
            CreateMap<Category, CategoryGetAllResponse>();
            CreateMap<CategoryCreateRequest, Category>();
            CreateMap<CategoryUpdateRequest, Category>();

            //content
            CreateMap<Content, ContentGetAllResponse>();
            CreateMap<Content, DemonstrationContentResponse>();
            CreateMap<Content, ArticleContentResponse>();
            CreateMap<ContentDemoCreate, Content>();
            CreateMap<DemonstrationContentsRequest, DemostrationContents>();
            CreateMap<DemostrationContents, DemonstrationContentsRequest>();
            CreateMap<ContentArticleCreate, Content>();

            //training
            CreateMap<TrainingContent, TrainingContentResponse>();
            CreateMap<TrainingContentRequest, TrainingContent>();
            CreateMap<Training, TrainingRequest>();
            CreateMap<TrainingRequest,Training>();
            CreateMap<Answer,AnswersRequest>();
            CreateMap<AnswersRequest, Answer>();
            
            //statistics 
            CreateMap<Statistic, StatisticsResponse>();
            CreateMap<StatisticsRequest, Statistic>();
            
        }
    }
}