using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AStwoD.DAL.Entity_First_Model;

namespace AStwoD.DAL.Repositories
{
    public class MenuRepository : IRepositoryBase<menuItemFromPage>
    {

        protected u380982_astwodEntities db = new u380982_astwodEntities(); 
        public  IEnumerable<menuItemFromPage> GetAll()
        {
           return  db.menuItemFromPages.ToList();
        }

        public  menuItemFromPage Get(int id)
        {
            return db.menuItemFromPages.LastOrDefault();
        }

        public  void Remove(int id)
        {

        }

    }
}