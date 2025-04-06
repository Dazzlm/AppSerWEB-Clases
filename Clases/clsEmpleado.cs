using AppSerWEB.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace AppSerWEB.Clases
{
	public class clsEmpleado
	{

		private DBSuperEntities1 dbSuper = new DBSuperEntities1();
		public EMPLeado empleado { get; set; }

		public string Insertar() {

			try
			{
				dbSuper.EMPLeadoes.Add(empleado);
				dbSuper.SaveChanges();
				return "Empleado Insertado correctamente";
			}
			catch {
				return "Error al insertar el empleado";
			}

		}

		public string Actualizar() {
			try
			{
				EMPLeado empl = Consultar(empleado.Documento);
				if (empl == null)
				{
					return "El empleado con el documento ingresado no existe";
				}
				dbSuper.EMPLeadoes.AddOrUpdate(empleado);
				dbSuper.SaveChanges();
				return "Empleado actualizado correctamente";
			}
			catch (Exception ex) {
				return "Error al actualizar el empleado" + ex.Message;
			}
		}

		public EMPLeado Consultar(string documento) {

			EMPLeado empl = dbSuper.EMPLeadoes.FirstOrDefault(e => e.Documento == documento);
			return empl;
		}

		public List<EMPLeado> ConsultarTodos()
		{
			return dbSuper.EMPLeadoes.ToList();
		}

		public string Eliminar()
		{
			try
			{
				EMPLeado empl = Consultar(empleado.Documento);
				if (empl == null)
				{
					return "El empleado con el documento ingresado no existe";
				}
				dbSuper.EMPLeadoes.Remove(empl);
				dbSuper.SaveChanges();
				return "Empleado eliminado correctamente";
			}
			catch (Exception ex)
			{
				return "Error al eliminar el empleado" + ex.Message;
			}
		}

		public string Eliminar(string Documento) {
            try
            {
                EMPLeado empl = Consultar(Documento);
                if (empl == null)
                {
                    return "El empleado con el documento ingresado no existe";
                }
                dbSuper.EMPLeadoes.Remove(empl);
                dbSuper.SaveChanges();
                return "Empleado eliminado correctamente";
            }
            catch (Exception ex)
            {
                return "Error al eliminar el empleado" + ex.Message;
            }
        }

		

    }
}