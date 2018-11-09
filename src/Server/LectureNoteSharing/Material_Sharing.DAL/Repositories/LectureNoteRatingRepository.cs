using System;
using System.Linq;
using Material_Sharing.DAL.Data;
using Material_Sharing.DAL.Entities;
using Material_Sharing.DAL.Interfaces;

namespace Material_Sharing.DAL.Repositories
{
    public class LectureNoteRatingRepository : Repository<LectureNoteRating>, ILectureNoteRatingRepository
    {
        public LectureNoteRatingRepository(ApplicationDataBaseContext dataBaseContext)
         : base(dataBaseContext){}

        public double GetAverageRating(string lectureNoteId)
        {
            try{
                return _dataBaseContext.LectureNoteRatings.Where(t => t.LectureNote.Id.Equals(lectureNoteId)).Average(t => t.Rating);
            }catch(Exception ){
                return 0.0;
            }
        }

        public LectureNoteRating GetByUserAndPost(string username, string postId)
        {
            return _dataBaseContext.LectureNoteRatings.Where(t => (t.User.UserName.Equals(username) && t.LectureNote.Id.Equals(postId))).FirstOrDefault();
        }
    }
}