using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backEnd.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backEnd.Controllers
{
    public class KluboviController : ControllerBase
    {
        public KluboviContext Context { get; set; }
        public KluboviController(KluboviContext context) { Context = context; }

        [Route("PreuzmiVideoKlubove")]
        [HttpGet]
        public async Task<List<VideoKlub>> PreuzmiVideoKlubove()
        {
            return await Context.VideoKlubovi.Include(vk => vk.Police).ToListAsync();
        }

        [Route("AzurirajPolicu")]
        [HttpPost]
        public async Task<IActionResult> AzurirajPolicu([FromBody] Polica p)
        {
            if (p.Current < p.Max)
                Context.Police.Update(p);
            else
                return BadRequest(new { Message = "Polica je već puna!" });
            await Context.SaveChangesAsync();
            return Ok();
        }

        [Route("ObrisiVideoKlub/{VideoKlubID}")]
        [HttpDelete]
        public async Task<IActionResult> ObrisiVideoKlub(int VideoKlubID)
        {
            var vk = Context.VideoKlubovi.Where(vk => vk.ID == VideoKlubID).FirstOrDefault();
            if (vk == null)
                return BadRequest(new { Message = $"Video Klub sa ID-om {VideoKlubID} ne postoji!" });
            Context.VideoKlubovi.Remove(vk);
            await Context.SaveChangesAsync();
            return Ok();
        }
    }
}