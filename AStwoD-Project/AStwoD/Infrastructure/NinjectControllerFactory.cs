using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using AStwoD.DAL.Entity_First_Model;
using AStwoD.DAL.Repositories;
using AStwoD.Infrastructure.Abstract;
using AStwoD.Infrastructure.Concrete;
using Ninject;

namespace AStwoD.Infrastructure
{
    public class NinjectControllerFactory :DefaultControllerFactory
    {
        private IKernel ninjectKernel;

        public NinjectControllerFactory()
        {
            ninjectKernel = new StandardKernel();
            AddBindings();
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return controllerType == null ? null : (IController)ninjectKernel.Get(controllerType);
        }

        private void AddBindings()
        {
            ninjectKernel.Bind<IAuthProvider>().To<FormsAuthProvider>();
            ninjectKernel.Bind<IRepositoryBase<menuItemFromPage>>().To<MenuRepository>();
            ninjectKernel.Bind<IRepositoryBase<astwod_Page>>().To<PageRepository>();
            ninjectKernel.Bind<IRepositoryBase<Article>>().To<ArticleRepository>();
        }
    }
}