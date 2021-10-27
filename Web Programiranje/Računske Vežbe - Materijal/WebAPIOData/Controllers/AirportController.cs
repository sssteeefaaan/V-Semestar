using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPIOData.Models;

namespace WebAPIOData.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AirportController : ControllerBase
    {
        private AirportContext airportContext;

        public AirportController(AirportContext context)
        {
            airportContext = context;
        }

        [HttpGet]
        [Route("Airports")]
        // public Task<IActionResult<string>> ...
        public ActionResult<List<Airport>> GetAirports()
        {
            return airportContext.Airports.ToList();
            // return Ok("Podatak");
            // return Content("Podatak");
            // return BadRequest("Podatak");
        }

        [HttpGet]
        [Route("Routes")]
        public ActionResult<List<Route>> GetRoutes()
        {
            // Explicit loading!!!
            // var r = context.Routes.Where(p => p.Passangers > 500).FirstOrDefault();
            // context.Entry<Route>(r).Reference(p => p.FromAirportRef).Load();
            // context.Entry<Route>(r).Reference(p => p.ToAirportRef).Load();
            // return r;
            // Eager loading!!!
            // return context.Routes.Include(p => p.FromAirportRef).Include(p => p.ToAirportRef).ToList();
            
            // Include, ThenInclude!!!
            // .Include(p => p.FromAirportRef).ThenInclude(p => p.TrecaKlasa);

            // Lazy loading!!!
            // return airportContext.Routes.First().FromAirportRef.City;

            return airportContext.Routes.ToList();
        }

        [HttpGet]
        [Route("GetRoute/{cityFrom}")]
        [EnableCors("CORSAll")]
        public JsonResult GetRoutesFromCity(string cityFrom)
        {
            var routes = airportContext.Routes
                        .Where(p => p.FromAirport == cityFrom)
                        .Include(p => p.FromAirportRef)
                        .Include(p => p.ToAirportRef)
                        .ToList();
            return new JsonResult(routes);
        }
    }
}
