using System;
using System.Collections.Generic;
using System.Text;

namespace ProductCatalog.Application.TestService
{
    public class Test : ITest
    {
        public string Get()
        {
            return "hello test";
        }
    }
}
