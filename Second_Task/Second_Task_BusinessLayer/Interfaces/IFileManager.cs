using Second_Task_Entities.FileEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Second_Task_BusinessLayer.Interfaces
{
    public interface IFileManager
    {
        public void SaveXslxInFolder(byte[] file, string fileName);

        public List<FolderFileEntity> GetFolderFileEntities();

        public void DeleteFile(string fileName);
    }
}
