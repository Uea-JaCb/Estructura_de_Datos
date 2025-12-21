using System;

namespace AgendaTelefonica
{
    // 1. DEFINICIÓN DE LA CLASE (POO)
    // Esto es el "molde" para crear cada contacto.
    // Usamos una clase simple con propiedades públicas.
    public class Contacto
    {
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // 2. CREACIÓN DE ESTRUCTURAS DE DATOS (VECTOR)
            // Creamos un vector (arreglo) con capacidad fija para 50 contactos.
            // Esto cumple el requisito de "Estructura de datos estática".
            Contacto[] miAgenda = new Contacto[50];
            
            // Variable para contar cuántos contactos hemos guardado realmente.
            int cantidadContactos = 0;
            
            // Variable para controlar el menú
            bool continuar = true;

            // 3. BUCLE PRINCIPAL DEL PROGRAMA
            while (continuar)
            {
                // Limpiamos la pantalla para que se vea ordenado
                Console.Clear();
                Console.WriteLine("=================================");
                Console.WriteLine("   AGENDA TELEFÓNICA (PRACTICA 1)");
                Console.WriteLine("=================================");
                Console.WriteLine("1. Agregar nuevo contacto");
                Console.WriteLine("2. Ver todos los contactos (Reportería)");
                Console.WriteLine("3. Buscar contacto por nombre");
                Console.WriteLine("4. Salir");
                Console.WriteLine("=================================");
                Console.Write("Seleccione una opción: ");

                string opcion = Console.ReadLine();

                Console.WriteLine(); // Espacio en blanco

                switch (opcion)
                {
                    case "1":
                        // VERIFICAR SI HAY ESPACIO EN EL VECTOR
                        if (cantidadContactos < miAgenda.Length)
                        {
                            Console.WriteLine("--- NUEVO CONTACTO ---");
                            
                            // Crear un nuevo objeto de tipo Contacto
                            Contacto nuevo = new Contacto();

                            // Pedir datos al usuario
                            Console.Write("Ingrese Nombre: ");
                            nuevo.Nombre = Console.ReadLine();

                            Console.Write("Ingrese Teléfono: ");
                            nuevo.Telefono = Console.ReadLine();

                            Console.Write("Ingrese Email: ");
                            nuevo.Email = Console.ReadLine();

                            // GUARDAR EN EL VECTOR
                            // Usamos la variable 'cantidadContactos' como índice
                            miAgenda[cantidadContactos] = nuevo;
                            
                            // Aumentamos el contador
                            cantidadContactos++;

                            Console.WriteLine("\n¡Contacto guardado exitosamente!");
                        }
                        else
                        {
                            Console.WriteLine("¡La agenda está llena!");
                        }
                        break;

                    case "2":
                        Console.WriteLine("--- LISTA DE CONTACTOS (REPORTERÍA) ---");
                        // Verificar si la agenda está vacía
                        if (cantidadContactos == 0)
                        {
                            Console.WriteLine("No hay contactos registrados.");
                        }
                        else
                        {
                            // RECORRER EL VECTOR
                            // Usamos un ciclo FOR para mostrar solo los contactos registrados
                            for (int i = 0; i < cantidadContactos; i++)
                            {
                                Console.WriteLine($"ID: {i + 1}");
                                Console.WriteLine($"Nombre:   {miAgenda[i].Nombre}");
                                Console.WriteLine($"Teléfono: {miAgenda[i].Telefono}");
                                Console.WriteLine($"Email:    {miAgenda[i].Email}");
                                Console.WriteLine("-------------------------------");
                            }
                        }
                        break;

                    case "3":
                        Console.WriteLine("--- BUSCAR CONTACTO ---");
                        Console.Write("Ingrese el nombre a buscar: ");
                        string busqueda = Console.ReadLine().ToLower(); // Convertir a minúsculas para facilitar búsqueda
                        
                        bool encontrado = false;

                        // RECORRER EL VECTOR PARA BUSCAR
                        for (int i = 0; i < cantidadContactos; i++)
                        {
                            // Comparamos el nombre guardado con lo que escribió el usuario
                            if (miAgenda[i].Nombre.ToLower().Contains(busqueda))
                            {
                                Console.WriteLine($"\n¡ENCONTRADO EN LA POSICIÓN {i + 1}!");
                                Console.WriteLine($"Nombre:   {miAgenda[i].Nombre}");
                                Console.WriteLine($"Teléfono: {miAgenda[i].Telefono}");
                                Console.WriteLine("-------------------------------");
                                encontrado = true;
                            }
                        }

                        if (!encontrado)
                        {
                            Console.WriteLine("\nNo se encontraron contactos con ese nombre.");
                        }
                        break;

                    case "4":
                        Console.WriteLine("Saliendo del sistema...");
                        continuar = false;
                        break;

                    default:
                        Console.WriteLine("Opción no válida. Intente de nuevo.");
                        break;
                }

                // Pausa para que el usuario pueda leer antes de borrar la pantalla
                if (continuar)
                {
                    Console.WriteLine("\nPresione ENTER para continuar...");
                    Console.ReadLine();
                }
            }
        }
    }
}