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
    public class ViewDisciplineModel : PageModel
    {
        private EvidencijaContext context;
        public List<Disciplina> Discipline { get; set; }
        public List<int> TrenutniBrojUcesnika { get; set; } = new List<int>();
        public List<Ucesnik> Pobednici { get; set; } = new List<Ucesnik>();
        public List<Turnir> Turniri { get; set; } = new List<Turnir>();

        public ViewDisciplineModel(EvidencijaContext context) { this.context = context; }
        public async Task OnGetAsync()
        {
            Discipline = await context.Discipline.ToListAsync();
            foreach (var dsc in Discipline)
            {
                TrenutniBrojUcesnika.Add(context.Ucesnici.Count(uc => uc.DisciplinaID == dsc.ID && uc.TurnirID == dsc.TurnirID));
                Turniri.Add(await context.Turniri.Where(t => t.ID == dsc.TurnirID).FirstOrDefaultAsync());
                Pobednici.Add(await context.Ucesnici.Where(uc => uc.ID == dsc.PobednikID && uc.DisciplinaID == dsc.ID && uc.TurnirID == dsc.TurnirID).FirstOrDefaultAsync());
            }
        }
        public string VratiPobednika(int i)
        {
            if (Pobednici.Count > i && Pobednici[i] != null)
                return Pobednici[i].Ime + " " + Pobednici[i].Prezime;
            return "Nepoznato!";
        }
        public string VratiTurnir(int i)
        {
            if (i < Turniri.Count && Turniri[i] != null)
                return Turniri[i].Naziv;
            return "Nepoznato";
        }
    }
}
