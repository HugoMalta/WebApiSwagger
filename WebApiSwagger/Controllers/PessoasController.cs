using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using LiteDB;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using WebApiSwagger.Model.Model;
using WebApiSwagger.Negocio;
using WebApiSwagger.Utils;

namespace WebApiSwagger.v1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoasController : ControllerBase
    {
        /// <summary>
        /// Listar todas as pessoas
        /// </summary>
        /// <returns>Lista de Pessoas</returns>
        [HttpGet]
        [SwaggerResponse(200)]
        public IEnumerable<Pessoa> Get()
        {
            try
            {
                using (var pessoaNegocio = new PessoaNegocio())
                {
                    return pessoaNegocio.Get();
                }
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        /// <summary>
        /// Selecionar Pessoa por identificador
        /// </summary>
        /// <param name="id">Identificador da pessoa</param>
        /// <returns>Objeto Pessoa</returns>
        [HttpGet("{id}", Name = "Get")]
        [SwaggerResponse(200)]
        public Pessoa Get(int id)
        {
            try
            {
                using (var pessoaNegocio = new PessoaNegocio())
                {
                    return pessoaNegocio.Get(id);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Incluir Pessoa
        /// </summary>
        /// <param name="_pessoa">Objeto de Pessoa</param>
        /// <returns>Resultado da ação - status code</returns>
        [SwaggerResponse(200)]
        [SwaggerResponse(400)]
        [HttpPost]
        public ActionResult Post([FromBody] Pessoa _pessoa)
        {
            using (var pessoaNegocio = new PessoaNegocio())
            {
                Pessoa pessoaInserida = pessoaNegocio.Post(_pessoa);
                if(pessoaInserida != null && pessoaInserida.Codigo > 0)
                {
                    return Ok();
                }
            }
            return BadRequest();
        }

        /// <summary>
        /// Atualizar pessoa
        /// </summary>
        /// <param name="id">Identificador da Pessoa</param>
        /// <param name="_pessoa">Objeto pessoa</param>
        /// <returns>Resultado da ação - status code</returns>
        [HttpPut("{id}")]
        [SwaggerResponse(200)]
        [SwaggerResponse(400)]
        public ActionResult Put(int id, [FromBody] Pessoa _pessoa)
        {
            using (var pessoaNegocio = new PessoaNegocio())
            {
                bool alterou = pessoaNegocio.Put(id, _pessoa);
                if (alterou == true)
                {
                    return Ok();
                }
            }
            return BadRequest();
        }

        /// <summary>
        /// Excluir Pessoa
        /// </summary>
        /// <param name="id">Identificador da Pessoa</param>
        /// <returns>Resultado da ação - status code</returns>
        [HttpDelete("{id}")]
        [SwaggerResponse(200)]
        [SwaggerResponse(400, Type=typeof(Pessoa))]
        public ActionResult Delete(int id)
        {
            using (var pessoaNegocio = new PessoaNegocio())
            {
                int numRegistrosAlterados = pessoaNegocio.Delete(id);
                if (numRegistrosAlterados > 0)
                {
                    return Ok();
                }
            }
            return BadRequest();
        }

    }
}
