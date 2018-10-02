using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebApiSwagger.v1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {

        /// <summary>
        /// Teste de método que não é apresentado no Swagger.
        /// </summary>
        /// <returns>Lista de valores</returns>
        [HttpGet("/teste")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public ActionResult<IEnumerable<string>> NaoMostrarNoSwagger()
        {
            return new string[] { "value1", "value2" };
        }

        /// <summary>
        /// Obter todos os valores. Projeto padrão.
        /// </summary>
        /// <returns>Lista de valores</returns>
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }
        
        /// <summary>
        /// Obter valor por Id
        /// </summary>
        /// <param name="id">Identificador do Método GET</param>
        /// <param name="testeParametroNulo"><b>Apenas</b> um parâmetro de teste...</param>
        /// <returns>Valor</returns>
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id, int? testeParametroNulo)
        {
            return "value";
        }

        /// <summary>
        /// Salvar
        /// </summary>
        /// <param name="value">Valor</param>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        /// <summary>
        /// Atualizar
        /// </summary>
        /// <param name="id">Identificador</param>
        /// <param name="value">Valor</param>
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        /// <summary>
        /// Excluir
        /// </summary>
        /// <param name="id">Identificador</param>
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
