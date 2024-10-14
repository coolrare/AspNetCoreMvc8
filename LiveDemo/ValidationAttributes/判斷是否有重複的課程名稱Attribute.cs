using LiveDemo.Models;
using System.ComponentModel.DataAnnotations;

namespace LiveDemo.ValidationAttributes
{
    public class 判斷是否有重複的課程名稱Attribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            string? title = value as string;
            if (string.IsNullOrEmpty(title))
            {
                return ValidationResult.Success;
            }

            var db = (ContosoUniversityContext)validationContext.GetService(typeof(ContosoUniversityContext))!;

            bool exists = db!.Courses.Any(c => c.Title == title);

            if (!exists)
            {
                return ValidationResult.Success;
            }
            else
            {
                var fieldName = validationContext.MemberName ?? "";
                return new ValidationResult("課程名稱已重複", new string[] { fieldName });
            }
        }
    }
}
