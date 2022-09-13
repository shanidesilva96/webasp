using SupermarketProA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SupermarketProA.Repository
{
    public class UnitOfWork
    {
        private readonly SupermarketContext _context;
        public UnitOfWork(SupermarketContext context)
        {
            _context = context;
        }


        GenericRepository<Cart> _CartReference;
        public GenericRepository<Cart> CartRepository
        {
            get
            {
                if (_CartReference == null)
                    _CartReference = new GenericRepository<Cart>(_context);
                return _CartReference;
            }
        }
    }
}
