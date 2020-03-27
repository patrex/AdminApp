using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdminApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AdminApp
{
    public class CreateEventModel : PageModel
    {
        private readonly AppDbContext _db;

        public CreateEventModel(AppDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public AEvent Event { get; set; }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                //Console.WriteLine(Event.EventDateTime);
                await _db.Events.AddAsync(Event);
                await _db.SaveChangesAsync();

                return RedirectToPage("ViewEvents");
            }
            else
            {
                return Page();
            }
        }
    }
}