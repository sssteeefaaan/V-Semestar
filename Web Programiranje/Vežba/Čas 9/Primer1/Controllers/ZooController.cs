using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Primer1.Models;

namespace Primer1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ZooController : ControllerBase
    {
        public ZooContext Context { get; set; }
        public ZooController(ZooContext context)
        { Context = context; }

        [Route("PreuzmiVrtove")]
        [HttpGet]
        public async Task<List<Vrt>> PreuzmiVrtove()
        {
            // Bitno include da bi vratio i informacije o lokacijama, u suprotnom postavlja na null
            return await Context.Vrtovi.Include(p => p.Lokacije).ToListAsync();
        }

        [Route("UpisiVrt")]
        [HttpPost]
        public async Task UpisiVrt([FromBody] Vrt vrt)
        {
            Context.Vrtovi.Add(vrt); // Može i async
            await Context.SaveChangesAsync();
        }

        [Route("IzmeniVrt")]
        [HttpPut]
        public async Task IzmeniVrt([FromBody] Vrt vrt)
        {
            // var stariVrt = await Context.Vrtovi.FindAsync(vrt.ID);
            // stariVrt.Kapacitet = vrt.Kapacitet;
            // stariVrt.Naziv = vrt.Naziv;
            // stariVrt.N = vrt.N;
            // stariVrt.M = vrt.M;

            Context.Update<Vrt>(vrt);
            await Context.SaveChangesAsync();
        }

        [Route("ObrisiVrt/{id}")]
        [HttpDelete]
        public async Task ObrisiVrt(int id)
        {
            var vrt = await Context.Vrtovi.FindAsync(id);
            Context.Remove(vrt);
            await Context.SaveChangesAsync();
        }

        // No idea what the actual fuck is going on here
        [Route("DodajLokaciju/{idVrta}")]
        [HttpPost]
        public async Task<IActionResult> DodajLokaciju(int idVrta, [FromBody] Lokacija lokacija)
        {
            var vrt = await Context.Vrtovi.FindAsync(idVrta);
            lokacija.Vrt = vrt;

            if (Context.Lokacije.Any(p => p.Vrsta == lokacija.Vrsta && (p.X != lokacija.X || p.Y != lokacija.Y)))
            {
                var xy = Context.Lokacije.Where(p => p.Vrsta == lokacija.Vrsta).FirstOrDefault();
                return BadRequest(new { x = xy?.X, y = xy?.Y });
            }

            var thatLok = Context.Lokacije.Where(p => p.X == lokacija.X && p.Y == lokacija.Y).FirstOrDefault();
            if (thatLok != null)
            {
                if (thatLok.MaxKapacitet < thatLok.Kapacitet + lokacija.Kapacitet)
                {
                    return StatusCode(406);
                }
                else if (thatLok.Vrsta != lokacija.Vrsta)
                {
                    return StatusCode(406);
                }
                else
                {
                    thatLok.Kapacitet += lokacija.Kapacitet;
                    await Context.SaveChangesAsync();
                    return Ok();
                }
            }

            if ((thatLok != null && thatLok.Kapacitet == 0) || thatLok == null)
            {
                Context.Lokacije.Add(lokacija);
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