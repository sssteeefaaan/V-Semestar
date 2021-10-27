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
    public class ViewDisciplineTurniraModel : PageModel
    {
        private EvidencijaContext context;
        public List<Disciplina> Discipline { get; set; }
        public List<int> TrenutniBrojUcesnika { get; set; } = new List<int>();
        public Turnir Turnir { get; set; }
        public List<Ucesnik> Pobednici { get; set; } = new List<Ucesnik>();
        public ViewDisciplineTurniraModel(EvidencijaContext context)
        { this.context = context; }
        public async Task OnGet(int turnirID)
        {
            Turnir = context.Turniri.Where(t => t.ID == turnirID).FirstOrDefault();
            Discipline = await context.Discipline.Where(dsc => dsc.TurnirID == turnirID).ToListAsync();
            foreach (var dsc in Discipline)
            {
                TrenutniBrojUcesnika.Add(context.Ucesnici.Count(uc => uc.DisciplinaID == dsc.ID && uc.TurnirID == turnirID));
                Pobednici.Add(context.Ucesnici.Where(uc => uc.ID == dsc.PobednikID && uc.DisciplinaID == dsc.ID && uc.TurnirID == turnirID).FirstOrDefault());
            }
        }

        public string VratiPobednika(int i)
        {
            if (Pobednici.Count > i && Pobednici[i] != null)
                return Pobednici[i].Ime + " " + Pobednici[i].Prezime;
            return "Nepoznato!";
        }
    }
}
