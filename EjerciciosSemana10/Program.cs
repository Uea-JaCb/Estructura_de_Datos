using System;
using SistemaVacunacionCovid.Logica;

namespace SistemaVacunacionCovid
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("===== INFORME OFICIAL DE VACUNACIÓN COVID-19 =====\n");

            GestorVacunacion gestor = new GestorVacunacion(500);

            Console.WriteLine($"Total ciudadanos registrados: {gestor.PadronNacional.Count}");
            Console.WriteLine($"Vacunados Pfizer: {gestor.VacunadosPfizer.Count}");
            Console.WriteLine($"Vacunados AstraZeneca: {gestor.VacunadosAstraZeneca.Count}");

            MostrarResultado("1) Ciudadanos NO vacunados", gestor.ObtenerNoVacunados());
            MostrarResultado("2) Ciudadanos con ambas dosis", gestor.ObtenerAmbasDosis());
            MostrarResultado("3) Ciudadanos solo Pfizer", gestor.ObtenerSoloPfizer());
            MostrarResultado("4) Ciudadanos solo AstraZeneca", gestor.ObtenerSoloAstraZeneca());

            Console.WriteLine("\nProceso finalizado.");
            Console.ReadLine();
        }

        static void MostrarResultado(string titulo, System.Collections.IEnumerable conjunto)
        {
            Console.WriteLine($"\n{titulo}");

            int contador = 0;
            foreach (var elemento in conjunto)
            {
                Console.Write(elemento + " ");
                contador++;
                if (contador == 10)
                {
                    Console.Write("...");
                    break;
                }
            }

            Console.WriteLine();
        }
    }
}