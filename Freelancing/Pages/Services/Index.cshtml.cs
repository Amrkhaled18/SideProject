using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Freelancing.Models;

namespace Freelancing.Pages.Services
{
    public class IndexModel : PageModel
    {
        private readonly FreelancingDbContext _context;

        public IndexModel(FreelancingDbContext context)
        {
            _context = context;
        }

        public IList<Service> Service { get; set; } = default!;
        
        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }
        
        [BindProperty(SupportsGet = true)]
        public string? ServiceType { get; set; }

        public async Task OnGetAsync()
        {
            var services = from s in _context.Services
                          where s.IsActive
                          select s;

            if (!string.IsNullOrEmpty(SearchString))
            {
                services = services.Where(s => s.Name.Contains(SearchString) || 
                                             s.Description.Contains(SearchString));
            }

            if (!string.IsNullOrEmpty(ServiceType))
            {
                services = services.Where(s => s.Type == ServiceType);
            }

            Service = await services.ToListAsync();
        }
    }
}