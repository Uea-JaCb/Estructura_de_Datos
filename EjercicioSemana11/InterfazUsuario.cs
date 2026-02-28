using System;

namespace TraductorDiccionario
{
    // Clase encargada de la interacción con el usuario
    public class InterfazUsuario
    {
        private Traductor _traductor;

        public InterfazUsuario()
        {
            _traductor = new Traductor();
        }

        // Muestra el menú principal
        public void MostrarMenu()
        {
            int opcion = -1;

            while (opcion != 0)
            {
                Console.WriteLine("\n==================== MENÚ ====================");
                Console.WriteLine("1. Traducir una frase");
                Console.WriteLine("2. Agregar palabras al diccionario");
                Console.WriteLine("0. Salir");
                Console.Write("Seleccione una opción: ");

                if (int.TryParse(Console.ReadLine(), out opcion))
                {
                    ProcesarOpcion(opcion);
                }
                else
                {
                    Console.WriteLine("\nError: Ingrese un número válido.");
                }
            }
        }

        private void ProcesarOpcion(int opcion)
        {
            switch (opcion)
            {
                case 1:
                    OpcionTraducir();
                    break;
                case 2:
                    OpcionAgregar();
                    break;
                case 0:
                    Console.WriteLine("\nSaliendo del programa...");
                    break;
                default:
                    Console.WriteLine("\nOpción no válida.");
                    break;
            }
        }

        private void OpcionTraducir()
        {
            Console.Write("\nIngrese la frase: ");
            string frase = Console.ReadLine();

            string resultado = _traductor.Traducir(frase);

            Console.WriteLine($"\nTraducción parcial: {resultado}");
        }

        private void OpcionAgregar()
        {
            Console.Write("\nIngrese la palabra en ESPAÑOL: ");
            string espanol = Console.ReadLine();

            Console.Write("Ingrese su traducción al INGLÉS: ");
            string ingles = Console.ReadLine();

            bool agregado = _traductor.IntentarAgregarPalabra(espanol, ingles);

            if (agregado)
            {
                Console.WriteLine("\nPalabra agregada correctamente.");
            }
            else
            {
                string existente = _traductor.ObtenerTraduccionDe(espanol?.ToLower());

                if (existente != null)
                {
                    Console.WriteLine($"\nLa palabra ya existe con traducción: {existente}");
                }
                else
                {
                    Console.WriteLine("\nNo se pudo agregar la palabra. Verifique los datos.");
                }
            }
        }
    }
}