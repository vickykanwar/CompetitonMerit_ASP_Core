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
    public class DeleteModel : PageModel
    {
        private readonly CompetitonMerit_ASP_Core.Data.CompetitionMerit _context;

        public DeleteModel(CompetitonMerit_ASP_Core.Data.CompetitionMerit context)
        {
            _context = context;
        }

        [BindProperty]
        public Student_participate Student_participate { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Student_participate = await _context.Student_participate.FirstOrDefaultAsync(m => m.Id == id);

            if (Student_participate == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Student_participate = await _context.Student_participate.FindAsync(id);

            if (Student_participate != null)
            {
                _context.Student_participate.Remove(Student_participate);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
