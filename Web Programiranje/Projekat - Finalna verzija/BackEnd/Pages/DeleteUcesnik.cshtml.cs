using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Server.Models;

namespace Server.Pages
{
    public class DeleteUcesnikModel : PageModel
    {
        private EvidencijaContext context;
        public DeleteUcesnikModel(EvidencijaContext context) { this.context = context; }

        public async Task<IActionResult> OnGetAsync(int turnirID, int disciplinaID, int ucesnikID)
        {
            if (!ModelState.IsValid)
                return BadRequest("Model state is invalid!");

            if (!context.Turniri.Any(t => t.ID == turnirID))
                return BadRequest($"Turnir with the key ({turnirID}) isn't in the database!");

            var disciplina = context.Discipline.Where(dsc => dsc.ID == disciplinaID && dsc.TurnirID == turnirID).FirstOrDefault();
            if (disciplina == null)
                return BadRequest($"Disciplina with the key ({turnirID}, {disciplinaID}) isn't in the database!");

            var ucesnik = context.Ucesnici.Where(uc => uc.TurnirID == turnirID && uc.DisciplinaID == disciplinaID && uc.ID == ucesnikID).FirstOrDefault();
            if (ucesnik == null)
                return BadRequest($"Ucesnik with the key ({turnirID}, {disciplinaID}, {ucesnikID}) doesn't exist in the database!");

            context.Ucesnici.Remove(ucesnik);
            context.Discipline.Update(disciplina);

            await context.SaveChangesAsync();
            return Redirect(Request.Headers["Referer"].ToString().Substring(Request.Headers["Referer"].ToString().LastIndexOf('/')));
        }
    }
}
