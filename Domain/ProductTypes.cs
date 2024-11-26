using Domain.common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class ProductTypes : BaseDomainEntity
    {
        public Guid Id { get; set; }
        public string ProductTypeCode { get; set; }
        public string Name { get; set; }
        public int Status { get; set; }
        public ICollection<Order> Orders { get; } = new List<Order>();
    }
}
