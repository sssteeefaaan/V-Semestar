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
    public class UpdateVrtModel : PageModel
    {
        [BindProperty]
        public Vrt Vrt { get; set; }
        private ZooContext zoo;

        public UpdateVrtModel(ZooContext context)
        {
            zoo = context;
        }

        public async Task OnGet(int id)
        {
            Vrt = await zoo.Vrtovi.FindAsync(id);
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (!ModelState.IsValid)
            {
                Vrt = await zoo.Vrtovi.FindAsync(id);
                return Page();
            }

            Vrt.ID = id;
            zoo.Vrtovi.Update(Vrt);
            await zoo.SaveChangesAsync();

            return RedirectToPage("./Vrtovi");
        }
    }
}
