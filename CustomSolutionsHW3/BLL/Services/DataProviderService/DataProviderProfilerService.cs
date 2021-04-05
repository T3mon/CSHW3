using DAL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.DataProviderService
{
    public class DataProviderProfilerService : IDataProviderProfilerService
    {
        private readonly IApplicationDbContext _dbContext;

        public DataProviderProfilerService(IApplicationDbContext dbContext)
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
