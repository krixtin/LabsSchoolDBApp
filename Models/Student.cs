using System;
using System.Collections.Generic;

namespace LabsSchoolDBApp.Models;

public partial class Student
{
    public int StudentId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? PersonalNr { get; set; }

    public string? ClassCode { get; set; }

    public virtual Class? ClassCodeNavigation { get; set; }

    public virtual ICollection<Grade> Grades { get; set; } = new List<Grade>();
}
