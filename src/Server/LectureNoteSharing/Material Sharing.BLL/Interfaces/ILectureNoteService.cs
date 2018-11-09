using System.Collections.Generic;
using System.Threading.Tasks;
using Material_Sharing.DAL.Entities;
using Material_Sharing.ViewModel.LectureNoteService;

namespace Material_Sharing.BLL.Interfaces{
    public interface ILectureNoteService
    {    
        Task<LectureNoteViewModel> CreateAsync(LectureNoteViewModel lectureNote);
        LectureNoteViewModel Update(LectureNoteEditModel lectureNote);
        LectureNoteViewModel GetById(string id);
        IEnumerable<LectureNoteViewModel> GetByUserId(string userId);
        IEnumerable<LectureNoteViewModel> GetAll();
        IEnumerable<LectureNoteViewModel> GetTopRating(int page,int countPerPage);
        bool CheckUniqueTitle(string title);
        void Delete(LectureNoteViewModel lectureNote);
        IEnumerable<LectureNoteViewModel> GetByTagId(string tagId);
        IEnumerable<LectureNoteViewModel> GetTagLecture(int page, string tagId, int count);
    }
}