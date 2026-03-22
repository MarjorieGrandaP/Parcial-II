// Archivo:     Program.cs
// Descripción: Punto de entrada principal del programa.
//              Su única responsabilidad es iniciar el menú.
//              Toda la lógica está delegada a las otras clases.
//
// Estructura del proyecto:
//   ├── Nodo.cs          → Define la estructura de cada nodo
//   ├── ArbolBST.cs      → Lógica del árbol (insertar, buscar, etc.)
//   ├── Menu.cs          → Interfaz de usuario en consola
//   └── Program.cs       → Punto de entrada (este archivo)

using System;

namespace SistemaBST
{
    /// Clase principal del programa.
    /// Sigue el principio de responsabilidad única (SRP):
    /// solo inicia la aplicación y delega todo lo demás al Menú.
    class Program
    {
        /// Método Main: primer método que ejecuta C# al iniciar.
        static void Main(string[] args)
        {
            // Configuración de la consola para soporte de caracteres especiales
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.Title = "Árbol Binario de Búsqueda (BST)";

            // Creamos el menú y lo iniciamos
            // El menú mantendrá el control hasta que el usuario elija salir
            Menu menu = new Menu();
            menu.Iniciar();
        }
    }
}