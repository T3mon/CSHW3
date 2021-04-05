using DAL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.DataProviderService
{
    public class DataProviderProfilerService : IDataProviderProfilerService
    {
        private readonly IApplicationDbContex _dbContext;

        public DataProviderProfilerService(IApplicationDbContex dbContext)
        {
            _dbContext = dbContext;
        }

        Task<string> IDataProviderProfilerService.ComparePerformanceLinq()
        {
            throw new NotImplementedException();
        }

        Task<string> IDataProviderProfilerService.ComparePerformanceSql()
        {
            throw new NotImplementedException();
        }
    }
}
