using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NavistarGL.Data;

namespace NavistarGL.Pages.Departments
{
    public class DeleteModel : PageModel
    {
        private readonly NavistarGL.Data.ApplicationDbContext _context;

        public DeleteModel(NavistarGL.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public departments departments { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            departments = await _context.departments.FirstOrDefaultAsync(m => m.DID == id);

            if (departments == null)
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

            departments = await _context.departments.FindAsync(id);

            if (departments != null)
            {
                _context.departments.Remove(departments);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
