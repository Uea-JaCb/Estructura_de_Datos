using System;
using System.Collections.Generic;

namespace TareaEstructuraDatos
{
    /// <summary>
    /// Implementación del algoritmo de Torres de Hanoi utilizando Pilas (Stacks) en lugar de recursividad.
    /// Simula el movimiento físico de los discos respetando las reglas del juego.
    /// </summary>
    public class HanoiPilas
    {
        private Stack<int> TorreOrigen;
        private Stack<int> TorreAuxiliar;
        private Stack<int> TorreDestino;
        private int NumDiscos;

        /// <summary>
        /// Constructor que inicializa el juego.
        /// </summary>
        /// <param name="n">Número total de discos.</param>
        public HanoiPilas(int n)
        {
            if (n < 1) throw new ArgumentException("El número de discos debe ser positivo.");

            NumDiscos = n;
            TorreOrigen = new Stack<int>();
            TorreAuxiliar = new Stack<int>();
            TorreDestino = new Stack<int>();

            // Inicializamos la Torre Origen: Discos grandes primero (base)
            // Ejemplo: Si N=3, apilamos 3, luego 2, luego 1.
            for (int i = NumDiscos; i >= 1; i--)
            {
                TorreOrigen.Push(i);
            }
        }

        /// <summary>
        /// Ejecuta el bucle iterativo para mover todos los discos al destino.
        /// Total de pasos: 2^n - 1.
        /// </summary>
        public void Resolver()
        {
            int totalMovimientos = (int)Math.Pow(2, NumDiscos) - 1;
            
            Console.WriteLine($"\n--- Resolviendo Hanoi para {NumDiscos} discos ---");
            Console.WriteLine($"--- Se requieren {totalMovimientos} movimientos ---\n");

            // REFERENCIAS para manejar el caso par/impar:
            // Si N es par, intercambiamos el rol lógico de Auxiliar y Destino para el ciclo.
            Stack<int> pilaDestinoRef = TorreDestino;
            Stack<int> pilaAuxiliarRef = TorreAuxiliar;
            string nombreDestino = "Destino";
            string nombreAuxiliar = "Auxiliar";

            if (NumDiscos % 2 == 0)
            {
                // Intercambio de referencias
                pilaDestinoRef = TorreAuxiliar;
                pilaAuxiliarRef = TorreDestino;
                nombreDestino = "Auxiliar";
                nombreAuxiliar = "Destino";
            }

            // Algoritmo Cíclico
            for (int i = 1; i <= totalMovimientos; i++)
            {
                // Movimiento 1 del ciclo: Origen <-> Destino
                if (i % 3 == 1)
                    MoverLegal(TorreOrigen, pilaDestinoRef, "Origen", nombreDestino);
                
                // Movimiento 2 del ciclo: Origen <-> Auxiliar
                else if (i % 3 == 2)
                    MoverLegal(TorreOrigen, pilaAuxiliarRef, "Origen", nombreAuxiliar);
                
                // Movimiento 3 del ciclo: Auxiliar <-> Destino
                else if (i % 3 == 0)
                    MoverLegal(pilaAuxiliarRef, pilaDestinoRef, nombreAuxiliar, nombreDestino);
            }

            Console.WriteLine("\n🎉 ¡Resolución completada con éxito!");
        }

        /// <summary>
        /// Decide en qué dirección mover el disco entre dos torres A y B, respetando la regla
        /// de que no se puede poner un disco grande sobre uno pequeño.
        /// </summary>
        private void MoverLegal(Stack<int> torreA, Stack<int> torreB, string nombreA, string nombreB)
        {
            // Caso 1: A está vacía -> B mueve a A
            if (torreA.Count == 0 && torreB.Count > 0)
            {
                EjecutarMovimiento(torreB, torreA, nombreB, nombreA);
            }
            // Caso 2: B está vacía -> A mueve a B
            else if (torreA.Count > 0 && torreB.Count == 0)
            {
                EjecutarMovimiento(torreA, torreB, nombreA, nombreB);
            }
            // Caso 3: Ambas tienen discos -> Comparamos tamaños (Peek)
            else if (torreA.Peek() < torreB.Peek()) // El disco de A es más pequeño, puede ir a B
            {
                EjecutarMovimiento(torreA, torreB, nombreA, nombreB);
            }
            else // El disco de B es más pequeño, puede ir a A
            {
                EjecutarMovimiento(torreB, torreA, nombreB, nombreA);
            }
        }

        private void EjecutarMovimiento(Stack<int> origen, Stack<int> destino, string nOrigen, string nDestino)
        {
            int disco = origen.Pop();
            destino.Push(disco);
            Console.WriteLine($"Mover disco [{disco}] de Torre {nOrigen} -> Torre {nDestino}");
        }
    }
}