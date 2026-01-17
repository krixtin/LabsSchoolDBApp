using System;
using System.Collections.Generic;

namespace LabsSchoolDBApp.Models;

public partial class Employee
{
    public int EmployeeId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public int? DepartmentId { get; set; }

    public DateOnly? EmploymentDate { get; set; }

    public int? Salary { get; set; }

    public virtual ICollection<Class> Classes { get; set; } = new List<Class>();

    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();

    public virtual Department? Department { get; set; }

    public virtual ICollection<Grade> Grades { get; set; } = new List<Grade>();
}
