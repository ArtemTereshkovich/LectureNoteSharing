using System;
using System.Collections.Generic;
using Material_Sharing.DAL.Entities;
using Material_Sharing.DAL.Repositories;

namespace Material_Sharing.DAL.Interfaces{
    public interface ILectureNoteRepository : IRepository<LectureNote>
    {
        bool CheckUniqueTitle(string title);
        IEnumerable<LectureNote> GetByUserId(string userId);
        IEnumerable<LectureNote> GetTopNotes(int page, int countPerPage);
        IEnumerable<LectureNote> GetTagsTopNotes(int page, string tagId, int count);
    }
}