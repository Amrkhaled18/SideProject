using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Freelancing.Models;
using Microsoft.AspNetCore.Authorization;

namespace Freelancing.Pages.Admin.Payments
{
    [Authorize(Policy = "AdminPolicy")]
    public class IndexModel : PageModel
    {
        private readonly FreelancingDbContext _context;

        public IndexModel(FreelancingDbContext context)
        {
            _context = context;
        }

        public IList<Payment> Payments { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Payments = await _context.Payments
                .Include(p => p.User)
                .Include(p => p.Service)
                .OrderByDescending(p => p.PaymentDate)
                .ToListAsync();
        }
    }
}