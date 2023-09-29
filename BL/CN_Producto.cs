using DL;
using ML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class CN_Producto
    {
        private CD_Producto objCapaDato = new CD_Producto();

        public List<Producto> Listar()
        {
            return objCapaDato.Listar();
        }

        public int Registrar(Producto obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (string.IsNullOrEmpty(obj.Nombre) || string.IsNullOrWhiteSpace(obj.Nombre))
            {
                Mensaje = "El Nombre del Producto no puede ser vacio";
            }

            else if (string.IsNullOrEmpty(obj.Descripcion) || string.IsNullOrWhiteSpace(obj.Descripcion))
            {
                Mensaje = "La descripción del Producto no puede ser vacio";
            }

            else if (obj.oMarca.idMarca == 0)
            {
                Mensaje = "Debe seleccionar una marca";
            }

            else if (obj.oCatergoria.idCategoria == 0)
            {
                Mensaje = "Debe seleccionar una Categoria";
            }

            else if (obj.Precio == 0)
            {
                Mensaje = "Debe ingresar el precio del producto";
            }

            if (obj.Stock == 0)
            {
                Mensaje = "Debe ingresar el Stock del producto";
            }

            else if (string.IsNullOrEmpty(Mensaje))
            {
                return objCapaDato.Registrar(obj, out Mensaje);

            }
            else
            {
                return 0;
            }
            return 0;
        }

        public bool Editar(Producto obj, out string Mensaje)

        {
            Mensaje = string.Empty;

            if (string.IsNullOrEmpty(obj.Nombre) || string.IsNullOrWhiteSpace(obj.Nombre))
            {
                Mensaje = "El Nombre del Producto no puede ser vacio";
            }

            else if (string.IsNullOrEmpty(obj.Descripcion) || string.IsNullOrWhiteSpace(obj.Descripcion))
            {
                Mensaje = "La descripción del Producto no puede ser vacio";
            }

            else if (obj.oMarca.idMarca == 0)
            {
                Mensaje = "Debe seleccionar una marca";
            }

            else if (obj.oCatergoria.idCategoria == 0)
            {
                Mensaje = "Debe seleccionar una Categoria";
            }

            else if (obj.Precio == 0)
            {
                Mensaje = "Debe ingresar el precio del producto";
            }

            if (obj.Stock == 0)
            {
                Mensaje = "Debe ingresar el Stock del producto";
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

        public bool GuardarDatosImagen(Producto obj, out string Mensaje)
        {
            return objCapaDato.GuardarDatosImagen(obj, out Mensaje);
        }


        public bool Eliminar(int id, out string Mensaje)
        {
            return objCapaDato.Eliminar(id, out Mensaje);
        }

    }
}

