using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Dto.Response
{
    public class ResponseDto<TResponse>
    {
        public TResponse Content { get; set; }
        public int Status { get; set; }
    }
}
