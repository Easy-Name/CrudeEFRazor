using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Domain.Models;
using Domain.Interfaces;

namespace Domain.Pages_Students
{
    public class IndexModel : PageModel
    {
        private readonly IStudentRepository _studentRepository;

        public IndexModel(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public IList<Student> Student { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Student = await _studentRepository.OnGetAsync();
        }
    }
}
