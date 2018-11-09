using System.Threading.Tasks;
using AutoMapper;
using Material_Sharing.BLL.Interfaces;
using Material_Sharing.DAL.Entities;
using Material_Sharing.DAL.Interfaces;
using Material_Sharing.ViewModel.LectureNoteService;
using Material_Sharing.ViewModel.RatingService;
using Material_Sharing.ViewModel.UserService;

namespace Material_Sharing.BLL.Services{
    public class LectureNoteRatingService : ILectureNoteRatingService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        private readonly ILectureNoteService _lectureNoteService;
        public LectureNoteRatingService(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IUserService userService,
            ILectureNoteService lectureNoteService
        )
        {
            _unitOfWork = unitOfWork;
            _userService = userService;
            _mapper = mapper;
            _lectureNoteService = lectureNoteService;
        }

        private async Task UpdateRatingAsync(string postId){
            LectureNote lectureNote = _unitOfWork.LectureNotes.Get(postId);
            if(lectureNote != null)
            {                
                lectureNote.AverageRating = _unitOfWork.LectureNoteRatings.GetAverageRating(postId);
                _unitOfWork.LectureNotes.Update(lectureNote); 
                 await _unitOfWork.SaveAsync();                              
            }                       
        }

        public async Task CreateAsync(RatingPutViewModel model)
        {
            var rating = _unitOfWork.LectureNoteRatings.GetByUserAndPost(model.AuthorId,model.PostId);
            if(rating == null){
                var newRating = new LectureNoteRating{
                    LectureNote = _unitOfWork.LectureNotes.Get(model.PostId),
                    User = _unitOfWork.Users.Get(model.AuthorId),
                    Rating = model.Rating
                };
                _unitOfWork.LectureNoteRatings.Add(newRating);
            }else{
                rating.Rating = model.Rating;
                _unitOfWork.LectureNoteRatings.Update(rating);
            }
            await _unitOfWork.SaveAsync();
            await UpdateRatingAsync(model.PostId);
        }

        public RatingViewModel GetLectureNoteRatingForUser(string postId, string username)
        {
            LectureNoteRating rating = _unitOfWork.LectureNoteRatings
                .GetByUserAndPost(username,postId);
            if(rating == null){
                return null;
            }
            else{
                RatingViewModel viewRating = _mapper
                    .Map<LectureNoteRating,RatingViewModel>(rating);
                viewRating.Liked = true;
                return viewRating;
            }
        }
    }
}