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
    public class EditModel : PageModel
    {

        public Model.Category category { get; set; }
        private readonly ApplicationDbContext _db;

        public EditModel(Model.Category category, ApplicationDbContext db)
        {
            this.category = category;
            _db = db;
        }

        public async Task OnGet(int id)
        {
         category =  await _db.Categories.FindAsync(id);
        }
        ////Without BindProperty
        //public async Task<IActionResult> OnPost(Model.Category category) {

        //    await _db.Categories.AddAsync(category);
        //    await _db.SaveChangesAsync();
        //    return RedirectToPage("Index");

        //}
        //With BindProperty
        public async Task<IActionResult> OnPost()
        {
            if (category.Name == category.DisplayOrder.ToString())
            {
                ModelState.AddModelError(string.Empty, "The DisplayOrder cannot exactly math the Name.");
            }
            if (ModelState.IsValid)
            {
                 _db.Update(category);
                await _db.SaveChangesAsync();
                TempData["success"] = "Edit Item Successfully";
                return RedirectToPage("Index");
            }
            return Page();

        }
    }
}