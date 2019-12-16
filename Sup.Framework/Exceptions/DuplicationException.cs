using System;
using System.Collections.Generic;
using System.Text;

namespace Sup.Framework.Exceptions
{
    public class DuplicationException:Exception
    {
        public DuplicationException()
        {

        }
        public DuplicationException(string message)
            : base(message)
        {

        }
    }
}
