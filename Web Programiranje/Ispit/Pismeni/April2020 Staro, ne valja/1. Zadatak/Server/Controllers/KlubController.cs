using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Models;

namespace Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VideoKlubController : ControllerBase
    {
        public KlubContext Context { get; set; }

        public VideoKlubController(KlubContext context)
        {
            Context = context;
        }

        [Route("PreuzmiVideoKlubove")]
        [HttpGet]
        public async Task<List<VideoKlub>> PreuzmiVideoKlubove()
        {
            return await Context.VideoKlubovi.Include(p => p.Police).ToListAsync();
        }

        [Route("UpisiVideoKlub")]
        [HttpPost]
        public async Task UpisiVideoKlub([FromBody] VideoKlub vk)
        {
            Context.VideoKlubovi.Add(vk);
            await Context.SaveChangesAsync();
        }

        [Route("IzmeniVideoKlub")]
        [HttpPut]
        public async Task IzmeniVideoKlub([FromBody] VideoKlub vk)
        {
            Context.Update<VideoKlub>(vk);
            await Context.SaveChangesAsync();
        }

        [Route("IzbrisiVideoKlub/{id}")]
        [HttpDelete]
        public async Task IzbrisiVideoKlub(int id)
        {
            var vk = await Context.FindAsync<VideoKlub>(id);
            Context.Remove<VideoKlub>(vk);
            await Context.SaveChangesAsync();
        }

        [Route("UnesiPolicu/{id}")]
        [HttpPost]
        public async Task<IActionResult> UnesiPolicu(int id, [FromBody] Polica polica)
        {
            var Vk = await Context.VideoKlubovi.FindAsync(id);
            if (Vk == null)
                return BadRequest("Video klub sa id-om: " + id + " ne postoji!");

            foreach (var postojecaPolica in Vk.Police)
            {
                if (postojecaPolica.Oznaka == polica.Oznaka && postojecaPolica.VideoKlubID == id)
                    return BadRequest("Polica već postoji!");
            }

            polica.VideoKlub = Vk;
            polica.VideoKlubID = id;
            Context.Police.Add(polica);
            await Context.SaveChangesAsync();
            return Ok();
        }

        // Koji je najbolji način rešavanja ovog problema?
        // - Obrisati vezu sa VideoKlubom?
        // - Smatrati Policu zavisnim entitetom i obrisati i nju?
        [Route("UklonitePolicu/{id}/{oznaka}")]
        [HttpDelete]
        public async Task<IActionResult> UklonitePolicu(int id, string oznaka)
        {
            var Vk = await Context.FindAsync<VideoKlub>(id);
            if (Vk == null)
                return BadRequest("Video klub sa id-om: " + id + " ne postoji!");

            var polica = Context.Police.Where(p => p.Oznaka == oznaka && p.VideoKlubID == id).FirstOrDefault();
            if (polica == null)
                return BadRequest("Ne postoji polica " + oznaka + " u video klubu sa id-om " + id + "!");

            Context.Remove<Polica>(polica);
            await Context.SaveChangesAsync();
            return Ok();
        }

        [Route("PromeniDVD/{id}/{zanr}/{kolicina}")]
        [HttpPost]
        public async Task<IActionResult> UnesiDVD(int id, string zanr, int kolicina)
        {
            var polica = Context.Police.Where(p => p.Oznaka == zanr && p.VideoKlubID == id).FirstOrDefault();
            if (polica == null)
                return BadRequest("Polica sa žanrom \"" + zanr + "\" ne postoji u video klubu sa id-om " + id);
            if (polica.Curr + kolicina > polica.Max || polica.Curr + kolicina < 0)
                return BadRequest("Polica " + zanr + " u video klubu sa id-om " + id + " nema dovoljan kapacitet!");
            polica.Curr += kolicina;
            await Context.SaveChangesAsync();
            return Ok();
        }
    }
}