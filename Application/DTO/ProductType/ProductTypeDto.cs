using Application.DTO.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.ProductType
{
    public class ProductTypeDto 
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public string CreatedBy { get; set; }

        public string? ProductTypeCode { get; set; }
    }
}
