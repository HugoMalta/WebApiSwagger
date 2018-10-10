using System;
using System.Collections.Generic;
using System.Text;
using WebApiSwagger.Model.Model;

namespace WebApiSwagger.Model.Interface
{
    public interface IPessoa
    {
        IEnumerable<Pessoa> Get();
        Pessoa Get(int id);
        Pessoa Post(Pessoa _pessoa);
        bool Put(int id, Pessoa _pessoa);
        int Delete(int id);
    }
}
