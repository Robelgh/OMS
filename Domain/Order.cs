using Domain.common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Order : BaseDomainEntity
    {
        public Guid Id { get; set; }
        public string OrderCode { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public DateTime DeliveryTime { get; set; }
        public int OrderStatus { get; set; }
        public int Status { get; set; }
        public ProductTypes ProductTypes { get; set; } = null!;
    }
}
