using System;

namespace TareaSemana6
{
    class Program
    {
        static void Main(string[] args)
        {
            ListaSimple miLista = new ListaSimple();

            Console.WriteLine("=== CARGA DE DATOS ===");
            miLista.InsertarFinal(10);
            miLista.InsertarFinal(5);
            miLista.InsertarFinal(10); 
            miLista.InsertarFinal(20);
            miLista.InsertarFinal(10); 
            
            miLista.DibujarLista();

            Console.WriteLine("\n=== EJERCICIO 1: CONTAR ELEMENTOS ===");
            int total = miLista.ContarElementos();
            Console.WriteLine($"La lista tiene {total} elementos.");

            Console.WriteLine("\n=== EJERCICIO 3: BUSCAR Y CONTAR OCURRENCIAS ===");
            Console.Write("Buscando el 10...");
            miLista.BuscarYContar(10);

            Console.Write("Buscando el 99...");
            miLista.BuscarYContar(99);

            Console.WriteLine("\nPresione cualquier tecla para terminar...");
            Console.ReadKey();
        }
    }
}