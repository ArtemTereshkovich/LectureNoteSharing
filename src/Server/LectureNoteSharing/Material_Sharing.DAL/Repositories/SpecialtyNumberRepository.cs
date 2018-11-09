using System.Linq;
using Material_Sharing.DAL.Data;
using Material_Sharing.DAL.Entities;
using Material_Sharing.DAL.Interfaces;

namespace Material_Sharing.DAL.Repositories
{
    public class SpecialtyNumberRepositpry : Repository<SpecialtyNumber>, ISpecialtyNumberRepository
    {
        public SpecialtyNumberRepositpry(ApplicationDataBaseContext dataBaseContext)
         : base(dataBaseContext) {}

        public SpecialtyNumber GetByTitle(string specialtyNumber)
        {
            return _dataBaseContext.SpecialtyNumbers.FirstOrDefault(t => t.Title.Equals(specialtyNumber));
        }

        public bool UniqueTitle(string title)       
        {
            return _dataBaseContext.SpecialtyNumbers.FirstOrDefault(t => t.Title.Equals(title)) == null;
        }
        
    }
}