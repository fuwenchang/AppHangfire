using Hangfire;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppHangfire
{
    public static class SendMessageJob
    {
        public static IApplicationBuilder SendMsg(this IApplicationBuilder app)
        {
            // 定时执行任务（每分钟执行一次）
            RecurringJob.AddOrUpdate(
                () => Console.WriteLine("原来是这样原来是这样原来是这样原来是这样原来是这样原来是这样原来是这样！"),
                 Cron.Minutely);

            Func<RequestDelegate, RequestDelegate> middleware = next =>
            {
                return context =>
                {
                    return next(context);
                };
            };

            return app.Use(middleware);
        }
    }
}
