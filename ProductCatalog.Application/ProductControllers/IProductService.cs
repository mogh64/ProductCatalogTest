using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductCatalog.Application.ProductControllers
{
    public interface IProductService
    {
       
        string Get();
    }
}
