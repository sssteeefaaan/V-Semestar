using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Primer1.Models;

namespace Primer1.Pages
{
    public class ObrisiVrtModel : PageModel
    {
        private ZooContext zoo;
        public ObrisiVrtModel(ZooContext context)
        {
            zoo = context;
        }
        public async Task<IActionResult> OnGetAsync(int id)
        {
            var vrt = await zoo.Vrtovi.FindAsync(id);
            zoo.Vrtovi.Remove(vrt);
            await zoo.SaveChangesAsync();

            return RedirectToPage("./Vrtovi");
        }
    }
}
