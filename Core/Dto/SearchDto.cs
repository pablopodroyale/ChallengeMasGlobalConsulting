using Core.Dto.Employee;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Dto
{
    public class SearchDto
    {
        public int PageLength { get; set; }
        public bool Asc { get; set; }
        public int? Id { get; set; }
    }
}
