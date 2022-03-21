using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookCave.UI.Middlewares
{
    public static class MiddlewareHelper
    {
        public static void UseTransferCart(this IApplicationBuilder app)
        {
            app.UseMiddleware<CartTransferMiddleware>();
        }
    }
}
