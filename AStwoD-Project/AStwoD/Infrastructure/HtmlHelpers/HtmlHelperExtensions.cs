﻿using System.Web.Mvc;
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
    }
}