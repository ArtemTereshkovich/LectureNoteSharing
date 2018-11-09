using Material_Sharing.DAL.Data;
using Material_Sharing.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;

namespace Material_Sharing.DAL.Interfaces{
    public interface IUnitOfWork : IDisposable
    {
        ApplicationDataBaseContext ApplicationDataBaseContext {get;}
        UserManager<ApplicationUser> UserManager {get;}
        SignInManager<ApplicationUser> SignInManager {get;}
        RoleManager<IdentityRole> RoleManager {get;}
        ICommentLikeRepository CommentLikes {get;}
        ICommentRepository Comments {get;}
        ILectureNoteRatingRepository LectureNoteRatings {get;}
        ILectureNoteRepository LectureNotes {get;}
        ILectureNoteTagRepository LectureNoteTags {get;}
        ISpecialtyNumberRepository SpecialtyNumber {get;}
        ITagRepository Tags {get;}
        IUserRepository Users {get;}
        Task SaveAsync();
    }
}