using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using LeaveManagement.Models;
using LeaveManagement.Data;
using LeaveManagement.ViewModels;
using Microsoft.EntityFrameworkCore;
using LeaveManagement.Enums;

namespace LeaveManagement.Controllers;

public class LeaveController : Controller
{
    public readonly AppDbContext _dbContext;

    public LeaveController(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public IActionResult Leaves()
    {
        
        return View(_dbContext.Leaves.Include(l => l.Employee).ToList());
        
    }

    public IActionResult AddLeave()
    {
        var model = new CreateLeaveView
        {
            AvailableEmployees = _dbContext.Employees.ToList()
        };
        return View(model);
    }

    [HttpPost]
    public IActionResult AddLeave(CreateLeaveView leaveReq)
    {
        if (!ModelState.IsValid)
        {
            return View(leaveReq);
        }
        var leave = new Leave
        {
            EmployeeId = leaveReq.EmployeeId,
            Type = leaveReq.Type,
            FromDate = leaveReq.FromDate,
            ToDate = leaveReq.ToDate,
            Status = Enums.LeaveStatus.Pending,
            Reason = leaveReq.Reason,
            CreatedOn = DateOnly.FromDateTime(DateTime.Today)
        };
        _dbContext.Add(leave);
        _dbContext.SaveChanges();
        return RedirectToAction("Leaves");
    }

    public IActionResult UpdateLeave(int id)
    {
        var leave = _dbContext.Leaves
        .Include(l => l.Employee)
        .FirstOrDefault(l => l.Id == id);
        if(leave == null)
        {
            return NotFound();
        }
        return View(leave);
    }

    [HttpPost]
    public IActionResult UpdateStatus(int id, LeaveStatus status)
    {
        var leave = _dbContext.Leaves.Find(id);
        if (leave == null)
            return NotFound();

        leave.Status = status;
        _dbContext.SaveChanges();
        return RedirectToAction("Leaves");

    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
