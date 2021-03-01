using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CompetitonMerit_ASP_Core.Data;
using CompetitonMerit_ASP_Core.Model;

namespace CompetitonMerit_ASP_Core.Pages.Meritlists
{
    public class EditModel : PageModel
    {
        private readonly CompetitonMerit_ASP_Core.Data.CompetitionMerit _context;

        public EditModel(CompetitonMerit_ASP_Core.Data.CompetitionMerit context)
        {
            _context = context;
        }

        [BindProperty]
        public Meritlist Meritlist { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Meritlist = await _context.Meritlist
                .Include(m => m.School)
                .Include(m => m.Student_participate)
                .Include(m => m.Subject).FirstOrDefaultAsync(m => m.Id == id);

            if (Meritlist == null)
            {
                return NotFound();
            }
           ViewData["SchoolId"] = new SelectList(_context.School, "Id", "School_Name");
           ViewData["Student_participateId"] = new SelectList(_context.Student_participate, "Id", "Student_Name");
           ViewData["SubjectId"] = new SelectList(_context.Subject, "Id", "Subject_Name");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Meritlist).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MeritlistExists(Meritlist.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool MeritlistExists(int id)
        {
            return _context.Meritlist.Any(e => e.Id == id);
        }
    }
}
