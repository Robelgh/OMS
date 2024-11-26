using Application.Repository;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repository
{
    public class ProductTypeRepository : GenericRepository<ProductTypes>, IProductTypeRepository
    {
        private readonly OMSDbContext _context;

        public ProductTypeRepository(OMSDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
