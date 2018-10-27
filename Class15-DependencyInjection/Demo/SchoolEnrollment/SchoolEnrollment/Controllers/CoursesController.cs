using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SchoolEnrollment.Data;
using SchoolEnrollment.Models;
using SchoolEnrollment.Models.Interfaces;

namespace SchoolEnrollment.Controllers
{
    public class CoursesController : Controller
    {
        private readonly ICourse _courses;

        public CoursesController(ICourse context)
        {
			_courses = context;
        }

        // GET: Courses
        public async Task<IActionResult> Index()
        {
            return View(await _courses.GetCourses());
        }

		// GET: Courses/Details/5
		public async Task<IActionResult> Details(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			// create new reference to the existing course in the database
			Course course = await _courses.GetCourse(id);

			if (course == null)
			{
				return NotFound();
			}

			return View(course);
		}

		// GET: Courses/Create
		public IActionResult Create()
		{
			return View();
		}

		// POST: Courses/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("ID,Name,Technology,Price")] Course course)
		{
			if (ModelState.IsValid)
			{
				// Create the course through dependency service
				await _courses.CreateCourse(course);

				return RedirectToAction(nameof(Index));
			}
			return View(course);
		}

		// GET: Courses/Edit/5
		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var course = await _courses.GetCourse(id);

			if (course == null)
			{
				return NotFound();
			}
			return View(course);
		}

		// POST: Courses/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Technology,Price")] Course course)
		{
			if (id != course.ID)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{
					await _courses.UpdateCourse(course);
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!CourseExists(course.ID))
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
			return View(course);
		}

		// GET: Courses/Delete/5
		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			Course course = await _courses.GetCourse(id);

			if (course == null)
			{
				return NotFound();
			}

			return View(course);
		}

		// POST: Courses/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			await _courses.DeleteCourse(id);
			return RedirectToAction(nameof(Index));
		}

		private bool CourseExists(int id)
		{
			return _courses.GetCourse(id) != null;
		}
	}
}
