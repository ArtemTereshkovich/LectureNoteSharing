using System.Collections.Generic;
using System.Threading.Tasks;
using Material_Sharing.DAL.Entities;
using Material_Sharing.ViewModel.RatingService;

namespace Material_Sharing.BLL.Interfaces{
    public interface ILectureNoteRatingService
    {
        Task CreateAsync(RatingPutViewModel model);
        RatingViewModel GetLectureNoteRatingForUser(string postId, string username);
        
    }
}