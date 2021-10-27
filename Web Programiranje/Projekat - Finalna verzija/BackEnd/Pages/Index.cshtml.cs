using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Server.Pages
{
    public class IndexModel : PageModel
    {
        public void OnGet()
        {
        }

        public IActionResult OnPost(string izbor)
        {
            return Redirect($"./View{izbor}");
        }
    }
}
