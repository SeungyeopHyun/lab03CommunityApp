using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CommunityApp.Data;
using CommunityApp.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CommunityApp.Pages.Provinces
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Province> ProvinceList { get; set; } = new List<Province>();

        [BindProperty]
        public Province NewProvince { get; set; } = new Province();

        public void OnGet()
        {
            ProvinceList = _context.Provinces.Include(p => p.Cities).ToList();
        }

        public async Task<IActionResult> OnPostCreateAsync()
        {
            if (!ModelState.IsValid)
            {
                ProvinceList = await _context.Provinces.Include(p => p.Cities).ToListAsync();
                return Page();
            }

            _context.Provinces.Add(NewProvince);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

        public async Task<IActionResult> OnPostDeleteAsync(string provinceCode) // ✅ id -> provinceCode로 변경
        {
            var province = await _context.Provinces
                .Include(p => p.Cities)
                .FirstOrDefaultAsync(p => p.ProvinceCode == provinceCode);

            if (province == null)
            {
                return NotFound();
            }

            _context.Cities.RemoveRange(province.Cities);
            _context.Provinces.Remove(province);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
