using Material_Sharing.DAL.Entities;

namespace Material_Sharing.DAL.Interfaces{
    public interface ISpecialtyNumberRepository : IRepository<SpecialtyNumber>
    {
        bool UniqueTitle(string title);
        SpecialtyNumber GetByTitle(string specialtyNumber);
    }
}