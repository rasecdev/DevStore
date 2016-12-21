using DevStore.Domain;
using DevStore.Infra.Mappings;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevStore.Infra.DataContexts
{
    public class DevStoreDataContext : DbContext
    {
        //Informar a ConnectionString
        public DevStoreDataContext() : base("DevStoreConnectionString")
        {
            //Instancia um ojeto do DevStoreDataContextInicializer para fazer a inicialização da base do projeto.
            //Desabilitar para gerar o banco.
            //Database.SetInitializer<DevStoreDataContext>(new DevStoreDataContextInicializer());

            //Modifica o carregamento em demanda e não recupera a Category altomaticamente. 
            //Para incluir é feita uma configuração no controller.
            Configuration.LazyLoadingEnabled = false;
        }

        //Usando a Interface IDbSet para não ocorrer erro na criação do controller no Web Api.
        public IDbSet<Product> Products { get; set; }

        public IDbSet<Category> Categories { get; set; }

        //Método para inicializar na creação das tabelas as configurações dos mapeamentos.
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Inicializa as configurações do mapeamento da categoria.
            modelBuilder.Configurations.Add(new CategoryMap());

            //Inicializa as configurações do mapeamento do produto.
            modelBuilder.Configurations.Add(new ProductMap());

            base.OnModelCreating(modelBuilder);
        }

    }    
}
