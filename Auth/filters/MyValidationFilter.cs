using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Auth.filters
{
    public class MyValidationFilter : Attribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            // Этот метод будет выполнен после выполнения метода действия контроллера.
            // Мы будем проверять состояние модели и, если оно недействительно, возвращать ответ с ошибкой.

            if (!context.ModelState.IsValid) // buni yozgandikkk
            {
                // Если модель недействительна, создаем ответ с ошибкой BadRequest и возвращаем ModelState.
                context.Result = new BadRequestObjectResult(context.ModelState);
            }
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            // Этот метод будет выполнен перед выполнением метода действия контроллера.
            // Yana shu xolat nima qilsa bno`ladi aniqleman lekin.... #@$@#!@#!@#
        }


        // Bu manimcha oxirgisidi ...
    }
}
