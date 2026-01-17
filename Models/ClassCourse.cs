using System;
using System.Collections.Generic;

namespace LabsSchoolDBApp.Models;

public partial class ClassCourse
{
    public int ClassCourseId { get; set; }

    public string? ClassCode { get; set; }

    public string? CourseCode { get; set; }

    public virtual Class? ClassCodeNavigation { get; set; }

    public virtual Course? CourseCodeNavigation { get; set; }
}
