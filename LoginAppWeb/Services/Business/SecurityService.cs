using LoginAppWeb.Models;
using LoginAppWeb.Services.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoginAppWeb.Services.Business
{
    public class SecurityService
    {
        public SecurityDAO daoService = new SecurityDAO();  
        public bool Authenticate(UserModel user)
        {
            return daoService.FindByUser(user);
        }
    }
}