using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using AStwoD.Infrastructure.Abstract;

namespace AStwoD.Infrastructure.Concrete
{
    public class FormsAuthProvider: IAuthProvider
    {
        public Boolean Authenticate(String username, String password){
           
            Boolean result = FormsAuthentication.Authenticate(username, password);

            if (result)
            {
                FormsAuthentication.SetAuthCookie(username, false); 
            }

            return result;
        }
    }
}