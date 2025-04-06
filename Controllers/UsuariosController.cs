using AppSerWEB.Clases;
using AppSerWEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;

namespace AppSerWEB.Controllers
{
    [RoutePrefix("api/Usuarios")]
    public class UsuariosController : ApiController
    {
        [HttpPost]
        [Route("CrearUsuario")]
        public string CrearUsuario([FromBody]Usuario usuario,int idPerfil)

        {
            clsUsuario clsUsuario = new clsUsuario();
            clsUsuario.usuario = usuario;
            return clsUsuario.CrearUsuario(idPerfil);
        }

    }

}
