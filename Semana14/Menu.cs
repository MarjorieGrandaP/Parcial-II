// Archivo:     Menu.cs
// Descripción: Gestiona toda la interfaz de usuario en consola.
//              Muestra el menú interactivo y procesa las opciones
//              del usuario, comunicándose con la clase ArbolBST.

using System;
using System.Collections.Generic;

namespace SistemaBST
{
    /// Clase encargada de mostrar el menú interactivo y
    /// gestionar la comunicación entre el usuario y el árbol BST.
    /// Separa la lógica de presentación de la lógica de datos.
    public class Menu
    {

        // ATRIBUTO PRIVADO
        // Una única instancia del árbol BST que se usará en todo
        // el ciclo de vida del menú.

        /// <summary>Instancia del Árbol Binario de Búsqueda.</summary>
        private ArbolBST arbol;

        // CONSTRUCTOR

        /// Inicializa el menú creando un árbol BST vacío.
        public Menu()
        {
            arbol = new ArbolBST(); // Creamos el árbol al iniciar el menú
        }

        // MÉTODO PRINCIPAL: INICIAR

        /// Inicia el bucle principal del menú.
        /// Continúa mostrando opciones hasta que el usuario elija salir.
        public void Iniciar()
        {
            bool ejecutando = true; // Controla el bucle principal del menú

            while (ejecutando)
            {
                MostrarEncabezado();       // Muestra el título y el menú
                int opcion = LeerOpcion(); // Lee y valida la opción del usuario

                // Ejecutamos la acción correspondiente a la opción elegida
                switch (opcion)
                {
                    case 1: OpcionInsertar();         break;
                    case 2: OpcionBuscar();            break;
                    case 3: OpcionEliminar();          break;
                    case 4: OpcionMostrarRecorridos(); break;
                    case 5: OpcionEstadisticas();      break;
                    case 6: OpcionLimpiar();           break;
                    case 7:
                        ejecutando = false; // Terminamos el bucle
                        MostrarMensaje("¡Hasta luego! Programa finalizado.", ConsoleColor.Cyan);
                        break;
                    default:
                        MostrarMensaje("Opción inválida. Por favor elige entre 1 y 7.", ConsoleColor.Red);
                        break;
                }

                // Pausa para que el usuario pueda leer el resultado antes de continuar
                if (ejecutando)
                {
                    Console.WriteLine("\nPresiona cualquier tecla para continuar...");
                    Console.ReadKey();
                }
            }
        }

        // SECCIÓN: OPCIONES DEL MENÚ
        // Cada método maneja una opción específica del menú.

        /// Opción 1: Solicita un valor al usuario y lo inserta en el árbol.
        private void OpcionInsertar()
        {
            Console.WriteLine("\n--- INSERTAR VALOR ---");
            Console.Write("Ingresa el valor a insertar: ");

            // Intentamos convertir la entrada a entero
            if (int.TryParse(Console.ReadLine(), out int valor))
            {
                arbol.Insertar(valor);
                MostrarMensaje($"✓ Valor {valor} insertado correctamente.", ConsoleColor.Green);
            }
            else
            {
                MostrarMensaje("✗ Entrada inválida. Debes ingresar un número entero.", ConsoleColor.Red);
            }
        }

        /// Opción 2: Busca un valor en el árbol e informa si existe.
        private void OpcionBuscar()
        {
            Console.WriteLine("\n--- BUSCAR VALOR ---");

            // Verificamos primero que el árbol no esté vacío
            if (arbol.EstaVacio())
            {
                MostrarMensaje("✗ El árbol está vacío. No hay valores que buscar.", ConsoleColor.Yellow);
                return;
            }

            Console.Write("Ingresa el valor a buscar: ");

            if (int.TryParse(Console.ReadLine(), out int valor))
            {
                bool encontrado = arbol.Buscar(valor);

                if (encontrado)
                    MostrarMensaje($"✓ El valor {valor} SÍ existe en el árbol.", ConsoleColor.Green);
                else
                    MostrarMensaje($"✗ El valor {valor} NO existe en el árbol.", ConsoleColor.Yellow);
            }
            else
            {
                MostrarMensaje("✗ Entrada inválida. Debes ingresar un número entero.", ConsoleColor.Red);
            }
        }

        /// Opción 3: Elimina un valor del árbol si existe.
        private void OpcionEliminar()
        {
            Console.WriteLine("\n--- ELIMINAR VALOR ---");

            if (arbol.EstaVacio())
            {
                MostrarMensaje("✗ El árbol está vacío. No hay valores que eliminar.", ConsoleColor.Yellow);
                return;
            }

            Console.Write("Ingresa el valor a eliminar: ");

            if (int.TryParse(Console.ReadLine(), out int valor))
            {
                // Verificamos si el valor existe antes de intentar eliminarlo
                if (arbol.Buscar(valor))
                {
                    arbol.Eliminar(valor);
                    MostrarMensaje($"✓ Valor {valor} eliminado correctamente.", ConsoleColor.Green);
                }
                else
                {
                    MostrarMensaje($"✗ El valor {valor} no existe en el árbol.", ConsoleColor.Yellow);
                }
            }
            else
            {
                MostrarMensaje("✗ Entrada inválida. Debes ingresar un número entero.", ConsoleColor.Red);
            }
        }

        /// Opción 4: Muestra los tres recorridos del árbol (Preorden, Inorden, Postorden).
        private void OpcionMostrarRecorridos()
        {
            Console.WriteLine("\n--- RECORRIDOS DEL ÁRBOL ---");

            if (arbol.EstaVacio())
            {
                MostrarMensaje("✗ El árbol está vacío. Inserta valores primero.", ConsoleColor.Yellow);
                return;
            }

            // Obtenemos las listas de cada recorrido
            List<int> preorden   = arbol.RecorridoPreorden();
            List<int> inorden    = arbol.RecorridoInorden();
            List<int> postorden  = arbol.RecorridoPostorden();

            // Mostramos cada recorrido formateado
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("  Preorden  (Raíz→Izq→Der): ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(string.Join(" → ", preorden));

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("  Inorden   (Izq→Raíz→Der): ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(string.Join(" → ", inorden));

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("  Postorden (Izq→Der→Raíz): ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(string.Join(" → ", postorden));

            Console.ResetColor();

            // Nota explicativa del recorrido inorden
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("\n  💡 El Inorden muestra los valores en orden ascendente.");
            Console.ResetColor();
        }

        /// Opción 5: Muestra el mínimo, máximo y altura del árbol.
        private void OpcionEstadisticas()
        {
            Console.WriteLine("\n--- ESTADÍSTICAS DEL ÁRBOL ---");

            if (arbol.EstaVacio())
            {
                MostrarMensaje("✗ El árbol está vacío. Inserta valores primero.", ConsoleColor.Yellow);
                return;
            }

            // Obtenemos los datos del árbol y los mostramos con formato
            int minimo  = arbol.ObtenerMinimo();
            int maximo  = arbol.ObtenerMaximo();
            int altura  = arbol.ObtenerAltura();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"  Valor mínimo : {minimo}");
            Console.WriteLine($"  Valor máximo : {maximo}");
            Console.WriteLine($"  Altura       : {altura} nivel(es)");
            Console.ResetColor();
        }

        /// Opción 6: Limpia completamente el árbol, eliminando todos los nodos.
        /// Pide confirmación al usuario antes de proceder.
        private void OpcionLimpiar()
        {
            Console.WriteLine("\n--- LIMPIAR ÁRBOL ---");

            if (arbol.EstaVacio())
            {
                MostrarMensaje("✗ El árbol ya está vacío.", ConsoleColor.Yellow);
                return;
            }

            // Pedimos confirmación para evitar borrados accidentales
            Console.Write("¿Estás seguro de que deseas eliminar todos los nodos? (s/n): ");
            string confirmacion = Console.ReadLine()?.Trim().ToLower();

            if (confirmacion == "s")
            {
                arbol.Limpiar();
                MostrarMensaje("✓ Árbol limpiado. Todos los nodos han sido eliminados.", ConsoleColor.Green);
            }
            else
            {
                MostrarMensaje("Operación cancelada.", ConsoleColor.Yellow);
            }
        }

        // SECCIÓN: MÉTODOS AUXILIARES DE INTERFAZ

        /// Muestra el encabezado principal y las opciones del menú.
        private void MostrarEncabezado()
        {
            Console.Clear(); // Limpiamos la pantalla en cada iteración
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("╔══════════════════════════════════════════╗");
            Console.WriteLine("║     ÁRBOL BINARIO DE BÚSQUEDA (BST)      ║");
            Console.WriteLine("╚══════════════════════════════════════════╝");
            Console.ResetColor();

            // Indicador de estado del árbol
            Console.ForegroundColor = arbol.EstaVacio() ? ConsoleColor.Yellow : ConsoleColor.Green;
            Console.WriteLine(arbol.EstaVacio()
                ? "  Estado: Árbol vacío"
                : $"  Estado: Árbol con elementos (Altura: {arbol.ObtenerAltura()})");
            Console.ResetColor();

            Console.WriteLine();
            Console.WriteLine("  [1] Insertar valor");
            Console.WriteLine("  [2] Buscar valor");
            Console.WriteLine("  [3] Eliminar valor");
            Console.WriteLine("  [4] Mostrar recorridos (Preorden / Inorden / Postorden)");
            Console.WriteLine("  [5] Ver mínimo, máximo y altura");
            Console.WriteLine("  [6] Limpiar árbol");
            Console.WriteLine("  [7] Salir");
            Console.WriteLine();
            Console.Write("  Elige una opción: ");
        }

        /// Lee la opción ingresada por el usuario y la valida como entero.
        /// <returns>La opción elegida como entero, o -1 si es inválida.</returns>
        private int LeerOpcion()
        {
            string entrada = Console.ReadLine();
            Console.WriteLine(); // Línea en blanco para mejorar legibilidad

            // Intentamos convertir la entrada a entero
            if (int.TryParse(entrada, out int opcion))
                return opcion;

            return -1; // Retornamos -1 si la entrada no es un número válido
        }

        /// Muestra un mensaje en consola con el color especificado.
        /// Restablece el color al terminar para no afectar el resto de la UI.
        /// <param name="mensaje">Texto a mostrar.</param>
        /// <param name="color">Color del texto.</param>
        private void MostrarMensaje(string mensaje, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine($"  {mensaje}");
            Console.ResetColor();
        }
    }
}