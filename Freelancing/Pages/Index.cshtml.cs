using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Freelancing.Models;

namespace Freelancing.Pages.Index
{
    public class IndexModel : PageModel
    {
        private readonly FreelancingDbContext _context;

        public IndexModel(FreelancingDbContext context)
        {
            _context = context;
        }

        public IList<Service> FeaturedServices { get; set; } = default!;

        public async Task OnGetAsync()
        {
            FeaturedServices = await _context.Services
                .Where(s => s.IsActive)
                .Take(6)
                .ToListAsync();
        }
    }
}