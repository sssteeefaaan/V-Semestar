using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI_1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MathController : ControllerBase
    {
        [HttpGet]
        [Route("Sabiranje/{x}/{y}")]
        public double Sabiranje(double x, double y)
        {
            return x + y;
        }

        [HttpGet]
        [Route("Oduzimanje/{x}/{y}")]
        public double Oduzimanje(double x, double y)
        {
            return x - y;
        }

        [HttpGet]
        [Route("Mnozenje/{x}/{y}")]
        public double Mnozenje(double x, double y)
        {
            return x * y;
        }

        [HttpGet]
        [Route("Deljenje/{x}/{y}")]
        public double Deljenje(double x, double y)
        {
            return x / y;
        }

        [HttpPost]
        [Route("DeljenjeVise")]
        public IEnumerable<double> DeljenjeVise([FromBody] double[] niz)
        {
            for (int i = 0; i < niz.Length - 1; i += 2)
            {
                yield return niz[i] / niz[i + 1];
            }
        }
    }
}
