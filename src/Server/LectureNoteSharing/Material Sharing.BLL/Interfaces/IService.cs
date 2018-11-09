using System.Collections.Generic;

namespace Material_Sharing.BLL.Interfaces{
    public interface IService<TEntity> where TEntity : class
    {
        TEntity Create(TEntity entity);
        IEnumerable<TEntity> GetAll();
        TEntity GetById(int Id);
        TEntity Update(TEntity entity);
        TEntity Delete(TEntity entity);      
        
    }
}