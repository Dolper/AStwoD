﻿//------------------------------------------------------------------------------
// <auto-generated>
//    Этот код был создан из шаблона.
//
//    Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//    Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AStwoD.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Objects;
    using System.Data.Objects.DataClasses;
    using System.Linq;
    
    public partial class AStwoDEntities : DbContext
    {
        public AStwoDEntities()
            : base("name=AStwoDEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Page> Pages { get; set; }
    
        public virtual int CreatePage(string name, string link, string title, string metaD, string metaK, Nullable<int> parentID, string content)
        {
            var nameParameter = name != null ?
                new ObjectParameter("Name", name) :
                new ObjectParameter("Name", typeof(string));
    
            var linkParameter = link != null ?
                new ObjectParameter("Link", link) :
                new ObjectParameter("Link", typeof(string));
    
            var titleParameter = title != null ?
                new ObjectParameter("Title", title) :
                new ObjectParameter("Title", typeof(string));
    
            var metaDParameter = metaD != null ?
                new ObjectParameter("MetaD", metaD) :
                new ObjectParameter("MetaD", typeof(string));
    
            var metaKParameter = metaK != null ?
                new ObjectParameter("MetaK", metaK) :
                new ObjectParameter("MetaK", typeof(string));
    
            var parentIDParameter = parentID.HasValue ?
                new ObjectParameter("ParentID", parentID) :
                new ObjectParameter("ParentID", typeof(int));
    
            var contentParameter = content != null ?
                new ObjectParameter("Content", content) :
                new ObjectParameter("Content", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CreatePage", nameParameter, linkParameter, titleParameter, metaDParameter, metaKParameter, parentIDParameter, contentParameter);
        }
    
        public virtual int DeletePageByID(Nullable<int> iD)
        {
            var iDParameter = iD.HasValue ?
                new ObjectParameter("ID", iD) :
                new ObjectParameter("ID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("DeletePageByID", iDParameter);
        }
    
        public virtual ObjectResult<GetAllPages_Result> GetAllPages()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetAllPages_Result>("GetAllPages");
        }
    
        public virtual ObjectResult<GetPageByID_Result> GetPageByID(Nullable<int> iD)
        {
            var iDParameter = iD.HasValue ?
                new ObjectParameter("ID", iD) :
                new ObjectParameter("ID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetPageByID_Result>("GetPageByID", iDParameter);
        }
    
        public virtual ObjectResult<GetPageByParentID_Result> GetPageByParentID(Nullable<int> parentID)
        {
            var parentIDParameter = parentID.HasValue ?
                new ObjectParameter("ParentID", parentID) :
                new ObjectParameter("ParentID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetPageByParentID_Result>("GetPageByParentID", parentIDParameter);
        }
    
        public virtual int UpdatePage(Nullable<int> iD, string name, string link, string title, string metaD, string metaK, Nullable<int> parentID, string content)
        {
            var iDParameter = iD.HasValue ?
                new ObjectParameter("ID", iD) :
                new ObjectParameter("ID", typeof(int));
    
            var nameParameter = name != null ?
                new ObjectParameter("Name", name) :
                new ObjectParameter("Name", typeof(string));
    
            var linkParameter = link != null ?
                new ObjectParameter("Link", link) :
                new ObjectParameter("Link", typeof(string));
    
            var titleParameter = title != null ?
                new ObjectParameter("Title", title) :
                new ObjectParameter("Title", typeof(string));
    
            var metaDParameter = metaD != null ?
                new ObjectParameter("MetaD", metaD) :
                new ObjectParameter("MetaD", typeof(string));
    
            var metaKParameter = metaK != null ?
                new ObjectParameter("MetaK", metaK) :
                new ObjectParameter("MetaK", typeof(string));
    
            var parentIDParameter = parentID.HasValue ?
                new ObjectParameter("ParentID", parentID) :
                new ObjectParameter("ParentID", typeof(int));
    
            var contentParameter = content != null ?
                new ObjectParameter("Content", content) :
                new ObjectParameter("Content", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("UpdatePage", iDParameter, nameParameter, linkParameter, titleParameter, metaDParameter, metaKParameter, parentIDParameter, contentParameter);
        }
    }
}
