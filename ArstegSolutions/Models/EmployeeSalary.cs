using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArstegSolutions.Models
{
    public class EmployeeSalary
    {
        public decimal GrossSalary { get; set; }
        public decimal TaxDeductionAmount { get; set; }
        public decimal InHandSalary { get; set; }
    }
}