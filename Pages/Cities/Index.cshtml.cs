using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CommunityApp.Data;
using CommunityApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CommunityApp.Pages.Cities
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<City> Cities { get; set; }

public async Task OnGetAsync()
{
    Cities = await _context.Cities.Include(c => c.Province).ToListAsync();
}


        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var city = await _context.Cities.FindAsync(id);
            if (city == null)
            {
                return NotFound();
            }

            _context.Cities.Remove(city);
            await _context.SaveChangesAsync();

            return RedirectToPage();
        }
    }
}
