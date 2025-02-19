using ASP_NET_Practice_4.Services.Abstract;
using System.Text.Json;
using System.Text.Json.Serialization;
using static System.Net.Mime.MediaTypeNames;

namespace ASP_NET_Practice_4.Services.Implementation
{
    public class JSONAnimalSender : IAnimalSender
    {
        private readonly IAnimal animal;

        public JSONAnimalSender(IAnimal animal)
        {
            this.animal = animal;
        }

        public async Task GetAnimal(HttpContext context)
        {
            // Writing JSON to html page
            await context.Response.WriteAsJsonAsync(animal);     
        }
        
    }
}
