using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Domain.Models;

namespace Domain.Pages_Premiums
{
    public class IndexModel : PageModel
    {
        private readonly Infrastructure.Data.ApplicationDbContext _context;

        public IndexModel(Infrastructure.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Premium> Premium { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Premium = await _context.Premium
                .Include(p => p.Student).ToListAsync();
        }
    }
}
