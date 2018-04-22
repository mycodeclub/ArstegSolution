using ArstegSolutions.Models;
using System.Linq;
using System.Web.Mvc;

namespace ArstegSolutions.Controllers
{
    public class CalculateNetSalaryController : Controller
    {

        private MyDbContext db = new MyDbContext();
        // GET: CalculateNetSalary
        public ActionResult Index()
        {
            ViewData["TaxSlabs"] = db.TaxSlabs.ToList();
            if (TempData.ContainsKey("salary"))
            {
                var salary = TempData["salary"] as EmployeeSalary; TempData.Keep();
                return View(salary);
            }
            return View();

        }
        // POST: CalculateNetSalary/NetSalary
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NetSalary([Bind(Include = "GrossSalary")] EmployeeSalary salary)
        {
            if (ModelState.IsValid)
            {
                decimal taxableAmount = salary.GrossSalary;
                decimal taxValue = 0;
                foreach (var taxSlab in db.TaxSlabs.ToList().OrderBy(tax => tax.Percentage))
                {
                    if (taxSlab.Percentage <= 0) taxableAmount -= taxSlab.EndAmount;
                    else if (taxableAmount > 0)
                    {
                        var slabDiff = taxSlab.EndAmount - taxSlab.StartAmount;
                        if (taxableAmount > slabDiff)
                        {
                            taxValue += ((taxSlab.Percentage * slabDiff) / 100);
                            taxableAmount -= slabDiff;
                        }
                        else if (taxableAmount < slabDiff)
                        {
                            taxValue += ((taxSlab.Percentage * taxableAmount) / 100);
                            taxableAmount -= taxableAmount;
                        }
                    }
                    salary.TaxDeductionAmount = taxValue;
                    salary.InHandSalary = salary.GrossSalary - taxValue;
                }
            }
            TempData["salary"] = salary;
            return RedirectToAction("Index");
        }
    }
}