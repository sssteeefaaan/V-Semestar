using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Server.Models;

namespace Server.Pages
{
    public class CreateDisciplinaModel : PageModel
    {
        private EvidencijaContext context;
        [BindProperty]
        public Disciplina Disciplina { get; set; } = new Disciplina();

        public CreateDisciplinaModel(EvidencijaContext context)
        { this.context = context; }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPostAsync(int turnirID)
        {
            if (!ModelState.IsValid)
                return BadRequest("Model state is invalid!");

            var turnir = context.Turniri.Where(t => t.ID == turnirID).FirstOrDefault();
            if (turnir == null)
                return BadRequest($"Turnir with key ({turnirID}) doesn't exit in the database!");

            int numberOfDisciplines = context.Discipline.Count(dsc => dsc.TurnirID == turnirID);
            if (numberOfDisciplines >= turnir.MaxDisciplina)
                return BadRequest($"Broj disciplina na turniru ne može biti {numberOfDisciplines + 1}, maks je: {turnir.MaxDisciplina}!");

            if (Disciplina.MaxUcesnici > 100 || Disciplina.MaxUcesnici < 1)
                return BadRequest($"Maksimalni broj učesnika na disciplini ne može biti {Disciplina.MaxUcesnici}! Range is [1-100]!");

            Disciplina.TurnirID = turnirID;

            context.Discipline.Add(Disciplina);
            context.Turniri.Update(turnir); // Mislim da nije neophodno iz nekog razloga

            await context.SaveChangesAsync();
            return Redirect($"./ViewDisciplineTurnira?turnirID={turnirID}");
        }
    }
}
