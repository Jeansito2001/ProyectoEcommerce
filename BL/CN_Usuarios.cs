using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DL;
using ML;

namespace BL
{
    public class CN_Usuarios
    {
        private CD_Usuarios objCapaDato = new CD_Usuarios();

        public List<Usuario> Listar()
        {
            return objCapaDato.Listar();
        }

        public int RegistrarU(Usuario obj, out string Mensaje)
        {
            Mensaje= string.Empty;

            if(string.IsNullOrEmpty(obj.Nombres) || string.IsNullOrWhiteSpace(obj.Nombres))
            {
                Mensaje = "El nombre del usuario no puede ser vacio";
            }
            else if(string.IsNullOrEmpty(obj.ApellidoP) || string.IsNullOrWhiteSpace(obj.ApellidoP)) 
            {
                Mensaje = "El apellido paterno del usuario no puede ser vacio";
            }
            else if (string.IsNullOrEmpty(obj.ApellidoM) || string.IsNullOrWhiteSpace(obj.ApellidoM))
            {
                Mensaje = "El apellido materno del usuario no puede ser vacio";
            }
            else if (string.IsNullOrEmpty(obj.Correo) || string.IsNullOrWhiteSpace(obj.Correo))
            {
                Mensaje = "El correo del usuario no puede ser vacio";
            }

            if(string.IsNullOrEmpty(Mensaje))
            {

                string clave = CN_Recursos.GenerarClave();

                string asunto = "Creación de Cuenta";
                string mensaje_correo = "<h3>Su cuenta fue creada correctamente</h3></br><p>Su contraseña para acceder es: !clave!</p>";
                mensaje_correo = mensaje_correo.Replace("!clave!", clave);

                bool respuesta = CN_Recursos.EnviarCorreo(obj.Correo, asunto, mensaje_correo);

                if (respuesta)
                {
                    obj.Contrasenia = CN_Recursos.ConvertirSha256(clave);
                    return objCapaDato.RegistrarU(obj, out Mensaje);
                }
                else
                {
                    Mensaje = "Hubo un error al enviar el correo";
                    return 0;
                }

            }
            else
            {
                return 0;
            }
        }

        public bool Editar(Usuario obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (string.IsNullOrEmpty(obj.Nombres) || string.IsNullOrWhiteSpace(obj.Nombres))
            {
                Mensaje = "El nombre del usuario no puede ser vacio";
            }
            else if (string.IsNullOrEmpty(obj.ApellidoP) || string.IsNullOrWhiteSpace(obj.ApellidoP))
            {
                Mensaje = "El apellido paterno del usuario no puede ser vacio";
            }
            else if (string.IsNullOrEmpty(obj.ApellidoM) || string.IsNullOrWhiteSpace(obj.ApellidoM))
            {
                Mensaje = "El apellido materno del usuario no puede ser vacio";
            }
            else if (string.IsNullOrEmpty(obj.Correo) || string.IsNullOrWhiteSpace(obj.Correo))
            {
                Mensaje = "El correo del usuario no puede ser vacio";
            }

            if (string.IsNullOrEmpty(Mensaje))
            {
                return objCapaDato.Editar(obj, out Mensaje);
            }
            else
            {
                return false;
            }
        }

        public bool Eliminar(int id, out string Mensaje)
        {
            return objCapaDato.Eliminar(id, out Mensaje);
        }
    }
}
