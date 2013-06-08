﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.ComponentModel;
using System.Data.EntityClient;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Linq;
using System.Runtime.Serialization;
using System.Xml.Serialization;

[assembly: EdmSchemaAttribute()]
#region EDM Relationship Metadata

[assembly: EdmRelationshipAttribute("u380982_astwodModel", "FK_Pages_Pages", "Pages", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, typeof(AStwoD.DAL.Entity_First_Model.astwod_Page), "Pages1", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, typeof(AStwoD.DAL.Entity_First_Model.astwod_Page), true)]

#endregion

namespace AStwoD.DAL.Entity_First_Model
{
    #region Contexts
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    public partial class u380982_astwodEntities : ObjectContext
    {
        #region Constructors
    
        /// <summary>
        /// Initializes a new u380982_astwodEntities object using the connection string found in the 'u380982_astwodEntities' section of the application configuration file.
        /// </summary>
        public u380982_astwodEntities() : base("name=u380982_astwodEntities", "u380982_astwodEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new u380982_astwodEntities object.
        /// </summary>
        public u380982_astwodEntities(string connectionString) : base(connectionString, "u380982_astwodEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new u380982_astwodEntities object.
        /// </summary>
        public u380982_astwodEntities(EntityConnection connection) : base(connection, "u380982_astwodEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        #endregion
    
        #region Partial Methods
    
        partial void OnContextCreated();
    
        #endregion
    
        #region ObjectSet Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<astwod_Page> astwod_Page
        {
            get
            {
                if ((_astwod_Page == null))
                {
                    _astwod_Page = base.CreateObjectSet<astwod_Page>("astwod_Page");
                }
                return _astwod_Page;
            }
        }
        private ObjectSet<astwod_Page> _astwod_Page;

        #endregion

        #region AddTo Methods
    
        /// <summary>
        /// Deprecated Method for adding a new object to the astwod_Page EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToastwod_Page(astwod_Page astwod_Page)
        {
            base.AddObject("astwod_Page", astwod_Page);
        }

        #endregion

        #region Function Imports
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectResult<astwod_Page> GetAllPages()
        {
            return base.ExecuteFunction<astwod_Page>("GetAllPages");
        }
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        /// <param name="mergeOption"></param>
        public ObjectResult<astwod_Page> GetAllPages(MergeOption mergeOption)
        {
            return base.ExecuteFunction<astwod_Page>("GetAllPages", mergeOption);
        }
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        /// <param name="iD">No Metadata Documentation available.</param>
        public ObjectResult<astwod_Page> GetPageByID(Nullable<global::System.Int32> iD)
        {
            ObjectParameter iDParameter;
            if (iD.HasValue)
            {
                iDParameter = new ObjectParameter("ID", iD);
            }
            else
            {
                iDParameter = new ObjectParameter("ID", typeof(global::System.Int32));
            }
    
            return base.ExecuteFunction<astwod_Page>("GetPageByID", iDParameter);
        }
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        /// <param name="mergeOption"></param>
        /// <param name="iD">No Metadata Documentation available.</param>
        public ObjectResult<astwod_Page> GetPageByID(Nullable<global::System.Int32> iD, MergeOption mergeOption)
        {
            ObjectParameter iDParameter;
            if (iD.HasValue)
            {
                iDParameter = new ObjectParameter("ID", iD);
            }
            else
            {
                iDParameter = new ObjectParameter("ID", typeof(global::System.Int32));
            }
    
            return base.ExecuteFunction<astwod_Page>("GetPageByID", mergeOption, iDParameter);
        }
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        /// <param name="name">No Metadata Documentation available.</param>
        /// <param name="link">No Metadata Documentation available.</param>
        /// <param name="title">No Metadata Documentation available.</param>
        /// <param name="metaD">No Metadata Documentation available.</param>
        /// <param name="metaK">No Metadata Documentation available.</param>
        /// <param name="parentID">No Metadata Documentation available.</param>
        /// <param name="content">No Metadata Documentation available.</param>
        public int CreatePage(global::System.String name, global::System.String link, global::System.String title, global::System.String metaD, global::System.String metaK, Nullable<global::System.Int32> parentID, global::System.String content)
        {
            ObjectParameter nameParameter;
            if (name != null)
            {
                nameParameter = new ObjectParameter("Name", name);
            }
            else
            {
                nameParameter = new ObjectParameter("Name", typeof(global::System.String));
            }
    
            ObjectParameter linkParameter;
            if (link != null)
            {
                linkParameter = new ObjectParameter("Link", link);
            }
            else
            {
                linkParameter = new ObjectParameter("Link", typeof(global::System.String));
            }
    
            ObjectParameter titleParameter;
            if (title != null)
            {
                titleParameter = new ObjectParameter("Title", title);
            }
            else
            {
                titleParameter = new ObjectParameter("Title", typeof(global::System.String));
            }
    
            ObjectParameter metaDParameter;
            if (metaD != null)
            {
                metaDParameter = new ObjectParameter("MetaD", metaD);
            }
            else
            {
                metaDParameter = new ObjectParameter("MetaD", typeof(global::System.String));
            }
    
            ObjectParameter metaKParameter;
            if (metaK != null)
            {
                metaKParameter = new ObjectParameter("MetaK", metaK);
            }
            else
            {
                metaKParameter = new ObjectParameter("MetaK", typeof(global::System.String));
            }
    
            ObjectParameter parentIDParameter;
            if (parentID.HasValue)
            {
                parentIDParameter = new ObjectParameter("ParentID", parentID);
            }
            else
            {
                parentIDParameter = new ObjectParameter("ParentID", typeof(global::System.Int32));
            }
    
            ObjectParameter contentParameter;
            if (content != null)
            {
                contentParameter = new ObjectParameter("Content", content);
            }
            else
            {
                contentParameter = new ObjectParameter("Content", typeof(global::System.String));
            }
    
            return base.ExecuteFunction("CreatePage", nameParameter, linkParameter, titleParameter, metaDParameter, metaKParameter, parentIDParameter, contentParameter);
        }
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        /// <param name="iD">No Metadata Documentation available.</param>
        public int DeletePageByID(Nullable<global::System.Int32> iD)
        {
            ObjectParameter iDParameter;
            if (iD.HasValue)
            {
                iDParameter = new ObjectParameter("ID", iD);
            }
            else
            {
                iDParameter = new ObjectParameter("ID", typeof(global::System.Int32));
            }
    
            return base.ExecuteFunction("DeletePageByID", iDParameter);
        }
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        /// <param name="parentID">No Metadata Documentation available.</param>
        public ObjectResult<astwod_Page> GetPageByParentID(Nullable<global::System.Int32> parentID)
        {
            ObjectParameter parentIDParameter;
            if (parentID.HasValue)
            {
                parentIDParameter = new ObjectParameter("ParentID", parentID);
            }
            else
            {
                parentIDParameter = new ObjectParameter("ParentID", typeof(global::System.Int32));
            }
    
            return base.ExecuteFunction<astwod_Page>("GetPageByParentID", parentIDParameter);
        }
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        /// <param name="mergeOption"></param>
        /// <param name="parentID">No Metadata Documentation available.</param>
        public ObjectResult<astwod_Page> GetPageByParentID(Nullable<global::System.Int32> parentID, MergeOption mergeOption)
        {
            ObjectParameter parentIDParameter;
            if (parentID.HasValue)
            {
                parentIDParameter = new ObjectParameter("ParentID", parentID);
            }
            else
            {
                parentIDParameter = new ObjectParameter("ParentID", typeof(global::System.Int32));
            }
    
            return base.ExecuteFunction<astwod_Page>("GetPageByParentID", mergeOption, parentIDParameter);
        }
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        /// <param name="iD">No Metadata Documentation available.</param>
        /// <param name="name">No Metadata Documentation available.</param>
        /// <param name="link">No Metadata Documentation available.</param>
        /// <param name="title">No Metadata Documentation available.</param>
        /// <param name="metaD">No Metadata Documentation available.</param>
        /// <param name="metaK">No Metadata Documentation available.</param>
        /// <param name="parentID">No Metadata Documentation available.</param>
        /// <param name="content">No Metadata Documentation available.</param>
        public int UpdatePage(Nullable<global::System.Int32> iD, global::System.String name, global::System.String link, global::System.String title, global::System.String metaD, global::System.String metaK, Nullable<global::System.Int32> parentID, global::System.String content)
        {
            ObjectParameter iDParameter;
            if (iD.HasValue)
            {
                iDParameter = new ObjectParameter("ID", iD);
            }
            else
            {
                iDParameter = new ObjectParameter("ID", typeof(global::System.Int32));
            }
    
            ObjectParameter nameParameter;
            if (name != null)
            {
                nameParameter = new ObjectParameter("Name", name);
            }
            else
            {
                nameParameter = new ObjectParameter("Name", typeof(global::System.String));
            }
    
            ObjectParameter linkParameter;
            if (link != null)
            {
                linkParameter = new ObjectParameter("Link", link);
            }
            else
            {
                linkParameter = new ObjectParameter("Link", typeof(global::System.String));
            }
    
            ObjectParameter titleParameter;
            if (title != null)
            {
                titleParameter = new ObjectParameter("Title", title);
            }
            else
            {
                titleParameter = new ObjectParameter("Title", typeof(global::System.String));
            }
    
            ObjectParameter metaDParameter;
            if (metaD != null)
            {
                metaDParameter = new ObjectParameter("MetaD", metaD);
            }
            else
            {
                metaDParameter = new ObjectParameter("MetaD", typeof(global::System.String));
            }
    
            ObjectParameter metaKParameter;
            if (metaK != null)
            {
                metaKParameter = new ObjectParameter("MetaK", metaK);
            }
            else
            {
                metaKParameter = new ObjectParameter("MetaK", typeof(global::System.String));
            }
    
            ObjectParameter parentIDParameter;
            if (parentID.HasValue)
            {
                parentIDParameter = new ObjectParameter("ParentID", parentID);
            }
            else
            {
                parentIDParameter = new ObjectParameter("ParentID", typeof(global::System.Int32));
            }
    
            ObjectParameter contentParameter;
            if (content != null)
            {
                contentParameter = new ObjectParameter("Content", content);
            }
            else
            {
                contentParameter = new ObjectParameter("Content", typeof(global::System.String));
            }
    
            return base.ExecuteFunction("UpdatePage", iDParameter, nameParameter, linkParameter, titleParameter, metaDParameter, metaKParameter, parentIDParameter, contentParameter);
        }

        #endregion

    }

    #endregion

    #region Entities
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="u380982_astwodModel", Name="astwod_Page")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class astwod_Page : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new astwod_Page object.
        /// </summary>
        /// <param name="id">Initial value of the ID property.</param>
        public static astwod_Page Createastwod_Page(global::System.Int32 id)
        {
            astwod_Page astwod_Page = new astwod_Page();
            astwod_Page.ID = id;
            return astwod_Page;
        }

        #endregion

        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 ID
        {
            get
            {
                return _ID;
            }
            set
            {
                if (_ID != value)
                {
                    OnIDChanging(value);
                    ReportPropertyChanging("ID");
                    _ID = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("ID");
                    OnIDChanged();
                }
            }
        }
        private global::System.Int32 _ID;
        partial void OnIDChanging(global::System.Int32 value);
        partial void OnIDChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String Name
        {
            get
            {
                return _Name;
            }
            set
            {
                OnNameChanging(value);
                ReportPropertyChanging("Name");
                _Name = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("Name");
                OnNameChanged();
            }
        }
        private global::System.String _Name;
        partial void OnNameChanging(global::System.String value);
        partial void OnNameChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String Link
        {
            get
            {
                return _Link;
            }
            set
            {
                OnLinkChanging(value);
                ReportPropertyChanging("Link");
                _Link = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("Link");
                OnLinkChanged();
            }
        }
        private global::System.String _Link;
        partial void OnLinkChanging(global::System.String value);
        partial void OnLinkChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String Title
        {
            get
            {
                return _Title;
            }
            set
            {
                OnTitleChanging(value);
                ReportPropertyChanging("Title");
                _Title = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("Title");
                OnTitleChanged();
            }
        }
        private global::System.String _Title;
        partial void OnTitleChanging(global::System.String value);
        partial void OnTitleChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String MetaD
        {
            get
            {
                return _MetaD;
            }
            set
            {
                OnMetaDChanging(value);
                ReportPropertyChanging("MetaD");
                _MetaD = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("MetaD");
                OnMetaDChanged();
            }
        }
        private global::System.String _MetaD;
        partial void OnMetaDChanging(global::System.String value);
        partial void OnMetaDChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String MetaK
        {
            get
            {
                return _MetaK;
            }
            set
            {
                OnMetaKChanging(value);
                ReportPropertyChanging("MetaK");
                _MetaK = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("MetaK");
                OnMetaKChanged();
            }
        }
        private global::System.String _MetaK;
        partial void OnMetaKChanging(global::System.String value);
        partial void OnMetaKChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.Int32> ParentID
        {
            get
            {
                return _ParentID;
            }
            set
            {
                OnParentIDChanging(value);
                ReportPropertyChanging("ParentID");
                _ParentID = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("ParentID");
                OnParentIDChanged();
            }
        }
        private Nullable<global::System.Int32> _ParentID;
        partial void OnParentIDChanging(Nullable<global::System.Int32> value);
        partial void OnParentIDChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String Content
        {
            get
            {
                return _Content;
            }
            set
            {
                OnContentChanging(value);
                ReportPropertyChanging("Content");
                _Content = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("Content");
                OnContentChanged();
            }
        }
        private global::System.String _Content;
        partial void OnContentChanging(global::System.String value);
        partial void OnContentChanged();

        #endregion

    
        #region Navigation Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("u380982_astwodModel", "FK_Pages_Pages", "Pages1")]
        public EntityCollection<astwod_Page> Pages1
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<astwod_Page>("u380982_astwodModel.FK_Pages_Pages", "Pages1");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<astwod_Page>("u380982_astwodModel.FK_Pages_Pages", "Pages1", value);
                }
            }
        }
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("u380982_astwodModel", "FK_Pages_Pages", "Pages")]
        public astwod_Page Page1
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<astwod_Page>("u380982_astwodModel.FK_Pages_Pages", "Pages").Value;
            }
            set
            {
                ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<astwod_Page>("u380982_astwodModel.FK_Pages_Pages", "Pages").Value = value;
            }
        }
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<astwod_Page> Page1Reference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<astwod_Page>("u380982_astwodModel.FK_Pages_Pages", "Pages");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<astwod_Page>("u380982_astwodModel.FK_Pages_Pages", "Pages", value);
                }
            }
        }

        #endregion

    }

    #endregion

    
}
