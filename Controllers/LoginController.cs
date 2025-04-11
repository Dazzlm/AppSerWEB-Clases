using AppSerWEB.Clases;
using AppSerWEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace AppSerWEB.Controllers
{
    [RoutePrefix("api/Login")]
    public class LoginController : ApiController
    {
        // GET: Login

        [HttpPost]
        [Route("Ingresar")]
        public IQueryable<LoginRespuesta> Ingresar([FromBody] Login login)
        {
            clsLogin _login = new clsLogin();
            _login.login = login;
            return _login.Ingresar();
        }

    }
}