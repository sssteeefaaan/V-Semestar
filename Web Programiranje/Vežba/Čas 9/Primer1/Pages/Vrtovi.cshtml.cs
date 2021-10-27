using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Primer1.Models;

namespace Primer1.Pages
{
    public class VrtoviModel : PageModel
    {
        public List<Vrt> Vrtovi { get; set; }
        private ZooContext zoo;
        public VrtoviModel(ZooContext context)
        {
            zoo = context;
        }
        public async Task OnGetAsync()
        {
            Vrtovi = await zoo.Vrtovi.ToListAsync();
        }
    }
}
