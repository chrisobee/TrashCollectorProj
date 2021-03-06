﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Stripe;
using TrashCollector.Data;
using TrashCollector.Models;
using TrashCollector.ViewModels;

namespace TrashCollector.Controllers
{
    [Authorize(Roles = "Customer")]
    public class CustomersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CustomersController(ApplicationDbContext context)
        {
            _context = context;
        }

        public void TestAPI()
        {
            StripeConfiguration.ApiKey = "sk_test_QXLWoazG2Z3Fr0EmJziWCTNo00DuNT5jxU";

            var options = new PaymentIntentCreateOptions
            {
                Amount = 1000,
                Currency = "usd",
                PaymentMethodTypes = new List<string> { "card" },
                ReceiptEmail = "jenny.rosen@example.com",
            };
            var service = new PaymentIntentService();
            service.Create(options);
        }

        // GET: Customers
        public async Task<IActionResult> Index()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var customer = await _context.Customers.Include(c => c.Address).Where(c => c.IdentityUserId == userId).FirstOrDefaultAsync();
            if(customer == null)
            {
                return RedirectToAction("Create");
            }
            return View(customer);
        }

        //GET: Customers/Date
        public async Task<IActionResult> Date(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers.Where(c => c.Id == id).FirstOrDefaultAsync();
            return View(customer);
        }

        // POST: Customers/Date
        [HttpPost]
        public IActionResult Date(int? id, Models.Customer customer)
        {
            var customerToUpdate =  _context.Customers.Where(c => c.Id == id).FirstOrDefault();
            customerToUpdate.OneTimePickup = customer.OneTimePickup;
            customerToUpdate.TempStart = customer.TempStart;
            customerToUpdate.TempEnd = customer.TempEnd;
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
        // GET: Customers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers
                .Include(c => c.Address)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // GET: Customers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CustomerWithAddress customerWithAddress)
        {
            if (ModelState.IsValid)
            {
                _context.Add(customerWithAddress.Address);
                await _context.SaveChangesAsync();

                customerWithAddress.Customer.IdentityUserId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                customerWithAddress.Customer.AddressId = customerWithAddress.Address.AddressId;
                _context.Add(customerWithAddress.Customer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", customerWithAddress.Customer.IdentityUserId);
            return View(customerWithAddress);
        }

        // GET: Customers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers.Include(c => c.Address).FirstOrDefaultAsync(c => c.Id == id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Models.Customer customer)
        {
            if (id != customer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var customerToUpdate = _context.Customers.Include(c=>c.Address).Where(c => c.Id == id).FirstOrDefault();
                    customerToUpdate.Address = customer.Address;
                    customerToUpdate.Name = customer.Name;
                    customerToUpdate.PickupDay = customer.PickupDay;
                    _context.Update(customerToUpdate);

                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerExists(customer.Id))
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
            return View(customer);
        }

        // GET: Customers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers
                .Include(c => c.IdentityUser)
                .Include(c => c.Address)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomerExists(int id)
        {
            return _context.Customers.Any(e => e.Id == id);
        }
    }
}
