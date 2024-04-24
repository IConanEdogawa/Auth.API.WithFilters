using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Http;
using System;
using Microsoft.AspNetCore.Mvc;

namespace Auth.filters
{
    public class MyResourceFilter : Attribute, IResourceFilter
    {
        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            // Этот метод будет выполнен после выполнения метода действия контроллера.
            // Bu ham shu axvol
        }

        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            // Этот метод будет выполнен перед выполнением метода действия контроллера.

            // Пример: Логирование запроса
            var requestPath = context.HttpContext.Request.Path;
            Console.WriteLine($"Запрос к пути: {requestPath}");

            // Пример: Проверка наличия заголовка Authorization
            if (!context.HttpContext.Request.Headers.ContainsKey("Authorization"))
            {
                // Если заголовок Authorization отсутствует, можно вернуть 401 Unauthorized
                context.Result = new StatusCodeResult(StatusCodes.Status401Unauthorized);
                return;
            }

            // Здесь вы можете добавить другие проверки или логику, например, проверку доступа или валидацию данных.
            // Albatta yana qo`shsa bo`ladi.
        }
    }
}
