using ASP_NET_Practice_4.Services.Abstract;

namespace ASP_NET_Practice_4.Figures.Services.Abstract
{
    public interface IFiguresSender
    {
        Task GetFigures(HttpContext context);
    }
}
