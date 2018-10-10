using LiteDB;
using System;
using System.Collections.Generic;
using System.Text;
using WebApiSwagger.Model.Interface;
using WebApiSwagger.Model.Model;

namespace WebApiSwagger.Repositorio
{
    public class PessoaRepositorio: IPessoa
    {
        public IEnumerable<Pessoa> Get()
        {
            try
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
            catch (Exception)
            {
                throw;
            }
        }
        public Pessoa Get(int id)
        {
            try
            {
                using (var db = new LiteDatabase(@"MyData.db"))
                {
                    // Get customer collection
                    var pessoas = db.GetCollection<Pessoa>("pessoas");

                    // Use Linq to query documents
                    var results = pessoas.FindById(id);

                    return results;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public Pessoa Post(Pessoa _pessoa)
        {
            if (_pessoa == null)
            {
                throw new ArgumentNullException(nameof(_pessoa));
            }
            try
            {
                using (var db = new LiteDatabase(@"MyData.db"))
                {
                    var pessoas = db.GetCollection<Pessoa>("pessoas");
                    var itemIncluido = pessoas.Insert(_pessoa);

                    return null;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool Put(int id, Pessoa _pessoa)
        {
            try
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

                    return pessoas.Update(pessoa);
                }

            }
            catch (Exception)
            {
                throw;
            }
        }
        public int Delete(int id)
        {
            try
            {
                using (var db = new LiteDatabase(@"MyData.db"))
                {
                    // Get customer collection
                    var pessoas = db.GetCollection<Pessoa>("pessoas");

                    return pessoas.Delete(x => x.Codigo == id);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
