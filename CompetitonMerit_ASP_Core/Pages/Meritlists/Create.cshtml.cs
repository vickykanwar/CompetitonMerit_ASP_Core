using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CompetitonMerit_ASP_Core.Data;
using CompetitonMerit_ASP_Core.Model;

namespace CompetitonMerit_ASP_Core.Pages.Meritlists
{
    public class CreateModel : PageModel
    {
        private readonly CompetitonMerit_ASP_Core.Data.CompetitionMerit _context;

        public CreateModel(CompetitonMerit_ASP_Core.Data.CompetitionMerit context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["SchoolId"] = new SelectList(_context.School, "Id", "School_Name");
        ViewData["Student_participateId"] = new SelectList(_context.Student_participate, "Id", "Student_Name");
        ViewData["SubjectId"] = new SelectList(_context.Subject, "Id", "Subject_Name");
            return Page();
        }

        [BindProperty]
        public Meritlist Meritlist { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Meritlist.Add(Meritlist);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
