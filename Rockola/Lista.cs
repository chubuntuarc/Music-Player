using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rockola
{
    class Lista
    {

       private string nombre;
        private Nodo primero;
        private Nodo ultimo;

        public Lista(string nombre)
        {
            this.nombre = nombre;
            primero = ultimo = null;
        } 

        public Lista()
        {
            nombre = "Lista";
            primero = ultimo = null;
        }

        
        public Nodo Ultimo
        {
            get { return ultimo; }
            set { ultimo = value; }
        }

        public Nodo Primero
        {
            get { return primero; }
            set { primero = value; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public Boolean esVacia()
        {
            return primero == null;
        }
        //
        public void insertarAlInicio<T>(T obj)
        {
            if (esVacia())
                primero = ultimo = new Nodo(obj);
            else
                ultimo = ultimo.Sig = new Nodo(obj);
        }

        public object eliminarDelFrente()
        {

            object datoRemovido = null;
            if (esVacia())
            {
                throw new Exception("La lista está vacía");
            }

            datoRemovido = primero.Datos;

            if (primero.Equals(ultimo))
            {
                primero = ultimo = null;
            }
            else
            {
                primero = primero.Sig;
            }

            return datoRemovido;
        }

        public object eliminarDeAtras()
        {
            object datoRemovido = null;
            if (esVacia())
            {
                throw new Exception("La lista está vacía");
            }

            datoRemovido = ultimo.Datos;

            if (primero.Equals(ultimo))
            {
                primero = ultimo = null;
            }
            else
            {
                Nodo actual = primero;

                while (actual.Sig != ultimo)
                {
                    actual = actual.Sig;
                }
                ultimo = actual;
                actual.Sig = null;
            }

            return datoRemovido;
        }

        public object getElementoIndice(int posicion)
        {
            if (esVacia())
            {
                return null;
            }
            else
            {
                Nodo actual = primero;
                int contador = 0;

                while ((actual != null) && (contador < posicion))
                {
                    actual = actual.Sig;
                    contador++;
                }
                if ((actual != null) && (contador == posicion))
                {
                    return actual.Datos;
                }
                else
                {
                    return null;
                }


            }
        }

        public void insertarElementoIndice<T>(int posicion, T obj)
        {
            Nodo nuevo;
            Nodo actual;

            if (esVacia())
            {
                return;
            }
            else
            {
                actual = primero;
                int contador = 0;

                while ((actual != null) && (contador < posicion - 1))
                {
                    actual = actual.Sig;
                    contador++;
                }

                if((actual != null) && (contador == posicion - 1))
                {
                    nuevo = new Nodo(obj, actual.Sig);
                    actual.Sig = nuevo;
                }
            }
        }

        //
        public object eliminarElementoIndice(int posicion)
        {
            object datoRemovido;
            Nodo actual;

            if (esVacia())
            {
                return null;
            }
            else
            {
                if (posicion == 0)
                {
                    datoRemovido = primero.Datos;
                    primero = primero.Sig;
                    return datoRemovido;
                }
                else
                {
                    actual = primero;
                    int contador = 0;

                    while ((actual != null) && (contador < posicion - 1))
                    {
                        actual = actual.Sig;
                        contador++;
                    }

                    if ((actual != null) && (contador == posicion - 1))
                    {
                        datoRemovido = actual.Sig.Datos;
                        actual.Sig = actual.Sig.Sig;
                        return datoRemovido;
                    }
                    

                }

                return null;
            }
        }

    }
}
