using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AStwoD.DAL.Entity_First_Model;

namespace AStwoD.DAL.Repositories
{
    public class TemplateRepository:IRepositoryBase<Template>
    {
        private u380982_astwodEntities db;
       
        public TemplateRepository()
        {
            db = new  u380982_astwodEntities();
        }

        public  IEnumerable<Template> GetAll()
        {
           return  db.GetTemplates();
        }

        public  Template Get(int id)
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

        public  void Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}