using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Server.Models;

namespace Server.Pages
{
    public class KluboviModel : PageModel
    {
        public List<VideoKlub> Klubovi { get; set; }
        private KlubContext klub;

        public KluboviModel(KlubContext context) { klub = context; }
        public async Task OnGetAsync()
        {
            Klubovi = await klub.VideoKlubovi.ToListAsync();
        }
    }
}
