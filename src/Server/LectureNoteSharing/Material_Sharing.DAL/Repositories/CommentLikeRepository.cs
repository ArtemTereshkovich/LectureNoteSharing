using Material_Sharing.DAL.Data;
using Material_Sharing.DAL.Entities;
using Material_Sharing.DAL.Interfaces;

namespace Material_Sharing.DAL.Repositories{
    public class CommentLikeRepository : Repository<CommentLike>, ICommentLikeRepository
    {
        public CommentLikeRepository(ApplicationDataBaseContext dataBaseContext)
         : base(dataBaseContext){}
    }
}