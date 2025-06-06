using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cambiarNombreAntesDeEnviar
{
    internal class Organizadores
    {
        private string nombre;
        private string tlfn;
        private string email;
        private List<Evento> eventosOrganizados;

        public Organizadores(string nombre, string tlfn, string email)
        {
           Nombre = nombre;
            Tlfn = tlfn;
            Email = email;
           EventosOrganizados = new List<Evento>();
        }
        public string Nombre { set { nombre = value; } get { return nombre; } }
        public string Tlfn { set { tlfn = value; } get { return tlfn; } }
        public string Email { set { email = value; } get { return email; } }
        public List<Evento> EventosOrganizados { set { eventosOrganizados = value; } get { return eventosOrganizados; } }
        public static Organizadores RegistrarOrganizador(string nombre, string tlfn, string email)
        {
            return new Organizadores(nombre, tlfn, email);
        }

        public static void EliminarOrganizador(List<Organizadores> organizadores, Organizadores organizador)
        {
            organizadores.Remove(organizador);
        }
        public void AñadirEvento(Evento evento)
        {
            EventosOrganizados.Add(evento);
        }

        public void EliminarEvento(Evento evento)
        {
            EventosOrganizados.Remove(evento);
        }

        public void OrganizarEvento(List<Usuario> usuarios)
        {
            Console.WriteLine("== ORGANIZAR UN EVENTO ==\n");

            Console.Write("Introduzca el nombre del evento: ");
            string nombre = Console.ReadLine();

            Console.Write("Introduzca la duración (en horas): ");
            double duracion = Convert.ToDouble(Console.ReadLine());

            Console.Write("Introduzca la fecha del evento (formato: yyyy-MM-dd): ");
            DateTime fecha = Convert.ToDateTime(Console.ReadLine());


            Console.Write("Introduzca la hora del evento (formato: HH:mm): ");
            TimeSpan hora = TimeSpan.Parse(Console.ReadLine());


            Console.Write("Introduzca el lugar del evento: ");
            string lugar = Console.ReadLine();

            Evento evento = new Evento(nombre, duracion, fecha, hora, lugar, usuarios);
            Console.WriteLine("Evento organizado con éxito.");
            eventosOrganizados.Add(evento);
        }

    }
}
