using IctBukhara.uz.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace IctBukhara.uz.Entitys
{
    public class AuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        public async void OnAuthorization(AuthorizationFilterContext context)
        {
            try
            {
                // agar harakat [AllowAnonymous] atributi bilan bezatilgan bo'lsa, avtorizatsiyani o'tkazib yuboring
                if (context.ActionDescriptor.EndpointMetadata.OfType<AllowAnonymousAttribute>().Any())
                    return;

                string token = (string)context.HttpContext.Session.GetString("token");
                int? id = context.HttpContext.Session.GetInt32("id");
                if (token is null || id is null)
                {
                    // tizimga kirishga ruxsat berilmagan.
                    context.HttpContext.Response.Redirect("/other/login?msg=token_mavjud_emas");
                    return;
                }
                var dbContext = context.HttpContext.RequestServices.GetService(typeof(DataContext)) as DataContext;
                if ((await dbContext.Admins.FirstOrDefaultAsync(a => a.Id == id))?.Token != token)
                {
                    // tizimga kirishga ruxsat berilmagan.
                    context.HttpContext.Response.Redirect("/other/login?msg=token_is_not_valid");
                    return;
                }
            }
            catch (Exception e)
            {
                try
                {
                    context?.HttpContext?.Response?.Redirect("/other/error?msg=" + e?.Message);
                    return;
                }
                catch
                {
                    // qanaqadir xatolik
                    return;
                }
            }
        }
    }
}
