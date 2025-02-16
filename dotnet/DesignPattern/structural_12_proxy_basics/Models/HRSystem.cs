using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using structural_12_proxy_basics.Interfaces;

namespace structural_12_proxy_basics.Models
{
    public class HRSystem
    {
        public void Process()
        {
            IEmployee employee = new EmployeeProxy();
            employee.Report();
            employee.ApplyVacation();
        }
    }
}