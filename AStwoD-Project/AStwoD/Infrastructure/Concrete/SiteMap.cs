using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AStwoD.Classes
{
    public enum ChangeFrequency
    {
        Always,Hourly,Daily,Weekly,Monthly,Yearly,Never
    }

   public  interface ISiteMapItem
    {
        string Url { get; }
        DateTime? LastModified { get; }
        ChangeFrequency? ChangeFrequency { get; }
        float? Priority { get; }
    }

    public class SiteMapItem:ISiteMapItem
    {
        public SiteMapItem(string url)
        {
            Url = url;
        }
        public string Url { get;  set; }
        public DateTime? LastModified { get;  set; }
        public ChangeFrequency? ChangeFrequency { get;  set; }
        public float? Priority { get;  set; }
    }
}