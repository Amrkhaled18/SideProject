using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Freelancing.Models;
using Microsoft.AspNetCore.Authorization;

namespace Freelancing.Pages.Admin.Services
{
    [Authorize(Policy = "AdminPolicy")]
    public class IndexModel : PageModel
    {
        private readonly FreelancingDbContext _context;

        public IndexModel(FreelancingDbContext context)
        {
            _context = context;
        }

        public IList<Service> Service { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Service = await _context.Services
                .OrderByDescending(s => s.CreatedAt)
                .ToListAsync();
        }
    }
}