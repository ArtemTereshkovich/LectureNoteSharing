using System.Collections.Generic;
using System.Threading.Tasks;
using Material_Sharing.DAL.Entities;

namespace Material_Sharing.BLL.Interfaces{
    public interface ISpecialtyNumberService
    {
        Task<SpecialtyNumber> CreateSpecialtyNumberAsync(string specialtyNumber);
    }
}