using System;

namespace BibliotecaApp
{
    class Program // Clase principal del programa
    {
        static void Main(string[] args) // Método principal donde se ejecuta el programa
        {
            // Crea una instancia de la clase Biblioteca para gestionar los libros
            Biblioteca biblioteca = new Biblioteca();
// Variable para controlar el ciclo del menú
            bool salir = false;

            while (!salir) // Bucle para mostrar el menú hasta que el usuario decida salir
            {
                Console.WriteLine("\n     MENÚ DE LA BIBLIOTECA");
                Console.WriteLine("1. Agregar libro");
                Console.WriteLine("2. Consultar libro por ISBN");
                Console.WriteLine("3. Listar todos los libros");
                Console.WriteLine("4. Listar autores únicos");
                Console.WriteLine("5. Filtrar libros por género");
                Console.WriteLine("6. Salir");
                Console.Write("Seleccione una opción: ");

                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    // Caso para agregar un libro a la biblioteca, solicita al usuario ingresar los detalles del libro y luego intenta agregarlo utilizando el método AgregarLibro de la clase Biblioteca
                    case "1":
                        Console.Write("Ingrese ISBN: ");
                        string isbn = Console.ReadLine();
                        Console.Write("Ingrese título: ");
                        string titulo = Console.ReadLine();
                        Console.Write("Ingrese autor: ");
                        string autor = Console.ReadLine();
                        Console.Write("Ingrese género: ");
                        string genero = Console.ReadLine();
                        Console.Write("Ingrese año: ");
                        int año = int.Parse(Console.ReadLine());
// Crea una nueva instancia de la clase Libro con los detalles ingresados por el usuario y luego intenta agregarlo a la biblioteca utilizando el método AgregarLibro, mostrando un mensaje indicando si el libro se agregó correctamente o si ya existe
                        Libro libro = new Libro(isbn, titulo, autor, genero, año);
                        if (biblioteca.AgregarLibro(libro))
                            Console.WriteLine("Libro agregado correctamente.");
                        else
                            Console.WriteLine("El libro ya existe.");
                        break;
// Caso para consultar un libro por su ISBN, solicita al usuario ingresar el ISBN del libro que desea consultar y luego utiliza el método ConsultarPorISBN de la clase Biblioteca para obtener el libro, mostrando su información si se encuentra o un mensaje indicando que no se encontró
                    case "2":
                        Console.Write("Ingrese ISBN: ");
                        isbn = Console.ReadLine();
                        libro = biblioteca.ConsultarPorISBN(isbn);
                        if (libro != null)
                            Console.WriteLine(libro);
                        else
                            Console.WriteLine("Libro no encontrado.");
                        break;
// Caso para listar todos los libros registrados en la biblioteca, utiliza el método ListarTodos de la clase Biblioteca para mostrar la información de cada libro registrado
                    case "3":
                        biblioteca.ListarTodos();
                        break;
// Caso para listar los autores únicos de los libros registrados en la biblioteca, utiliza el método ListarAutoresUnicos de la clase Biblioteca para mostrar una lista de autores sin duplicados
                    case "4":
                        biblioteca.ListarAutoresUnicos();
                        break;
// Caso para filtrar los libros por género, solicita al usuario ingresar el género que desea filtrar y luego utiliza el método FiltrarPorGenero de la clase Biblioteca para mostrar los libros que coinciden con el género especificado, o un mensaje indicando que no se encontraron libros de ese género
                    case "5":
                        Console.Write("Ingrese género: ");
                        genero = Console.ReadLine();
                        biblioteca.FiltrarPorGenero(genero);
                        break;
// Caso para salir del programa, establece la variable salir en true para terminar el bucle del menú y muestra un mensaje indicando que se está saliendo del programa
                    case "6":
                        salir = true;
                        Console.WriteLine("Saliendo del programa...");
                        break;
// Caso por defecto para manejar opciones inválidas, muestra un mensaje indicando que la opción seleccionada no es válida y solicita al usuario que intente nuevamente
                    default:
                        Console.WriteLine("Opción inválida. Intente nuevamente.");
                        break;
                }
            }
        }
    }
}