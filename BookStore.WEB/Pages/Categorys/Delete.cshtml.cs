using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.WEB.Data;
using BookStore.WEB.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookStore.WEB.Pages.Categorys
{
    [BindProperties]
    public class DeleteModel : PageModel
    {

        public Category category { get; set; }
        private readonly ApplicationDbContext _db;

        public DeleteModel(ApplicationDbContext db)
        {
            _db = db;
        }


        public void OnGet(int id)
        {
            category = _db.Categories.Find(id);
        }

        ////Without BindProperty
        //public async Task<IActionResult> OnPost(Model.Category category) {

        //    await _db.Categories.AddAsync(category);
        //    await _db.SaveChangesAsync();
        //    return RedirectToPage("Index");

        //}

        public async Task<IActionResult> OnPost()
        {
      
                var categordb = await _db.Categories.FindAsync(category.Id);
                if (categordb != null)
                {
                    _db.Categories.Remove(categordb);
                    await _db.SaveChangesAsync();
                TempData["success"] = "Delete Item Successfully";
                return RedirectToPage("Index");
                }
  
            
            return Page();

        }
    }
}