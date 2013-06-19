using System.Collections.Generic;
using AStwoD.DAL.Entity_First_Model;

namespace AStwoD.DAL.Repositories
{
    public  interface IRepositoryBase<TEntity>
    {
          IEnumerable<TEntity> GetAll();
          TEntity Get(int id);
          void Remove(int id);
    }
}
