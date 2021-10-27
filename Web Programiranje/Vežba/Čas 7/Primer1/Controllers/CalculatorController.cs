using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace Primer1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {
        [HttpGet]
        [Route("Add/{a}/{b}")]
        public double Add(double a, double b) { return a + b; }

        [HttpGet]
        [Route("Subtract/{a}/{b}")]
        public double Subtract(double a, double b) { return a - b; }

        [HttpGet]
        [Route("Multiply/{a}/{b}")]
        public double Multiply(double a, double b) { return a * b; }

        [HttpGet]
        [Route("Divide/{x}/{y}")]
        public double Divide([FromRoute(Name = "x")] double a, [FromRoute(Name = "y")] double b)
        { return a / b; }

        [HttpPost]
        [Route("DivideAll")]
        public IEnumerable<double> DivideAll([FromBody] double[] array)
        {
            for (int i = 0; i < array.Length; i += 2)
            {
                yield return array[i] / array[i + 1];
            }
        }
    }
}