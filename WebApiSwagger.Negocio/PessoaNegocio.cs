using System;
using System.Collections.Generic;
using System.Text;
using WebApiSwagger.Model.Interface;
using WebApiSwagger.Model.Model;
using WebApiSwagger.Repositorio;

namespace WebApiSwagger.Negocio
{
    public class PessoaNegocio: IDisposable,  IPessoa
    {
        public IPessoa _pessoaRepositorio { get; set; }

        public PessoaNegocio()
        {
            _pessoaRepositorio = new PessoaRepositorio();
        }
        public void Dispose()
        {
        }
        public IEnumerable<Pessoa> Get()
        {
            try
            {
                return _pessoaRepositorio.Get();
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
                return _pessoaRepositorio.Get(id);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public Pessoa Post(Pessoa _pessoa)
        {  
            try
            {
                return _pessoaRepositorio.Post(_pessoa);
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
                return _pessoaRepositorio.Put(id, _pessoa);
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
                return _pessoaRepositorio.Delete(id);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void Disposible()
        {
        }
    }
}
