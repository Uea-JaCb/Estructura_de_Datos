using System;
using System.Collections.Generic; // Necesario para List<T>
using System.Linq; // Utilizado auxiliarmente (aunque priorizaremos lógica manual)

namespace TareaEstructuraDatos
{
    // CLASE PRINCIPAL: Encapsula la lógica de los ejercicios (POO)
    public class GestorDeEjercicios
    {
        // EJERCICIO 1: Almacenar asignaturas y mostrarlas
        public void Ejercicio1_ListaAsignaturas()
        {
            Console.WriteLine("\n--- Ejercicio 1: Lista de Asignaturas ---");
            
            // Creación de la estructura de datos: Lista Genérica de Strings
            List<string> asignaturas = new List<string> { "Matemáticas", "Física", "Química", "Historia", "Lengua" };
            
            Console.WriteLine("Las asignaturas del curso son:");
            // Recorrido secuencial de la lista
            foreach (string asignatura in asignaturas)
            {
                Console.WriteLine("- " + asignatura);
            }
        }

        // EJERCICIO 2: Mensaje personalizado por asignatura
                public void Ejercicio2_MensajeEstudio()
        {
            Console.WriteLine("\n--- Ejercicio 2: Mensajes de Estudio ---");
            
            List<string> asignaturas = new List<string> { "Matemáticas", "Física", "Química", "Historia", "Lengua" };
            
            foreach (string asignatura in asignaturas)
            {
                // Uso de interpolación de cadenas de C#
                Console.WriteLine($"Yo estudio {asignatura}");
            }
        }

        // EJERCICIO 5: Números del 1 al 10 en orden inverso
                public void Ejercicio5_Inverso()
        {
            Console.WriteLine("\n--- Ejercicio 5: Orden Inverso ---");
            
            List<int> numeros = new List<int>();
            
            // Llenado de la lista
            for (int i = 1; i <= 10; i++)
            {
                numeros.Add(i);
            }

            Console.Write("Números en orden inverso: ");
            
            // Algoritmo de recorrido inverso (LIFO visual)
            // Empezamos desde el último índice (Count - 1) hasta 0
            for (int i = numeros.Count - 1; i >= 0; i--)
            {
                Console.Write(numeros[i]);
                
                // Estética: Agregamos coma solo si no es el último número a imprimir
                if (i > 0) Console.Write(", ");
            }
            Console.WriteLine();
        }

        // EJERCICIO 9: Conteo de vocales
        public void Ejercicio9_ConteoVocales()
        {
            Console.WriteLine("\n--- Ejercicio 9: Conteo de Vocales ---");
            
            Console.Write("Introduce una palabra: ");
            string palabra = Console.ReadLine().ToLower(); // Normalizamos a minúsculas
            
            // Estructura auxiliar: Lista de vocales a buscar
            List<char> vocales = new List<char> { 'a', 'e', 'i', 'o', 'u' };

            foreach (char vocal in vocales)
            {
                int contador = 0;
                // Algoritmo de búsqueda de frecuencia
                foreach (char letra in palabra)
                {
                    if (letra == vocal)
                    {
                        contador++;
                    }
                }
                
                // Solo mostramos si la vocal aparece al menos una vez
                if (contador > 0) 
                {
                    Console.WriteLine($"La vocal '{vocal}' aparece {contador} veces.");
                }
            }
        }

        // EJERCICIO 10: Menor y Mayor precio
        public void Ejercicio10_MinMax()
        {
            Console.WriteLine("\n--- Ejercicio 10: Min y Max ---");
            
            List<int> precios = new List<int> { 50, 75, 46, 22, 80, 65, 8 };
            
            if (precios.Count == 0)
            {
                Console.WriteLine("La lista está vacía.");
                return;
            }

            // Algoritmo manual para encontrar Min y Max
            // Asumimos el primer elemento como el actual menor y mayor
            int menor = precios[0];
            int mayor = precios[0];

            foreach (int precio in precios)
            {
                if (precio < menor) menor = precio;
                if (precio > mayor) mayor = precio;
            }

            Console.WriteLine("Lista de precios: " + string.Join(", ", precios));
            Console.WriteLine($"El menor precio es: {menor}");
            Console.WriteLine($"El mayor precio es: {mayor}");
        }
    }

    // Clase para el menú de opciones
    class Program
    {
        static void Main(string[] args)
        {
            // Instanciación del objeto (POO)
            GestorDeEjercicios gestor = new GestorDeEjercicios();
            bool continuar = true;

            while (continuar)
            {
                Console.Clear();
                Console.WriteLine("=== TAREA ESTRUCTURA DE DATOS: LISTAS ===");
                Console.WriteLine("1. Ejercicio 1 (Mostrar Asignaturas)");
                Console.WriteLine("2. Ejercicio 2 (Mensaje 'Yo estudio')");
                Console.WriteLine("3. Ejercicio 5 (Números 1-10 Inverso)");
                Console.WriteLine("4. Ejercicio 9 (Conteo Vocales)");
                Console.WriteLine("5. Ejercicio 10 (Precios Min/Max)");
                Console.WriteLine("6. Salir");
                Console.Write("Seleccione una opción: ");

                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1": gestor.Ejercicio1_ListaAsignaturas(); break;
                    case "2": gestor.Ejercicio2_MensajeEstudio(); break;
                    case "3": gestor.Ejercicio5_Inverso(); break;
                    case "4": gestor.Ejercicio9_ConteoVocales(); break;
                    case "5": gestor.Ejercicio10_MinMax(); break;
                    case "6": continuar = false; break;
                    default: Console.WriteLine("Opción no válida."); break;
                }

                if (continuar)
                {
                    Console.WriteLine("\nPresione cualquier tecla para volver al menú...");
                    Console.ReadKey();
                }
            }
        }
    }
}