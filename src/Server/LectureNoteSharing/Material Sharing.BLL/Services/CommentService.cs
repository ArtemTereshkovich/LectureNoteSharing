using System;
using System.Collections.Generic;
using AutoMapper;
using Material_Sharing.BLL.Interfaces;
using Material_Sharing.DAL.Entities;
using Material_Sharing.DAL.Interfaces;
using Material_Sharing.ViewModel.CommentService;

namespace Material_Sharing.BLL.Services{
    public class CommentService:ICommentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CommentService(IUnitOfWork unitOfWork,
            IMapper mapper
        )
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public IEnumerable<CommentViewModel> GetByPostId(string postId){
            return _mapper.Map<IEnumerable<Comment>,IEnumerable<CommentViewModel>>
                (_unitOfWork.Comments.GetByLectureNoteId(postId));
             
        }

        public async System.Threading.Tasks.Task<CommentViewModel> CreateAsync(CreateCommentViewModel model){
            Comment comment = new Comment{
                Author = _unitOfWork.Users.Get(model.AuthorId),
                LectureNote = _unitOfWork.LectureNotes.Get(model.LectureNoteId),
                Date = DateTime.Now,
                CommentText = model.CommentText               
            };
            var newComment =_unitOfWork.Comments.Add(comment);
            await _unitOfWork.SaveAsync();
            return _mapper.Map<Comment,CommentViewModel>(newComment);
        }
    }
}