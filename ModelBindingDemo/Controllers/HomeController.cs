using Microsoft.AspNetCore.Mvc;
using ModelBindingDemo.Models;
using System.Diagnostics;

namespace ModelBindingDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        // http://localhost:5018/Home/Privacy?name=Will
        // Result: Will
        public IActionResult Privacy(string name)
        {
            ViewBag.name = name ?? "沒有 name 參數";

            return View();
        }


        // http://localhost:5018/Home/Privacy?name=Will
        // Result: 沒有 name 參數
        // Reason: 因為複雜模型預設不會從 Query String 取得參數
        public IActionResult Privacy1(PrivacyRequestDto name)
        {
            ViewBag.name = name.Name ?? "沒有 name 參數";

            return View("Privacy");
        }

        // http://localhost:5018/Home/Privacy?name=Will
        // Result: 沒有 name 參數
        // Reason: 因為 [FromQuery] 只能從簡單型別取值，簡單型別會嘗試呼叫該型別的 TryParse 靜態方法或 TypeConverter 實作
        public IActionResult Privacy2([FromQuery] PrivacyRequestDto name)
        {
            ViewBag.name = name.Name ?? "沒有 name 參數";

            return View("Privacy");
        }

        // http://localhost:5018/Home/Privacy3?data=Will
        // Result: Will
        // Reason: 因為 [FromQuery] 只能從簡單型別取值，簡單型別會嘗試呼叫該型別的 TryParse 靜態方法或 TypeConverter 實作
        // Reason: 當找不到該型別的 TryParse 靜態方法或 TypeConverter 實作時，就會嘗試繫結到該型別的每一個屬性！
        public IActionResult Privacy3([FromQuery] PrivacyRequestDto data)
        {
            ViewBag.name = data.Name ?? "沒有 name 參數";

            return View("Privacy");
        }

        // http://localhost:5018/Home/Privacy4?data=Will
        // Result: Will
        // Reason: 只要加入 public static bool TryParse 方法加入 PrivacyRequestDto 型別，就可以將 data 參數綁定到該型別！
        public IActionResult Privacy4(PrivacyRequestDto data)
        {
            ViewBag.name = data.Name ?? "沒有 name 參數";

            return View("Privacy");
        }

        // http://localhost:5018/Home/Privacy5?dateRange=2024/7/1-2024/7/11
        // Result: 2024-07-01 到 2024-07-11
        // Reason: 找到該型別的 TryParse 靜態方法，此時可以將 dateRange 參數轉換成 DateRange 型別！
        public IActionResult Privacy5(DateRange dateRange)
        {
            ViewBag.name = $"{dateRange.Start.ToString("yyyy-MM-dd")} " +
                $"到 {dateRange.End.ToString("yyyy-MM-dd")}";

            return View("Privacy");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
