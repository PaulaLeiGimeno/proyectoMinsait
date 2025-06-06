using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Xml.Linq;


namespace cambiarNombreAntesDeEnviar
{
    internal class Evento
    {
        private string nombre;
        private int id;
        private double duracion;
        private DateTime fecha;
        private TimeSpan hora;
        private string lugar;
        private List<Usuario> usuarios;


        public string Nombre { set { nombre = value; } get { return nombre; } }
        public int Id { set { id = value; } get { return id; } }
        public double Duracion { set { duracion = value; } get { return duracion; } }
        public DateTime Fecha { set { fecha = value; } get { return fecha; } }
        public TimeSpan Hora { set { hora = value; } get { return hora; } }
        public string Lugar { set { lugar = value; } get { return lugar; } }
        public List<Usuario> Usuarios { set { usuarios = value; } get { return usuarios; } }



        public Evento(string nombre, double duracion, DateTime fecha, TimeSpan hora, string lugar, List<Usuario> usuarios)
        {
            Nombre = nombre;
            Duracion = duracion;
            Fecha = fecha;
            Hora = hora;
            Lugar = lugar;
            Usuarios = usuarios;
        }
        public virtual void RegistrarUsuario(Usuario usuario)
        {
            Usuarios.Add(usuario);
        }
        public void ModificarEvento()
        {
            Console.WriteLine("Introduce el nuevo nombre del evento:");
            Nombre = Console.ReadLine();

            Console.WriteLine("Introduce la nueva duración en horas:");
            Duracion = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Introduce la nueva fecha (formato: yyyy-MM-dd):");
            Fecha = Convert.ToDateTime(Console.ReadLine());

            Console.WriteLine("Introduce la nueva hora (formato: HH:mm):");
            Hora = TimeSpan.Parse(Console.ReadLine());

            Console.WriteLine("Introduce el nuevo lugar:");
            Lugar = Console.ReadLine();

            Console.WriteLine("Evento modificado con éxito.");
        }
        public override string ToString()
        {
            return $"Nombre: {Nombre}, Duración: {Duracion}h, Fecha: {Fecha.ToShortDateString()}, Hora: {Hora}, Lugar: {Lugar}";
        }



        public void EliminarUsuario(Usuario usuario)
        {
            if (Usuarios.Contains(usuario))
            {
                Usuarios.Remove(usuario);
            }
        }


    }
}

