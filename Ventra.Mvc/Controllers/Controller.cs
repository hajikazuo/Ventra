using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Ventra.Infrastructure.Services.Interfaces;
using Ventra.Mvc.ViewModel;

namespace Ventra.Mvc.Controllers
{
    public class Controller  : Microsoft.AspNetCore.Mvc.Controller
    {
        protected readonly ICategoryService _categoryService;

        public ICategoryService categoryService { get; }


        public Controller(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var categories = _categoryService.GetAll(context.HttpContext.RequestAborted).Result;

            var data = new LayoutViewModel
            {
                Categories = categories.ToList()
            };

            ViewBag.Layout = data;

            base.OnActionExecuting(context);
        }
    }
}
