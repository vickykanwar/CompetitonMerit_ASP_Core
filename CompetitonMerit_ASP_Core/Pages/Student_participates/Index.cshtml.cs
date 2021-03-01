using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CompetitonMerit_ASP_Core.Data;
using CompetitonMerit_ASP_Core.Model;

namespace CompetitonMerit_ASP_Core.Pages.Student_participates
{
    public class IndexModel : PageModel
    {
        private readonly CompetitonMerit_ASP_Core.Data.CompetitionMerit _context;

        public IndexModel(CompetitonMerit_ASP_Core.Data.CompetitionMerit context)
        {
            _context = context;
        }

        public IList<Student_participate> Student_participate { get;set; }

        public async Task OnGetAsync()
        {
            Student_participate = await _context.Student_participate.ToListAsync();
        }
    }
}
