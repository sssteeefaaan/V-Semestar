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
    public class ViewUcesnikeDisciplineModel : PageModel
    {
        private EvidencijaContext context;
        public List<Ucesnik> Ucesnici { get; set; }
        public Disciplina Disciplina { get; set; }
        public ViewUcesnikeDisciplineModel(EvidencijaContext context)
        { this.context = context; }
        public async Task OnGet(int turnirID, int disciplinaID)
        {
            Disciplina = context.Discipline.Where(dsc => dsc.TurnirID == turnirID && dsc.ID == disciplinaID).FirstOrDefault();
            Ucesnici = await context.Ucesnici.Where(uc => uc.TurnirID == turnirID && uc.DisciplinaID == disciplinaID).ToListAsync();
        }
    }
}
