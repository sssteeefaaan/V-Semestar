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
    public class DeleteDisciplinaModel : PageModel
    {
        private EvidencijaContext context;

        public DeleteDisciplinaModel(EvidencijaContext context)
        { this.context = context; }
        public async Task<IActionResult> OnGetAsync(int turnirID, int disciplinaID)
        {
            if (!ModelState.IsValid)
                return BadRequest("Model state is invalid!");

            var turnir = context.Turniri.Where(t => t.ID == turnirID).FirstOrDefault();
            if (turnir == null)
                return BadRequest($"Turnir with the key ({turnirID}) doesn't exist in the database!");

            var disciplina = context.Discipline.Where(dsc => dsc.TurnirID == turnirID && disciplinaID == dsc.ID).FirstOrDefault();
            if (disciplina == null)
                return BadRequest($"Discilina with the key ({turnirID}, {disciplinaID}) doesn't exist in the database!");

            var ucesnici = await context.Ucesnici.Where(uc => uc.TurnirID == turnirID && uc.DisciplinaID == disciplinaID).ToListAsync();
            if (ucesnici != null)
                ucesnici.ForEach(uc => context.Ucesnici.Remove(uc));

            context.Discipline.Remove(disciplina);
            context.Turniri.Update(turnir);

            await context.SaveChangesAsync();
            return Redirect(Request.Headers["Referer"].ToString().Substring(Request.Headers["Referer"].ToString().LastIndexOf('/')));
        }
    }
}
