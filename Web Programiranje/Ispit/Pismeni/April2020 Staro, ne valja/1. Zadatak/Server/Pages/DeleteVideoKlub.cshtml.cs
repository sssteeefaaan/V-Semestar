using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Server.Models;

namespace Server.Pages
{
    public class DeleteVideoKlubModel : PageModel
    {
        private KlubContext klub;

        public DeleteVideoKlubModel(KlubContext context) { klub = context; }
        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (!ModelState.IsValid)
                return Page();

            var forDeletion = await klub.VideoKlubovi.FindAsync(id);
            if (forDeletion == null)
                return BadRequest("Video klub sa id-om " + id + " ne postoji!");

            klub.VideoKlubovi.Remove(forDeletion);
            await klub.SaveChangesAsync();
            return RedirectToPage("./Klubovi");
        }
    }
}
