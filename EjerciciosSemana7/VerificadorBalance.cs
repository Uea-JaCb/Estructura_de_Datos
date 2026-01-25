using System;
using System.Collections.Generic;

namespace TareaEstructuraDatos
{
    /// <summary>
    /// Clase utilitaria para la verificación de sintaxis de expresiones usando la estructura de datos Pila (Stack).
    /// </summary>
    public static class VerificadorBalance
    {
        /// <summary>
        /// Determina si los pares de paréntesis, corchetes y llaves están correctamente cerrados y anidados.
        /// </summary>
        /// <param name="expresion">Cadena que contiene la fórmula matemática.</param>
        /// <returns>True si es válida, False si tiene errores de balanceo.</returns>
        public static bool EsBalanceada(string expresion)
        {
            // Pila para almacenar los caracteres de apertura LIFO (Last In, First Out)
            Stack<char> pila = new Stack<char>();

            foreach (char caracter in expresion)
            {
                // 1. Si es un símbolo de apertura, lo guardamos en la pila
                if (caracter == '(' || caracter == '{' || caracter == '[')
                {
                    pila.Push(caracter);
                }
                // 2. Si es un símbolo de cierre, debemos verificar contra el tope de la pila
                else if (caracter == ')' || caracter == '}' || caracter == ']')
                {
                    // Si encontramos un cierre pero la pila está vacía, hay un error (ej: "5 + 2 )")
                    if (pila.Count == 0) return false;

                    char ultimoAbierto = pila.Pop();

                    // Verificamos que el cierre corresponda al último abierto
                    if (!SonPareja(ultimoAbierto, caracter))
                    {
                        return false;
                    }
                }
            }

            // 3. Al finalizar el recorrido, la pila debe estar vacía.
            // Si quedan elementos, significa que faltaron cierres (ej: "(5 + 2").
            return pila.Count == 0;
        }

        /// <summary>
        /// Método auxiliar para comprobar la correspondencia de tipos.
        /// </summary>
        private static bool SonPareja(char apertura, char cierre)
        {
            return (apertura == '(' && cierre == ')') ||
                   (apertura == '{' && cierre == '}') ||
                   (apertura == '[' && cierre == ']');
        }
    }
}