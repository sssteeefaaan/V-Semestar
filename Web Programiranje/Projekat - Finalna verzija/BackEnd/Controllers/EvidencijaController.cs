using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Models;

namespace Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EvidencijaController : ControllerBase
    {
        public EvidencijaContext Context { get; set; }

        public EvidencijaController(EvidencijaContext context)
        {
            Context = context;
        }

        #region TurnirCRUD

        [Route("CreateTurnir")]
        [HttpPost]
        public async Task<IActionResult> CreateTurnir([FromBody] Turnir turnir)
        {
            if (turnir.MaxDisciplina > 100 || turnir.MaxDisciplina < 1)
                return BadRequest(new { Message = $"Number of disciplines on the tournament can't be {turnir.MaxDisciplina}. Range is [1-100]!" });
            Context.Turniri.Add(turnir);
            await Context.SaveChangesAsync();
            return Ok(turnir.ID);
        }

        [Route("ReadTurnire")]
        [HttpGet]
        public async Task<List<Turnir>> ReadTurnire()
        {
            return await Context.Turniri.ToListAsync();
        }

        [Route("ReadTurnir/{turnirID}")]
        [HttpGet]
        public async Task<Turnir> ReadTurnir(int turnirID)
        {
            return await Context.Turniri.Where(t => t.ID == turnirID).FirstOrDefaultAsync();
        }

        [Route("UpdateTurnir")]
        [HttpPost]
        public async Task<IActionResult> UpdateTurnir([FromBody] Turnir turnir)
        {
            if (!Context.Turniri.Any(t => t.ID == turnir.ID))
                return BadRequest(new { Message = $"Turnir with the key ({ turnir.ID }) doesn't exist in the database!" });

            if (turnir.MaxDisciplina > 100 || turnir.MaxDisciplina < 1)
                return BadRequest(new { Message = $"Number of disciplines on the tournament can't be {turnir.MaxDisciplina}. Range is [1-100]!" });

            Context.Turniri.Update(turnir);
            await Context.SaveChangesAsync();
            return Ok();
        }

        [Route("DeleteTurnir/{turnirID}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteTurnir(int turnirID)
        {
            var turnir = Context.Turniri.Where(t => t.ID == turnirID).FirstOrDefault();
            if (turnir == null)
                return BadRequest(new { Message = $"Turnir with the key ({ turnirID }) doesn't exist in the database!" });

            var disciplineTurnira = await Context.Discipline.Where(dsc => dsc.TurnirID == turnirID).ToListAsync();
            var ucesniciTurnira = await Context.Ucesnici.Where(uc => uc.TurnirID == turnirID).ToListAsync();

            if (ucesniciTurnira != null)
                ucesniciTurnira.ForEach(uc => Context.Ucesnici.Remove(uc));
            if (disciplineTurnira != null)
                disciplineTurnira.ForEach(dsc => Context.Discipline.Remove(dsc));
            Context.Turniri.Remove(turnir);

            await Context.SaveChangesAsync();
            return Ok();
        }

        #endregion

        #region DisciplinaCRUD

        [Route("CreateDisciplina/{turnirID}")]
        [HttpPost]
        public async Task<IActionResult> CreateDisciplina(int turnirID, [FromBody] Disciplina disciplina)
        {
            var turnir = await Context.Turniri.Where(t => t.ID == turnirID).FirstOrDefaultAsync();
            if (turnir == null)
                return BadRequest(new { Message = $"Turnir with the key ({ turnirID }) doesn't exist in the database!" });

            var discipline = await Context.Discipline.Where(dsc => dsc.TurnirID == turnirID).ToListAsync();
            foreach (var dsc in discipline)
            {
                if (dsc.Naziv == disciplina.Naziv && dsc.Lokacija == disciplina.Lokacija)
                    return BadRequest(new { Message = $"Disciplina with the name {dsc.Naziv} at the location {dsc.Lokacija} already exist!" });
            }

            if (discipline.Count() >= turnir.MaxDisciplina)
                return BadRequest(new { Message = $"Number of disciplines on the tournament can't be {discipline.Count()}! Range is [1-100]!" });

            if (disciplina.MaxUcesnici > 100 || disciplina.MaxUcesnici < 1)
                return BadRequest(new { Message = $"Maksimalni broj učesnika can't be {disciplina.MaxUcesnici}! Range is [1-100]!" });

            disciplina.TurnirID = turnirID;

            Context.Discipline.Add(disciplina);
            Context.Turniri.Update(turnir);

            await Context.SaveChangesAsync();
            return Ok(disciplina.ID);
        }

        [Route("ReadDiscipline")]
        [HttpGet]
        public async Task<List<Disciplina>> ReadDiscipline()
        {
            return await Context.Discipline.ToListAsync();
        }

        [Route("ReadDisciplineSaTurnira/{turnirID}")]
        [HttpGet]
        public async Task<List<Disciplina>> ReadDisciplineSaTurnira(int turnirID)
        {
            return await Context.Discipline.Where(d => d.TurnirID == turnirID).ToListAsync();
        }

        [Route("ReadDisciplina/{disciplinaID}")]
        [HttpGet]
        public async Task<Disciplina> ReadDisciplina(int disciplinaID)
        {
            return await Context.Discipline.Where(dsc => dsc.ID == disciplinaID).FirstOrDefaultAsync();
        }
        [Route("UpdateDisciplina")]
        [HttpPost]
        public async Task<IActionResult> UpdateDisciplina([FromBody] Disciplina disciplina)
        {
            if (!Context.Discipline.Any(dsc => dsc.ID == disciplina.ID && dsc.TurnirID == disciplina.TurnirID))
                return BadRequest(new { Message = $"Disciplina with the key ({disciplina.TurnirID}, {disciplina.ID}) doesn't exist in the database!" });

            if (disciplina.MaxUcesnici > 100 || disciplina.MaxUcesnici < 1)
                return BadRequest(new { Message = $"Maksimalni broj učesnika can't be {disciplina.MaxUcesnici}! Range is [1-100]!" });

            Context.Discipline.Update(disciplina);
            await Context.SaveChangesAsync();
            return Ok();
        }

        [Route("DeleteDisciplina/{turnirID}/{disciplinaID}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteDisciplina(int turnirID, int disciplinaID)
        {
            var turnir = Context.Turniri.Where(t => t.ID == turnirID).FirstOrDefault();
            if (turnir == null)
                return BadRequest(new { Message = $"Turnir with the key ({ turnirID }) doesn't exist in the database!" });

            var disciplina = Context.Discipline.Where(dsc => dsc.TurnirID == turnirID && dsc.ID == disciplinaID).FirstOrDefault();
            if (disciplina == null)
                return BadRequest(new { Message = $"Disciplina with the key ({turnirID}, {disciplinaID}) doesn't exist in the database!" });

            var ucesniciDiscipline = await Context.Ucesnici.Where(uc => uc.DisciplinaID == disciplinaID && uc.TurnirID == turnirID).ToListAsync();

            if (ucesniciDiscipline != null)
                ucesniciDiscipline.ForEach(uc => Context.Ucesnici.Remove(uc));

            Context.Discipline.Remove(disciplina);
            Context.Turniri.Update(turnir);

            await Context.SaveChangesAsync();
            return Ok();
        }

        #endregion

        #region UcesnikCRUD

        [Route("CreateUcesnik/{turnirID}/{disciplinaID}")]
        [HttpPost]
        public async Task<IActionResult> CreateUcesnik(int turnirID, int disciplinaID, [FromBody] Ucesnik ucesnik)
        {
            if (!Context.Turniri.Any(t => t.ID == turnirID))
                return BadRequest(new { Message = $"Turnir with the key ({ turnirID }) doesn't exist in the database!" });

            var disciplina = await Context.Discipline.Where(dsc => dsc.ID == disciplinaID && dsc.TurnirID == turnirID).FirstOrDefaultAsync();
            if (disciplina == null)
                return BadRequest(new { Message = $"Disciplina with the key ({turnirID}, {disciplinaID}) doesn't exist in the database!" });

            if (Context.Ucesnici.Count(uc => uc.DisciplinaID == disciplinaID && uc.TurnirID == turnirID) >= disciplina.MaxUcesnici)
                return BadRequest(new { Message = $"Disciplina with the key ({turnirID}, {disciplinaID}) is at full capacity!" });

            if (ucesnik.Brzina > 30 || ucesnik.Brzina < 20)
                return BadRequest(new { Message = $"Brzina ucesnika can't be {ucesnik.Brzina}! Range is [20-30]!" });

            ucesnik.DisciplinaID = disciplinaID;
            ucesnik.TurnirID = turnirID;

            Context.Ucesnici.Add(ucesnik);
            Context.Discipline.Update(disciplina);

            await Context.SaveChangesAsync();
            return Ok(ucesnik.ID);
        }

        [Route("ReadUcesnike")]
        [HttpGet]
        public async Task<List<Ucesnik>> ReadUcesnike()
        {
            return await Context.Ucesnici.ToListAsync();
        }

        [Route("ReadUcesnikeSaDiscipline/{turnirID}/{disciplinaID}")]
        [HttpGet]
        public async Task<List<Ucesnik>> ReadUcesnikeSaDiscipline(int turnirID, int disciplinaID)
        {
            return await Context.Ucesnici.Where(uc => uc.DisciplinaID == disciplinaID && uc.TurnirID == turnirID).ToListAsync();
        }

        [Route("ReadUcesnik/{ucesnikID}")]
        [HttpGet]
        public async Task<Ucesnik> ReadUcesnik(int ucesnikID)
        {
            return await Context.Ucesnici.Where(ucesnik => ucesnik.ID == ucesnikID).FirstOrDefaultAsync();
        }

        [Route("UpdateUcesnik")]
        [HttpPost]
        public async Task<IActionResult> UpdateUcesnik([FromBody] Ucesnik ucesnik)
        {
            if (!Context.Turniri.Any(t => t.ID == ucesnik.TurnirID))
                return BadRequest(new { Message = $"Turnir with the key ({ ucesnik.TurnirID }) doesn't exist in the database!" });
            if (!Context.Discipline.Any(dsc => dsc.TurnirID == ucesnik.TurnirID && dsc.ID == ucesnik.DisciplinaID))
                return BadRequest(new { Message = $"Disciplina with the key ({ucesnik.TurnirID}, {ucesnik.DisciplinaID}) doesn't exist in the database!" });
            if (!Context.Ucesnici.Any(uc => uc.ID == ucesnik.ID && uc.DisciplinaID == ucesnik.DisciplinaID && uc.TurnirID == ucesnik.TurnirID))
                return BadRequest(new { Message = $"Učesnik with key ({ucesnik.TurnirID}, {ucesnik.DisciplinaID}, {ucesnik.ID}) doesn't exist in the database!" });
            if (ucesnik.Brzina > 30 || ucesnik.Brzina < 10)
                return BadRequest(new { Message = $"Brzina ucesnika can't be {ucesnik.Brzina}! Range is [20-30]!" });

            Context.Ucesnici.Update(ucesnik);
            await Context.SaveChangesAsync();
            return Ok();
        }

        [Route("DeleteUcesnik/{turnirID}/{disciplinaID}/{ucesnikID}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteUcesnik(int turnirID, int disciplinaID, int ucesnikID)
        {
            // if any turniri, discipline sa tunrirID i discipline ID
            if (!Context.Turniri.Any(t => t.ID == turnirID))
                return BadRequest(new { Message = $"Turnir with the key ({ turnirID }) doesn't exist in the database!" });

            var disciplina = Context.Discipline.Where(dsc => dsc.TurnirID == turnirID && dsc.ID == disciplinaID).FirstOrDefault();
            if (disciplina == null)
                return BadRequest(new { Message = $"Disciplina with the key ({turnirID}, {disciplinaID}) doesn't exist in the database!" });

            var ucesnik = Context.Ucesnici.Where(uc => uc.TurnirID == turnirID && uc.DisciplinaID == disciplinaID && uc.ID == ucesnikID).FirstOrDefault();
            if (ucesnik == null)
                return BadRequest(new { Message = $"Učesnik with key ({turnirID}, {disciplinaID}, {ucesnikID}) doesn't exist in the database!" });

            Context.Ucesnici.Remove(ucesnik);
            Context.Discipline.Update(disciplina);

            await Context.SaveChangesAsync();
            return Ok();
        }

        [Route("ForceDeleteUcesnik/{turnirID}/{disciplinaID}/{ucesnikID}")]
        [HttpDelete]
        public async Task<IActionResult> ForceDeleteUcesnik(int turnirID, int disciplinaID, int ucesnikID)
        {
            var disciplina = Context.Discipline.Where(dsc => dsc.TurnirID == turnirID && dsc.ID == disciplinaID).FirstOrDefault();
            var ucesnik = Context.Ucesnici.Where(uc => uc.TurnirID == turnirID && uc.DisciplinaID == disciplinaID && uc.ID == ucesnikID).FirstOrDefault();
            if (ucesnik == null)
                return BadRequest(new { Message = $"Učesnik with key ({turnirID}, {disciplinaID}, {ucesnikID}) doesn't exist in the database!" });

            if (disciplina != null)
            {
                Context.Discipline.Update(disciplina);
            }

            Context.Ucesnici.Remove(ucesnik);


            await Context.SaveChangesAsync();
            return Ok();
        }
        #endregion
    }
}