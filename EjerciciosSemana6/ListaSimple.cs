using System;

namespace TareaSemana6
{
    // DEFINICIÓN DE LA LISTA ENLAZADA
    public class ListaSimple
    {
        private Nodo? head; // Cabeza de la lista 

        public ListaSimple()
        {
            head = null; // Inicialización 
        }

        // Método auxiliar para llenar la lista 
        public void InsertarFinal(int dato)
        {
            Nodo nuevoNodo = new Nodo(dato);
            if (head == null)
            {
                head = nuevoNodo; 
            }
            else
            {
                Nodo actual = head;
                while (actual.Next != null)
                {
                    actual = actual.Next;
                }
                actual.Next = nuevoNodo; 
            }
        }

        // Método auxiliar para visualizar 
        public void DibujarLista()
        {
            Nodo? actual = head;
            Console.Write("head -->");
            while (actual != null)
            {
                Console.Write($" [{actual.Data}|*] -->"); 
                actual = actual.Next;
            }
            Console.WriteLine(" null");
        }

        // EJERCICIO 1: Contar Elementos
        public int ContarElementos()
        {
            int contador = 0;
            Nodo? actual = head;

            while (actual != null)
            {
                contador++;          
                actual = actual.Next; 
            }
            return contador;
        }

        // EJERCICIO 3: Buscar y Contar
        public void BuscarYContar(int valorBusqueda)
        {
            int vecesEncontrado = 0;
            Nodo? actual = head;
            
            while (actual != null)
            {
                if (actual.Data == valorBusqueda)
                {
                    vecesEncontrado++;
                }
                actual = actual.Next;
            }

            if (vecesEncontrado == 0)
            {
                Console.WriteLine($"\n[Resultado] El dato {valorBusqueda} NO fue encontrado en la lista.");
            }
            else
            {
                Console.WriteLine($"\n[Resultado] El dato {valorBusqueda} se encuentra {vecesEncontrado} veces en la lista.");
            }
        }
    }
}