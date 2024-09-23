using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Domain.Models;
using Domain.Interfaces;

namespace Domain.Pages_Students
{
    public class DeleteModel : PageModel
    {

        private readonly IStudentRepository _studentRepository;

        public DeleteModel(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }


        [BindProperty]
        public Student Student { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = _studentRepository.OnGetAsync(id).Result;

            if (student == null)
            {
                return NotFound();
            }
            else
            {
                Student = student;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var student = await _context.Students.FindAsync(id); (why use FindAsync?)??????????
            var student = _studentRepository.OnGetAsync(id).Result; //here is the usage of the repository to query the database

            if (student != null)
            {
                Student = student;
                await _studentRepository.DeleteAsync(Student); //here is the usage of the repository to query the database
            }

            return RedirectToPage("./Index");
        }
    }
}
