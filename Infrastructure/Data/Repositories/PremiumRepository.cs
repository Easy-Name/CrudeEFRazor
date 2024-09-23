using Domain.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Repositories
{
    public class PremiumRepository : IPremiumRepository
    {
        private readonly ApplicationDbContext _context;

        public PremiumRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Premium>> OnGetAsync()
        {
            return await _context.Premium
                .Include(p => p.Student).ToListAsync();
        }
    }
}
