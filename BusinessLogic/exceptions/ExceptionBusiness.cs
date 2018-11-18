using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.exceptions
{
    public class ExceptionBusiness: Exception
    {
        public ExceptionBusiness()
        {

        }

        public ExceptionBusiness(string message, Exception ex): base(message, ex)
        {

        }
    }
}
