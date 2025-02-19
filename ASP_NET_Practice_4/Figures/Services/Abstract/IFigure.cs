namespace ASP_NET_Practice_4.Figures.Services.Abstract
{
    public interface IFigure
    {
        public string Name { get; init; } 

        public int Angles { get; init; }

    }

    // Added DTO classes to have chance to serialize IFigure in XML file properly
    public class RectangleDTO
    {
        public string Name { get; set; }
        public int Angles { get; set; }
    }

    public class TriangleDTO
    {
        public string Name { get; set; }
        public int Angles { get; set; }
    }
    
    public class PentagonDTO
    {
        public string Name { get; set; }
        public int Angles { get; set; }
    }     
}
