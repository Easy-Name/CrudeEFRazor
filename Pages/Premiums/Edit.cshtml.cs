using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Domain.Models;
using Domain.Interfaces;

namespace Domain.Pages_Premiums
{
    public class EditModel : PageModel
    {

        private readonly IPremiumRepository _premiumRepository;

        public EditModel(IPremiumRepository premiumRepository)
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
            Premium = premium;
           ViewData["StudentId"] = new SelectList(_context.Students, "Id", "Email");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Premium).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PremiumExists(Premium.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool PremiumExists(int id)
        {
            return _context.Premium.Any(e => e.Id == id);
        }
    }
}
