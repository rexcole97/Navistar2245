using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using NavistarGL.Data;

namespace NavistarGL.Pages.Employees
{
    public class CreateModel : PageModel
    {
        private readonly NavistarGL.Data.ApplicationDbContext _context;

        public CreateModel(NavistarGL.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public employees employees { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.employees.Add(employees);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
