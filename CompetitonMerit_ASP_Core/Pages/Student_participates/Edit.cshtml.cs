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

namespace CompetitonMerit_ASP_Core.Pages.Student_participates
{
    public class EditModel : PageModel
    {
        private readonly CompetitonMerit_ASP_Core.Data.CompetitionMerit _context;

        public EditModel(CompetitonMerit_ASP_Core.Data.CompetitionMerit context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Student_participate).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Student_participateExists(Student_participate.Id))
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

        private bool Student_participateExists(int id)
        {
            return _context.Student_participate.Any(e => e.Id == id);
        }
    }
}
