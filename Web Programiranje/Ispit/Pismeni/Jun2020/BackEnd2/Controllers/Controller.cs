using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEnd.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Controllers
{
    public class Controller : ControllerBase
    {
        public Context Context { get; set; }

        public Controller(Context cntx) { Context = cntx; }

        [Route("PreuzmiMeceve")]
        [HttpGet]
        public async Task<List<Mec>> PreuzmiMeceve()
        {
            return await Context.Mecevi.Include(m => m.Igraci).ThenInclude(i => i.Poeni).ToListAsync();
        }

        [Route("DodajSet/{IgracID}")]
        [HttpPut]
        public async Task<IActionResult> DodajSet(int IgracID)
        {
            var igrac = Context.Igraci.Where(i => i.ID == IgracID).FirstOrDefault();
            if (igrac == null)
                return BadRequest(new { Message = $"Igrac sa ID-om {IgracID} ne postoji!" });
            var p = new Poen();
            p.Vrednost = 0;
            p.IgracID = IgracID;
            Context.Poeni.Add(p);
            await Context.SaveChangesAsync();
            return Ok();
        }

        [Route("DodajPoen/{IgracID}")]
        [HttpPost]
        public async Task<IActionResult> DodajPoen(int IgracID)
        {
            var igrac = Context.Igraci.Where(i => i.ID == IgracID).FirstOrDefault();
            if (igrac == null)
                return BadRequest(new { Message = $"Igrac sa ID-om {IgracID} ne postoji!" });
            var poen = Context.Poeni.Where(p => p.IgracID == IgracID).LastOrDefault();
            if (poen == null)
                return BadRequest(new { Message = $"Igrac sa ID-om {IgracID} nema poena!" });
            poen.Vrednost += 1;
            if (poen.Vrednost > 6)
                return BadRequest(new { Message = "Maksimalni broj poena u setu je 6!" });
            await Context.SaveChangesAsync();
            return Ok();
        }

        [Route("AzurirajMec")]
        [HttpPost]
        public async Task<IActionResult> AzurirajMec([FromBody] Mec m)
        {
            Context.Mecevi.Update(m);
            await Context.SaveChangesAsync();
            return Ok();
        }

        [Route("AzurirajIgraca")]
        [HttpPost]
        public async Task<IActionResult> AzurirajIgraca([FromBody] Igrac i)
        {
            var igrac = Context.Igraci.Where(igr => igr.ID == i.ID).FirstOrDefault();
            if (igrac == null)
                return BadRequest(new { Message = $"Igrac sa ID-om {i.ID} ne postoji!" });
            igrac.Poeni = i.Poeni;
            await Context.SaveChangesAsync();
            return Ok();
        }

        [Route("ObrisiMec/{MecID}")]
        [HttpDelete]
        public async Task<IActionResult> ObrisiMec(int MecID)
        {
            var mec = Context.Mecevi.Where(m => m.ID == MecID).FirstOrDefault();
            if (mec == null)
                return BadRequest(new { Message = $"Mec sa ID-om {MecID} ne postoji!" });
            Context.Mecevi.Remove(mec);
            await Context.SaveChangesAsync();
            return Ok();
        }
    }
}