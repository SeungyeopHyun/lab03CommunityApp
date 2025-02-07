using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CommunityApp.Data;
using CommunityApp.Models;
using System.Threading.Tasks;

namespace CommunityApp.Pages.Provinces
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public EditModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Province Province { get; set; } = new Province();

        public async Task<IActionResult> OnGetAsync(string provinceCode)
        {
            if (string.IsNullOrEmpty(provinceCode))
            {
                return NotFound();
            }

            Province = await _context.Provinces.FindAsync(provinceCode);

            if (Province == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var existingProvince = await _context.Provinces.FindAsync(Province.ProvinceCode);
            if (existingProvince == null)
            {
                return NotFound();
            }

            // ProvinceCode는 PK이므로 변경하지 않고, ProvinceName만 변경
            existingProvince.ProvinceName = Province.ProvinceName;

            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}
