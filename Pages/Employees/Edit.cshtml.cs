using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NavistarGL.Data;

namespace NavistarGL.Pages.Employees
{
    public class EditModel : PageModel
    {
        private readonly NavistarGL.Data.ApplicationDbContext _context;

        public EditModel(NavistarGL.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public employees employees { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            employees = await _context.employees.FirstOrDefaultAsync(m => m.EID == id);

            if (employees == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(employees).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!employeesExists(employees.EID))
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

        private bool employeesExists(int id)
        {
            return _context.employees.Any(e => e.EID == id);
        }
    }
}
