// Clase que representa cada elemento del árbol binario
public class Nodo
{
    // Dato que almacena el nodo
    public int valor;

    // Referencia al hijo izquierdo (valores menores)
    public Nodo izquierdo;

    // Referencia al hijo derecho (valores mayores)
    public Nodo derecho;

    // Constructor: inicializa el nodo con un valor
    public Nodo(int valor)
    {
        this.valor = valor;

        // Al inicio no tiene hijos
        izquierdo = null;
        derecho = null;
    }
}