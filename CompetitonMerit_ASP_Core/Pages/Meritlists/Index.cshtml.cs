using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CompetitonMerit_ASP_Core.Data;
using CompetitonMerit_ASP_Core.Model;

namespace CompetitonMerit_ASP_Core.Pages.Meritlists
{
    public class IndexModel : PageModel
    {
        private readonly CompetitonMerit_ASP_Core.Data.CompetitionMerit _context;

        public IndexModel(CompetitonMerit_ASP_Core.Data.CompetitionMerit context)
        {
            _context = context;
        }

        public IList<Meritlist> Meritlist { get;set; }

        public async Task OnGetAsync()
        {
            Meritlist = await _context.Meritlist
                .Include(m => m.School)
                .Include(m => m.Student_participate)
                .Include(m => m.Subject).ToListAsync();
        }
    }
}
