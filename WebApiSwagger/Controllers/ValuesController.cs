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
        /// Primeiro Get
        /// </summary>
        /// <returns></returns>
        [HttpGet("/teste")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public ActionResult<IEnumerable<string>> NaoMostrarNoSwagger()
        {
            return new string[] { "value1", "value2" };
        }

        /// <summary>
        /// Primeiro Get
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }
        

        /*///// <summary>
        ///// Segundo Get com parâmetro
        ///// </summary>
        ///// <param name="id">Id de entrada</param>
        ///// <param name="id">Id de entrada</param>
        ///// <returns>Retorno Xpto</returns>*/
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">Identificador do Método GET</param>
        /// <param name="testeParametroNulo"><b>Apenas</b> um parâmetro de teste...</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id, int? testeParametroNulo)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
