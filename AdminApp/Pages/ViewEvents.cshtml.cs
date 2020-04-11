using System.Collections.Generic;
using System.Threading.Tasks;
using AdminApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AdminApp
{
    public class ViewEventsModel : PageModel
    {
        private readonly AppDbContext _db;

        public ViewEventsModel(AppDbContext db)
        {
            _db = db;
        }

        public IEnumerable<APINEvent> Events { get; set; }
        public async Task OnGet()
        {
            Events = await _db.Events.ToListAsync();
        }

        public async Task<IActionResult> OnPostDelete(int? id)
        {
            var someEvent = _db.Events.FindAsync(id);

            if (someEvent != null)
            {
                //_db.Events.Remove(someEvent);
                await _db.SaveChangesAsync();

                return RedirectToPage("ViewEvents");
            }

            return NotFound();
        }
    }
}