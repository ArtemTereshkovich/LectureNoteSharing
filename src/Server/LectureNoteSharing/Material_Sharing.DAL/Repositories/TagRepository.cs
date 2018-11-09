using System.Collections.Generic;
using Material_Sharing.DAL.Data;
using Material_Sharing.DAL.Entities;
using System.Linq;
using Material_Sharing.DAL.Interfaces;

namespace Material_Sharing.DAL.Repositories{
    public class TagRepository : Repository<Tag>, ITagRepository
    {
        public TagRepository(ApplicationDataBaseContext dataBaseContext)
         : base(dataBaseContext){}

        public IEnumerable<Tag> GetTopTags(int count)
        {
            return _DbSet.OrderBy(t => t.CountUses).Take(count).ToList();
        }
    }
}