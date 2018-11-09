using System.Collections.Generic;
using Material_Sharing.DAL.Entities;

namespace Material_Sharing.DAL.Interfaces{
    public interface ICommentRepository : IRepository<Comment>
    {
         IEnumerable<Comment> GetByLectureNoteId(string lectureNoteId);
    }
}