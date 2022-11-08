using System.Collections.Generic;
using System.Linq;

namespace Biblioteca.Models
{
    public class UsuarioService
    {
        public void Inserir(Usuario user)
        {
            using(BibliotecaContext bc = new BibliotecaContext())
            {
                Usuario usuario = new Usuario();
                usuario.Login = user.Login;
                usuario.Password = Criptografia.HashPassword(user.Password);
                bc.Usuarios.Add(usuario);
                bc.SaveChanges();
            }
        }

        public void Atualizar(Usuario user)
        {
            using(BibliotecaContext bc = new BibliotecaContext())
            {
                Usuario usuario = bc.Usuarios.Find(user.Id);
                if(usuario != null)
                {
                usuario.Login = user.Login;
                usuario.Password = user.Password;
                bc.SaveChanges();
                }
            }
        }

        public void Deletar(int id)
        {
            using(BibliotecaContext bc = new BibliotecaContext())
            {
                Usuario usuario = bc.Usuarios.Find(id);
                bc.Usuarios.Remove(usuario);
                bc.SaveChanges();
            }
        }

        public ICollection<Usuario> Listar()
        {
            using(BibliotecaContext bc = new BibliotecaContext())
            {
             ICollection<Usuario> consulta = bc.Usuarios.ToList();

                return consulta;
            }
        }

        public Usuario DetalhesExcluir(int id)
  {
      using (BibliotecaContext bc = new BibliotecaContext())
      {
          Usuario usuarios = bc.Usuarios.Where(p => p.Id == id).SingleOrDefault();
          return usuarios;
      }
  }
    }
}