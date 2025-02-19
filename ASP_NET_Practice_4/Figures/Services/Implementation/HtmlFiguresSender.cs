using ASP_NET_Practice_4.Figures.Services.Abstract;
using System.Text;

namespace ASP_NET_Practice_4.Figures.Services.Implementation
{
    public class HtmlFiguresSender : IFiguresSender
    {
        private readonly IEnumerable<IFigure> figures;
        public HtmlFiguresSender(IEnumerable<IFigure> figures)
        {
            this.figures = figures;
        }

        public async Task GetFigures(HttpContext context)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var figure in figures)
            {
                sb.Append("<h1 style = 'text-align:center; color: green'>Figures info</h1>");
                sb.Append($"<h2>Name: {figure.Name}</h2>");
                sb.Append($"<h2>Sound: {figure.Angles}</h2>");
            }

            context.Response.ContentType = "text/html;charset=utf-8";
            await context.Response.WriteAsync(sb.ToString());
        }
    }
}
