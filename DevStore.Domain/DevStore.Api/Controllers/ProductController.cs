using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using DevStore.Domain;
using DevStore.Infra.DataContexts;

namespace DevStore.Api.Controllers
{
    //Rota para todo o controller, informando a versão e o tipo de acesso.
    [RoutePrefix("api/v1/public")]
    public class ProductController : ApiController
    {
        private DevStoreDataContext db = new DevStoreDataContext();

        //Para não retornar apenas o Iqueryable(lista de produtos) e sim uma mensagem de retorno padronizado.
        [Route("products")] //Para configurar a rota do HttpResponseMessage
        public HttpResponseMessage GetProduts()
        {
            var result = db.Products.Include("Category").ToList();

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [Route("categories")] //Para configurar a rota do HttpResponseMessage
        public HttpResponseMessage GetCategories()
        {
            var result = db.Categories.ToList();

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        //Entre chaves está o parâmetro.
        [Route("categories/{categoryId}/products")] //Para configurar a rota do HttpResponseMessage
        public HttpResponseMessage GetProductsByCategories(int categoryId)
        {
            var result = db.Products.Include("Category").Where(x => x.CategoryId == categoryId).ToList();

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpPost]
        [Route("products")] //Para configurar a rota do HttpResponseMessage
        public HttpResponseMessage PostProduct(Product product)
        {
            if (product == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            try
            {
                db.Products.Add(product);
                db.SaveChanges();

                //Boa prática retornar o que foi postado.
                var result = product;

                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception)
            {

                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Falha ao incluir o Produto.");
            }
           
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
        }

    }
}