using ASP_NET_Practice_4.Figures.Services.Abstract;
using ASP_NET_Practice_4.Services.Abstract;

namespace ASP_NET_Practice_4.Figures.Middleware
{
    public class FiguresMiddleware
    {
        private readonly RequestDelegate next;

        public FiguresMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext context,
            IEnumerable<IFigure> figures,
            IFiguresSender figuresSender
            )
        {
            string path = context.Request.Path;
            if (!string.IsNullOrEmpty(path) && (path.ToLower() == "/figures" || path.ToLower() == "/figure"))
            {
                figuresSender?.GetFigures(context);
            }
            else
            {
                await next(context);
            }
        }
    }
}
