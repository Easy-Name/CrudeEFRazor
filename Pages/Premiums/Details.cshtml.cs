using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Domain.Models;
using Domain.Interfaces;

namespace Domain.Pages_Premiums
{
    public class DetailsModel : PageModel
    {
        private readonly IPremiumRepository _premiumRepository;

        public DetailsModel(IPremiumRepository premiumRepository)
        {
            _premiumRepository = premiumRepository;
        }


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
    }
}
