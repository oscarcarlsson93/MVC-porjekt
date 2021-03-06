﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Mvc02.Data;
using Mvc02.Models;

namespace Mvc02.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Products
        public async Task<IActionResult> Index(int? id)
        {
            if (id == null)
            {
                var xxx = await _context.Product.Include(x => x.Category).ToListAsync();
                return View(xxx);

            }
            else if (id == 1)
            {
                var xxx = await _context.Product.Include(x => x.Category).OrderBy(x => x.Name).ToListAsync();
                return View(xxx);
            }
            else if (id == 2)
            {
                var xxx = await _context.Product.Include(x => x.Category).OrderBy(x => x.CategoryId).ToListAsync();
                return View(xxx);
            }
            else if (id == 3)
            {
                var xxx = await _context.Product.Include(x => x.Category).OrderBy(x => x.Price).ToListAsync();
                return View(xxx);
            }
            else
            {
                var xxx = await _context.Product.Include(x => x.Category).OrderBy(x => x.Name).ToListAsync();
                return View(xxx);
            }
            
        }

        public async Task<IActionResult> Search(string q)
        {
            var xxx = await _context.Product.Include(x => x.Category).Where(x => x.Name == q).ToListAsync();
            return View(xxx);
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product.Include(x => x.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/Create
        public IActionResult Create()
        {

            var listofCategory = _context.Categories;

            var vm = new CreateProductVm();

            var list = new List<SelectListItem>();
            foreach (var category in listofCategory)
            {
                list.Add(new SelectListItem
                {
                    Text = category.Name,
                    Value = category.Id.ToString(),

                }
                );
            }
            vm.AllCategories = list;
            return View(vm);

        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Price,CategoryId,ForSale,Description")] Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            

            var viewmodel = new CreateProductVm()
            {
                AllCategories = _context.Categories.Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() }),
                Product = await _context.Product.FindAsync(id)
            };
            return View(viewmodel);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Price,CategoryId,ForSale")] Product product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Product.FindAsync(id);
            _context.Product.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _context.Product.Any(e => e.Id == id);
        }
        public async Task<IActionResult> Block2(IdentityUser user)
        {
            //var user2 = await _context.Users.FindAsync(user.Email);
            DateTime now = DateTime.Now;
            DateTime Now5 = now.AddMinutes(1);
            user.LockoutEnd = Now5;
            _context.Update(user);
            return View();
        }
    }
}
