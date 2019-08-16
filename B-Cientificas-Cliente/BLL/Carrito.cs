using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Carrito
    {
        public string proyecto_id { set; get; }
        public string nombre { set; get; }
        public string precio { set; get; }
        
        public static List<Carrito> carritoLista = new List<Carrito>();

        public Boolean agregar(Carrito item)
        {
            foreach(Carrito c in carritoLista)
            {
                if (c.proyecto_id == item.proyecto_id)
                {
                    return false;
                }
            }
            carritoLista.Add(item);
            return true;
        }
    }
}
