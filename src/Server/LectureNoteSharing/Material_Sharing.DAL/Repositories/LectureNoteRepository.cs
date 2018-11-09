using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Material_Sharing.DAL.Data;
using Material_Sharing.DAL.Entities;
using Material_Sharing.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Material_Sharing.DAL.Repositories{
    public class LectureNoteRepository : Repository<LectureNote>, ILectureNoteRepository
    {
        public LectureNoteRepository(ApplicationDataBaseContext dataBaseContext) 
        : base(dataBaseContext){}

        public bool CheckUniqueTitle(string title)
        {
            return _dataBaseContext.LectureNotes.FirstOrDefault(t => t.Title.Equals(title)) == null;
        }

        public IEnumerable<LectureNote> GetByUserId(string userId)
        {
            return _dataBaseContext.LectureNotes.Where(t => t.Author.Id.Equals(userId))
            .Include(t => t.Author)
            .Include(t => t.Specialty)
            .Include(t => t.Tags)
            .ToList();
        }

        public override LectureNote Get(string id){
            return _dataBaseContext.LectureNotes.Where(t => t.Id.Equals(id))
            .Include(t => t.Author)
            .Include(t => t.Specialty)
            .Include(t => t.Tags)
            .FirstOrDefault();
        }

        public override IEnumerable<LectureNote> GetAll(){
            return _dataBaseContext.LectureNotes
            .Include(t => t.Author)
            .Include(t => t.Specialty)
            .Include(t => t.Tags)
            .ToList();
        }

        public IEnumerable<LectureNote> GetTopNotes(int page, int countPerPage)
        {
            return _dataBaseContext.LectureNotes.OrderByDescending(t => t.AverageRating)
                .Skip((page-1)*countPerPage)
                .Take(countPerPage)
                .Include(t => t.Author)
                .Include(t => t.Specialty)
                .Include(t => t.Tags)
                .ToList();
        }

        public IEnumerable<LectureNote> GetTagsTopNotes(int page, string tagId, int count)
        {
            return _dataBaseContext.LectureNotes
                .Where(t => t.Tags.Where(p => p.Id.Equals(tagId)).Count() != 0)
                .OrderByDescending(t => t.AverageRating)
                .Skip((page-1)*count)
                .Take(count)
                .Include(t => t.Author)
                .Include(t => t.Specialty)
                .Include(t => t.Tags)
                .ToList();
        }
    }
}