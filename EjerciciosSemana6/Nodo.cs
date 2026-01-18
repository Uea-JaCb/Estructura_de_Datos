using System;

namespace TareaSemana6
{
    // DEFINICIÓN DE NODO
    public class Nodo
    {
        public int Data;      // Campo de datos 
        public Nodo? Next;    // Puntero al siguiente nodo 

        public Nodo(int data)
        {
            this.Data = data;
            this.Next = null; // Inicialmente apunta a null 
        }
    }
}