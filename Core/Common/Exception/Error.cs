using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Common.Exception
{
    public class Error
    {
        public string Description { get; set; }

        public Error(System.Exception e)
        {
            this.Description = e.Message;
        }

        public Error(string error)
        {
            this.Description = error;
        }


    }
}
