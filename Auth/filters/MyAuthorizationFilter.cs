using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Http;
using System;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Auth.filters
{
    public class MyAuthorizationFilter : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            // Здесь вы можете определить логику авторизации, например, проверку Role или Permission => shunarlirow bo`ladi.
            // albatta burinchi o`zimga ^_^

            // Пример: Проверка, имеет ли пользователь определенную Role
            if (!context.HttpContext.User.IsInRole("Admin"))
            {
                // Если пользователь не имеет необходимой Role, вернем 403 Forbidden
                context.Result = new StatusCodeResult(StatusCodes.Status403Forbidden);
                return;
            }

            // Пример: Проверка, имеет ли пользователь определенный идентификатор
            var userId = context.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId))
            {
                // Если идентификатор пользователя отсутствует или пуст, вернем 401 Unauthorized
                context.Result = new StatusCodeResult(StatusCodes.Status401Unauthorized);
                return;
            }

            // Если пользователь прошел проверку авторизации, можно продолжить выполнение запроса
            // Yoki shunchaki qoldirish buyog`iga sizga noima kere bo`sa qo`shas Role yoki Permission ni tekshiradigan attribute filter bu.
        }
    }
}
