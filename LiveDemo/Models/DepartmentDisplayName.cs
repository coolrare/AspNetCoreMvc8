#nullable disable
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace LiveDemo.Models;

[ModelMetadataType<DepartmentMetadata>()]
public partial class Department { }

public partial class DepartmentMetadata
{
    public int DepartmentId { get; set; }

    [DisplayName("部門名稱")]
    public string Name { get; set; }

    [DisplayName("部門預算")]
    public decimal Budget { get; set; }

    public DateTime StartDate { get; set; }

    public int? InstructorId { get; set; }

    public byte[] RowVersion { get; set; }

    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();

    public virtual Person Instructor { get; set; }
}