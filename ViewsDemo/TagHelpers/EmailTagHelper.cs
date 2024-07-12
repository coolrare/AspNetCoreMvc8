using Microsoft.AspNetCore.Razor.TagHelpers;

namespace ViewsDemo.TagHelpers;

/// <summary>
/// 可以輕易的透過這個 Tag Helper 來產生 Email 的超連結
/// </summary>
[HtmlTargetElement("email")]
public class EmailTagHelper : TagHelper
{
    public string? Name { get; set; }
    public required string Address { get; set; }

    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        output.TagName = "a";
        output.Attributes.SetAttribute("href", $"mailto:{Address}");
        output.Content.SetContent(this.Name ?? Address);
    }
}
