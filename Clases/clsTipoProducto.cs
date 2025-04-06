using AppSerWEB.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;

namespace AppSerWEB.Clases
{
    public class clsTipoProducto
    {
        private DBSuperEntities1 dbSuper = new DBSuperEntities1();

        public string Insertar(TIpoPRoducto tipoProducto)
        {
            try
            {
                dbSuper.TIpoPRoductoes.Add(tipoProducto);
                dbSuper.SaveChanges();
                return "Tipo de producto insertado correctamente";
            }
            catch (Exception ex)
            {
                return "Error al insertar el tipo de producto: " + ex.Message;

            }
        }
        public string Actualizar(TIpoPRoducto tipoProducto) {
            try {
                dbSuper.TIpoPRoductoes.AddOrUpdate(tipoProducto);
                dbSuper.SaveChanges();
                return "Tipo de producto actualizado correctamente";
            }
            catch (Exception ex)
            {
                return "Error al actualizar el tipo de producto: " + ex.Message;
            }
        }
    }
}
