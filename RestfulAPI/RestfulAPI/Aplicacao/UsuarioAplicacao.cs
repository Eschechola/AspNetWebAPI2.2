using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestfulAPI.Models;

namespace RestfulAPI.Aplicacao
{
    public class UsuarioAplicacao
    {
        private readonly ApiContext _contexto;

        public UsuarioAplicacao(ApiContext contexto)
        {
            _contexto = contexto;
        }

        public string InsertUser(Usuarios usuario)
        {
            try
            {
                if(usuario != null)
                {
                    _contexto.Add(usuario);
                    _contexto.SaveChanges();

                    return "Usuário cadastrado com sucesso!";
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
    }
}
