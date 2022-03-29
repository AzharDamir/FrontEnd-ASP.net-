using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TestAsp.Pages.admin
{
    public class Logout : PageModel
    {
        public IActionResult OnGet()
        {
            if (!HttpContext.User.Identity.IsAuthenticated) return Redirect("/admin");
            HttpContext.SignOutAsync();
            return Redirect("/admin");  
        }
    }
}
