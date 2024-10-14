#nullable disable
using LiveDemo.Utils;
using System;
using System.Collections.Generic;

namespace LiveDemo.Models;

public partial class Course
{
    public static explicit operator CourseList(Course course)
    {
        return new CourseList
        {
            Title = course.Title,
            Credits = course.Credits,
            Description = course.Description,
            Slug = course.Title.ToSlug()
        };
    }
}