using System;
using System.Collections.Generic;
using System.Linq;

namespace BibliotecaApp // Puedes cambiar el nombre del espacio de nombres según tu proyecto
{
    public class Biblioteca // Clase para representar la biblioteca
    {
        private Dictionary<string, Libro> libros; //    

        public Biblioteca() // Constructor para inicializar la colección de libros
        {
            // Inicializa el diccionario de libros
            libros = new Dictionary<string, Libro>();
        }

        // Agregar un libro
        public bool AgregarLibro(Libro libro)
        {
            // Verifica si el libro ya existe por su ISBN antes de agregarlo
            if (!libros.ContainsKey(libro.ISBN))
            {
                // Agrega el libro al diccionario usando su ISBN como clave
                libros.Add(libro.ISBN, libro);
                return true; // Retorna true si el libro se agregó exitosamente
            }
            return false;
        }

        // Consultar un libro por ISBN
        public Libro ConsultarPorISBN(string isbn)
        {
            // Intenta obtener el libro del diccionario usando el ISBN como clave
            libros.TryGetValue(isbn, out Libro libro);
            return libro;
        }

        // Listar todos los libros
        public void ListarTodos() // Método para listar todos los libros en la biblioteca
        {
            // Verifica si hay libros registrados antes de intentar listarlos
            if (libros.Count == 0)
            {
                // Si no hay libros, muestra un mensaje indicando que no hay registros
                Console.WriteLine("No hay libros registrados.");
                return;
            }

            foreach (var libro in libros.Values) // Itera sobre los valores del diccionario (los libros) y los muestra en la consola
            {
                // Muestra la información de cada libro utilizando el método ToString sobrescrito en la clase Libro
                Console.WriteLine(libro);
            }
        }

        // Obtener autores únicos (operación de conjunto)
        public void ListarAutoresUnicos()
        {
            // Utiliza LINQ para seleccionar los autores de los libros y un HashSet para obtener solo los autores únicos
            var autores = new HashSet<string>(libros.Values.Select(l => l.Autor));
            Console.WriteLine("Autores únicos:"); // Muestra los autores únicos utilizando un HashSet para evitar duplicados
            foreach (var autor in autores)
            { 
                // Muestra cada autor único en la consola
                Console.WriteLine(autor);
            }
        }

        // Filtrar libros por género
        public void FiltrarPorGenero(string genero)
        {
            // Utiliza LINQ para filtrar los libros por género, ignorando mayúsculas y minúsculas, y convierte el resultado a una lista
            var filtrados = libros.Values.Where(l => l.Genero.Equals(genero, StringComparison.OrdinalIgnoreCase)).ToList();
            if (filtrados.Count == 0) // Verifica si no se encontraron libros del género especificado antes de intentar listarlos
            {
                // Si no se encontraron libros del género especificado, muestra un mensaje indicando que no hay resultados
                Console.WriteLine($"No hay libros del género: {genero}");
                return;
            }
// Si se encontraron libros del género especificado, muestra un mensaje indicando el género y luego lista los libros filtrados utilizando el método ToString sobrescrito en la clase Libro
            Console.WriteLine($"Libros del género {genero}:");
            foreach (var libro in filtrados)
            {
                // Muestra la información de cada libro filtrado utilizando el método ToString sobrescrito en la clase Libro
                Console.WriteLine(libro);
            }
        }
    }
}