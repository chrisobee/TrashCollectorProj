using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TrashCollector.Data;
using TrashCollector.Models;
using TrashCollector.ViewModels;

namespace TrashCollector.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly ApplicationDbContext _context;
        public EmployeesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Employees
        public IActionResult Index()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var employee = _context.Employees.Include(e => e.Address).Where(e => e.IdentityUserId == userId).FirstOrDefault();
            if(employee == null)
            {
                return RedirectToAction("Create");
            }
            var currentDay = DateTime.Now.DayOfWeek;
            var customers = _context.Customers.Include(c => c.Address).Where(c => c.PickupDay == currentDay && 
                                                                            c.Address.Zipcode == employee.Address.Zipcode).ToList();
            return View(customers);
        }

        // POST: Employees/Index
        [HttpPost]
        public IActionResult Index(DayOfWeek filteredDay)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var employee = _context.Employees.Include(e => e.Address).Where(e => e.IdentityUserId == userId).FirstOrDefault();

            var customers = _context.Customers.Include(c => c.Address).Where(c => c.PickupDay == filteredDay &&
                                                                             c.Address.Zipcode == employee.Address.Zipcode).ToList();
            return View(customers);
        }
        public async Task<IActionResult> ChargeCustomer(int? id)
        {
            double pricePerPickup = 5.00;
            var customer = await _context.Customers.Where(c => c.Id == id).FirstOrDefaultAsync();
            customer.Balance += pricePerPickup;
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        // GET: Employees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // GET: Employees/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EmployeeWithAddress employeeWithAddress)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employeeWithAddress.Address);
                await _context.SaveChangesAsync();

                employeeWithAddress.Employee.IdentityUserId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                employeeWithAddress.Employee.AddressId = employeeWithAddress.Address.AddressId;
                _context.Add(employeeWithAddress.Employee);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View(employeeWithAddress);
        }

        // GET: Employees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Employee employee)
        {
            if (id != employee.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(employee.Id))
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
            return View(employee);
        }

        // GET: Employees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employees.Any(e => e.Id == id);
        }
    }
}
