using Microsoft.AspNetCore.Mvc;
using Second_Task.Models;
using Second_Task_BusinessLayer.Interfaces;
using System.Diagnostics;
using System.Text.RegularExpressions;

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
            return View();
        }

        public async Task<IActionResult> AddFileToDatabase()
        {
            if (TempData["Exception"] != null)
            {
                ViewData["Exception"] = TempData["Exception"];
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddFile([FromForm(Name = "file")] IFormFile file)
        {
            if (file != null && file.Length > 0)
            {
                string fileName = file.FileName;
                byte[] fileBytes;
                try
                {
                    if (Regex.IsMatch(fileName, @"^.*[^xlsx]xlsx$") == false) throw new Exception("Incorrect file type");
                    using (var ms = new MemoryStream())
                    {
                        file.CopyTo(ms);
                        fileBytes = ms.ToArray();
                    }

                    _fileManager.SaveXslxInFolder(fileBytes, fileName);
                }
                catch (Exception ex)
                {
                    TempData["Exception"] = ex.Message;
                }
            }
            return RedirectToAction("AddFileToDatabase");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}