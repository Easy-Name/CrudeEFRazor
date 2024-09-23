using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Domain.Models;
using Infrastructure.Data;
using Domain.Interfaces;

namespace Domain.Pages_Students
{
    public class DetailsModel : PageModel
    {
       /* private readonly ApplicationDbContext _context;

        public DetailsModel(ApplicationDbContext context)
        {
            _context = context;
        }*/






        private readonly IStudentRepository _studentRepository;

        public DetailsModel(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }





        public Student Student { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = _studentRepository.OnGetAsync(id).Result; //here is the usage of the repository to query the database

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
    }
}
