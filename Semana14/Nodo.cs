// Archivo:     Nodo.cs
// Descripción: Define la estructura de un nodo individual dentro
//              del Árbol Binario de Búsqueda (BST).
//              Cada nodo almacena un valor entero y referencias
//              a sus hijos izquierdo y derecho.

namespace SistemaBST
{
    /// Representa un nodo dentro del Árbol Binario de Búsqueda.
    /// Cada nodo contiene:
    ///   - Un valor entero (dato almacenado).
    ///   - Una referencia al hijo izquierdo (valores menores).
    ///   - Una referencia al hijo derecho (valores mayores).
    public class Nodo
    {
        // PROPIEDADES DEL NODO

        /// Valor entero almacenado en este nodo.
        public int Valor { get; set; }

        /// Referencia al nodo hijo izquierdo.
        /// Contiene valores MENORES que el nodo actual.
        /// Es null si no tiene hijo izquierdo.
        public Nodo HijoIzquierdo { get; set; }

        /// Referencia al nodo hijo derecho.
        /// Contiene valores MAYORES que el nodo actual.
        /// Es null si no tiene hijo derecho.
        public Nodo HijoDerecho { get; set; }

        /// Crea un nuevo nodo con el valor indicado.
        /// Por defecto, los hijos izquierdo y derecho son null,
        /// lo que indica que es un nodo hoja (sin descendientes).
        /// <param name="valor">Valor entero que almacenará el nodo.</param>
        public Nodo(int valor)
        {
            Valor          = valor;
            HijoIzquierdo  = null; // Sin hijo izquierdo al crearse
            HijoDerecho    = null; // Sin hijo derecho al crearse
        }
    }
}