using DevStore.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevStore.Infra.Mappings
{
    public class CategoryMap : EntityTypeConfiguration<Category>
    {
        public CategoryMap()
        {
            //Inforam qual será o nome da tabela.
            ToTable("Category");

            //Informa qual será a chave primária.
            HasKey(x => x.Id);

            //Informa as características para a propriedade Title, tem no máximo 60 caracteres e é obrigatória.
            //Acima de 60 caracteres dará erro.
            Property(x => x.Title).HasMaxLength(60).IsRequired();

        }
    }
}
