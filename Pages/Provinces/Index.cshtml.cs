using CommunityApp.Data;
using CommunityApp.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CommunityApp.Pages.Provinces
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Province> Provinces { get; set; } = new();

        public async Task OnGetAsync()
        {
            Provinces = await _context.Provinces.ToListAsync();
        }
    }
}
