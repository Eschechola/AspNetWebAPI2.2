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
        private readonly ApiContext _contexto;

        public UsuarioController(ApiContext contexto)
        {
            _contexto = contexto;
        }

        public IActionResult Index()
        {
            return Ok("Index API - medium.com/@lucas.eschechola");
        }
    }
}