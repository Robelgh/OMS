using Application.Repository;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repository
{
    public class UsersRepository : GenericRepository<Users>, IUserRepository
    {
        private readonly OMSDbContext _context;

        public UsersRepository(OMSDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
