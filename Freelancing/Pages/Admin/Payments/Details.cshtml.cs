using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Freelancing.Models;
using Microsoft.AspNetCore.Authorization;

namespace Freelancing.Pages.Admin.Payments
{
    [Authorize(Policy = "AdminPolicy")]
    public class DetailsModel : PageModel
    {
        private readonly FreelancingDbContext _context;

        public DetailsModel(FreelancingDbContext context)
        {
            _context = context;
        }

        public Payment Payment { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var payment = await _context.Payments
                .Include(p => p.User)
                .Include(p => p.Service)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (payment == null)
            {
                return NotFound();
            }
            else
            {
                Payment = payment;
            }
            return Page();
        }
    }
}