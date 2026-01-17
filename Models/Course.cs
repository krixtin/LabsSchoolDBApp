using System;
using System.Collections.Generic;

namespace LabsSchoolDBApp.Models;

public partial class Course
{
    public string CourseCode { get; set; } = null!;

    public int? TeacherId { get; set; }

    public string? CourseName { get; set; }

    public virtual ICollection<ClassCourse> ClassCourses { get; set; } = new List<ClassCourse>();

    public virtual ICollection<Grade> Grades { get; set; } = new List<Grade>();

    public virtual Employee? Teacher { get; set; }
}
