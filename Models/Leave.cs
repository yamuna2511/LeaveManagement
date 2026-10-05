using System.ComponentModel.DataAnnotations;
using LeaveManagement.Enums;

namespace LeaveManagement.Models;

public class Leave
{
    public int Id {get;set;}
    [Required(ErrorMessage = "Employee is required")]
    public int EmployeeId {get;set;}
    [Required(ErrorMessage = "Leave type is required")]
    public LeaveType Type {get;set;}
    [Required(ErrorMessage = "From Date is required")]
    public DateOnly FromDate {get;set;}
    public DateOnly ToDate {get;set;}
    public LeaveStatus Status {get;set;} = LeaveStatus.Pending;
    public string? Reason {get;set;}
    public DateOnly CreatedOn {get;set;}
    public Employee? Employee {get;set;}
}