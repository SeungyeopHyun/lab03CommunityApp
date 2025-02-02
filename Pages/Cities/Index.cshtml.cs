using CommunityApp.Data;
using CommunityApp.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CommunityApp.Pages.Cities
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<City> Cities { get; set; } = new();

        public async Task OnGetAsync()
        {
            Cities = await _context.Cities.ToListAsync();
        }
    }
}
