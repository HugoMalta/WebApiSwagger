using LiteDB;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WebApiSwagger.Model.Model
{
    public class Pessoa
    {
        [Required]
        [Key]
        [Display(Name = "Código")]
        [BsonId(true)]
        public int Codigo { get; set; }

        [Required(ErrorMessage = "Sujeito sem nome não existe!")]
        //[MinLength(5, ErrorMessage = "O tamanho mínimo do nome são 5 caracteres.")]
        [StringLength(20, ErrorMessage = "Este campo aceita entre 5 e 20 caracteres.", MinimumLength = 5)]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Data de Nascimento")]
        public DateTime DataNascimento { get; set; }

        [Display(Name = "CPF ou RG")]
        public string Documento { get; set; }
    }

    /*

        using (var db = new LiteDatabase(@"MyData.db"))
                {
                    // Get customer collection
                    var pessoas = db.GetCollection<Pessoa>("pessoas");

                    // Create your new customer instance
                    var pessoa = new Pessoa
                    {
                        Nome = "John Doe",
                        DataNascimento = DateTime.Now.AddYears(-18)
                    };

                    // Insert new customer document (Id will be auto-incremented)
                    pessoas.Insert(pessoa);

                    // Update a document inside a collection
                    pessoa.Nome = "Joana Doe";

                    pessoas.Update(pessoa);

                    // Index document using a document property
                    pessoas.EnsureIndex(x => x.Nome);

                    // Use Linq to query documents
                    var results = pessoas.Find(x => x.Nome.StartsWith("Jo"));
                }
         */
}
