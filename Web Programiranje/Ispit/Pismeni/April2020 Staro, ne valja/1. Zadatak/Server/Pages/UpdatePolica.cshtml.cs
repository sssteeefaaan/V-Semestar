using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Server.Models;

namespace Server.Pages
{
    public class UpdatePolicaModel : PageModel
    {
        private KlubContext klub;
        [BindProperty]
        public Polica Polica { get; set; }
        public UpdatePolicaModel(KlubContext context)
        {
            klub = context;
        }
        public void OnGet(string oznaka, int id)
        {
            Polica = klub.Police.Where(p => p.Oznaka == oznaka && p.VideoKlubID == id).FirstOrDefault();
            // if (Polica == null)
            //     return BadRequest("Ništa nije pronađeno!");
        }

        public async Task<IActionResult> OnPostAsync(int id, string oznaka)
        {
            if (!ModelState.IsValid)
            {
                Polica = klub.Police.Where(p => p.Oznaka == oznaka && p.VideoKlubID == id).FirstOrDefault();
                return Page();
            }

            if (Polica.Curr > Polica.Max || Polica.Curr < 0 || Polica.Max < 0)
                return BadRequest("Pogrešno unete vrednosti");

            Polica.VideoKlub = klub.VideoKlubovi.Where(p => p.ID == id).FirstOrDefault();
            if (Polica.VideoKlub == null)
                return BadRequest("Nema video kluba sa id-om " + id);
            Polica.VideoKlubID = id;
            klub.Police.Update(Polica);
            await klub.SaveChangesAsync();
            return RedirectToPage("./Klubovi");
        }
    }
}
