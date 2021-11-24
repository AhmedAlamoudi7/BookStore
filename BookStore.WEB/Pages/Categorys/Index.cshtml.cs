using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.WEB.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookStore.WEB.Pages.Categorys
{
    public class IndexModel : PageModel
    {


        public ApplicationDbContext _db;
        public List<BookStore.WEB.Model.Category> Categories { get; set; }


        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public void OnGet()
        {
            Categories = _db.Categories.ToList();
        }
    }
}
