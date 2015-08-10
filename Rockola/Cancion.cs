using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rockola
{
    class Cancion
    {
         private string descripcion;

        public Cancion() { }

        public Cancion(string descripcion)
        {
            this.descripcion = descripcion;
        }

        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }
    }
}
