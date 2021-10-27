using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Server.Models;

namespace Server.Pages
{
    public class DeletePolicaModel : PageModel
    {
        private KlubContext klub;

        public DeletePolicaModel(KlubContext context)
        {
            klub = context;
        }
        public async Task<IActionResult> OnGet(int id, string oznaka)
        {
            var polica = klub.Police.Where(p => p.Oznaka == oznaka && p.VideoKlubID == id).FirstOrDefault();
            if (polica == null)
                return BadRequest("Ništa nije pronađeno!");

            klub.Police.Remove(polica);
            await klub.SaveChangesAsync();
            return RedirectToPage("./Klubovi");
        }
    }
}
