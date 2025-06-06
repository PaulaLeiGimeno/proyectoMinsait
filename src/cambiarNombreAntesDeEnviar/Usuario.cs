using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cambiarNombreAntesDeEnviar
{
    internal class Usuario
    {
        private string nombre;
        private string email;
        private string contraseña;
        private List<Evento> eventosApuntados;



        public Usuario(string nombre, string email, string contraseña)
        {
            Nombre = nombre;
            Email = email;
            Contraseña = contraseña;
            EventosApuntados = new List<Evento>();
        }

        public string Nombre { set { nombre = value; } get { return nombre; } }
        public string Email { set { email = value; } get { return email; } }
        public string Contraseña { set { contraseña = value; } get { return contraseña; } }
        public List<Evento> EventosApuntados { set { eventosApuntados = value; } get { return eventosApuntados; } }

        public static Usuario RegistrarUsuario(string nombre, string email, string contraseña)
        {
            return new Usuario(nombre, email, contraseña);
        }

        public static void CancelarUsuario(List<Usuario> usuarios, Usuario usuario)
        {
            foreach (var evento in usuario.EventosApuntados)
            {
                evento.Usuarios.Remove(usuario);
            }
            usuarios.Remove(usuario);
        }

    }
}
