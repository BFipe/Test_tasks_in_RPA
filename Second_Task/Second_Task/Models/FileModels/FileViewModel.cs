using Second_Task_BusinessLayer.Dtos;
using Second_Task_Entities.FileEntities;

namespace Second_Task.Models.FileModels
{
    public class FileViewModel
    {
        public List<FolderFileEntity> FileEntities { get; set; } = new();

        public List<DbFileInfo> DbFiles { get; set; } = new();

        public List<string> Errors { get; set; } = new();   
    }
}
