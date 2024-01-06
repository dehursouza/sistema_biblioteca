using System.Linq;
using System.Collections.Generic;
using System.Collections;

namespace Biblioteca.Models
{
    public class UsuarioService
    {
        public List<Usuario> Listar()
        {
            using (BibliotecaContext bc = new BibliotecaContext())
            {
                return bc.Usuarios.ToList();
            }
        }
        public Usuario Listar(int id)
        {
            using (BibliotecaContext bc = new BibliotecaContext())
            {
                return bc.Usuarios.Find(id);
            }
        }
        public void incluirUsuario(Usuario novoUser)
        {
            using (BibliotecaContext bc = new BibliotecaContext())
            {
                bc.Usuarios.Add(novoUser);
                bc.SaveChanges();
            }
        }
        public void editarUsuario(Usuario userEditado)
        {
            using (BibliotecaContext bc = new BibliotecaContext())
            {
                Usuario u = bc.Usuarios.Find(userEditado.Id);

                u.Login = userEditado.Login;
                u.Nome = userEditado.Nome;
                u.Senha = userEditado.Senha;
                u.Tipo = userEditado.Tipo;

                bc.SaveChanges();
            }
        }
        public void excluirUsuario(int id)
        {
            using (BibliotecaContext bc = new BibliotecaContext())
            {
                bc.Usuarios.Remove(bc.Usuarios.Find(id));
                bc.SaveChanges();
            }
        }



        /*
        public void Inserir(Usuario U)
        {
            using (BibliotecaContext bc = new BibliotecaContext())
            {
                bc.Usuarios.Add(U);
                bc.SaveChanges();
            }
        }

        public void Atualizar(Usuario U)
        {
            using (BibliotecaContext bc = new BibliotecaContext())
            {
                Usuario Usuario = bc.Usuarios.Find(U.Id);
                Usuario.Senha = U.Senha;
                Usuario.Login = U.Login;
                Usuario.Nome = U.Nome;

                bc.SaveChanges();
            }
        }

        public ICollection<Usuario> ListarTodos(FiltrosUsuarios filtro = null)
        {
            using (BibliotecaContext bc = new BibliotecaContext())
            {
                IQueryable<Usuario> query;

                if (filtro != null)
                {
                    //definindo dinamicamente a filtragem
                    switch (filtro.TipoFiltro)
                    {
                        case "Senha":
                            query = bc.Usuarios.Where(U => U.Senha.Contains(filtro.Filtro));
                            break;

                        case "Login":
                            query = bc.Usuarios.Where(U => U.Login.Contains(filtro.Filtro));
                            break;

                        default:
                            query = bc.Usuarios;
                            break;
                    }
                }
                else
                {
                    // caso filtro não tenha sido informado
                    query = bc.Usuarios;
                }

                //ordenação padrão
                return query.OrderBy(U => U.Login).ToList();
            }
        }


        public Usuario ObterPorId(int id)
        {
            using (BibliotecaContext bc = new BibliotecaContext())
            {
                return bc.Usuarios.Find(id);
            }
        }
        */
    }
}