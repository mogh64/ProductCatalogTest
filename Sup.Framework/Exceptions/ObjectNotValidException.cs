using System;
using System.Collections.Generic;
using System.Text;

namespace Sup.Framework.Exceptions
{
    public class ObjectNotValidException:Exception
    {
        public ObjectNotValidException()
        {

        }
        public ObjectNotValidException(string message)
            :base(message)
        {
            
        }
    }
}

