using Core.Common.Exception;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Dto
{
    public class ServiceResultDto<T>
    {
        public bool Succedded { get; set; }

        public List<Error> Errors { get; set; }

        public T obj { get; set; }

        public ServiceResultDto()
        {
            Errors = new List<Error>();
        }
    }
}
