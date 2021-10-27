using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Server.Models;

namespace Server.Pages
{
    public class CreateTurnirModel : PageModel
    {
        private EvidencijaContext context;
        [BindProperty]
        public Turnir Turnir { get; set; }

        public CreateTurnirModel(EvidencijaContext context)
        {
            this.context = context;
        }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return BadRequest("Model state is invalid!");

            if (Turnir.MaxDisciplina > 100 || Turnir.MaxDisciplina < 1)
                return BadRequest($"Can't create a turnir with the maximum number of disciplines {Turnir.MaxDisciplina}! Range is [1-100]!");

            context.Turniri.Add(Turnir);
            await context.SaveChangesAsync();
            return RedirectToPage("./ViewTurniri");
        }
    }
}
