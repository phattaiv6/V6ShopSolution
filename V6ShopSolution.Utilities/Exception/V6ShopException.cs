using System;
using System.Collections.Generic;
using System.Text;

namespace V6ShopSolution.Utilities.Exceptions
{
    public class V6ShopException : Exception
    {
        public V6ShopException()
        {

        }
        public V6ShopException(string message) : base (message)
        {

        }
        public V6ShopException(string message , Exception inner) : base (message , inner)
        {

        }
    }
}
