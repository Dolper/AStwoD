using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using AStwoD.DAL.Entity_First_Model;

namespace AStwoD.Models
{
    public class ArticleModel
    {

        public int ID { get; set; }
        [Display(Name = "Загловок статьи")]
        public string Title { get; set; }
        [Display(Name = "Краткое содержание статьи")]
        public string Preview { get; set; }
        [Display(Name = "Полный текст статьи")]
        public string Content { get; set; }
        [Required(ErrorMessage = "Поле не может быть пустым")]
        [Display(Name = "URL статьи")]
        public string URL { get; set; }
        [Display(Name = "MetaKeywords")]
        public string MetaKeywords { get; set; }
        [Display(Name = "MetaDescription")]
        public string MetaDescription { get; set; }
        [Display(Name = "Дата публикации статьи")]
        public DateTime PublicationDate { get; set; }

        public bool IsRemove { get; set; }

        public ArticleModel() { }

        public ArticleModel(int id, string title, string preview, string content, string url, string metaKeywords, string metaDescription, DateTime publicationDate, bool isRemove)
        {
            ID = id;
            Title = title;
            Preview = preview;
            Content = content;
            URL = url;
            MetaKeywords = metaKeywords;
            MetaDescription = metaDescription;
            PublicationDate = publicationDate;
            IsRemove = isRemove;
        }

        public static implicit operator ArticleModel(Article article)
        {
            return new ArticleModel(article.ID, article.Title, article.Preview, article.Content, article.URL, article.MetaKeywords, article.MetaDescription, article.PublicationDate, article.IsRemove);
        }
    }
}