using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace structural_12_proxy_basics.Interfaces
{
    public interface IEmployee
    {
        decimal GetSalary();
        void Report();
        void ApplyVacation();
    }
}