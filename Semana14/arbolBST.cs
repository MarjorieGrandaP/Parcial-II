// Archivo:     ArbolBST.cs
// Descripción: Implementa el Árbol Binario de Búsqueda (BST) con
//              todas sus operaciones principales:
//              - Insertar, Buscar, Eliminar nodos.
//              - Recorridos: Preorden, Inorden, Postorden.
//              - Obtener mínimo, máximo y altura del árbol.
//              - Limpiar el árbol completo.

using System;
using System.Collections.Generic;

namespace SistemaBST
{
    /// Clase que representa el Árbol Binario de Búsqueda (BST).
    /// 
    /// Regla fundamental del BST:
    ///   - Los valores MENORES al nodo actual van al subárbol IZQUIERDO.
    ///   - Los valores MAYORES al nodo actual van al subárbol DERECHO.
    ///   - No se permiten valores duplicados.
    public class ArbolBST
    {
        // ATRIBUTO PRIVADO: RAÍZ DEL ÁRBOL
        // La raíz es el punto de entrada a toda la estructura.
        // Es privada para proteger la integridad del árbol.

        /// Nodo raíz del árbol. Es null cuando el árbol está vacío.
        private Nodo raiz;

        // CONSTRUCTOR

        /// Inicializa un árbol BST vacío (sin ningún nodo).
        public ArbolBST()
        {
            raiz = null; // El árbol comienza vacío
        }

    
        // SECCIÓN 1: INSERTAR

        /// Inserta un nuevo valor en el árbol BST.
        /// Si el valor ya existe, no se inserta (no se permiten duplicados).
        /// <param name="valor">Valor entero a insertar.</param>
        public void Insertar(int valor)
        {
            // Llamamos al método recursivo privado para insertar
            raiz = InsertarRecursivo(raiz, valor);
        }

        /// Método privado recursivo que recorre el árbol para encontrar
        /// la posición correcta donde insertar el nuevo valor.
        /// <param name="nodoActual">Nodo que se evalúa en esta iteración.</param>
        /// <param name="valor">Valor a insertar.</param>
        /// <returns>El nodo actualizado (con el nuevo hijo si aplica).</returns>
        private Nodo InsertarRecursivo(Nodo nodoActual, int valor)
        {
            // CASO BASE: Si llegamos a un lugar vacío (null), creamos el nodo aquí
            if (nodoActual == null)
                return new Nodo(valor);

            // Comparamos el valor con el nodo actual para decidir hacia dónde bajar
            if (valor < nodoActual.Valor)
            {
                // El valor es MENOR → va al subárbol IZQUIERDO
                nodoActual.HijoIzquierdo = InsertarRecursivo(nodoActual.HijoIzquierdo, valor);
            }
            else if (valor > nodoActual.Valor)
            {
                // El valor es MAYOR → va al subárbol DERECHO
                nodoActual.HijoDerecho = InsertarRecursivo(nodoActual.HijoDerecho, valor);
            }
            // Si valor == nodoActual.Valor → es duplicado, no hacemos nada

            // Retornamos el nodo actual (sin cambios si era duplicado)
            return nodoActual;
        }

        // SECCIÓN 2: BUSCAR

        /// Busca un valor en el árbol BST.
        /// <param name="valor">Valor a buscar.</param>
        /// <returns>True si el valor existe, False si no se encontró.</returns>
        public bool Buscar(int valor)
        {
            return BuscarRecursivo(raiz, valor);
        }

        /// Método privado recursivo que recorre el árbol buscando el valor.
        /// Gracias a la propiedad del BST, descarta la mitad del árbol en cada paso.
        /// <param name="nodoActual">Nodo evaluado en esta iteración.</param>
        /// <param name="valor">Valor a buscar.</param>
        /// <returns>True si fue encontrado, False si no.</returns>
        private bool BuscarRecursivo(Nodo nodoActual, int valor)
        {
            // CASO BASE 1: Llegamos a null → el valor no existe en el árbol
            if (nodoActual == null)
                return false;

            // CASO BASE 2: Encontramos el valor → retornamos true
            if (valor == nodoActual.Valor)
                return true;

            // Decidimos en qué subárbol seguir buscando
            if (valor < nodoActual.Valor)
                return BuscarRecursivo(nodoActual.HijoIzquierdo, valor);  // Buscar a la izquierda
            else
                return BuscarRecursivo(nodoActual.HijoDerecho, valor);    // Buscar a la derecha
        }

        // SECCIÓN 3: ELIMINAR

        /// Elimina un valor del árbol BST.
        /// Maneja los 3 casos posibles:
        ///   1) El nodo es hoja (sin hijos).
        ///   2) El nodo tiene solo un hijo.
        ///   3) El nodo tiene dos hijos (se reemplaza con el sucesor inorden).
        /// <param name="valor">Valor a eliminar.</param>
        public void Eliminar(int valor)
        {
            raiz = EliminarRecursivo(raiz, valor);
        }

        /// Método privado recursivo para eliminar un nodo del árbol.
        /// <param name="nodoActual">Nodo evaluado en esta iteración.</param>
        /// <param name="valor">Valor a eliminar.</param>
        /// <returns>El nodo actualizado tras la eliminación.</returns>
        private Nodo EliminarRecursivo(Nodo nodoActual, int valor)
        {
            // CASO BASE: El valor no existe en el árbol
            if (nodoActual == null)
                return null;

            if (valor < nodoActual.Valor)
            {
                // El valor a eliminar está en el subárbol IZQUIERDO
                nodoActual.HijoIzquierdo = EliminarRecursivo(nodoActual.HijoIzquierdo, valor);
            }
            else if (valor > nodoActual.Valor)
            {
                // El valor a eliminar está en el subárbol DERECHO
                nodoActual.HijoDerecho = EliminarRecursivo(nodoActual.HijoDerecho, valor);
            }
            else
            {
                // ¡ENCONTRAMOS el nodo a eliminar! Manejamos los 3 casos:

                // CASO 1: Nodo hoja (sin hijos) → simplemente lo eliminamos
                if (nodoActual.HijoIzquierdo == null && nodoActual.HijoDerecho == null)
                    return null;

                // CASO 2a: Solo tiene hijo DERECHO → lo reemplazamos con ese hijo
                if (nodoActual.HijoIzquierdo == null)
                    return nodoActual.HijoDerecho;

                // CASO 2b: Solo tiene hijo IZQUIERDO → lo reemplazamos con ese hijo
                if (nodoActual.HijoDerecho == null)
                    return nodoActual.HijoIzquierdo;

                // CASO 3: Tiene DOS hijos
                // Encontramos el SUCESOR INORDEN (el menor valor del subárbol derecho)
                // y reemplazamos el valor del nodo actual con él
                int sucesor = ObtenerMinimo(nodoActual.HijoDerecho);
                nodoActual.Valor = sucesor;

                // Luego eliminamos el sucesor del subárbol derecho
                nodoActual.HijoDerecho = EliminarRecursivo(nodoActual.HijoDerecho, sucesor);
            }

            return nodoActual;
        }

        // SECCIÓN 4: RECORRIDOS DEL ÁRBOL

        // 4.1 RECORRIDO INORDEN (Izquierdo → Raíz → Derecho)
        // Resultado: valores en orden ASCENDENTE

        /// Recorre el árbol en Inorden y devuelve los valores en orden ascendente.
        /// Orden: Subárbol Izquierdo → Nodo Actual → Subárbol Derecho
        /// <returns>Lista de enteros en orden ascendente.</returns>
        public List<int> RecorridoInorden()
        {
            List<int> resultado = new List<int>();
            InordenRecursivo(raiz, resultado);
            return resultado;
        }

        private void InordenRecursivo(Nodo nodo, List<int> resultado)
        {
            if (nodo == null) return;              // Caso base: nodo vacío
            InordenRecursivo(nodo.HijoIzquierdo, resultado); // 1. Ir a la izquierda
            resultado.Add(nodo.Valor);                        // 2. Procesar nodo actual
            InordenRecursivo(nodo.HijoDerecho, resultado);    // 3. Ir a la derecha
        }

        // 4.2 RECORRIDO PREORDEN (Raíz → Izquierdo → Derecho)

        /// Recorre el árbol en Preorden.
        /// Orden: Nodo Actual → Subárbol Izquierdo → Subárbol Derecho
        /// Útil para copiar o serializar la estructura del árbol.
        /// <returns>Lista de enteros en orden preorden.</returns>
        public List<int> RecorridoPreorden()
        {
            List<int> resultado = new List<int>();
            PreordenRecursivo(raiz, resultado);
            return resultado;
        }

        private void PreordenRecursivo(Nodo nodo, List<int> resultado)
        {
            if (nodo == null) return;               // Caso base: nodo vacío
            resultado.Add(nodo.Valor);                         // 1. Procesar nodo actual
            PreordenRecursivo(nodo.HijoIzquierdo, resultado);  // 2. Ir a la izquierda
            PreordenRecursivo(nodo.HijoDerecho, resultado);     // 3. Ir a la derecha
        }

        // 4.3 RECORRIDO POSTORDEN (Izquierdo → Derecho → Raíz)

        /// Recorre el árbol en Postorden.
        /// Orden: Subárbol Izquierdo → Subárbol Derecho → Nodo Actual
        /// Útil para eliminar el árbol o evaluar expresiones.
        /// <returns>Lista de enteros en orden postorden.</returns>
        public List<int> RecorridoPostorden()
        {
            List<int> resultado = new List<int>();
            PostordenRecursivo(raiz, resultado);
            return resultado;
        }

        private void PostordenRecursivo(Nodo nodo, List<int> resultado)
        {
            if (nodo == null) return;                // Caso base: nodo vacío
            PostordenRecursivo(nodo.HijoIzquierdo, resultado);  // 1. Ir a la izquierda
            PostordenRecursivo(nodo.HijoDerecho, resultado);     // 2. Ir a la derecha
            resultado.Add(nodo.Valor);                           // 3. Procesar nodo actual
        }

        // SECCIÓN 5: MÍNIMO, MÁXIMO Y ALTURA

        /// Obtiene el valor MÍNIMO del árbol (nodo más a la izquierda).
        /// Lanza una excepción si el árbol está vacío.
        /// <returns>El valor mínimo del árbol.</returns>
        public int ObtenerMinimo()
        {
            if (raiz == null)
                throw new InvalidOperationException("El árbol está vacío.");
            return ObtenerMinimo(raiz);
        }

        /// Método privado recursivo: baja siempre por la izquierda hasta
        /// encontrar el nodo más profundo a la izquierda (el mínimo).
        private int ObtenerMinimo(Nodo nodo)
        {
            // Si no tiene hijo izquierdo, este ES el mínimo
            if (nodo.HijoIzquierdo == null)
                return nodo.Valor;

            // Seguimos bajando por la izquierda
            return ObtenerMinimo(nodo.HijoIzquierdo);
        }

        /// Obtiene el valor MÁXIMO del árbol (nodo más a la derecha).
        /// Lanza una excepción si el árbol está vacío.
        /// <returns>El valor máximo del árbol.</returns>
        public int ObtenerMaximo()
        {
            if (raiz == null)
                throw new InvalidOperationException("El árbol está vacío.");
            return ObtenerMaximo(raiz);
        }

        /// Método privado recursivo: baja siempre por la derecha hasta
        /// encontrar el nodo más profundo a la derecha (el máximo).
        private int ObtenerMaximo(Nodo nodo)
        {
            // Si no tiene hijo derecho, este ES el máximo
            if (nodo.HijoDerecho == null)
                return nodo.Valor;

            // Seguimos bajando por la derecha
            return ObtenerMaximo(nodo.HijoDerecho);
        }

        /// Calcula la ALTURA del árbol (número de niveles).
        /// Un árbol vacío tiene altura 0.
        /// Un árbol con solo la raíz tiene altura 1.
        /// <returns>La altura del árbol como entero.</returns>
        public int ObtenerAltura()
        {
            return CalcularAltura(raiz);
        }

        /// Método privado recursivo que calcula la altura del árbol.
        /// La altura es el mayor número de aristas desde la raíz hasta una hoja.
        private int CalcularAltura(Nodo nodo)
        {
            // CASO BASE: nodo vacío → altura 0
            if (nodo == null) return 0;

            // Calculamos la altura de cada subárbol recursivamente
            int alturaIzquierda = CalcularAltura(nodo.HijoIzquierdo);
            int alturaDerecha   = CalcularAltura(nodo.HijoDerecho);

            // La altura del nodo actual es 1 + la mayor altura de sus subárboles
            return 1 + Math.Max(alturaIzquierda, alturaDerecha);
        }

        // SECCIÓN 6: LIMPIAR Y ESTADO DEL ÁRBOL
        /// Elimina TODOS los nodos del árbol, dejándolo vacío.
        /// Al poner la raíz en null, el recolector de basura de C#
        /// liberará automáticamente la memoria de todos los nodos.
        public void Limpiar()
        {
            raiz = null; // Al eliminar la referencia raíz, se libera todo el árbol
        }

        /// Indica si el árbol está vacío (sin ningún nodo).
        /// <returns>True si está vacío, False si tiene al menos un nodo.</returns>
        public bool EstaVacio()
        {
            return raiz == null;
        }
    }
}