using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using LeaveManagement.Models;
using LeaveManagement.Data;

namespace LeaveManagement.Controllers;

public class EmployeeController : Controller
{
    public readonly AppDbContext _dbContext;

    public EmployeeController(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public IActionResult Employees()
    {
        
        return View(_dbContext.Employees.ToList());
    }

    public IActionResult AddEmployee()
    {
        return View();
    }

    [HttpPost]
    public IActionResult AddEmployee(Employee employeeReq)
    {
        if (!ModelState.IsValid)
        {
            return View(employeeReq);
        }
        employeeReq.CreatedOn = DateOnly.FromDateTime(DateTime.Today);
        _dbContext.Add(employeeReq);
        _dbContext.SaveChanges();
        return RedirectToAction("Employees");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
