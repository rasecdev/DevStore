using DevStore.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevStore.Infra.Mappings
{
    public class ProductMap : EntityTypeConfiguration<Product>
    {
        public ProductMap()
        {
            //Inforam qual será o nome da tabela.
            ToTable("Product");

            //Informa qual será a chave primária.
            HasKey(x => x.Id);

            //Informa as características para as propriedades, tem no máximo 160 caracteres e é obrigatória.            
            Property(x => x.Title).HasMaxLength(160).IsRequired();

            Property(x => x.Price).IsRequired();

            Property(x => x.AcquireDate).IsRequired();

            //Informa qual propriedade é obrigatória.
            HasRequired(x => x.Category);
        }
    }
}
