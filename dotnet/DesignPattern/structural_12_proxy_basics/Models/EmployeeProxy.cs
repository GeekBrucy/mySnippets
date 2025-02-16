using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using structural_12_proxy_basics.Interfaces;

namespace structural_12_proxy_basics.Models
{
    public class EmployeeProxy : IEmployee
    {
        public void ApplyVacation()
        {

        }

        public decimal GetSalary()
        {
            return 0;
        }

        public void Report()
        {

        }
    }
}