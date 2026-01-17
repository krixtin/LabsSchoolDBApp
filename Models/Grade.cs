using System;
using System.Collections.Generic;

namespace LabsSchoolDBApp.Models;

public partial class Grade
{
    public int GradeId { get; set; }

    public string? CourseCode { get; set; }

    public int? TeacherId { get; set; }

    public int? StudentId { get; set; }

    public DateOnly? Date { get; set; }

    public int? Grade1 { get; set; }

    public virtual Course? CourseCodeNavigation { get; set; }

    public virtual Student? Student { get; set; }

    public virtual Employee? Teacher { get; set; }
}
