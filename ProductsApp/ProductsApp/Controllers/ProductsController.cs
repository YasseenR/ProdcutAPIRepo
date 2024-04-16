using ProductsApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProductsApp.Controllers
{
    public class ProductsController : ApiController
    {
        Product[] products = new Product[]
        {
            new Product { Id = 1, Name = "Potato Soup", Category = "Schmoceries", Price = 42 },
            new Product { Id = 2, Name = "Bo-bo", Category = "Keys", Price = 30.5M },
            new Product { Id = 3, Name = "Hammer", Category = "Hardware", Price = 17.9M }
        };

        public ProductsController()
        {
        }
        public ProductsController(Product[] products)
        {
            this.products = products;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return products;
        }

        public IHttpActionResult GetProduct(int id)
        {
            var product = products.FirstOrDefault((p) => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
    }
}
