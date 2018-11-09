using Material_Sharing.BLL.Interfaces;
using Material_Sharing.DAL.Entities;
using Material_Sharing.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Material_Sharing.BLL.Services
{
    public class SpecialtyNumberService : ISpecialtyNumberService
    {
        private readonly IUnitOfWork _unitOfWork;

        public SpecialtyNumberService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async System.Threading.Tasks.Task<SpecialtyNumber> CreateSpecialtyNumberAsync(string specialtyNumber)
        {
            SpecialtyNumber specialt;
            if( _unitOfWork.SpecialtyNumber.UniqueTitle(specialtyNumber)){
                specialt = _unitOfWork.SpecialtyNumber.Add(new SpecialtyNumber { Title = specialtyNumber });
                await _unitOfWork.SaveAsync();
            }else{
                specialt = _unitOfWork.SpecialtyNumber.GetByTitle(specialtyNumber);                
            }
            
            return specialt;

        }

    }
}
