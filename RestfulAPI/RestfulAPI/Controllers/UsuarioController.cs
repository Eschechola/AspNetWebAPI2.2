using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestfulAPI.Models;

namespace RestfulAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioContext _contexto;

        public UsuarioController(UsuarioContext contexto)
        {
            _contexto = contexto;
        }

        public IActionResult Index()
        {
            var usuario = new Usuarios()
            {
                Nome = "Lucas",
                Email = "lucas@eu.com",
                Senha = "eschechola123"
            };

            _contexto.Add(usuario);
            _contexto.SaveChanges();

            return Ok("Index API - medium.com/@lucas.eschechola");
        }
    }
}