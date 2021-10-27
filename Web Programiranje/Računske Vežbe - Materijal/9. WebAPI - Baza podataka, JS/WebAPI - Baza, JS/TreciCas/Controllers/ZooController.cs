using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TreciCas.Models;

namespace TreciCas.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ZooController : ControllerBase
    {
        public ZooContext Context { get; set; }

        public ZooController(ZooContext context)
        {
            Context = context;
        }

        [Route("PreuzmiVrtove")]
        [HttpGet]
        public async Task<List<Vrt>> PreuzmiVrtove()
        {
            return await Context.Vrtovi.Include(p => p.Lokacije).ToListAsync();
        }

        [Route("UpisiVrt")]
        [HttpPost]
        public async Task UpisiVrt([FromBody] Vrt vrt)
        {
            Context.Vrtovi.Add(vrt);
            await Context.SaveChangesAsync();
        }

        [Route("IzmeniVrt")]
        [HttpPut]
        public async Task IzmeniVrt([FromBody] Vrt vrt)
        {
            //var stariVrt = await Context.Vrtovi.FindAsync(vrt.ID);
            //stariVrt.Kapacitet = vrt.Kapacitet;
            //stariVrt.Naziv = vrt.Naziv;
            //stariVrt.M = vrt.M;
            //stariVrt.N = vrt.N;

            Context.Update<Vrt>(vrt);
            await Context.SaveChangesAsync();
        }

        [Route("IzbrisiVrt/{id}")]
        [HttpDelete]
        public async Task IzbrisiVrt(int id)
        {
            var vrt = await Context.Vrtovi.FindAsync(id);
            Context.Remove(vrt);
            await Context.SaveChangesAsync();
        }

        [Route("UpisLokacije/{idVrta}")]
        [HttpPost]
        // Upis može takođe da se vrši preko FormData, tako što će atribut da bude [FromForm]
        // Aplikacija nema formu, tako da je ovde korišćen FromBody, ali je jednostavnije koristiti FormData.
        public async Task<IActionResult> UpisiLokaciju(int idVrta, [FromBody] Lokacija lok)
        {
            var vrt = await Context.Vrtovi.FindAsync(idVrta);
            lok.Vrt = vrt;

            if (Context.Lokacije.Any(p => p.Vrsta == lok.Vrsta && (p.X != lok.X || p.Y != lok.Y)))
            {
                var xy = Context.Lokacije.Where(p => p.Vrsta == lok.Vrsta).FirstOrDefault();
                return BadRequest(new { X = xy?.X, Y = xy?.Y });
            }

            var thatLok = Context.Lokacije.Where(p => p.X == lok.X && p.Y == lok.Y).FirstOrDefault();

            if (thatLok != null)
            {
                if (thatLok.MaxKapacitet < thatLok.Kapacitet + lok.Kapacitet)
                {
                    return StatusCode(406);
                }
                else if (thatLok.Vrsta != lok.Vrsta)
                {
                    return StatusCode(406);
                }
                else
                {
                    thatLok.Kapacitet += lok.Kapacitet;
                    await Context.SaveChangesAsync();
                    return Ok();
                }
            }

            if ((thatLok != null && thatLok.Kapacitet == 0) || thatLok == null)
            {
                Context.Lokacije.Add(lok);
                await Context.SaveChangesAsync();
                return Ok();
            }
            else
            {
                return StatusCode(406);
            }
        }
    }
}
