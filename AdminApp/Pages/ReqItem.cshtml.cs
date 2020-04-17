using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdminApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AdminApp.Pages
{
    public class ReqItemModel : PageModel
    {
        private readonly AppDbContext _db;

        public ReqItemModel(AppDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public string Item { get; set; }

        [BindProperty]
        public IEnumerable<StoreItems> Items { get; set; }

        public List<SelectListItem> Options { get; set; }

        [BindProperty]
        public APINUser Requester { get; set; }

        [BindProperty]
        public Requests UserRequest { get; set; }

        public async Task OnGet(string id)
        {
            Requester = await _db.Users.FindAsync(id);   //fetch the current user

            if (Requester != null) 
            {
                Items = await _db.StoreItems.ToListAsync();

                //populate the select list
                Options = Items.Select(a => 
                                        new SelectListItem { 
                                            Value = a.ItemName,
                                            Text = a.ItemName
                                        }).ToList();
            } 
            else
            {
                RedirectToPage("Error");    //Current user not found
            }
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                await _db.Requests.AddAsync(UserRequest);

                var y = 8;

                return RedirectToPage("UserDashboard");
            }
            else
            {
                return RedirectToPage();
            }
        }
        
    }
}