using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Pages
{
    public class IndexModel : PageModel
    {
        private Context _context;
        public List<Staniste> Stanista { get; set; }

        public IndexModel(Context context) { _context = context; }

        public async Task OnGetAsync()
        {
            Stanista = _context.Stanista.ToList();
        }
    }
}