using Auth.MyModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace Auth.filters
{
    public class MyExceptionFilter : Attribute, IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            // здесь показано, как работать с возможными исключениями
            // bazi exceptionlarimizni catch qilishimiz mumkin


            var exception = context.Exception;

            // Обработка исключения типа UnauthorizedAccessException
            if (exception is UnauthorizedAccessException)
            {
                context.Result = new ObjectResult("Доступ запрещен")
                {
                    StatusCode = 403 // Запрещено
                };
                return;
            }

            // Обработка исключения типа NotFoundException (например, ресурс не найден)
            if (exception is NotFoundException)
            {
                context.Result = new ObjectResult("Ресурс не найден")
                {
                    StatusCode = 404 // Не найдено
                };
                return;
            }

            // Обработка других исключений
            context.Result = new ObjectResult("Произошла внутренняя ошибка сервера")
            {
                StatusCode = 500 // Внутренняя ошибка сервера
            };
        }
    }

    
}
