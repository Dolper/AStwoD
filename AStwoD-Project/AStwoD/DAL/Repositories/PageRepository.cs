using System.Collections.Generic;
using System.Linq;
using AStwoD.DAL.Entity_First_Model;

namespace AStwoD.DAL.Repositories
{
    public class PageRepository : IRepositoryBase<astwod_Page>
    {
        protected u380982_astwodEntities db = new u380982_astwodEntities(); 
        public  IEnumerable<astwod_Page> GetAll()
        {
            return db.GetAllPages().ToList();
        }

        public astwod_Page GetPageByName(string name)
        {
            return db.GetPageByName(name).FirstOrDefault();
        }

        public IEnumerable<astwod_Page> GetPagesByInputTitle(string title)
        {
            return db.GetPagesByInputTitle(title).ToList();
        }

        public IEnumerable<astwod_Page> GetPagesByParentId(int? parentId)
        {
            return db.GetPageByParentID(parentId);
        }

        public void CreatePage(string name, string link, string title, string metaD, string metaK, int? parentId, string content, byte? menuWeight, bool isMenu)
        {
            db.CreatePage(name, link, title, metaD, metaK, parentId, content, isMenu, menuWeight);
        }

        public void UpdatePage(int id, string name, string link, string title, string metaD, string metaK, int? parenId, string content, byte? menuWeight, bool isMenu)
        {
            db.UpdatePage(id, name, link, title, metaD, metaK, parenId, content, isMenu, menuWeight);
        }

        public  astwod_Page Get(int id)
        {
            return db.GetPageByID(id).FirstOrDefault();
        }

        public  void Remove(int id)
        {
            db.DeletePageByID(id);
        }
    }
}