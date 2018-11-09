using System;
using System.Threading.Tasks;
using Material_Sharing.DAL.Data;
using Material_Sharing.DAL.Entities;
using Material_Sharing.DAL.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace Material_Sharing.DAL.Repositories{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDataBaseContext _applicationDataBaseContext;
        public UnitOfWork(ApplicationDataBaseContext applicationDataBaseContext,
           UserManager<ApplicationUser> userManager,
           SignInManager<ApplicationUser> signInManager,
           RoleManager<IdentityRole> roleManager )
        {
            _applicationDataBaseContext = applicationDataBaseContext;
            UserManager = userManager;
            SignInManager = signInManager;
            RoleManager = roleManager;
            CommentLikes = new CommentLikeRepository(_applicationDataBaseContext);
            Comments = new CommentRepository(_applicationDataBaseContext);
            LectureNoteRatings = new LectureNoteRatingRepository(_applicationDataBaseContext);
            LectureNotes = new LectureNoteRepository(_applicationDataBaseContext);
            LectureNoteTags = new LectureNoteTagRepository(_applicationDataBaseContext);
            SpecialtyNumber = new SpecialtyNumberRepositpry(_applicationDataBaseContext);
            Tags = new TagRepository(_applicationDataBaseContext);
            Users = new UserRepository(_applicationDataBaseContext);
        }
        public ApplicationDataBaseContext ApplicationDataBaseContext => _applicationDataBaseContext;
        public UserManager<ApplicationUser> UserManager {get;private set;}
        public SignInManager<ApplicationUser> SignInManager  {get;private set;}
        public RoleManager<IdentityRole> RoleManager  {get;private set;}
        public ICommentLikeRepository CommentLikes  {get;private set;}
        public ICommentRepository Comments  {get;private set;}
        public ILectureNoteRatingRepository LectureNoteRatings  {get;private set;}
        public ILectureNoteRepository LectureNotes  {get;private set;}
        public ILectureNoteTagRepository LectureNoteTags  {get;private set;}
        public ISpecialtyNumberRepository SpecialtyNumber  {get;private set;}
        public ITagRepository Tags  {get;private set;}
        public IUserRepository Users  {get;private set;}
        
        public async Task SaveAsync()
        {
           await _applicationDataBaseContext.SaveChangesAsync();
        }
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _applicationDataBaseContext.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}