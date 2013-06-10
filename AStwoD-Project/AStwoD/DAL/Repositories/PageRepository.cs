using System.Collections.Generic;
using System.Linq;
using AStwoD.DAL.Entity_First_Model;

namespace AStwoD.DAL.Repositories
{
    public class PageRepository : RepositoryBase<astwod_Page>
    {
        public override IEnumerable<astwod_Page> GetAll()
        {
            return db.GetAllPages().ToList();
        }

        public astwod_Page GetPageByName(string name)
        {
            return db.GetPageByName(name).FirstOrDefault();
        }

        public void CreatePage(string name, string link, string title, string metaD, string metaK, int? parentId, string content,byte? menuWeight,bool isMenu)
        {
            db.CreatePage(name, link, title, metaD, metaK, parentId, content,isMenu,menuWeight);
        }

        public void UpdatePage(int id, string name, string link, string title, string metaD, string metaK, int? parenId, string content, byte? menuWeight, bool isMenu)
        {
            db.UpdatePage(id, name, link, title, metaD, metaK, parenId, content,isMenu,menuWeight);
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