using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cambiarNombreAntesDeEnviar
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Usuario> usuarios = new List<Usuario>();
            List<Organizadores> organizadores = new List<Organizadores>();
            List<Evento> eventos = new List<Evento>();

            bool salir = false;

            while (!salir)
            {
                Console.WriteLine("\n==== MENÚ PRINCIPAL ====");
                Console.WriteLine("1. Registrar Usuario");
                Console.WriteLine("2. Registrar Organizador");
                Console.WriteLine("3. Organizar Evento");
                Console.WriteLine("4. Modificar Evento");
                Console.WriteLine("5. Mostrar Eventos");
                Console.WriteLine("6. Salir");
                Console.Write("Selecciona una opción: ");

                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        Console.Write("Nombre del usuario: ");
                        string nombreUsuario = Console.ReadLine();
                        Console.Write("Email del usuario: ");
                        string emailUsuario = Console.ReadLine();
                        Console.Write("Contraseña del usuario: ");
                        string contraseñaUsuario = Console.ReadLine();

                        Usuario nuevoUsuario = Usuario.RegistrarUsuario(nombreUsuario, emailUsuario, contraseñaUsuario);
                        usuarios.Add(nuevoUsuario);
                        Console.WriteLine("Usuario registrado con éxito.");
                        break;

                    case "2":
                        Console.Write("Nombre del organizador: ");
                        string nombreOrg = Console.ReadLine();
                        Console.Write("Teléfono del organizador: ");
                        string tlfnOrg = Console.ReadLine();
                        Console.Write("Email del organizador: ");
                        string emailOrg = Console.ReadLine();

                        Organizadores nuevoOrg = Organizadores.RegistrarOrganizador(nombreOrg, tlfnOrg, emailOrg);
                        organizadores.Add(nuevoOrg);
                        Console.WriteLine("Organizador registrado con éxito.");
                        break;

                    case "3":
                        if (organizadores.Count == 0)
                        {
                            Console.WriteLine("No hay organizadores registrados.");
                            break;
                        }

                        Console.WriteLine("Organizadores disponibles:");
                        for (int i = 0; i < organizadores.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. {organizadores[i].Nombre}");
                        }

                        Console.Write("Seleccione un organizador por número: ");
                        int indexOrg;
                        if (int.TryParse(Console.ReadLine(), out indexOrg) && indexOrg > 0 && indexOrg <= organizadores.Count)
                        {
                            organizadores[indexOrg - 1].OrganizarEvento(usuarios);
                            eventos.AddRange(organizadores[indexOrg - 1].EventosOrganizados);
                        }
                        else
                        {
                            Console.WriteLine("Opción no válida.");
                        }
                        break;

                    case "4":
                        if (eventos.Count == 0)
                        {
                            Console.WriteLine("No hay eventos disponibles para modificar.");
                            break;
                        }

                        Console.WriteLine("Eventos disponibles:");
                        for (int i = 0; i < eventos.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. {eventos[i].Nombre}");
                        }

                        Console.Write("Seleccione un evento por número para modificar: ");
                        int indexEvento;
                        if (int.TryParse(Console.ReadLine(), out indexEvento) && indexEvento > 0 && indexEvento <= eventos.Count)
                        {
                            eventos[indexEvento - 1].ModificarEvento(); // ← Usamos la versión sugerida anteriormente
                        }
                        else
                        {
                            Console.WriteLine("Selección no válida.");
                        }
                        break;

                    case "5":
                        if (eventos.Count == 0)
                        {
                            Console.WriteLine("No hay eventos registrados.");
                        }
                        else
                        {
                            Console.WriteLine("=== Lista de Eventos ===");
                            foreach (var evt in eventos)
                            {
                                Console.WriteLine(evt);
                            }
                        }
                        break;

                    case "6":
                        salir = true;
                        Console.WriteLine("Saliendo del programa...");
                        break;

                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }
                Console.Clear();
            }
        }
    }
}
