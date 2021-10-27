using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Server.Models;

namespace Server.Pages
{
    public class CreateVideoKlubModel : PageModel
    {

        private KlubContext klub;
        [BindProperty]
        public VideoKlub VKlub { get; set; }

        public CreateVideoKlubModel(KlubContext context)
        {
            klub = context;
        }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            klub.VideoKlubovi.Add(VKlub);
            await klub.SaveChangesAsync();
            return RedirectToPage("./Klubovi");
        }
    }
}
