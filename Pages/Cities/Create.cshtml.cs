using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CommunityApp.Data;
using CommunityApp.Models;

namespace CommunityApp.Pages.Cities
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        [BindProperty]
        public City City { get; set; } = new City();

        public CreateModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Cities.Add(City);
            _context.SaveChanges();

            return RedirectToPage("./Index"); // 리스트 페이지로 이동
        }
    }
}
