using ASP_NET_Practice_4.Figures.Services.Abstract;
using ASP_NET_Practice_4.Services.Abstract;
using Microsoft.AspNetCore.Rewrite;
using System.Data;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Xml;
using System.Xml.Serialization;

namespace ASP_NET_Practice_4.Figures.Services.Implementation
{
    
    public class SaveFigureXML : IFiguresSender
    {
        private readonly IEnumerable<IFigure> figures;
        public SaveFigureXML(IEnumerable<IFigure> figures)
        {
            this.figures = figures;
        }

        public async Task GetFigures(HttpContext context)
        {
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "figures.xml");

            try
            {
                var figureList = figures.ToList(); // Convert to List
                var figureDTOs = MapFiguresToDTOs(figureList); // Map to DTOs

                using (TextWriter writer = new StreamWriter(filePath))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(List<object>)); // Use List<object> for DTOs
                    using (XmlWriter xmlWriter = XmlWriter.Create(writer, new XmlWriterSettings() { Indent = true }))
                    {
                        serializer.Serialize(xmlWriter, figureDTOs);
                    }
                }
                await context.Response.WriteAsync($"</br><h1>Writing to file successful!</h1>");
            }
            catch (Exception ex)
            {
                await context.Response.WriteAsync($"<h1>Error writing to file: {ex.Message}</h1>");
            }
        }

        // DTO classes located in IFigureXML
        // Method to map each concrete class to it's corresponding DTO
        public List<object> MapFiguresToDTOs(List<IFigure> figures)
        {
            var figureDTOs = new List<object>();

            foreach (var figure in figures)
            {
                switch (figure)
                {
                    case Triangle triangle:
                        figureDTOs.Add(new TriangleDTO { Name = triangle.Name, Angles = triangle.Angles });
                        break;
                    case Rectangle rectangle:
                        figureDTOs.Add(new RectangleDTO { Name = rectangle.Name, Angles = rectangle.Angles });
                        break;
                    case Pentagon pentagon:
                        figureDTOs.Add(new RectangleDTO { Name = pentagon.Name, Angles = pentagon.Angles });
                        break;
                }
            }
            return figureDTOs;
        }



        //public async Task GetFigures(HttpContext context)
        //{
        //    TextWriter writer = new StreamWriter(filePath);

        //    XmlSerializer serializer = new XmlSerializer(typeof(List<IFigure>));
        //    using (XmlWriter xmlWriter = XmlWriter.Create(writer, new XmlWriterSettings() { Indent = true }))
        //    {
        //        serializer.Serialize(xmlWriter, figures);
        //    }

        //    await context.Response.WriteAsync($"</br><h1>Writing to file successful!</h1>");


        //}
    }
}
