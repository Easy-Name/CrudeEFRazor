using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Domain.Models;
using Domain.Interfaces;

namespace Domain.Pages_Premiums
{
    public class CreateModel : PageModel
    {

        private readonly IPremiumRepository _premiumRepository;
        private readonly IStudentRepository _studentRepository;

        public CreateModel(IPremiumRepository premiumRepository, IStudentRepository studentRepository)
        {
            _premiumRepository = premiumRepository;
            _studentRepository = studentRepository;
        }

        public IActionResult OnGet()
        {
        //ViewData["StudentId"] = new SelectList(_context.Students, "Id", "Email");
        ViewData["StudentId"] = new SelectList(_studentRepository.OnGetAsync().Result, "Id", "Email"); //here is the usage of the repository to query the database
            return Page();
        }

        [BindProperty]
        public Premium Premium { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _premiumRepository.CreateAsync(Premium); //here is the usage of the repository to query the database

            return RedirectToPage("./Index");
        }
    }
}
