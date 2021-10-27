using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TreciCas.Models;

namespace TreciCas.Pages
{
    public class CreateVrtModel : PageModel
    {
        [BindProperty]
        public Vrt Vrt { get; set; }

        private ZooContext zoo;

        public CreateVrtModel(ZooContext context)
        {
            zoo = context;
        }

        public void OnGet()
        {
            
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            zoo.Vrtovi.Add(Vrt);
            await zoo.SaveChangesAsync();

            return RedirectToPage("./Vrtovi");
        }
    }
}
