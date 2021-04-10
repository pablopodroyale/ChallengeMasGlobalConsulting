using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Common.Exception
{
    public class CustomException : System.Exception
    {
        public IEnumerable<Error> Errors { get; set; }

        public CustomException()
        {
            Errors = new List<Error>();
        }

        public CustomException(IEnumerable<Error> errors)
        {
            this.Errors = errors;
        }
    }
}
