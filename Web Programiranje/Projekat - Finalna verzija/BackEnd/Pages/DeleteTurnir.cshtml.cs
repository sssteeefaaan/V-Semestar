using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Server.Models;

namespace Server.Pages
{
    public class DeleteTurnirModel : PageModel
    {
        private EvidencijaContext context;

        public DeleteTurnirModel(EvidencijaContext context) { this.context = context; }
        public async Task<IActionResult> OnGetAsync(int turnirID)
        {
            if (!ModelState.IsValid)
                return BadRequest("Model state is invalid!");

            var turnir = context.Turniri.Where(t => t.ID == turnirID).FirstOrDefault();
            if (turnir == null)
                return BadRequest($"Turnir with the key ({turnirID}) isn't in the database!");

            var ucesnici = await context.Ucesnici.Where(uc => uc.TurnirID == turnirID).ToListAsync();
            if (ucesnici != null)
                ucesnici.ForEach(uc => context.Ucesnici.Remove(uc));

            var discipline = await context.Discipline.Where(dsc => dsc.TurnirID == turnirID).ToListAsync();
            if (discipline != null)
                discipline.ForEach(dsc => context.Discipline.Remove(dsc));

            context.Turniri.Remove(turnir);

            await context.SaveChangesAsync();

            return RedirectToPage(Request.Headers["Referer"].ToString().Substring(Request.Headers["Referer"].ToString().LastIndexOf('/')));
        }
    }
}
