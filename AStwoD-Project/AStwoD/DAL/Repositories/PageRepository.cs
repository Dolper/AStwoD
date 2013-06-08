using System.Collections.Generic;
using System.Linq;
using AStwoD.DAL.Entity_First_Model;

namespace AStwoD.DAL.Repositories
{
    public class PageRepository : BaseRepository<astwod_Page>
    {
        public override IEnumerable<astwod_Page> GetAll()
        {
            return db.GetAllPages().ToList();
        }

        public override astwod_Page Get(int id)
        {
            return db.GetPageByID(id).FirstOrDefault();
        }

        public override void Remove(int id)
        {
             db.DeletePageByID(id);
        }
    }
}