using System; // using System.Collections.Generic; // No es necesario en este caso

namespace BibliotecaApp // Puedes cambiar el nombre del espacio de nombres según tu proyecto
{
    public class Libro // Clase para representar un libro
    {
        public string ISBN { get; set; } //public string Titulo { get; set; }
        public string Titulo { get; set; } //public string Autor { get; set; }
        public string Autor { get; set; } //public string Genero { get; set; }
        public string Genero { get; set; } //public int Año { get; set; }
        public int Año { get; set; } // Constructor para inicializar las propiedades del libro

// Constructor para inicializar las propiedades del libro
        public Libro(string isbn, string titulo, string autor, string genero, int año)
        {
            ISBN = isbn;
            Titulo = titulo;
            Autor = autor;
            Genero = genero;
            Año = año;
        }
// Sobrescribir el método ToString para mostrar la información del libro de manera legible
        public override string ToString() // Sobrescribir el método ToString para mostrar la información del libro de manera legible
        {
            // Devuelve una cadena con la información del libro
            return $"ISBN: {ISBN} | Título: {Titulo} | Autor: {Autor} | Género: {Genero} | Año: {Año}";
        }
    }
}