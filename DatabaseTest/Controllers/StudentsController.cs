using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DatabaseTest.Models;
using DatabaseTest.ModelView;

namespace DatabaseTest.Controllers
{
    public class StudentsController : Controller
    {
        private readonly SqlStudentRepository _context;
        private readonly AppDbContext _db;

        public StudentsController(SqlStudentRepository context, AppDbContext db)
        {
            _context = context;
            _db = db;
        }

        // GET: Students
        public async Task<IActionResult> Index()
        {
            var studentAddressViews = from m in _db.Students
                                      join n in _db.Addresses on m.ID equals n.ID
                                      select new StudentAddressViewModel
                                      {
                                          ID = m.ID,
                                          Name = m.Name,
                                          Age = m.Age,
                                          City = n.City,
                                          District = n.District,
                                          Pin = n.Pin
                                      };
            View view = new View()
            {
                studentView = await studentAddressViews.ToListAsync()
            };

            
            return View(view);
        }

        // GET: Students/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = _context.GetAllStudents()
                .FirstOrDefault(m => m.ID == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // GET: Students/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(StudentAddressViewModel studentAddressViewModel)
        {
            if (ModelState.IsValid)
            {
                Student student = new Student();
                student.Name = studentAddressViewModel.Name;
                student.Age = studentAddressViewModel.Age;
                student.Address = new Address
                {
                    City = studentAddressViewModel.City,
                    District = studentAddressViewModel.District,
                    Pin = studentAddressViewModel.Pin
                };
                _context.Create(student);
                return RedirectToAction(nameof(Index));
            }
            return View(studentAddressViewModel);
        }

        // GET: Students/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = _context.GetStudent(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Age")] Student student)
        {
            if (id != student.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(student);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentExists(student.ID))
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
            return View(student);
        }

        // GET: Students/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = _context.GetAllStudents()
                .FirstOrDefault(m => m.ID == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _context.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        private bool StudentExists(int id)
        {
            return _context.GetAllStudents().Any(e => e.ID == id);
        }
    }
}
