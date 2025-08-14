using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Freelancing.Models;
using Microsoft.AspNetCore.Authorization;
using System.ComponentModel.DataAnnotations;

namespace Freelancing.Pages.Admin.Payments
{
    [Authorize(Policy = "AdminPolicy")]
    public class UpdateStatusModel : PageModel
    {
        private readonly FreelancingDbContext _context;

        public UpdateStatusModel(FreelancingDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public InputModel Input { get; set; } = new();

        public Payment Payment { get; set; } = default!;

        public class InputModel
        {
            [Required]
            public string Status { get; set; } = string.Empty;
            
            public string? Notes { get; set; }
        }

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

            Payment = payment;
            Input.Status = payment.Status;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var payment = await _context.Payments
                .Include(p => p.User)
                .Include(p => p.Service)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (payment == null)
            {
                return NotFound();
            }

            Payment = payment;

            if (!ModelState.IsValid)
            {
                return Page();
            }

            payment.Status = Input.Status;
            
            try
            {
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Payment status updated successfully!";
                return RedirectToPage("./Details", new { id = payment.Id });
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaymentExists(payment.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
        }

        private bool PaymentExists(int id)
        {
            return _context.Payments.Any(e => e.Id == id);
        }
    }
}