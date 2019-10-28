using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NavistarGL.Data;

namespace NavistarGL.Pages.Employees
{
    public class DetailsModel : PageModel
    {
        private readonly NavistarGL.Data.ApplicationDbContext _context;

        public DetailsModel(NavistarGL.Data.ApplicationDbContext context)
        {
            _context = context;
        }

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
    }
}
