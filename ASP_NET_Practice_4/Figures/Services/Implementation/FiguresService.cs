using ASP_NET_Practice_4.Figures.Services.Abstract;
using ASP_NET_Practice_4.Services.Abstract;

namespace ASP_NET_Practice_4.Figures.Services.Implementation
{
    public class FiguresService
    {
        public FiguresService(IFigure figure)
        {
            Figure = figure;
        }
        public IFigure Figure { get; }
    }
}
