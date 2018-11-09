using System.Collections.Generic;
using Material_Sharing.DAL.Entities;

namespace Material_Sharing.DAL.Interfaces{
    public interface ITagRepository : IRepository<Tag>
    {
        IEnumerable<Tag> GetTopTags(int count);
    }
}