using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MvcTodoApp.Models;

namespace MvcTodoApp.Controllers;

public class HomeController : Controller
{

//
private static List<TaskItem> tasks = new List<TaskItem>
    {
    new TaskItem { Id = 1, Title = "على تدرب MVC Design Pattern", IsComplete = false },
    new TaskItem { Id = 2, Title = "على تدرب N-tier Architecture", IsComplete = false },
    new TaskItem { Id = 3, Title = "استخدام على تدرب git", IsComplete = false },
};

    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }


// / <summary>
// .يعرض القائمة الرئيسية للمهام ///
/// </summary>

    public IActionResult Index()
    {
        return View(tasks);
    }


// /// <summary>
// .إضافة مهمة جديدة ///
// /// </summary>
[HttpPost]
public IActionResult AddTask(string title)
{
if (!string.IsNullOrEmpty(title))
{
int newId = tasks.Max(t => t.Id) + 1;
var newTask = new TaskItem { Id = newId, Title = title, IsComplete = false };
tasks.Add(newTask);
}
return RedirectToAction("Index");
}
// /// <summary>
// .تعيين مهمة مكتملة ///
// /// </summary>
[HttpPost]
public IActionResult CompleteTask(int id)
{
var task = tasks.FirstOrDefault(t => t.Id == id);
if (task != null)
task.IsComplete = true;
return RedirectToAction("Index");
}
// /// <summary>
// 6
// .تعديل عنوان المهمة ///
// /// </summary>
// /// <param name="id"> المهمة معرف>/param>
// /// <param name="newTitle">الجديد العنوان>/param>
[HttpPost]
public IActionResult EditTask(int id, string newTitle)
{
// id ابحث عن المهمة باستخدام :TODO //
// غير فارغ newTitle تأكد من أن المهمة موجودة وأن :TODO //
// عدّل عنوان المهمة :TODO //
return RedirectToAction("Index");   
 }




    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

}