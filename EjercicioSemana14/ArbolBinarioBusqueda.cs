using System;

// Clase que contiene toda la lógica del árbol binario de búsqueda
public class ArbolBinarioBusqueda
{
    // Nodo raíz del árbol
    private Nodo raiz;

    // Constructor: inicia el árbol vacío
    public ArbolBinarioBusqueda()
    {
        raiz = null;
    }

    // ==============================
    // INSERTAR
    // ==============================
    // Método público que inicia la inserción
    public void Insertar(int valor)
    {
        raiz = InsertarRec(raiz, valor);
    }

    // Método recursivo para ubicar correctamente el valor
    private Nodo InsertarRec(Nodo actual, int valor)
    {
        // Si encontramos un espacio vacío, creamos el nodo
        if (actual == null)
            return new Nodo(valor);

        // Si el valor es menor, va a la izquierda
        if (valor < actual.valor)
            actual.izquierdo = InsertarRec(actual.izquierdo, valor);

        // Si es mayor, va a la derecha
        else if (valor > actual.valor)
            actual.derecho = InsertarRec(actual.derecho, valor);

        // Si es igual, no se inserta (evitamos duplicados)
        else
            Console.WriteLine("El valor ya existe en el árbol.");

        return actual;
    }

    // ==============================
    // BUSCAR
    // ==============================
    // Devuelve true si el valor existe en el árbol
    public bool Buscar(int valor)
    {
        return BuscarRec(raiz, valor) != null;
    }

    // Búsqueda recursiva
    private Nodo BuscarRec(Nodo actual, int valor)
    {
        // Si llegamos a null o encontramos el valor, retornamos
        if (actual == null || actual.valor == valor)
            return actual;

        // Si el valor es menor, buscamos a la izquierda
        if (valor < actual.valor)
            return BuscarRec(actual.izquierdo, valor);

        // Caso contrario, buscamos a la derecha
        return BuscarRec(actual.derecho, valor);
    }

    // ==============================
    // ELIMINAR (MEJORADO)
    // ==============================
    public bool Eliminar(int valor)
    {
        // Verificamos si el valor existe
        if (!Buscar(valor))
            return false;

        // Si existe, se elimina
        raiz = EliminarRec(raiz, valor);
        return true;
    }

    // Método recursivo de eliminación
    private Nodo EliminarRec(Nodo actual, int valor)
    {
        if (actual == null) return actual;

        // Buscar el nodo
        if (valor < actual.valor)
            actual.izquierdo = EliminarRec(actual.izquierdo, valor);

        else if (valor > actual.valor)
            actual.derecho = EliminarRec(actual.derecho, valor);

        else
        {
            // === CASO 1: Sin hijo izquierdo ===
            if (actual.izquierdo == null)
                return actual.derecho;

            // === CASO 2: Sin hijo derecho ===
            if (actual.derecho == null)
                return actual.izquierdo;

            // === CASO 3: Dos hijos ===
            int sucesor = EncontrarMinimo(actual.derecho);
            actual.valor = sucesor;
            actual.derecho = EliminarRec(actual.derecho, sucesor);
        }

        return actual;
    }

    // ==============================
    // MÍNIMO Y MÁXIMO
    // ==============================
    public int ObtenerMinimo()
    {
        return EncontrarMinimo(raiz);
    }

    private int EncontrarMinimo(Nodo nodo)
    {
        while (nodo.izquierdo != null)
            nodo = nodo.izquierdo;

        return nodo.valor;
    }

    public int ObtenerMaximo()
    {
        Nodo temp = raiz;

        while (temp.derecho != null)
            temp = temp.derecho;

        return temp.valor;
    }

    // ==============================
    // ALTURA DEL ÁRBOL
    // ==============================
    public int Altura()
    {
        return CalcularAltura(raiz);
    }

    private int CalcularAltura(Nodo nodo)
    {
        if (nodo == null)
            return 0;

        int izq = CalcularAltura(nodo.izquierdo);
        int der = CalcularAltura(nodo.derecho);

        return Math.Max(izq, der) + 1;
    }

    // ==============================
    // RECORRIDOS
    // ==============================
    public void MostrarRecorridos()
    {
        if (raiz == null)
        {
            Console.WriteLine("El árbol está vacío.");
            return;
        }

        Console.Write("Preorden: ");
        Preorden(raiz);
        Console.WriteLine();

        Console.Write("Inorden: ");
        Inorden(raiz);
        Console.WriteLine();

        Console.Write("Postorden: ");
        Postorden(raiz);
        Console.WriteLine();
    }

    private void Preorden(Nodo nodo)
    {
        if (nodo != null)
        {
            Console.Write(nodo.valor + " ");
            Preorden(nodo.izquierdo);
            Preorden(nodo.derecho);
        }
    }

    private void Inorden(Nodo nodo)
    {
        if (nodo != null)
        {
            Inorden(nodo.izquierdo);
            Console.Write(nodo.valor + " ");
            Inorden(nodo.derecho);
        }
    }

    private void Postorden(Nodo nodo)
    {
        if (nodo != null)
        {
            Postorden(nodo.izquierdo);
            Postorden(nodo.derecho);
            Console.Write(nodo.valor + " ");
        }
    }

    // ==============================
    // LIMPIAR
    // ==============================
    public void Limpiar()
    {
        raiz = null;
        Console.WriteLine("Árbol limpiado.");
    }

    public bool EstaVacio()
    {
        return raiz == null;
    }
}