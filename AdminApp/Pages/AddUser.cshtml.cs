using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdminApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AdminApp
{
    public class AddUserModel : PageModel
    {
        private readonly AppDbContext _db;

        public AddUserModel(AppDbContext db)
        {
            _db = db;
        }
        public void OnGet()
        {

        }
    }
}