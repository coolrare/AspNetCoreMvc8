#nullable disable
using LiveDemo.ValidationAttributes;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LiveDemo.Models;

public partial class CourseList
{
    public string Title { get; set; }

    [UIHint(nameof(Credits))]
    public int Credits { get; set; }
    public string Description { get; set; }

    public string Slug { get; set; }

}