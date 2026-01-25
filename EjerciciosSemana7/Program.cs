using System;

namespace TareaEstructuraDatos
{
    class Program
    {
        static void Main(string[] args)
        {
            bool continuar = true;

            while (continuar)
            {
                Console.Clear();
                Console.WriteLine("==================================================");
                Console.WriteLine("   TAREA: PILAS (STACKS) - ESTRUCTURA DE DATOS    ");
                Console.WriteLine("==================================================");
                Console.WriteLine("1. Verificar Paréntesis Balanceados");
                Console.WriteLine("2. Resolver Torres de Hanoi (Paso a paso)");
                Console.WriteLine("3. Salir");
                Console.WriteLine("==================================================");
                Console.Write("Seleccione una opción: ");

                string opcion = Console.ReadLine();

                try
                {
                    switch (opcion)
                    {
                        case "1":
                            EjecutarBalanceo();
                            break;
                        case "2":
                            EjecutarHanoi();
                            break;
                        case "3":
                            continuar = false;
                            Console.WriteLine("Finalizando la sesión...");
                            break;
                        default:
                            Console.WriteLine("⚠ Opción no reconocida. Intente nuevamente.");
                            Pausar();
                            break;
                    }
                }
                catch (Exception ex)
                {
                    // Captura cualquier error inesperado global
                    Console.WriteLine($"\n❌ Ocurrió un error inesperado: {ex.Message}");
                    Pausar();
                }
            }
        }

        static void EjecutarBalanceo()
        {
            Console.Clear();
            Console.WriteLine("--- EJERCICIO 1: PARÉNTESIS BALANCEADOS ---");
            Console.WriteLine("Ingrese una expresión matemática (ej: {5+(2*3)}):");
            
            string entrada = Console.ReadLine();

            // Validación simple de entrada vacía
            if (string.IsNullOrWhiteSpace(entrada))
            {
                Console.WriteLine("⚠ La entrada no puede estar vacía.");
                Pausar();
                return;
            }

            bool resultado = VerificadorBalance.EsBalanceada(entrada);

            Console.WriteLine("\nRESULTADO:");
            if (resultado)
                Console.WriteLine("✅ Fórmula CORRECTAMENTE balanceada.");
            else
                Console.WriteLine("❌ Error: La fórmula NO está balanceada (falla en paréntesis/llaves).");

            Pausar();
        }

        static void EjecutarHanoi()
        {
            Console.Clear();
            Console.WriteLine("--- EJERCICIO 2: TORRES DE HANOI CON PILAS ---");
            Console.Write("Ingrese el número de discos (Entre 1 y 10 para visualizar bien): ");
            
            try
            {
                // Intentamos convertir la entrada a número
                int n = int.Parse(Console.ReadLine());

                // Validación lógica de negocio
                if (n < 1)
                {
                    Console.WriteLine("⚠ El número de discos debe ser mayor a 0.");
                }
                else if (n > 15)
                {
                    Console.WriteLine("⚠ Demasiados discos generarían miles de pasos. Intente con menos de 15.");
                }
                else
                {
                    HanoiPilas juego = new HanoiPilas(n);
                    juego.Resolver();
                }
            }
            catch (FormatException)
            {
                // Se ejecuta si el usuario ingresa texto en lugar de números
                Console.WriteLine("❌ Error de Formato: Por favor ingrese solo números enteros.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error: {ex.Message}");
            }

            Pausar();
        }

        static void Pausar()
        {
            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
        }
    }
}
