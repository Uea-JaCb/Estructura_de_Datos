using System;

namespace TraductorDiccionario
{
    // Punto de entrada del programa
    class Program
    {
        static void Main(string[] args)
        {
            InterfazUsuario interfaz = new InterfazUsuario();
            interfaz.MostrarMenu();
        }
    }
}