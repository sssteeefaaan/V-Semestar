using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Server.Models;

namespace Server.Pages
{
    public class UpdateDisciplinaModel : PageModel
    {
        private EvidencijaContext context;
        [BindProperty]
        public string GoBack { get; set; }
        [BindProperty]
        public Disciplina Disciplina { get; set; } = new Disciplina();

        public UpdateDisciplinaModel(EvidencijaContext context)
        { this.context = context; }
        public void OnGet(int turnirID, int disciplinaID)
        {
            GoBack = Request.Headers["Referer"].ToString().Substring(Request.Headers["Referer"].ToString().LastIndexOf('/'));
            Disciplina = context.Discipline.Where(dsc => dsc.TurnirID == turnirID && disciplinaID == dsc.ID).FirstOrDefault();
        }
        public async Task<IActionResult> OnPostAsync(int turnirID, int disciplinaID)
        {
            if (!ModelState.IsValid)
                return BadRequest("Model state is invalid!");

            if (!context.Turniri.Any(t => t.ID == turnirID))
                return BadRequest($"Turnir with the key {turnirID} doesn't exist in the database!");

            Disciplina.TurnirID = turnirID;

            if (!context.Discipline.Any(dsc => dsc.TurnirID == turnirID && dsc.ID == disciplinaID))
                return BadRequest($"Disciplina with the key ({turnirID}, {disciplinaID}) doesn't exist in the database!");

            if (Disciplina.MaxUcesnici > 100 || Disciplina.MaxUcesnici < 1)
                return BadRequest($"Maksimalni broj učesnika na disciplini ne može biti {Disciplina.MaxUcesnici}! Range is [1-100]!");

            Disciplina.ID = disciplinaID;

            context.Discipline.Update(Disciplina);

            await context.SaveChangesAsync();
            return Redirect(GoBack);
        }
    }
}
