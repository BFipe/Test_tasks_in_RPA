using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Second_Task_BusinessLayer.Interfaces
{
    public interface IExcelReader
    {
        public Task ReadFile(string xlsxFilePath);
    }
}
