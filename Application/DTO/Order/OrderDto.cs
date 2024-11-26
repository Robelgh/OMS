using Application.DTO.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.Order
{
    public class OrderDto : BaseDtos
    {
        public Guid? Id { get; set; }
        public string? OrderCode { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public DateTime? DeliveryTime { get; set; }
        public int OrderStatus { get; set; }
    }
}
