using Microsoft.AspNetCore.Mvc;
using Second_Task.Models;
using Second_Task.Models.DatabaseModels;
using Second_Task.Models.FileModels;
using Second_Task_BusinessLayer.Interfaces;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace Second_Task.Controllers
{
    public class HomeController : Controller
    {
        private readonly IExcelManager _excelManager;
        private readonly IFileManager _fileManager;

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IExcelManager excelManager, IFileManager fileManager)
        {
            _logger = logger;
            _excelManager = excelManager;
            _fileManager = fileManager;
        }

        public async Task<IActionResult> FileManagement()
        {
            FileViewModel fileViewModel = new();

            //Getting exception messages
            if (TempData["Exception"] != null)
            {
                fileViewModel.Errors.Add(TempData["Exception"].ToString());
            }

            try
            {
                //Get info about files in folder (Name and if file with the same name is already in the database)
                fileViewModel.FileEntities = await _fileManager.GetFolderFileEntities();
                fileViewModel.DbFiles = await _excelManager.GetFilesInfo();
            }
            catch (Exception ex)
            {
                fileViewModel.Errors.Add(ex.Message);
            }
            return View(fileViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddFile([FromForm(Name = "file")] IFormFile file)
        {
            if (file != null && file.Length > 0)
            {
                try
                {
                    //Check if file is .xsls type

                    string fileName = file.FileName;
                    if (Regex.IsMatch(fileName, @"^.*[^xlsx]xlsx$") == false) throw new Exception("Incorrect file type");

                    byte[] fileBytes;

                    //Converting to byte massive
                    using (var ms = new MemoryStream())
                    {
                        file.CopyTo(ms);
                        fileBytes = ms.ToArray();
                    }

                    //Saving procedure
                    _fileManager.SaveXslxInFolder(fileBytes, fileName);
                }
                catch (Exception ex)
                {
                    TempData["Exception"] = ex.Message;
                }
            }
            return RedirectToAction("FileManagement");
        }

        [HttpPost]
        public async Task<IActionResult> PushFileIntoDatabase(string fileName)
        {
            try
            {
                await _fileManager.PushFileIntoDatabase(fileName);
            }
            catch (Exception ex)
            {
                TempData["Exception"] = ex.Message;
            }

            return RedirectToAction("FileManagement");
        }

        [HttpPost]
        public IActionResult DeleteFileFromFolder(string fileName)
        {
            try
            {
                //Deleting fole by its name
                _fileManager.DeleteFile(fileName);
            }
            catch (Exception ex)
            {
                TempData["Exception"] = ex.Message;
            }
            return RedirectToAction("FileManagement");
        }

        public async Task<IActionResult> DeleteFileFromDatabase(string fileId)
        {
            try
            {
                await _excelManager.DeleteFile(fileId);
            }
            catch (Exception ex)
            {
                TempData["Exception"] = ex.Message;
            }
            return RedirectToAction("FileManagement");
        }

        [HttpPost]
        public async Task<IActionResult> ViewDatabaseFile(string fileId)
        {
            DatabaseFileDataViewModel databaseFileDataViewModel = new();
            if (String.IsNullOrWhiteSpace(fileId)) return RedirectToAction("FileManagement");
            try
            {
                databaseFileDataViewModel.FileData = await _excelManager.GetFileData(fileId);
            }
            catch (Exception ex)
            {
                databaseFileDataViewModel.Errors.Add(ex.Message);
            }
            return View(databaseFileDataViewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}