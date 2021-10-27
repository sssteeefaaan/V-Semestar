using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Server.Models;

namespace Server.Pages
{
    public class UpdateVideoKlubModel : PageModel
    {
        [BindProperty]
        public VideoKlub VKlub { get; set; }
        private KlubContext klub;
        public UpdateVideoKlubModel(KlubContext context) { klub = context; }
        public void OnGet(int id)
        {
            VKlub = klub.VideoKlubovi.Where(p => p.ID == id).FirstOrDefault();
        }
        public async Task<IActionResult> OnPost(int id)
        {
            if (!ModelState.IsValid)
            {
                VKlub = await klub.VideoKlubovi.FindAsync(id);
                return Page();
            }

            VKlub.ID = id;
            klub.VideoKlubovi.Update(VKlub);
            await klub.SaveChangesAsync();
            return RedirectToPage("./Klubovi");
        }
    }
}
