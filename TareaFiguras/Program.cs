using System;

namespace FigurasGeometricas
{
    /// <summary>
    /// Clase Cuadrado: Representa una figura geométrica de cuatro lados iguales.
    /// Encapsula la longitud del lado como dato primitivo.
    /// </summary>
    public class Cuadrado
    {
        // Variable privada que almacena la longitud del lado del cuadrado
        // Se restringe el acceso para proteger el estado del objeto
        private double lado;

        // Constructor que inicializa la instancia con la medida del lado
        public Cuadrado(double ladoInicial)
        {
            this.lado = ladoInicial;
        }

        // CalcularArea es una función que retorna un valor double.
        // Realiza el cálculo multiplicando el lado por sí mismo.
        public double CalcularArea()
        {
            return this.lado * this.lado;
        }

        // CalcularPerimetro es una función que retorna un valor double.
        // Determina el perímetro sumando los cuatro lados de la figura.
        public double CalcularPerimetro()
        {
            return 4 * this.lado;
        }
    }

    /// <summary>
    /// Clase Triangulo: Representa un triángulo rectángulo definido por su base y altura.
    /// Encapsula las dimensiones necesarias para los cálculos geométricos.
    /// </summary>
    public class Triangulo
    {
        // Variables privadas para almacenar las dimensiones base y altura
        private double baseTriangulo;
        private double alturaTriangulo;

        // Constructor que recibe dos argumentos double para inicializar el objeto
        public Triangulo(double baseInicial, double alturaInicial)
        {
            this.baseTriangulo = baseInicial;
            this.alturaTriangulo = alturaInicial;
        }

        // CalcularArea es una función que retorna un valor double.
        // Aplica la fórmula geométrica estándar: (base * altura) / 2
        public double CalcularArea()
        {
            return (this.baseTriangulo * this.alturaTriangulo) / 2;
        }

        // CalcularPerimetro es una función que retorna un valor double.
        // Calcula la hipotenusa internamente y suma los tres lados.
        public double CalcularPerimetro()
        {
            // Calcula la hipotenusa utilizando el Teorema de Pitágoras (raíz cuadrada de la suma de los catetos al cuadrado)
            double hipotenusa = Math.Sqrt((this.baseTriangulo * this.baseTriangulo) + (this.alturaTriangulo * this.alturaTriangulo));
            
            // Retorna la suma de la base, la altura y la hipotenusa calculada
            return this.baseTriangulo + this.alturaTriangulo + hipotenusa;
        }
    }

    // Clase principal que contiene el punto de entrada de la aplicación
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- CÁLCULO DE FIGURAS GEOMÉTRICAS ---");

            // Instanciación de objetos con valores predefinidos
            
            // Se crea un objeto Cuadrado con un lado de 5.0 unidades
            Cuadrado miCuadrado = new Cuadrado(5.0);

            // Se crea un objeto Triangulo con base 3.0 y altura 4.0
            Triangulo miTriangulo = new Triangulo(3.0, 4.0);

            // Visualización de resultados para el Cuadrado
            Console.WriteLine("\nRESULTADOS DEL CUADRADO (Lado = 5):");
            // Invoca al método para obtener el área
            Console.WriteLine("Área: " + miCuadrado.CalcularArea());
            // Invoca al método para obtener el perímetro
            Console.WriteLine("Perímetro: " + miCuadrado.CalcularPerimetro());

            // Visualización de resultados para el Triángulo
            Console.WriteLine("\nRESULTADOS DEL TRIÁNGULO (Base = 3, Altura = 4):");
            // Invoca al método para obtener el área
            Console.WriteLine("Área: " + miTriangulo.CalcularArea());
            // Invoca al método para obtener el perímetro
            Console.WriteLine("Perímetro: " + miTriangulo.CalcularPerimetro());

            // Mantiene la consola abierta hasta que el usuario presione Enter
            Console.ReadLine();
        }
    }
}