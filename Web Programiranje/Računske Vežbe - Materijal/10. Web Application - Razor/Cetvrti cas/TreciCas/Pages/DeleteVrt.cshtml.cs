using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TreciCas.Models;

namespace TreciCas.Pages
{
    public class DeleteVrtModel : PageModel
    {
        private ZooContext zoo;
        public DeleteVrtModel(ZooContext context)
        {
            zoo = context;
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var vrt = zoo.Vrtovi.Include(p => p.Lokacije).Where(p => p.ID == id).FirstOrDefault();
            zoo.Vrtovi.Remove(vrt);
            await zoo.SaveChangesAsync();

            return RedirectToPage("./Vrtovi");
        }
    }
}
