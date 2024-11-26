using Application.Repository;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repository
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        private readonly OMSDbContext _context;

        public OrderRepository(OMSDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
