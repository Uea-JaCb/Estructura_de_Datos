using System;

class Program
{
    static void Main()
    {
        // Se crea el árbol
        ArbolBinarioBusqueda arbol = new ArbolBinarioBusqueda();

        bool salir = false;

        // Menú principal
        while (!salir)
        {
            Console.WriteLine("\n===== MENÚ BST =====");
            Console.WriteLine("1. Insertar");
            Console.WriteLine("2. Buscar");
            Console.WriteLine("3. Eliminar");
            Console.WriteLine("4. Recorridos");
            Console.WriteLine("5. Estadísticas");
            Console.WriteLine("6. Limpiar árbol");
            Console.WriteLine("7. Salir");
            Console.Write("Opción: ");

            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    Console.Write("Ingrese valor: ");
                    if (int.TryParse(Console.ReadLine(), out int v1))
                    {
                        arbol.Insertar(v1);
                        Console.WriteLine("✔ Valor insertado correctamente.");
                    }
                    else
                    {
                        Console.WriteLine("❌ Entrada inválida.");
                    }
                    break;

                case "2":
                    Console.Write("Buscar valor: ");
                    if (int.TryParse(Console.ReadLine(), out int v2))
                    {
                        if (arbol.Buscar(v2))
                            Console.WriteLine("✔ El valor SI existe en el árbol.");
                        else
                            Console.WriteLine("❌ El valor NO existe en el árbol.");
                    }
                    break;

                case "3":
                    Console.Write("Eliminar valor: ");
                    if (int.TryParse(Console.ReadLine(), out int v3))
                    {
                        if (arbol.Eliminar(v3))
                            Console.WriteLine("✔ Valor eliminado correctamente.");
                        else
                            Console.WriteLine("❌ El valor no existe.");
                    }
                    break;

                case "4":
                    Console.WriteLine("\n📌 Recorridos del árbol:");
                    arbol.MostrarRecorridos();
                    break;

                case "5":
                    if (!arbol.EstaVacio())
                    {
                        Console.WriteLine("\n📊 Estadísticas del árbol:");
                        Console.WriteLine("✔ Mínimo: " + arbol.ObtenerMinimo());
                        Console.WriteLine("✔ Máximo: " + arbol.ObtenerMaximo());
                        Console.WriteLine("✔ Altura: " + arbol.Altura());
                    }
                    else
                    {
                        Console.WriteLine("⚠ El árbol está vacío.");
                    }
                    break;

                case "6":
                    arbol.Limpiar();
                    Console.WriteLine("✔ El árbol fue limpiado correctamente.");
                    break;

                case "7":
                    salir = true;
                    Console.WriteLine("Saliendo del programa...");
                    break;

                default:
                    Console.WriteLine("❌ Opción inválida.");
                    break;
            }
        }
    }
}