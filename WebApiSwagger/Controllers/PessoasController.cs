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
        [SwaggerResponse((int)HttpStatusCode.OK)]
        [SwaggerResponse(210)]
        [SwaggerOperationFilter(typeof(int))]
        [SwaggerResponse(401)]
        public IEnumerable<Pessoa> Get()
        {
            using (var db = new LiteDatabase(@"MyData.db"))
            {
                // Get customer collection
                var pessoas = db.GetCollection<Pessoa>("pessoas");

                // Use Linq to query documents
                var results = pessoas.FindAll();

                return results;
            }
        }


        /// <summary>
        /// Selecionar Pessoa por identificador
        /// </summary>
        /// <param name="id">Identificador da pessoa</param>
        /// <returns>Objeto Pessoa</returns>
        [HttpGet("{id}", Name = "Get")]
        public Pessoa Get(int id)
        {
            /// asdfasdf
            /// sdfasdf
            /// asdf
            /// asdf
            /// asdf
            /// 


            using (var db = new LiteDatabase(@"MyData.db"))
            {
                // Get customer collection
                var pessoas = db.GetCollection<Pessoa>("pessoas");

                // Use Linq to query documents
                var results = pessoas.FindById(id);

                return results;
            }
        }

        /// <summary>
        /// Incluir Pessoa
        /// </summary>
        /// <param name="_pessoa">Objeto de Pessoa</param>
        /// <returns>Retorna lista de pessoas!</returns>
        [SwaggerResponse(500)]
        [SwaggerResponse(200)]
        [SwaggerResponse(400)]
        [HttpPost]
        public IEnumerable<Pessoa> Post([FromBody] Pessoa _pessoa)
        {
            using (var db = new LiteDatabase(@"MyData.db"))
            {
                // Get customer collection
                var pessoas = db.GetCollection<Pessoa>("pessoas");
                pessoas.Insert(_pessoa);
                return null;
            }

        }

        /// <summary>
        /// Atualizar pessoa
        /// </summary>
        /// <param name="id">Identificador da Pessoa</param>
        /// <param name="_pessoa">Objeto pessoa</param>
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Pessoa _pessoa)
        {
            using (var db = new LiteDatabase(@"MyData.db"))
            {
                // Get customer collection
                var pessoas = db.GetCollection<Pessoa>("pessoas");

                // Use Linq to query documents
                var pessoa = pessoas.FindById(id);

                pessoa.DataNascimento = _pessoa.DataNascimento;
                pessoa.Documento = _pessoa.Documento;
                pessoa.Nome = _pessoa.Nome;

                pessoas.Update(pessoa);
            }
        }

        /// <summary>
        /// Excluir Pessoa
        /// </summary>
        /// <param name="id">Identificador da Pessoa</param>
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            using (var db = new LiteDatabase(@"MyData.db"))
            {
                // Get customer collection
                var pessoas = db.GetCollection<Pessoa>("pessoas");

                pessoas.Delete(x => x.Codigo == id);
            }
        }

    }
}
