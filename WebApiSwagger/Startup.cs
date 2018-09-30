using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;

namespace WebApiSwagger.v1
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            //ativa o serviço de documentação do swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new Info
                    {
                        Title = "Teste Documentação de Api Usando Swagger, Swashbuckle",
                        Version = "v1",
                        Description = @" <b>O que temos implementado:</b>
    - API Rest  usando ASP.Net Core 2.1
    - LiteDB para persistência - Este é um banco de dados NoSql local, ou seja, não é necessário instalar nada no computador que está hospedando aplicação. 
    - Swagger-Swashbuckle para documentação de APIs
    - A documentação gerada pelo Visual Studio através do ""Comentários em XML"" foi adicionada automaticamente à documentação Swagger.
    - 

<b>Pacotes Nuget instalados:</b>
    - Install-Package Swashbuckle.AspNetCore
    - Install-Package LiteDB

<b>Observações relativas à implementação: </b>
    - [BsonId(true)] define a property como chave primária
    - c.IncludeXmlComments(xmlPath) - define que os 'Comentários XML' da aplicação serão incluidas no Swagger gerado.
    - [ApiExplorerSettings(IgnoreApi = true)] - remove o método do Swagger


<b>Próximos Passos:</b>
    - Documentar possíveis responses diretamente no código para ser exibido no Swagger
    - Gerar json ao compilar aplicação
    - ? ",
                        Contact = new Contact
                        {
                            Name = "Estudo ou compro uma bicicleta?",
                            Url = "https://www.tudogostoso.com.br/receita/146529-bolo-sorvete.html"
                        }
                    });
                //Obtem o xml da documentação adicionada no código e vincula ao swagger.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //permite que o swagger seja utilizado na api.
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Primeira versão da API!!!!");
            });

            app.UseMvc();
        }
    }
}
