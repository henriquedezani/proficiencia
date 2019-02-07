using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proficiencia.Application.DAO;
using Proficiencia.Application.Models;

namespace Proficiencia.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private UsuarioDAO usuarioData = new UsuarioDAO();

        public ActionResult<IEnumerable<Usuario>> Get()
        {
            try
            {
                return usuarioData.ListarTodos();
            }
            catch (Exception)
            {
                throw;
            }            
        }

        [HttpGet("{id}")]
        public ActionResult<Usuario> Get(int id)
        {
            return usuarioData.RecuperarPorId(id);            
        }

        [HttpPost]
        public ActionResult<Usuario> Post([FromBody] Usuario model)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var usuario = usuarioData.Insert(model);
            
            return CreatedAtAction("Get", new { id = usuario.Id });
        }

    }
}