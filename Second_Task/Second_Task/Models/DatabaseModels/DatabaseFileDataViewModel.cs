using Second_Task_Entities.ExcelEntities;

namespace Second_Task.Models.DatabaseModels
{
    public class DatabaseFileDataViewModel
    {
        public ExcelFile FileData { get; set; }

        public List<string> Errors { get; set; } = new();
    }
}
