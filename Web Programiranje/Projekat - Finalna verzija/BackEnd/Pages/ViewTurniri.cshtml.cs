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
    public class ViewTurniriModel : PageModel
    {
        private EvidencijaContext context;
        public List<Turnir> Turniri { get; set; }
        public List<int> TrenutniBrojDisciplina { get; set; } = new List<int>();
        public List<int> TrenutniBrojUcesnika { get; set; } = new List<int>();

        public ViewTurniriModel(EvidencijaContext context)
        {
            this.context = context;
        }
        public async Task OnGet()
        {
            Turniri = await context.Turniri.ToListAsync();
            Turniri.ForEach(t =>
            {
                TrenutniBrojDisciplina.Add(context.Discipline.Count(dsc => dsc.TurnirID == t.ID));
                TrenutniBrojUcesnika.Add(context.Ucesnici.Count(uc => uc.TurnirID == t.ID));
            });
        }
    }
}
