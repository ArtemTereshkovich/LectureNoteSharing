using Material_Sharing.DAL.Data;
using Material_Sharing.DAL.Entities;
using Material_Sharing.DAL.Interfaces;

namespace Material_Sharing.DAL.Repositories{
    public class LectureNoteTagRepository : Repository<LectureNoteTag>, ILectureNoteTagRepository
    {
        public LectureNoteTagRepository(ApplicationDataBaseContext dataBaseContext) 
        : base(dataBaseContext){}
    }
}