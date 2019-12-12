using Microsoft.AspNetCore.Mvc;
using Sup.Framework.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductCatalog.Application.ProductControllers
{
     [ApiVersion("2.0")]
     [Route("api/v{version:apiVersion}/Product")]
    [ApiController]
    public class Product2Service : IProductService
    {
        public Product2Service()
        {

        }
        [HttpGet]
        public string Get()
        {
            return "Hello world v2";
        }
    }
}
