using BookCave.Application.Abstracts;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BookCave.UI.Middlewares
{
    public class CartTransferMiddleware
    {
        private readonly RequestDelegate _next;

        public CartTransferMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext, ICartService cartService)
        {
            if (httpContext.User.Identity.IsAuthenticated && httpContext.Request.Cookies.ContainsKey(Constants.COOKIE_NAME))
            {
                string anonId = httpContext.Request.Cookies[Constants.COOKIE_NAME];
                string userId = httpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
                await cartService.TransferCartAsync(anonId, userId);
                httpContext.Response.Cookies.Delete(Constants.COOKIE_NAME);
            }
            await _next(httpContext);
        }
    }
}
