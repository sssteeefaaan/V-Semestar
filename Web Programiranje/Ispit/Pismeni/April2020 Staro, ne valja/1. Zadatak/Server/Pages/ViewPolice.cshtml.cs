using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Server.Models;

namespace Server.Pages
{
    public class ViewPoliceModel : PageModel
    {
        [BindProperty]
        public VideoKlub VKlub { get; set; }
        private KlubContext klub;

        public ViewPoliceModel(KlubContext context) { klub = context; }
        public async Task OnGetAsync(int id)
        {
            VKlub = await klub.VideoKlubovi.FindAsync(id);

            var police = klub.Police.Where(p => p.VideoKlub.ID == VKlub.ID);
            foreach (var p in police)
                if (!VKlub.Police.Contains(p))
                    VKlub.Police.Add(p);
        }

        public async Task OnPostAsync(int id)
        {
            VKlub = await klub.VideoKlubovi.FindAsync(id);

            var police = klub.Police.Where(p => p.VideoKlub.ID == VKlub.ID);
            foreach (var p in police)
                if (!VKlub.Police.Contains(p))
                    VKlub.Police.Add(p);
        }

        // ZAŠTO OVO NE RADI!?
        // public async Task<IActionResult> OnGetAsync(int id)
        // {
        //     if (!ModelState.IsValid)
        //         return Page();
        //     VKlub = await klub.VideoKlubovi.FindAsync(id);
        //     if (VKlub == null)
        //         return BadRequest("Ne postoji video klub sa id-om " + id + "!");

        //     return OK();
        // }
    }
}
