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
    public class IndexModel : PageModel
    {
        private readonly TestAsp.Data.DataContext _context;

        public IndexModel(TestAsp.Data.DataContext context)
        {
            _context = context;
        }

        public IList<Livre> Livre { get;set; }

        public async Task OnGetAsync()
        {
            Livre = await _context.Livres.ToListAsync();
        }
    }
}
