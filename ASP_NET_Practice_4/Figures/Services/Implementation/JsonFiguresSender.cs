using ASP_NET_Practice_4.Figures.Services.Abstract;
using ASP_NET_Practice_4.Services.Abstract;
using System.Text;

namespace ASP_NET_Practice_4.Figures.Services.Implementation
{
    public class JsonFiguresSender : IFiguresSender
    {
        private readonly IEnumerable<IFigure> figures;
        public JsonFiguresSender(IEnumerable<IFigure> figures)
        {
            this.figures = figures;
        }

        public async Task GetFigures(HttpContext context)
        {
            context.Response.ContentType = "text/html;charset=utf-8";
            await context.Response.WriteAsJsonAsync(figures);
        }
    }
}
