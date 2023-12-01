using Repasoo1;
using System;
namespace Examen_Listas
{
    class program
    {
        static void Main(string[] args)
        {
            Lista miLista = new Lista();

            // Insertar al inicio
            miLista.Inserinicio(new Persona("Alice", 30));

            // Insertar en medio
            miLista.insertarMedio(new Persona("Bob", 12));

            // Insertar al final
            miLista.InsertarFinal("Charlie", 20);

            // Imprimir lista original
            Console.WriteLine("Lista original:");
            miLista.OrdernarEImprimir();

            // Busqueda Binaria
            int edadBuscada = 30;
            Console.WriteLine($"\nBuscando persona con edad {edadBuscada}:");
            miLista.BusquedaBinaria(edadBuscada);

            

        }

    }
}