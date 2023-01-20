using Second_Task_Entities.FileEntities;

namespace Second_Task.Models.FileModels
{
    public class FolderFileViewModel
    {
        public List<FolderFileEntity> FileEntities { get; set; } = new();

        public List<string> Errors { get; set; } = new();   
    }
}
