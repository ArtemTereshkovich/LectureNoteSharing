using System.Linq;
using AutoMapper;
using Material_Sharing.DAL.Entities;
using Material_Sharing.ViewModel.CommentService;
using Material_Sharing.ViewModel.LectureNoteService;
using Material_Sharing.ViewModel.RatingService;
using Material_Sharing.ViewModel.UserService;

namespace Material_Sharing.BLL.AutoMapperProfiles
{
    public class BLLProfile : Profile
    {
        public BLLProfile()
        : this("BLLProfile")
        {
        }
        protected BLLProfile(string profileName)
        : base(profileName)
        {
            CreateMap<LectureNote,LectureNoteViewModel>()
            .ForMember(v => v.Id, t =>t.MapFrom(k =>k.Id))
            .ForMember(v => v.DateOfCreate, t => t.MapFrom(k =>k.DateOfCreate.ToString()))
            .ForMember(v => v.AuthorUsername, t => t.MapFrom(k => k.Author.UserName))
            .ForMember(v => v.DateOfEdit, t => t.MapFrom(k => k.DateOfLastChange.ToString()))
            .ForMember(v => v.SpecialtyNumber, t => t.MapFrom(k => k.Specialty.Title))
            .ForMember(v => v.DateOfCreate,t => t.MapFrom(k => k.DateOfCreate.ToString()))
            .ForMember(v => v.AverageRating,t => t.MapFrom(k => k.AverageRating.ToString("F1")))
            .ReverseMap()
            .ForPath(k => k.Author.Name, t => t.MapFrom(v => v.AuthorUsername));

            CreateMap<LectureNoteViewModel,LectureNoteEditModel>()
            .ForMember(v => v.Id,t =>t.MapFrom(k => k.Id))
            .ForMember(v => v.Description,t =>t.MapFrom(k => k.Description))
            .ForMember(v => v.Text,t =>t.MapFrom(k => k.Text))
            .ForMember(v => v.Title,t =>t.MapFrom(k => k.Title));

            CreateMap<ApplicationUserViewModel,ApplicationUser>()
            .ForMember(v => v.Id,t =>t.MapFrom(k => k.Id))
            .ForMember(v => v.UserName,t =>t.MapFrom(k => k.Username))
            .ForMember(v => v.Email,t =>t.MapFrom(k => k.Email))
            .ForMember(v => v.Name,t =>t.MapFrom(k => k.Name))
            .ForMember(v => v.Surname,t =>t.MapFrom(k => k.Surname));

            CreateMap<LectureNoteEditModel,LectureNote>()
            .ForMember(v => v.Id,t =>t.MapFrom(k => k.Id))
            .ForMember(v => v.AverageRating,t =>t.MapFrom(k => k.AverageRating))            
            .ForMember(v => v.Title,t =>t.MapFrom(k => k.Title))
            .ForMember(v => v.Description,t =>t.MapFrom(k => k.Description))
            .ForMember(v => v.Text,t =>t.MapFrom(k => k.Text))
            .ForMember(v => v.DateOfLastChange,t =>t.MapFrom(k => k.DateOfEdit));

            CreateMap<RegisterViewModel,ApplicationUser>()
            .ForMember(e => e.Email,t => t.MapFrom(k => k.Email))
            .ForMember(e => e.Name,t => t.MapFrom(k =>k.Name))
            .ForMember(e => e.Surname,t => t.MapFrom(k => k.Surname))
            .ForMember(e => e.UserName ,t => t.MapFrom(k => k.Username));

            CreateMap<ApplicationUser,ApplicationUserViewModel>()
            .ForMember(v =>v.Id,t => t.MapFrom(k => k.Id))
            .ForMember(v =>v.Email,t => t.MapFrom(k => k.Email))
            .ForMember(v =>v.Name,t => t.MapFrom(k => k.Name))
            .ForMember(v =>v.Surname,t => t.MapFrom(k => k.Surname))
            .ForMember(v =>v.Username,t => t.MapFrom(k => k.UserName));

            CreateMap<LectureNoteRating,RatingViewModel>()
            .ForMember(v => v.PostId ,t => t.MapFrom(e => e.LectureNote.Id))
            .ForMember(v => v.Rating ,t => t.MapFrom(e => e.Rating));

            CreateMap<CreateCommentViewModel , Comment>()
            .ForMember( v => v.CommentText, t => t.MapFrom(k => k.CommentText));

            CreateMap<Comment , CommentViewModel>()
            .ForMember(v => v.Author,t => t.MapFrom(k => k.Author.UserName))
            .ForMember(v => v.Text,t => t.MapFrom(k => k.CommentText))
            .ForMember(v => v.Date,t => t.MapFrom(k => k.Date.ToString()));
        }
    }
}