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
    public class TarefaController : ControllerBase
    {
        private TarefaDAO tarefaData = new TarefaDAO();

        public ActionResult<IEnumerable<Tarefa>> Get()
        {
           
            return tarefaData.ListarTodos();
        }

        [HttpGet("{id}")]
        public ActionResult<Tarefa> Get(int id)
        {
            return tarefaData.RecuperarPorId(id);
        }

        [HttpPost]
        public void Post([FromBody] Tarefa model)
        {
            if (model != null)
            {
                tarefaData.Insert(model);
            }
        }

    }
}