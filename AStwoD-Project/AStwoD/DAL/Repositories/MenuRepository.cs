using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AStwoD.DAL.Entity_First_Model;

namespace AStwoD.DAL.Repositories
{
    public class MenuRepository : RepositoryBase<menuItemFromPage>
    {
        public override IEnumerable<menuItemFromPage> GetAll()
        {
           return  db.menuItemFromPages.ToList();
        }

        public override menuItemFromPage Get(int id)
        {
            return db.menuItemFromPages.LastOrDefault();
        }

        public override void Remove(int id)
        {

        }

    }
}