using Material_Sharing.DAL.Entities;

namespace Material_Sharing.DAL.Interfaces{
    public interface ILectureNoteRatingRepository : IRepository<LectureNoteRating>
    {
        LectureNoteRating GetByUserAndPost(string username, string postId);
        double GetAverageRating(string lectureNoteId);
    }
}