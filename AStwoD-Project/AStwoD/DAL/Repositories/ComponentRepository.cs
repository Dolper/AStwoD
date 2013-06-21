using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AStwoD.DAL.Entity_First_Model;

namespace AStwoD.DAL.Repositories
{
    public class ComponentRepository:IRepositoryBase<Component>
    {
        private u380982_astwodEntities db;
       
        public ComponentRepository()
        {
            db=new u380982_astwodEntities();
        }

        public  IEnumerable<Component> GetAll()
        {
            return db.GetAllComponents();
        }

        public void CreateComponent(string name,string label,string content)
        {
            db.CreateComponent(name, label, content);
        }

        public void UpdateComponent(int id,string name,string label,string content)
        {
            db.UpdateComponent(id, name, label, content);
        }

        public  Component Get(int id)
        {
            return db.GetComponentByID(id).FirstOrDefault();
        }

        public Component GetComponentByName(string name)
        {
            return db.GetComponentByName(name).FirstOrDefault();
        }

        public  void Remove(int id)
        {
            db.DeleteComponent(id);
        }
    }
}