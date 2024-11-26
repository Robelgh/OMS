using Domain.common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Product : BaseDomainEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid ProductTypeId { get; set; }
        public string ProductCode { get; set; }
        public int Status { get; set; }
        public ICollection<Order> Orders { get; } = new List<Order>();
        public ProductTypes ProductTypes { get; set; } = null!;


    }
}
