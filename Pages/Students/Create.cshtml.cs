using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Domain.Models;
using Domain.Interfaces;

namespace Domain.Pages_Students
{
    public class CreateModel : PageModel
    {
        private readonly IStudentRepository _studentRepository;

        public CreateModel(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }


        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Student Student { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _studentRepository.CreateAsync(Student); //here is the usage of the repository to query the database

            return RedirectToPage("./Index");
        }
    }
}
