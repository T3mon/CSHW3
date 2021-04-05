using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Models
{
    public class EmployeeDto
    {
        public string Name { get; set; }
        public string SecondName { get; set; }
        public HiringHistorieDto HiringHistories { get; set; }
    }
}
