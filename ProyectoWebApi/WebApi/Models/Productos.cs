using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace model.entity
{
    public class Productos
    {
        public int IdProducto { get; set; }
        public string TipoProducto { get; set; }
        public string CodigoUnico { get; set; }
        public string NombreProducto { get; set; }
        public string Activo { get; set; }
        public string Cantidad { get; set; }
        public string Valor { get; set; }
        public int Total { get; set; }


        public int IdProductos
        {
            get
            {
                return IdProducto;
            }

            set
            {
                IdProducto = value;
            }
        }


        public Productos()
        {

        }
        public Productos(int IdProductos)
        {
            this.IdProducto = IdProductos;
        }
        public Productos(int IdProductos, string TipoProducto, string CodigoUnico, string NombreProducto,  string Activo,  string Cantidad, string Valor, int Total)
        {
            this.IdProducto = IdProductos;
    
        }



    }
}