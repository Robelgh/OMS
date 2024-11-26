using Application.DTO.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.Product
{
    public class ProductDto : BaseDtos
    {
        public string Name { get; set; }
        public Guid ProductTypeId { get; set; }
        public string ProductCode { get; set; }
    }
}
