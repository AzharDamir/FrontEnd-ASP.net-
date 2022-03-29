#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TestAsp.Data;
using TestAsp.Models;

namespace TestAsp.Pages.admin.Livres
{
    [Authorize]
    public class DetailsModel : PageModel
    {
        private readonly TestAsp.Data.DataContext _context;

        public DetailsModel(TestAsp.Data.DataContext context)
        {
            _context = context;
        }

        public Livre Livre { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Livre = await _context.Livres.FirstOrDefaultAsync(m => m.id == id);

            if (Livre == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
