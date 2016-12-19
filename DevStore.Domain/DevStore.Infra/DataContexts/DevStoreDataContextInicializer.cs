using DevStore.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevStore.Infra.DataContexts
{
    class DevStoreDataContextInicializer : DropCreateDatabaseIfModelChanges<DevStoreDataContext>
    {
        protected override void Seed(DevStoreDataContext context)
        {

            context.Categories.Add(new Category { Id = 1, Title = "Informática"});

            context.Categories.Add(new Category { Id = 2, Title = "Games"});

            context.Categories.Add(new Category { Id = 3, Title = "Didático"});

            context.SaveChanges();

            context.Products.Add(new Product { Id = 1, Title = "Introdução á Lógica de Programação.", Price = 122, AcquireDate = new DateTime(2016, 5, 28), IsActive = true, CategoryId = 1});

            context.Products.Add(new Product { Id = 2, Title = "Melhores games de 2016", Price = 82, AcquireDate = new DateTime(2016, 12, 15), IsActive = true, CategoryId = 2 });

            context.Products.Add(new Product { Id = 3, Title = "História da Arte.", Price = 150, AcquireDate = new DateTime(2016, 3, 15), IsActive = true, CategoryId = 3 });

            base.Seed(context);
        }
    }
}
