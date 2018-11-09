using System.Collections.Generic;
using System.Linq;
using Material_Sharing.DAL.Data;
using Material_Sharing.DAL.Entities;
using Material_Sharing.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Material_Sharing.DAL.Repositories{
    public class CommentRepository : Repository<Comment>, ICommentRepository
    {
        public CommentRepository(ApplicationDataBaseContext dataBaseContext)
         : base(dataBaseContext){}

        public IEnumerable<Comment> GetByLectureNoteId(string lectureNoteId)
        {
          return _dataBaseContext.Comments.Where(t => t.LectureNote.Id.Equals(lectureNoteId))
            .Include(v => v.Author).OrderBy(k => k.Date).ToList();
        }
    }
}