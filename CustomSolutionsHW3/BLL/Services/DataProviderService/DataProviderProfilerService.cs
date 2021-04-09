using DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public string ComparePerformance()
        {
            return $"Linq method lead time: {GetEmployeesLinq()} , Raw SQL query lead time: {GetEmployeesSql()}";
        }

        public string GetEmployeesLinq()
        {
            var timer = System.Diagnostics.Stopwatch.StartNew();
            var res = _dbContext.Employees.Include(e => e.HiringHistories).ThenInclude(a => a.Achievements).ToList();

            return timer.ElapsedMilliseconds.ToString();
        }

        public string GetEmployeesSql()
        {
            var timer = System.Diagnostics.Stopwatch.StartNew();
            
            var sql = string.Format(@"SELECT Employees.id, Employees.Name, Employees.LastName, HiringHistories.CompanyName, Achievements.Dscription FROM Employees INNER JOIN HiringHistories on(Employees.id = HiringHistories.EmployeId) INNER JOIN Achievements ON(HiringHistories.Id = Achievements.HiringHistorieId)");

            var res = _dbContext.Employees.FromSqlRaw(sql).ToList();

            return timer.ElapsedMilliseconds.ToString();
        }
    }
}
