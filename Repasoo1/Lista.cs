using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Repasoo1
{
    public class Lista
    {
        Nodo primero;
        Nodo ultimo;

        public Lista()
        {
            primero = null;
            ultimo = null;
        }
        public bool ListaVacia()
        {
            
           return (primero ==  null);
           
        }
        public int Longitud()
        {
            int longitud = 0;
            Nodo actual = primero;
            while (actual != null)
            {
                longitud++;
                actual = actual.getSiguiente();
            }
            return longitud;
        }
        public void Inserinicio(Persona persona)
        {
            Nodo nuevoNodo = new Nodo(persona);

            if(ListaVacia())
            {
                primero = ultimo = nuevoNodo;
            }
            else
            {
                nuevoNodo._Siguiente = primero;
                primero = nuevoNodo;
            }
        }
        public void insertarMedio(Persona valor)
        {
            if(ListaVacia())
            {
                primero = ultimo = new Nodo(valor);
            }
            Nodo nodoActual = primero;
            while(nodoActual._Siguiente != null && nodoActual._Siguiente.getDatos().Edad <= valor.Edad)
            {
                Nodo nuevoNodo = new Nodo(valor);
                nuevoNodo._Siguiente = nodoActual._Siguiente;
                nodoActual._Siguiente = nuevoNodo;

                if(nodoActual == ultimo)
                {
                    ultimo = nuevoNodo;
                }
            }
          
        }
        public void InsertarFinal(string nombre, int edad)
        {
          Persona nuevoPersona = new Persona(nombre, edad);
            Nodo nuevaNodo = new Nodo(nuevoPersona);

            if(ListaVacia())
            {
                primero = ultimo = nuevaNodo;
            }
            else
            {
                ultimo._Siguiente = nuevaNodo;
                ultimo = nuevaNodo;
            }
        }
        public void OrdernarEImprimir()
        {
            Nodo actual = primero;
            while (actual != null)
            {
                Nodo minNodo = actual;
                Nodo temp = actual.getSiguiente();
                while (temp != null)
                {
                    if (temp.getDatos().Edad < minNodo.getDatos().Edad)
                    {
                        minNodo = temp;
                    }
                    temp = temp.getSiguiente();
                }
                Persona tempPersona = actual.getDatos();
                actual._datos = minNodo._datos;
                minNodo._datos = tempPersona;

                Console.WriteLine($"El nombre es {actual.getDatos().Nombre} y la edad es {actual.getDatos().Edad}");
                actual = actual.getSiguiente();
            }
        }
        public void BusquedaBinaria(int edadBuscada)
        {
            OrdernarEImprimir();

            int izquierda = 0;
            int derecha = Longitud() - 1;
            bool encontrado = false;

            while (izquierda <= derecha)
            {
                int medio = izquierda + (derecha - izquierda) / 2;
                int contador = 0;
                Nodo actual = primero;

                // Avanzar al nodo en la posición del medio
                while (contador < medio && actual != null)
                {
                    actual = actual.getSiguiente();
                    contador++;
                }

                // Verificar si el nodo actual tiene la edad buscada
                if (actual != null && actual.getDatos().Edad == edadBuscada)
                {
                    Console.WriteLine($"La persona con la edad {edadBuscada} se encuentra en la posición {medio}.");
                    encontrado = true;
                    break;
                }
                else if (actual != null && actual.getDatos().Edad < edadBuscada)
                {
                    // Si la edad buscada es mayor, buscar en la mitad derecha
                    izquierda = medio + 1;
                }
                else
                {
                    // Si la edad buscada es menor, buscar en la mitad izquierda
                    derecha = medio - 1;
                }
            }

            if (!encontrado)
            {
                Console.WriteLine($"La persona con la edad {edadBuscada} no se encuentra en la lista.");
            }
        }
    }
}
