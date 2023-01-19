using Microsoft.AspNetCore.Mvc;
using Second_Task.Models;
using Second_Task_BusinessLayer.Interfaces;
using System.Diagnostics;

namespace Second_Task.Controllers
{
    public class HomeController : Controller
    {
        private readonly IExcelReader _excelReader;
        private readonly IFileManager _fileManager;

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IExcelReader excelReader, IFileManager fileManager)
        {
            _logger = logger;
            _excelReader = excelReader;
            _fileManager = fileManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Privacy()
        {
            await _excelReader.ReadFile(@"D:\Рабочий стол\Visual Studio\Test_tasks_in_RPA\Second_Task\Second_Task\wwwroot\ExcelFiles\DemoExcel.xlsx");
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}