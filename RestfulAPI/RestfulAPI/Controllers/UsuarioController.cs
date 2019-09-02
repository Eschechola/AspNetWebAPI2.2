using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestfulAPI.Aplicacao;
using RestfulAPI.Models;

namespace RestfulAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        //variavel de contexto para acesso as utilidades do entity
        private ApiContext _contexto;

        public UsuarioController(ApiContext contexto)
        {
            _contexto = contexto;
        }

        public IActionResult Index()
        {
            return Ok("Index API - medium.com/@lucas.eschechola");
        }

        [HttpPost]
        [Route("InsertUser")]
        [Authorize]
        public IActionResult InsertUser([FromBody]Usuarios usuarioEnviado)
        {
            try
            {
                if (!ModelState.IsValid || usuarioEnviado == null)
                {
                    return BadRequest("Dados inválidos! Tente novamente.");
                }
                else
                {
                    var resposta = new UsuarioAplicacao(_contexto).InsertUser(usuarioEnviado);
                    return Ok(resposta);
                }
            }
            catch (Exception)
            {
                return BadRequest("Erro ao comunicar com a base de dados!");
            }
        }

        [HttpPut]
        [Route("UpdateUser")]
        [Authorize]
        public IActionResult UpdateUser([FromBody]Usuarios usuarioEnviado)
        {
            try
            {
                if (!ModelState.IsValid || usuarioEnviado == null)
                {
                    return BadRequest("Dados inválidos! Tente novamente.");
                }
                else
                {
                    var resposta = new UsuarioAplicacao(_contexto).UpdateUser(usuarioEnviado);
                    return Ok(resposta);
                }
            }
            catch (Exception)
            {
                return BadRequest("Erro ao comunicar com a base de dados!");
            }
        }

        [HttpPost]
        [Route("GetUserByEmail")]
        [Authorize]
        public IActionResult GetClienteByEmail([FromBody]string email)
        {
            try
            {
                if (email == string.Empty)
                {
                    return BadRequest("Email inválido! Tente novamente.");
                }
                else
                {
                    var resposta = new UsuarioAplicacao(_contexto).GetUserByEmail(email);

                    if (resposta != null)
                    {
                        var usuarioResposta = JsonConvert.SerializeObject(resposta);
                        return Ok(usuarioResposta);
                    }
                    else
                    {
                        return BadRequest("Usuário não cadastrado!");
                    }
                }
            }
            catch (Exception)
            {
                return BadRequest("Erro ao comunicar com a base de dados!");
            }
        }

        [HttpGet]
        [Route("GetAllUsers")]
        [Authorize]
        public IActionResult GetAllClientes()
        {
            try
            {
                var listaDeUsuarios = new UsuarioAplicacao(_contexto).GetAllUsers();

                if (listaDeUsuarios != null)
                {
                    var resposta = JsonConvert.SerializeObject(listaDeUsuarios);
                    return Ok(resposta);
                }
                else
                {
                    return BadRequest("Nenhum usuário cadastrado!");
                }
            }
            catch (Exception)
            {
                return BadRequest("Erro ao comunicar com a base de dados!");
            }
        }

        [HttpDelete]
        [Route("DeleteUserByEmail")]
        [Authorize]
        public IActionResult DeleteUserByEmail([FromBody]string email)
        {
            try
            {
                if (email == string.Empty)
                {
                    return BadRequest("Email inválido! Tente novamente.");
                }
                else
                {
                    var resposta = new UsuarioAplicacao(_contexto).DeleteUserByEmail(email);
                    return Ok(resposta);
                }
            }
            catch (Exception)
            {
                return BadRequest("Erro ao comunicar com a base de dados!");
            }
        }
    }
}