using System;
using System.Collections.Generic;
using System.Text;

namespace Sup.Framework.Exceptions
{
    public class UnAuthorizedException:Exception
    {
        public UnAuthorizedException()
        {

        }
        public UnAuthorizedException(string message)
            : base(message)
        {

        }
    }
}
