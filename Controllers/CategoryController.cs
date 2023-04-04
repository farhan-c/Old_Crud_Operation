using Crud_Operation.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Crud_Operation.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        private CrudDbContext db = new CrudDbContext();
        public async Task<ActionResult> CategoryList()
        {
            return View(await db.Categories.ToListAsync());
        }
        public async Task<ActionResult> ProductList()
        { 
            return View(await db.Products.ToListAsync());
        }
        public async Task<ActionResult> CreateProduct(int id)
        {
            Session["id"] = id;
            await db.SaveChangesAsync();
            return View();
        }
        public async Task<ActionResult> CreateCategory()
        {
            await db.SaveChangesAsync();
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> CreateProduct(Product p,FormCollection form)
        {
            p.CategoryId = Convert.ToInt32(form["Id"]);
            db.Products.Add(p);
            await db.SaveChangesAsync();
            return RedirectToAction("ProductList");
        }
        [HttpPost]
        public async Task<ActionResult> CreateCategory(Category c)
        {
            db.Categories.Add(c);
            await db.SaveChangesAsync();
            return RedirectToAction("CategoryList");
        }
        public async Task<ActionResult> EditProduct(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            await db.SaveChangesAsync();
            return View(product);
        }
        [HttpPost]
        public async Task<ActionResult> EditProduct(Product p)
        {
            db.Entry(p).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return RedirectToAction("ProductList");
        }
        public async Task<ActionResult> EditCategory(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            await db.SaveChangesAsync();
            return View(category);
        }
        [HttpPost]
        public async Task<ActionResult> EditCategory(Category c)
        {
            db.Entry(c).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return RedirectToAction("CategoryList");
        }
        public async Task<ActionResult> DeleteProduct(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            await db.SaveChangesAsync();
            return View(product);
        }
        [HttpPost, ActionName("DeleteProduct")]
        public async Task<ActionResult> DeleteProductConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
            await db.SaveChangesAsync();
            return RedirectToAction("ProductList");
        }
        public async Task<ActionResult> DeleteCategory(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            await db.SaveChangesAsync();
            return View(category);
        }
        [HttpPost, ActionName("DeleteCategory")]
        public async Task<ActionResult> DeleteCategoryConfirmed(int id)
        {
            Category category = db.Categories.Find(id);
            db.Categories.Remove(category);
            await db.SaveChangesAsync();
            return RedirectToAction("CategoryList");

        }
        public async Task<ActionResult> CategoryDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            await db.SaveChangesAsync();
            return View(category);
        }
        public async Task<ActionResult> ProductDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            await db.SaveChangesAsync();
            return View(product);
        }
    }
}