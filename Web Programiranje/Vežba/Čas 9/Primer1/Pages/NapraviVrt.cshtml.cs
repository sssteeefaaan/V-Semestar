using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Primer1.Models;

namespace Primer1.Pages
{
    public class NapraviVrtModel : PageModel
    {
        [BindProperty]
        public Vrt Vrt { get; set; }

        private ZooContext zoo;

        public NapraviVrtModel(ZooContext context)
        { zoo = context; }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            zoo.Vrtovi.Add(Vrt);
            await zoo.SaveChangesAsync();
            return RedirectToPage("./Vrtovi");
        }
    }
}
