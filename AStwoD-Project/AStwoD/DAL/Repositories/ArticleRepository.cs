using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AStwoD.DAL.Entity_First_Model;

namespace AStwoD.DAL.Repositories
{
    public class ArticleRepository:IRepositoryBase<Article>
    {
        private u380982_astwodEntities db;
        public ArticleRepository()
        {
            db = new u380982_astwodEntities();
        }

        public IEnumerable<Article> GetAll()
        {
            return db.GetAllArticles();
        }

        public Article Get(int id)
        {
            return db.GetArticleByID(id).FirstOrDefault();
        }

        public Article GetArticleByURL(string url)
        {
            return db.GetArticleByURL(url).FirstOrDefault();
        }

        public void CreateArticle(string title, string preview, string content,string url, string metaKeywords, string metaDescription, DateTime? publicationDate, bool isRemove)
        {
            db.CreateArticle(title, preview, content, url,metaKeywords, metaDescription, publicationDate, isRemove);
        }

        public void UpdateArticleByID(int id, string title, string preview, string content, string url, string metaKeywords, string metaDescription, DateTime publicationDate, bool isRemove)
        {
            db.UpdateArticleByID(id, title, preview, content,url, metaKeywords, metaDescription, publicationDate, isRemove);
        }

        public void Remove(int id)
        {
            db.DeleteArticleByID(id);
        }
    }
}