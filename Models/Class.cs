using System;
using System.Collections.Generic;

namespace LabsSchoolDBApp.Models;

public partial class Class
{
    public string ClassCode { get; set; } = null!;

    public int? ClassTeacher { get; set; }

    public virtual ICollection<ClassCourse> ClassCourses { get; set; } = new List<ClassCourse>();

    public virtual Employee? ClassTeacherNavigation { get; set; }

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}
