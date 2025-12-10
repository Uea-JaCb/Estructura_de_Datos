using System;
namespace RegistroEstudiantes
{
    // 1. Definición de la Clase Estudiante
    // Esta clase actúa como una plantilla para crear objetos de tipo estudiante.
    public class Estudiante
    {
        // Propiedades básicas (Get/Set permiten leer y escribir datos)
        public string Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Direccion { get; set; }
        // USO DE ARRAY: Definimos un arreglo de strings para guardar exactamente 3 teléfonos.
        public string[] Telefonos { get; set; }
        // Constructor: Se ejecuta al crear el estudiante para inicializar el array.
        public Estudiante()
        {
            Telefonos = new string[3]; // Reservamos espacio para 3 números (índices 0, 1 y 2)
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // Instanciamos un objeto de la clase Estudiante
            Estudiante nuevoEstudiante = new Estudiante();
            Console.WriteLine("=== REGISTRO DE ESTUDIANTE ===");
            // 2. Captura de datos básicos
            Console.Write("Ingrese el ID: ");
            nuevoEstudiante.Id = Console.ReadLine();
            Console.Write("Ingrese el Nombre: ");
            nuevoEstudiante.Nombre = Console.ReadLine();
            Console.Write("Ingrese el Apellido: ");
            nuevoEstudiante.Apellido = Console.ReadLine();
            Console.Write("Ingrese la Dirección: ");
            nuevoEstudiante.Direccion = Console.ReadLine();
            // 3. Captura de teléfonos usando un ciclo FOR (Iteración sobre el Array)
            Console.WriteLine("\n--- Registro de Teléfonos ---");
            for (int i = 0; i < 3; i++)
            {
                // i + 1 es solo visual para que el usuario vea "Teléfono 1" en vez de "0"
                Console.Write($"Ingrese el número de teléfono {i + 1}: ");
                // Guardamos el dato en la posición 'i' del array
                nuevoEstudiante.Telefonos[i] = Console.ReadLine();
            }
            // 4. Mostrar los resultados (Salida de datos)
            Console.WriteLine("\n========================================");
            Console.WriteLine("       DATOS REGISTRADOS EXITOSAMENTE");
            Console.WriteLine("========================================");
            Console.WriteLine($"ID:        {nuevoEstudiante.Id}");
            Console.WriteLine($"Estudiante:{nuevoEstudiante.Nombre} {nuevoEstudiante.Apellido}");
            Console.WriteLine($"Dirección: {nuevoEstudiante.Direccion}");
            Console.WriteLine("Teléfonos de contacto:");
            // Recorremos el array para mostrar los números guardados
            foreach (string tel in nuevoEstudiante.Telefonos)
            {
                Console.WriteLine($"- {tel}");
            }
            // Pausa para que no se cierre la consola inmediatamente
            Console.WriteLine("\nPresione cualquier tecla para salir...");
            Console.ReadKey();
        }
    }
}
