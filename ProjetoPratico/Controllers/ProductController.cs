using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjetoPratico.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoPratico.Controllers
{
    public class ProductController : Controller
    {
        private readonly Context _context;

        public ProductController(Context context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var product = _context.Products
                          .Include(c => c.Category)
                          .AsNoTracking();
            return View(await product.ToListAsync()) ;
        }

        [HttpGet]
        public IActionResult CreateProduct()
        {
            FillCategory();

            return View();
        } 

        [HttpPost]
        public async Task<IActionResult> CreateProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(product);
            }
        }

        [HttpGet]
        public IActionResult UpdateProduct(int? id)
        {
            if(id != null)
            {
                FillCategory();

                Product product = _context.Products.Find(id);
                return View(product);
            }
            else
            {
                return NotFound();

            }

        }

        [HttpPost]
        public async Task<IActionResult> UpdateProduct(int? id, Product product)
        {
            if(id != null)
            {
                if (ModelState.IsValid)
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View(product);
                }
            }
            else
            {
                return View(product);
            }
        }

        [HttpGet]
        public IActionResult DeleteProduct(int? id)
        {
            if(id != null)
            {
                Product product = _context.Products.Find(id);
                return View(product);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> DeleteProduct(int? id, Product product)
        {
            if (id != null)
            {
            
                    _context.Remove(product);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
              
            }
            else
            {
                return View(product);

            }
        }
        private void FillCategory()
        {
            ViewBag.CategoryId = new SelectList
            (
                 _context.Categorys.ToList(),
                "Id",
                "Name"
            );
        }
    }

}
