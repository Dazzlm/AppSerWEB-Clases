using AppSerWEB.Clases;
using AppSerWEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace AppSerWEB.Controllers
{
    [RoutePrefix("api/Productos")]
    [Authorize]
    public class ProductosController:ApiController
	{

        [HttpGet]
        [Route("ConsultarImagenes")]

        public IQueryable ConsultarImagenes(int idproducto)
        {
            clsProducto Producto = new clsProducto();

            return Producto.ListarImagenes(idproducto);

        }

        [HttpGet]
        [Route("ConsultarTodos")]
        public List<PRODucto> ConsultarTodos()
        {
            clsProducto Producto = new clsProducto();
            return Producto.ConsultarTodos();
        }

        [HttpGet]
        [Route("ConsultarXTipo")]
        public List<PRODucto> ConsultarXTipo(int codigoTipo)
        {
            clsProducto Producto = new clsProducto();
            return Producto.ConsultarPorTipo(codigoTipo);
        }

        [HttpGet]
        [Route("Consultar")]
        public PRODucto Consultar(int codigo)
        {
            clsProducto Producto = new clsProducto();
            return Producto.Consultar(codigo);
        }

        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] PRODucto producto)
        {
            clsProducto Producto = new clsProducto();
            Producto.producto = producto;
            return Producto.Insertar();
        }

        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] PRODucto producto)
        {
            clsProducto Producto = new clsProducto();
            Producto.producto = producto;
            return Producto.Actualizar();
        }
        [HttpPut]
        [Route("Inactivar")]
        public string Inactivar(int codigo)
        {
            clsProducto Producto = new clsProducto();
            return Producto.modificarEstado(codigo, false);

        }

        [HttpPut]
        [Route("Activar")]
        public string Activar(int codigo)
        {
            clsProducto Producto = new clsProducto();
            return Producto.modificarEstado(codigo, true);

        }


        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar([FromBody] PRODucto producto)
        {
            clsProducto Producto = new clsProducto();
            Producto.producto = producto;
            return Producto.Eliminar();
        }

        [HttpDelete]
        [Route("EliminarXCodigo")]
        public string EliminarXCodigo( int codigo)
        {
            clsProducto Producto = new clsProducto();
           
            return Producto.Eliminar(codigo);
        }

    }
}