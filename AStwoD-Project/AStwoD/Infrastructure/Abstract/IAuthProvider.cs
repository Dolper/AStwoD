using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AStwoD.Infrastructure.Abstract
{
    public interface IAuthProvider
    {

        Boolean Authenticate(String userName, String password);

    }
}