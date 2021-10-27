using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Server.Models;

namespace Server.Pages
{
    public class UpdateUcesnikModel : PageModel
    {
        private EvidencijaContext context;
        [BindProperty]
        public string GoBack { get; set; }
        [BindProperty]
        public Ucesnik Ucesnik { get; set; }
        public UpdateUcesnikModel(EvidencijaContext context) { this.context = context; }
        public void OnGet(int turnirID, int disciplinaID, int ucesnikID)
        {
            GoBack = Request.Headers["Referer"].ToString().Substring(Request.Headers["Referer"].ToString().LastIndexOf('/'));
            Ucesnik = context.Ucesnici.Where(uc => uc.TurnirID == turnirID && uc.DisciplinaID == disciplinaID && uc.ID == ucesnikID).FirstOrDefault();
        }

        public async Task<IActionResult> OnPostAsync(int turnirID, int disciplinaID, int ucesnikID)
        {
            if (!ModelState.IsValid)
                return BadRequest("Model state is invalid!");

            if (!context.Turniri.Any(t => t.ID == turnirID))
                return BadRequest($"Turnir with the key ({turnirID}) doesn't exist in the database!");

            Ucesnik.TurnirID = turnirID;

            if (!context.Discipline.Any(dsc => dsc.TurnirID == turnirID && dsc.ID == disciplinaID))
                return BadRequest($"Disciplina with the key ({turnirID}, {disciplinaID}) doesn't exist in the database!");

            Ucesnik.DisciplinaID = disciplinaID;

            if (!context.Ucesnici.Any(uc => uc.TurnirID == turnirID && uc.DisciplinaID == disciplinaID && uc.ID == ucesnikID))
                return BadRequest($"Ucesnik with the key ({turnirID}, {disciplinaID}, {ucesnikID}) doesn't exist in the database!");

            if (Ucesnik.Brzina > 100 || Ucesnik.Brzina < 1)
                return BadRequest($"Ucesnik, brzina can't be {Ucesnik.Brzina}! Range is [1-100]!");

            Ucesnik.ID = ucesnikID;

            context.Ucesnici.Update(Ucesnik);

            await context.SaveChangesAsync();
            return Redirect(GoBack);
        }
    }
}
