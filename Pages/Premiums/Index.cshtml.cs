using Microsoft.AspNetCore.Mvc.RazorPages;
using Domain.Models;
using Domain.Interfaces;

namespace Domain.Pages_Premiums
{
    public class IndexModel : PageModel
    {

        private readonly IPremiumRepository _premiumRepository;

        public IndexModel(IPremiumRepository premiumRepository)
        {
            _premiumRepository = premiumRepository;
        }

        public IList<Premium> Premium { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Premium = await _premiumRepository.OnGetAsync();
        }
    }
}
