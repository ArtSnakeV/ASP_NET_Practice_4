using ASP_NET_Practice_4.Figures.Services.Abstract;

namespace ASP_NET_Practice_4.Figures.Services.Implementation
{
    public class Pentagon : IFigure
    {
        public string Name { get; init; }
        public int Angles { get; init; }

        public Pentagon()
        {
            Name = "Pentagon";
            Angles = 5;
        }
    }
}
