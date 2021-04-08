using BLL.Services.DataProviderService;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomSolutionsHW3.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeController : ControllerBase
    {
        private readonly IDataProviderProfilerService _dataProviderProfilerService;
        public EmployeController(IDataProviderProfilerService dataProviderProfilerService)
        {
            _dataProviderProfilerService = dataProviderProfilerService;
        }

        [HttpGet]
        public ActionResult<string> Index()
        {
            return _dataProviderProfilerService.ComparePerformance();
        }
    }
}
