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
    public class IndexModel : PageModel
    {
        private readonly NavistarGL.Data.ApplicationDbContext _context;

        public IndexModel(NavistarGL.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<departments> departments { get;set; }

        public async Task OnGetAsync()
        {
            departments = await _context.departments.ToListAsync();
        }
    }
}
