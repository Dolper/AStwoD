using System.Collections.Generic;
using AStwoD.DAL.Entity_First_Model;

namespace AStwoD.DAL.Repositories
{
    public abstract class RepositoryBase<TEntity>
    {
        protected u380982_astwodEntities db = new u380982_astwodEntities(); 

        public abstract IEnumerable<TEntity> GetAll();
        public abstract TEntity Get(int id);
        public abstract void Remove(int id);

    }
}
