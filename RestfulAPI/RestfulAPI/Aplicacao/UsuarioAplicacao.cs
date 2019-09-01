using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestfulAPI.Models;

namespace RestfulAPI.Aplicacao
{
    public class UsuarioAplicacao
    {
        private ApiContext _contexto;

        public UsuarioAplicacao(ApiContext contexto)
        {
            _contexto = contexto;
        }

        public string InsertUser(Usuarios usuario)
        {
            try
            {
                if (usuario != null)
                {
                    var usuarioExiste = GetUserByEmail(usuario.Email);

                    if (usuarioExiste == null)
                    {
                        _contexto.Add(usuario);
                        _contexto.SaveChanges();

                        return "Usuário cadastrado com sucesso!";
                    }
                    else
                    {
                        return "Email já cadastrado na base de dados.";
                    }
                }
                else
                {
                    return "Usuário inválido!";
                }
            }
            catch (Exception)
            {
                return "Não foi possível se comunicar com a base de dados!";
            }
        }


        public string UpdateUser(Usuarios usuario)
        {
            try
            {
                if (usuario != null)
                {
                    _contexto.Update(usuario);
                    _contexto.SaveChanges();

                    return "Usuário alterado com sucesso!";
                }
                else
                {
                    return "Usuário inválido!";
                }
            }
            catch (Exception)
            {
                return "Não foi possível se comunicar com a base de dados!";
            }
        }

        public Usuarios GetUserByEmail(string email)
        {
            Usuarios primeiroUsuario = new Usuarios();

            try
            {
                if (email == string.Empty)
                {
                    return null;
                }

                var cliente = _contexto.Usuarios.Where(x => x.Email == email).ToList();
                primeiroUsuario = cliente.FirstOrDefault();

                if (primeiroUsuario != null)
                {
                    return primeiroUsuario;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Usuarios> GetAllUsers()
        {
            List<Usuarios> listaDeUsuarios = new List<Usuarios>();
            try
            {

                listaDeUsuarios = _contexto.Usuarios.Select(x => x).ToList();

                if (listaDeUsuarios != null)
                {
                    return listaDeUsuarios;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public string DeleteUserByEmail(string email)
        {
            try
            {
                if (email == string.Empty)
                {
                    return "Email inválido! Por favor tente novamente.";
                }
                else
                {
                    var usuario = GetUserByEmail(email);

                    if (usuario != null)
                    {
                        _contexto.Usuarios.Remove(usuario);
                        _contexto.SaveChanges();

                        return "Usuário " + usuario.Nome + " deletado com sucesso!";
                    }
                    else
                    {
                        return "Usuário não cadastrado!";
                    }
                }
            }
            catch (Exception)
            {
                return "Não foi possível se comunicar com a base de dados!";
            }
        }
    }
}
