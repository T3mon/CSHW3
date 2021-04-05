using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.DataProviderService
{
    public interface IDataProviderProfilerService
    {
        public Task<string> ComparePerformanceLinq();
        public Task<string> ComparePerformanceSql();
    }
}
