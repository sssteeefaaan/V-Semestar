using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers
{
    public class FabrikaController : ControllerBase
    {
        public EvidencijaContext Context { get; set; }
        public FabrikaController(EvidencijaContext context)
        {
            Context = context;
        }

        [Route("PreuzmiFabrike")]
        [HttpGet]
        public async Task<List<Fabrika>> PreuzmiFabrike()
        {
            return await Context.Fabrike.Include(f => f.Silosi).ToListAsync();
        }

        [Route("PreuzmiSiloseIzFabrike/{FabrikaID}")]
        [HttpGet]
        public async Task<List<Silos>> PreuzmiSiloseIzFabrike(int FabrikaID)
        {
            return await Context.Silosi.Where(s => s.Fabrika.ID == FabrikaID).ToListAsync();
        }

        [Route("NapraviFabriku")]
        [HttpPut]
        public async Task<IActionResult> NapraviFabriku([FromBody] Fabrika f)
        {
            Context.Fabrike.Add(f);
            await Context.SaveChangesAsync();
            return Ok(f.ID);
        }

        [Route("NapraviSilosZaFabriku/{FabrikaID}")]
        [HttpPut]
        public async Task<IActionResult> NapraviSilosZaFabriku([FromBody] Silos s, int FabrikaID)
        {
            var f = Context.Fabrike.Where(f => f.ID == FabrikaID).FirstOrDefault();
            if (f == null)
                return BadRequest(new { Message = $"Ne postoji fabrika sa id-om:{FabrikaID}!" });
            s.Fabrika = f;
            Context.Silosi.Add(s);
            await Context.SaveChangesAsync();
            return Ok(s.ID);
        }

        [Route("PreuzmiFabriku/{FabrikaID}")]
        [HttpGet]
        public async Task<Fabrika> PreuzmiFabriku(int FabrikaID)
        {
            return await Context.Fabrike.Where(f => f.ID == FabrikaID).Include(f => f.Silosi).FirstOrDefaultAsync();
        }

        [Route("PreuzmiSilos/{SilosID}")]
        [HttpGet]
        public async Task<Silos> PreuzmiSilos(int SilosID)
        {
            return await Context.Silosi.Where(s => s.ID == SilosID).FirstOrDefaultAsync();
        }

        [Route("AzurirajFabriku")]
        [HttpPost]
        public async Task AzurirajFabriku([FromBody] Fabrika fabrika)
        {
            Context.Fabrike.Update(fabrika);
            await Context.SaveChangesAsync();
        }

        [Route("AzurirajSilos")]
        [HttpPost]
        public async Task<IActionResult> AzurirajSilos([FromBody] Silos silos)
        {
            if (silos.Kapacitet < silos.TrenutnaKolicina)
                return BadRequest(new { Message = "Količina prevazilazi dozvoljeni kapacitet!" });
            Context.Silosi.Update(silos);
            await Context.SaveChangesAsync();
            return Ok();
        }

        [Route("ObrisiFabriku/{FabrikaID}")]
        [HttpDelete]
        public async Task ObrisiFabriku(int FabrikaID)
        {
            Context.Fabrike.Remove(Context.Fabrike.Where(f => f.ID == FabrikaID).FirstOrDefault());
            await Context.SaveChangesAsync();
        }

        [Route("ObrisiSilos/{SilosID}")]
        [HttpDelete]
        public async Task ObrisiSilos(int SilosID)
        {
            Context.Silosi.Remove(Context.Silosi.Where(s => s.ID == SilosID).FirstOrDefault());
            await Context.SaveChangesAsync();
        }

    }
}