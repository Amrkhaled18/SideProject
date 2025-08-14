using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Freelancing.Models;
using Microsoft.AspNetCore.Authorization;

namespace Freelancing.Pages.Admin.Users
{
    [Authorize(Policy = "AdminPolicy")]
    public class IndexModel : PageModel
    {
        private readonly FreelancingDbContext _context;

        public IndexModel(FreelancingDbContext context)
        {
            _context = context;
        }

        public IList<User> Users { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Users = await _context.Users
                .Where(u => !u.IsAdmin)
                .OrderByDescending(u => u.CreatedAt)
                .ToListAsync();
        }
    }
}