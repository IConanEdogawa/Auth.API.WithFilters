using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Http;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace Auth.filters
{
    public class MyActionFilter : Attribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            // Этот метод будет выполнен после выполнения метода действия.
            // Здесь вы можете выполнять постобработку, если это необходимо.
            // Я не знал, что и как написать здесь «атрибут», поэтому фильтр остался на месте.
            // tarjima: man qana qilib yozishdi xullas bilamdim aniqrog`i nima yozish mukinligini bilamdim.
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            // Этот метод будет выполнен перед выполнением метода действия.
            // Здесь вы можете выполнять логику аутентификации.

            // Проверяем наличие заголовка Authorization в запросе
            if (!context.HttpContext.Request.Headers.ContainsKey("Authorization"))
            {
                // Если заголовок Authorization отсутствует, возвращаем 401 Unauthorized
                context.Result = new StatusCodeResult(StatusCodes.Status401Unauthorized);
                return;
            }

            // Bu yerda shunchaki authorization bo`lganligini aniqlanadi.

            // Получаем токен из заголовка Authorization
            // Mana shu lekin qizi`gakan.
            var authorizationHeader = context.HttpContext.Request.Headers["Authorization"].FirstOrDefault();
            if (string.IsNullOrEmpty(authorizationHeader))
            {
                // Если заголовок Authorization пуст, возвращаем 401 Unauthorized
                context.Result = new StatusCodeResult(StatusCodes.Status401Unauthorized);
                return;
            }

            // Извлекаем токен из заголовка Authorization
            var token = authorizationHeader.Replace("Bearer ", "");

            // Проверяем валидность JWT токена
            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtToken = tokenHandler.ReadToken(token) as JwtSecurityToken;

            if (jwtToken == null)
            {
                // Если токен недействителен, возвращаем 401 Unauthorized
                context.Result = new StatusCodeResult(StatusCodes.Status401Unauthorized);
                return;
            }

            // Если токен действителен, вы можете выполнить дополнительные проверки при необходимости
            // betga o`tsa demak func to`g`ri ishlagan.
            // отсюда нужная функция пройдет без ошибок
        }
    }
}
