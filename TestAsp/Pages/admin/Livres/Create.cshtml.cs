#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TestAsp.Data;
using TestAsp.Models;

namespace TestAsp.Pages.admin.Livres
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly TestAsp.Data.DataContext _context;

        public CreateModel(TestAsp.Data.DataContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Livre Livre { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Livres.Add(Livre);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
