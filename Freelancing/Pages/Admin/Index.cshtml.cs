using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Freelancing.Models;
using Microsoft.AspNetCore.Authorization;

namespace Freelancing.Pages.Admin
{
    [Authorize(Policy = "AdminPolicy")]
    public class IndexModel : PageModel
    {
        private readonly FreelancingDbContext _context;

        public IndexModel(FreelancingDbContext context)
        {
            _context = context;
        }

        public IList<Service> Services { get; set; } = default!;
        public IList<User> RecentUsers { get; set; } = default!;
        public IList<Payment> RecentPayments { get; set; } = default!;
        public int TotalServices { get; set; }
        public int TotalUsers { get; set; }
        public int TotalPayments { get; set; }
        public decimal TotalRevenue { get; set; }

        public async Task OnGetAsync()
        {
            Services = await _context.Services
                .OrderByDescending(s => s.CreatedAt)
                .Take(5)
                .ToListAsync();

            RecentUsers = await _context.Users
                .Where(u => !u.IsAdmin)
                .OrderByDescending(u => u.CreatedAt)
                .Take(5)
                .ToListAsync();

            RecentPayments = await _context.Payments
                .Include(p => p.User)
                .Include(p => p.Service)
                .OrderByDescending(p => p.PaymentDate)
                .Take(5)
                .ToListAsync();

            TotalServices = await _context.Services.CountAsync();
            TotalUsers = await _context.Users.Where(u => !u.IsAdmin).CountAsync();
            TotalPayments = await _context.Payments.CountAsync();
            TotalRevenue = await _context.Payments
                .Where(p => p.Status == "Completed")
                .SumAsync(p => p.Amount);
        }
    }
}