using AppSerWEB.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace AppSerWEB.Clases
{
	public class clsProducto
	{
		private DBSuperEntities1 dbSuper = new DBSuperEntities1();
        public PRODucto producto { get; set; }

        public string Insertar()
        {
            try
            {
                dbSuper.PRODuctoes.Add(producto);
                dbSuper.SaveChanges();
                return "Producto Insertado correctamente";
            }
            catch(Exception ex)
            {
                return "Error al insertar el producto"+ex.Message;
            }
        }

        public string  modificarEstado(int codigo, bool Activo)
        {
            try
            {

                PRODucto prod = Consultar(codigo);
                if (prod == null)
                {
                    return "El producto con el codigo ingresado no existe en base de datos";
                }
                prod.Activo = Activo;
                dbSuper.SaveChanges();
                if (Activo)
                {
                    return "Producto activado correctamente";
                }
                else
                {
                    return "Producto desactivado correctamente";
                }

            }
            catch (Exception ex)
            {
                return "Error al modificar el estado del producto" + ex.Message;
            }
        }
        public string Actualizar()
        {
            try
            {
                PRODucto prod = Consultar(producto.Codigo);
                if (prod == null)
                {
                    return "El producto con el codigo ingresado no existe";
                }
                dbSuper.PRODuctoes.AddOrUpdate(producto);
                dbSuper.SaveChanges();
                return "Producto actualizado correctamente";
            }
            catch (Exception ex)
            {
                return "Error al actualizar el producto" + ex.Message;
            }
        }

        public PRODucto Consultar(int codigo)
        {
            return dbSuper.PRODuctoes.FirstOrDefault(p => p.Codigo == codigo);
            
        }

        public List<PRODucto> ConsultarTodos()
        {
            return dbSuper.PRODuctoes.ToList();
        }

        public List<PRODucto> ConsultarPorTipo(int codigoTipo)
        {
            return dbSuper.PRODuctoes.Where(p => p.CodigoTipoProducto == codigoTipo).ToList();
        }

        public string Eliminar()
        {
            try
            {
                PRODucto prod = Consultar(producto.Codigo);
                if (prod == null)
                {
                    return "El producto con el codigo ingresado no existe";
                }
                dbSuper.PRODuctoes.Remove(prod);
                dbSuper.SaveChanges();
                return "Producto eliminado correctamente";
            }
            catch (Exception ex)
            {
                return "Error al eliminar el producto" + ex.Message;
            }
        }

        public string Eliminar (int codigo)
        {
            try
            {
                PRODucto prod = Consultar(codigo);
                if (prod == null)
                {
                    return "El producto con el codigo ingresado no existe";
                }
                dbSuper.PRODuctoes.Remove(prod);
                dbSuper.SaveChanges();
                return "Producto eliminado correctamente";
            }
            catch (Exception ex)
            {
                return "Error al eliminar el producto" + ex.Message;
            }
        }

        public  string GrabarImagenProducto(int idProducto, List<string> Imagenes)
        {
            try
            {
                ImagenesProducto imagenProducto = new ImagenesProducto();
                foreach (string imagen in Imagenes)
                {
                    imagenProducto.idProducto = idProducto;
                    imagenProducto.NombreImagen = imagen;
                    dbSuper.ImagenesProductoes.Add(imagenProducto);
                    dbSuper.SaveChanges();
                }
                return "Imagenes guardadas correctamente";
            }
            catch (Exception ex)
            { 
             return "Error al guardar las imagenes del producto" + ex.Message; 
            }
        }

        public IQueryable ListarImagenes(int idProducto)
        {
            return from P in dbSuper.Set<PRODucto>()
                       join TP in dbSuper.Set<TIpoPRoducto>() 
                       on P.CodigoTipoProducto equals TP.Codigo
                       join I in dbSuper.Set<ImagenesProducto>()
                       on P.Codigo equals I.idProducto
                   where P.Codigo == idProducto
                   orderby I.NombreImagen
                   select new
                   {
                       idTipoProducto = TP.Codigo,
                       TipoProducto = TP.Nombre,
                       idProducto = P.Codigo,
                       Producto = P.Nombre,
                       Imagen = I.NombreImagen
                   };
        }

    }
}