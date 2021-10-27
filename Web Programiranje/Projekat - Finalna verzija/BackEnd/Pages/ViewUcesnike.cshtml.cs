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
    public class ViewUcesnikeModel : PageModel
    {
        private EvidencijaContext context;
        public List<Ucesnik> Ucesnici { get; set; } = new List<Ucesnik>();
        public List<Disciplina> Discipline { get; set; } = new List<Disciplina>();
        public List<Turnir> Turniri { get; set; } = new List<Turnir>();

        public ViewUcesnikeModel(EvidencijaContext context) { this.context = context; }
        public async Task OnGet()
        {
            Ucesnici = await context.Ucesnici.ToListAsync();
            foreach (var uc in Ucesnici)
            {
                Discipline.Add(context.Discipline.Where(dsc => dsc.TurnirID == uc.TurnirID && dsc.ID == uc.DisciplinaID).FirstOrDefault());
                Turniri.Add(context.Turniri.Where(t => t.ID == uc.TurnirID).FirstOrDefault());
            }
        }
        public string VratiDisciplinu(int i)
        {
            if (i < Discipline.Count && Discipline[i] != null)
                return Discipline[i].Naziv;
            return "Nepoznato";
        }
        public string VratiTurnir(int i)
        {
            if (i < Turniri.Count && Turniri[i] != null)
                return Turniri[i].Naziv;
            return "Nepoznato";
        }
    }
}
