using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web.Mvc;
using AStwoD.DAL.Repositories;

namespace AStwoD.Infrastructure.HtmlHelpers
{
    public static class HtmlHelperExtensions
    {
        public static MvcHtmlString GetComponent(this HtmlHelper helper, string componentName)
        {
            ComponentRepository componentRepository = new ComponentRepository();
            if (componentRepository.GetComponentByName(componentName) != null)
                return new MvcHtmlString(componentRepository.GetComponentByName(componentName).Content);
            return new MvcHtmlString("has not contain :(");
        }

        public static IEnumerable<int> GetAllIndexes(this string source, string matchString)
        {
            matchString = Regex.Escape(matchString);
            return from Match match in Regex.Matches(source, matchString) select match.Index;
        }
    }


}