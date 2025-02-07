using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CommunityApp.Data;
using CommunityApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommunityApp.Pages.Cities
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CreateModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public City City { get; set; } = new City();

        // ✅ ProvinceList를 public으로 선언
        public List<SelectListItem> ProvinceList { get; set; } = new List<SelectListItem>();

        public async Task<IActionResult> OnGetAsync()
        {
            // Province 리스트 가져오기
            ProvinceList = await _context.Provinces
                .Select(p => new SelectListItem { Value = p.ProvinceCode, Text = p.ProvinceName })
                .ToListAsync();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                // Province 리스트 다시 로드 (Validation 실패 시)
                ProvinceList = await _context.Provinces
                    .Select(p => new SelectListItem { Value = p.ProvinceCode, Text = p.ProvinceName })
                    .ToListAsync();

                return Page();
            }

            _context.Cities.Add(City);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
