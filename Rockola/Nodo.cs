using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rockola
{
    class Nodo
    {
        private Object datos;
        private Nodo sig;
        private Nodo anterior;

        public Nodo()
        {
            datos = sig = anterior = null;
        }

        public Nodo(Object obj)
        {
            datos = obj;
            sig = anterior = null;
        }

        public Nodo(Object obj, Nodo sig)
        {
            datos = obj;
            this.sig = sig;
        }

        internal Nodo Anterior
        {
            get { return anterior; }
            set { anterior = value; }
        }

        internal Nodo Sig
        {
            get { return sig; }
            set { sig = value; }
        }

        public Object Datos
        {
            get { return datos; }
            set { datos = value; }
        }


    }
}
