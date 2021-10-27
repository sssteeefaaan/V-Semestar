using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Server.Models;

namespace Server.Pages
{
    public class CreateUcesnikModel : PageModel
    {
        private EvidencijaContext context;
        [BindProperty]
        public Ucesnik Ucesnik { get; set; } = new Ucesnik();

        public CreateUcesnikModel(EvidencijaContext context)
        { this.context = context; }
        public async Task<IActionResult> OnPostAsync(int turnirID, int disciplinaID)
        {
            if (!ModelState.IsValid)
                return BadRequest("Model state is invalid!");

            if (!context.Turniri.Any(t => t.ID == turnirID))
                return BadRequest($"Turnir with the key ({turnirID}) doesn't exist in the database!");

            Ucesnik.TurnirID = turnirID;

            var disciplina = context.Discipline.Where(dsc => dsc.TurnirID == turnirID && dsc.ID == disciplinaID).FirstOrDefault();
            if (disciplina == null)
                return BadRequest($"Disciplina with the key ({turnirID}, {disciplinaID}) doesn't exist in the database!");

            if (context.Ucesnici.Count(uc => uc.DisciplinaID == disciplinaID && uc.TurnirID == turnirID) >= disciplina.MaxUcesnici)
                return BadRequest($"Disciplina with the key ({turnirID}, {disciplinaID}) is at full capacity!");

            if (Ucesnik.Brzina > 100 || Ucesnik.Brzina < 1)
                return BadRequest($"Ucesnik, brzina can't be {Ucesnik.Brzina}! Range is [1-100]!");

            Ucesnik.DisciplinaID = disciplinaID;

            context.Ucesnici.Add(Ucesnik);
            context.Discipline.Update(disciplina);

            await context.SaveChangesAsync();
            return Redirect($"./ViewUcesnikeDiscipline?turnirID={turnirID}&disciplinaID={disciplinaID}");
            // return RedirectToPage("./ViewTurniri");
        }
    }
}
