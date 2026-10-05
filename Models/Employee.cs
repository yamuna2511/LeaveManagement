using System.ComponentModel.DataAnnotations;
using LeaveManagement.Enums;

namespace LeaveManagement.Models;

public class Employee
{
    public int Id {get;set;}
    [Required(ErrorMessage = "Name is required")]
    public string Name {get;set;} = string.Empty;
    public Department Department {get;set;}
    [Required(ErrorMessage = "Email is required")]
    public string Email {get;set;} = string.Empty;
    public DateOnly CreatedOn {get;set;}

}