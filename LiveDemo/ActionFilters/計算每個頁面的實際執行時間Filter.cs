using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace LiveDemo.ActionFilters
{
    public class 計算每個頁面的實際執行時間Attribute : ActionFilterAttribute
    {
        private readonly ILogger<計算每個頁面的實際執行時間Attribute> logger;

        public 計算每個頁面的實際執行時間Attribute(ILogger<計算每個頁面的實際執行時間Attribute> logger)
        {
            this.logger = logger;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            // 記錄開始時間
            context.HttpContext.Items["StartTime"] = DateTime.Now;

            // 短路寫法
            //context.Result = new ContentResult
            //{
            //    Content = "執行中...",
            //};

            base.OnActionExecuting(context);
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            // 計算執行時間
            var startTime = (DateTime)context.HttpContext.Items["StartTime"]!;

            var endTime = DateTime.Now;

            var duration = endTime - startTime;

            this.logger.LogInformation("執行時間: {duration}", duration);

            var controller = context.Controller as Controller;

            controller!.ViewBag.Duration = duration;

            base.OnActionExecuted(context);
        }
    }
}
