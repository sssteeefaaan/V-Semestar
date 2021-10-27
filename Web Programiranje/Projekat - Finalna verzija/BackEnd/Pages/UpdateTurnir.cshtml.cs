using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Server.Models;

namespace Server.Pages
{
    public class UpdateTurnirModel : PageModel
    {
        private EvidencijaContext context;
        [BindProperty]
        public Turnir Turnir { get; set; }

        public UpdateTurnirModel(EvidencijaContext context) { this.context = context; }
        public void OnGet(int turnirID)
        {
            Turnir = context.Turniri.Where(t => t.ID == turnirID).FirstOrDefault();
        }
        public async Task<IActionResult> OnPostAsync(int turnirID)
        {
            if (!ModelState.IsValid)
            {
                Turnir = context.Turniri.Where(t => t.ID == turnirID).FirstOrDefault();
                return BadRequest("Model state is invalid!");
            }

            if (!context.Turniri.Any(t => t.ID == turnirID))
            {
                Turnir = context.Turniri.Where(t => t.ID == turnirID).FirstOrDefault();
                return BadRequest($"Turnir with the key ({turnirID}) doesn't exist in the database!");
            }

            if (Turnir.MaxDisciplina > 100 || Turnir.MaxDisciplina < 1)
            {
                Turnir = context.Turniri.Where(t => t.ID == turnirID).FirstOrDefault();
                return BadRequest($"Can't create a turnir with the maximum number of disciplines {Turnir.MaxDisciplina}! Range is [1-100]!");
            }

            Turnir.ID = turnirID;

            context.Turniri.Update(Turnir);

            await context.SaveChangesAsync();
            return Redirect("./ViewTurniri");
        }
    }
}
