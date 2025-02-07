using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CommunityApp.Data;
using CommunityApp.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CommunityApp.Pages.Cities
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public EditModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public City City { get; set; } = new City();

        // ✅ ProvinceList를 public으로 선언하고 초기화
        [BindProperty]
        public List<SelectListItem> ProvinceList { get; set; } = new List<SelectListItem>();

        public async Task<IActionResult> OnGetAsync(int id)
        {
            City = await _context.Cities.FindAsync(id);
            if (City == null)
            {
                return NotFound();
            }

            // Province 리스트 추가
            ProvinceList = await _context.Provinces
                .Select(p => new SelectListItem { Value = p.ProvinceCode, Text = p.ProvinceName })
                .ToListAsync();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                // Province 목록 다시 불러오기 (Validation 실패 시 필요)
                ProvinceList = await _context.Provinces
                    .Select(p => new SelectListItem { Value = p.ProvinceCode, Text = p.ProvinceName })
                    .ToListAsync();

                return Page();
            }

            var existingCity = await _context.Cities.FindAsync(City.CityId);
            if (existingCity == null)
            {
                return NotFound();
            }

            // ProvinceCode 검증
            var province = await _context.Provinces.FindAsync(City.ProvinceCode);
            if (province == null)
            {
                ModelState.AddModelError("City.ProvinceCode", "Invalid Province Code.");
                ProvinceList = await _context.Provinces
                    .Select(p => new SelectListItem { Value = p.ProvinceCode, Text = p.ProvinceName })
                    .ToListAsync();

                return Page();
            }

            existingCity.CityName = City.CityName;
            existingCity.Population = City.Population;
            existingCity.ProvinceCode = City.ProvinceCode;

            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}
