using Microsoft.AspNetCore.Mvc;
using StudentRepositoryDemo.Models;
using StudentRepositoryDemo.Repository;

namespace StudentRepositoryDemo.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentRepository _repository;

        public StudentController(IStudentRepository repository)
        {
            _repository = repository;
        }

        // INDEX
        public IActionResult Index()
        {
            var students = _repository.GetAllStudents();
            return View(students);
        }

        // CREATE GET
        public IActionResult Create()
        {
            return View();
        }

        // CREATE POST
        [HttpPost]
        public IActionResult Create(Student student)
        {
            _repository.AddStudent(student);
            return RedirectToAction("Index");
        }

        // DETAILS
        public IActionResult Details(int id)
        {
            var student = _repository.GetStudentById(id);

            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // EDIT GET
        public IActionResult Edit(int id)
        {
            var student = _repository.GetStudentById(id);

            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // EDIT POST
        [HttpPost]
        public IActionResult Edit(Student student)
        {
            _repository.UpdateStudent(student);
            return RedirectToAction("Index");
        }

        // DELETE
        public IActionResult Delete(int id)
        {
            _repository.DeleteStudent(id);
            return RedirectToAction("Index");
        }
    }
}