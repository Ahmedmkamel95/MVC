using folder_structure.Models;
using Microsoft.AspNetCore.Mvc;

namespace folder_structure.Controllers
{
    public class StudentController : Controller
    {
       List<Student> students = new List<Student>
            {
                new Student { Id = 1,Name= "mrwan", Age= 10 },
                new Student { Id = 2,Name= "Ahmed", Age= 20 },
                new Student { Id = 3,Name= "Mohamed", Age= 30 },
                new Student { Id = 4,Name= "fatma", Age= 40 },
                new Student { Id = 5,Name= "tamer", Age= 50 },
                new Student { Id = 6,Name= "kamel", Age= 60 },
            };
        public IActionResult Index()
        {
            
            students = students.Where(x => x.Age <= 50).ToList();
            return View(students);
        }

        public IActionResult Display(string name)
        {
            ViewData["Name"] = name;
            return View();
        }
        public IActionResult GetById(int id)
        {
            var student = students.Where(x=>x.Id == id).FirstOrDefault();
            return View(student);
        }
        public IActionResult Delete(int id)
        {
            var student = students.Where(x => x.Id == id).FirstOrDefault();
            students.Remove(student);
            return View(student);
        }

    }
}
