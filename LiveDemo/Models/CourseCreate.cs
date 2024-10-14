#nullable disable
using LiveDemo.ValidationAttributes;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LiveDemo.Models;

public partial class CourseCreate : IValidatableObject
{
    [Required]
    [判斷是否有重複的課程名稱]
    [MinLength(5)]
    [StringLength(100)]
    [BindRequired]
    [DisplayName("課程名稱")]
    public string Title { get; set; }

    [Required]
    [BindRequired]
    [Range(0, 5, ErrorMessage = "請在設定 Credit 的時候使用 1 ~ 5 的值")]
    [DisplayName("課程評價")]
    public int Credits { get; set; }

    public DateTime StartDate { get; set; }


    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (this.Title.Contains("Git") && this.Credits < 3)
        {
            yield return new ValidationResult("Git 課程的評價過低！", new string[] { nameof(Title) });
        }
    }
}