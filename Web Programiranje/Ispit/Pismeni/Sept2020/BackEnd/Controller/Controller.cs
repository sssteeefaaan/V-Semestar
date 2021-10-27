using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Controller
{
    public class Controller : ControllerBase
    {
        Context Context { get; set; }

        public Controller(Context context) { Context = context; }

        [Route("PreuzmiZooVrtove")]
        [HttpGet]
        public async Task<List<ZooVrt>> PreuzmiVrtove()
        {
            return await Context.ZooVrtovi.Include(zv => zv.Stanista).ToListAsync();
        }

        [Route("AzurirajStaniste")]
        [HttpPost]
        public async Task<IActionResult> AzurirajStaniste([FromBody] Staniste s)
        {
            var staniste = await Context.Stanista.Where(st => st.ID == s.ID).FirstOrDefaultAsync();
            if (staniste == null)
                return BadRequest(new { Message = $"Nema staništa sa ID-om {s.ID}!" });
            else
            {
                if (s.Trenutno > staniste.Max)
                    return BadRequest(new { Message = $"Kapacitet prevaziđen! Maksimalno može da se doda {staniste.Max - staniste.Trenutno}!" });
            }

            staniste.Trenutno = s.Trenutno;
            staniste.Boja = s.Boja;
            staniste.Vrsta = s.Vrsta;
            Context.Stanista.Update(staniste);
            await Context.SaveChangesAsync();
            return Ok();
        }

        [Route("DodajStaniste/{ZooVrtID}")]
        [HttpPut]
        public async Task<IActionResult> DodajStaniste([FromBody] Staniste st, int ZooVrtID)
        {
            var zv = await Context.ZooVrtovi.Where(z => z.ID == ZooVrtID).FirstOrDefaultAsync();
            if (zv == null)
                return BadRequest(new { Message = $"Nema Zoološkog vrta sa ID-om {ZooVrtID}!" });
            st.ZooVrtID = ZooVrtID;
            Context.Stanista.Add(st);
            await Context.SaveChangesAsync();
            return Ok(st.ID);
        }
    }
}