using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Server.Models;

namespace Server.Pages
{
    public class CreatePolicaModel : PageModel
    {
        [BindProperty]
        public Polica Polica { get; set; }
        private KlubContext klub;

        public CreatePolicaModel(KlubContext context)
        {
            klub = context;
        }
        public async Task OnGet(int id)
        {
            Polica = new Polica();
            Polica.VideoKlub = await klub.VideoKlubovi.FindAsync(id);
            if (Polica.VideoKlub == null)
                /*return*/
                BadRequest("Ne postoji video klub sa tim idom (" + id + ")!");
            Polica.VideoKlubID = id;
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            // Ne upisuje ga u niz, samo u bazu....
            if (!ModelState.IsValid)
                return Page();

            if (Polica.Curr > Polica.Max || Polica.Curr < 0 || Polica.Max < 0)
                return BadRequest("Pogrešno unete vrednosti");

            Polica.VideoKlub = await klub.VideoKlubovi.FindAsync(id);
            if (Polica.VideoKlub == null)
                return BadRequest("Video Klub je null");
            Polica.VideoKlubID = id;

            if (klub.Police.Any(p => p.Oznaka == Polica.Oznaka && p.VideoKlubID == id))
                return BadRequest("Polica sa oznakom " + Polica.Oznaka + " već postoji!");

            klub.Police.Add(Polica);
            await klub.SaveChangesAsync();

            // Can I force method: get here?
            return RedirectToPage("./Klubovi");
        }
    }
}