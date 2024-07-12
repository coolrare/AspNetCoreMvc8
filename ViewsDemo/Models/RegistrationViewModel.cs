using System.ComponentModel.DataAnnotations;

namespace ViewsDemo.Models;

public class RegistrationViewModel
{
    [Required(ErrorMessage = "會員編號為必填")]
    [Display(Name = "會員編號")]
    public required string Id { get; set; }

    [Required(ErrorMessage = "First Name is required.")]
    [Display(Name = "名字")]
    public string? FirstName { get; set; }

    [Required(ErrorMessage = "Last Name is required.")]
    [Display(Name = "姓氏")]
    public string? LastName { get; set; }

    // 加入註冊日期
    [Display(Name = "註冊日期")]
    //[UIHint("DateTime")]
    public DateTime? RegisterDate { get; set; }
}
