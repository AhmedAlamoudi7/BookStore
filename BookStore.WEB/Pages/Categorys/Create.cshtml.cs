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
    public class CreateModel : PageModel
    {

        public Category category { get; set; }
        private readonly ApplicationDbContext _db;

        public CreateModel(Category category, ApplicationDbContext db)
        {
            this.category = category;
            _db = db;
        }

        public void OnGet()
        {
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
                await _db.Categories.AddAsync(category);
                await _db.SaveChangesAsync();
                TempData["success"] = "Add Item Successfully";
                return RedirectToPage("Index");
            }
            return Page();

        }
    }
}