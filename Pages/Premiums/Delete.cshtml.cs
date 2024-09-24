using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Domain.Models;
using Domain.Interfaces;

namespace Domain.Pages_Premiums
{
    public class DeleteModel : PageModel
    {
        private readonly IPremiumRepository _premiumRepository;

        public DeleteModel(IPremiumRepository premiumRepository)
        {
            _premiumRepository = premiumRepository;
        }

        [BindProperty]
        public Premium Premium { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var premium = await _premiumRepository.OnGetAsync(id);  //here is the usage of the repository to query the database

            if (premium == null)
            {
                return NotFound();
            }
            else
            {
                Premium = premium;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var premium = await _context.Premium.FindAsync(id);
            var premium = await _premiumRepository.OnGetAsync(id);  //here is the usage of the repository to query the database

            if (premium != null)
            {
                Premium = premium;
                await _premiumRepository.DeleteAsync(premium); //here is the usage of the repository to query the database
            }

            return RedirectToPage("./Index");
        }
    }
}
