using Microsoft.AspNetCore.Mvc;
using ProductCatalog.Application.TestService;
using Sup.Framework.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductCatalog.Application.ProductControllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/Product")]
    [ApiController]
    public class ProductController: SupController, IProductService
    {
        private readonly ITest test;

        public ProductController(ITest test)
        {
            this.test = test;
        }
        [HttpGet]
        public string Get()
        {
            return this.test.Get();
        }
    }
}
