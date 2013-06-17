using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AStwoD.DAL.Entity_First_Model;

namespace AStwoD.DAL.Repositories
{
    public class TemplateRepository:RepositoryBase<Template>
    {
        public override IEnumerable<Template> GetAll()
        {
           return  db.GetAllTemplates();
        }

        public override Template Get(int id)
        {
            return db.GetTemplateById(id).FirstOrDefault();
        }

        public void CreateTemplate(string name)
        {
            db.CreateTemplate(name);
        }

        public Template GetByName(string name)
        {
            return db.GetTemplateByName(name).FirstOrDefault();
        }

        public override void Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}