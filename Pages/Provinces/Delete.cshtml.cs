using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CommunityApp.Data;
using CommunityApp.Models;

namespace CommunityApp.Pages.Provinces
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DeleteModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnPost(string id)
        {
            var province = _context.Provinces.Find(id);

            if (province == null)
            {
                return NotFound();
            }

            _context.Provinces.Remove(province);
            _context.SaveChanges();

            return RedirectToPage("./Index");
        }
    }
}
