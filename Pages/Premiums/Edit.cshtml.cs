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
        private readonly IStudentRepository _studentRepository;

        public EditModel(IPremiumRepository premiumRepository, IStudentRepository studentRepository)
        {
            _premiumRepository = premiumRepository;
            _studentRepository = studentRepository;
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
            //ViewData["StudentId"] = new SelectList(_context.Students, "Id", "Email");
            ViewData["StudentId"] = new SelectList(_studentRepository.OnGetAsync().Result, "Id", "Email");//here is the usage of the repository to query the database
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

            //_context.Attach(Premium).State = EntityState.Modified;
            _premiumRepository.Update(Premium);//here is the usage of the repository to query the database

            try
            {
                //await _context.SaveChangesAsync();
                await _premiumRepository.SaveChangesAsync();
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
            return _premiumRepository.PremiumExists(id);//here is the usage of the repository to query the database
        }
    }
}
