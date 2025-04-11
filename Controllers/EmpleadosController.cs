using AppSerWEB.Clases;
using AppSerWEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AppSerWEB.Controllers
{
    [RoutePrefix ("api/Empleados")]
    [Authorize]
    public class EmpleadosController : ApiController
    {
        [HttpGet]
        [Route("ConsultarTodos")]

        public  List<EMPLeado> ConsultarTodos()
        {
            clsEmpleado Empleado = new clsEmpleado();

            return Empleado.ConsultarTodos();

        }

        [HttpGet]
        [Route("ConsultarXDocumento")]
        public EMPLeado ConsultarXDocumento(string documento)
        {
            clsEmpleado Empleado = new clsEmpleado();
            return Empleado.Consultar(documento);
        }

        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] EMPLeado empleado)
        {
            clsEmpleado Empleado = new clsEmpleado();
            Empleado.empleado = empleado;
            return Empleado.Insertar();
        }

        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] EMPLeado empleado)
        {
            clsEmpleado Empleado = new clsEmpleado();
            Empleado.empleado = empleado;
            return Empleado.Actualizar();
        }

        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar([FromBody] EMPLeado empleado)
        {
            clsEmpleado Empleado = new clsEmpleado();
            Empleado.empleado = empleado;
            return Empleado.Eliminar();
        }

        [HttpDelete]
        [Route("EliminarXDocumento")]
        public string EliminarXDocumento(string Documento)
        {
            clsEmpleado Empleado = new clsEmpleado();
            return Empleado.Eliminar(Documento);
        }

    }
}