using AppSerWEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppSerWEB.Clases
{
    public class clsUsuario
    {
        private DBSuperEntities1 dbSuper = new DBSuperEntities1();
        public Usuario usuario { get; set; }
        public string CrearUsuario(int idPerfil)
        {
            try
            {
                clsCypher cypher = new clsCypher();
                cypher.Password = usuario.Clave;
                if (cypher.CifrarClave())
                {
                    usuario.Clave = cypher.PasswordCifrado;
                    usuario.Salt = cypher.Salt;
                    dbSuper.Usuarios.Add(usuario);
                    dbSuper.SaveChanges();
                    Usuario_Perfil UsuarioPerfil = new Usuario_Perfil();
                    UsuarioPerfil.idPerfil = idPerfil;
                    UsuarioPerfil.Activo = true;
                    UsuarioPerfil.idUsuario = usuario.id;
                    dbSuper.Usuario_Perfil.Add(UsuarioPerfil);
                    dbSuper.SaveChanges();
                    return "Usuario creado correctamente";

                }
                else
                {
                    return "Error al encriptar la clave";
                }


            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}