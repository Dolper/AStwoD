using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AStwoD.DAL.Entity_First_Model;

namespace AStwoD.DAL.Repositories
{
    public class ComponentRepository:RepositoryBase<Component>
    {
        public override IEnumerable<Component> GetAll()
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

        public override Component Get(int id)
        {
            return db.GetComponentByID(id).FirstOrDefault();
        }

        public Component GetComponentByName(string name)
        {
            return db.GetComponentByName(name).FirstOrDefault();
        }

        public override void Remove(int id)
        {
            db.DeleteComponent(id);
        }
    }
}