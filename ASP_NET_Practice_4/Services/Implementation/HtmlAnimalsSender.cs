using ASP_NET_Practice_4.Services.Abstract;
using System.Text;

namespace ASP_NET_Practice_4.Services.Implementation
{
    public class HtmlAnimalsSender : IAnimalsSender
    {
        private readonly IEnumerable<IAnimal> animals;
        public HtmlAnimalsSender(IEnumerable<IAnimal> animals)
        {
            this.animals = animals;
        }

        public async Task GetAnimals(HttpContext context, IEnumerable<IAnimal> animals)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<h1 style = 'text-align:center; color: green'>Animal info</h1>");
            foreach (var animal in animals)
            {
                sb.Append($"<h2>Name: {animal.AnimalName}</h2>");
                sb.Append($"<h2>Sound: {animal.AnimalSound}</h2>");
            }           
            context.Response.ContentType = "text/html;charset=utf-8";
            await context.Response.WriteAsync(sb.ToString());
        }

        // Functions `plugs`
        public async Task WriteAnimals(HttpContext context, IEnumerable<IAnimal> animals) {
            await GetAnimals(context, animals);
        }
        public async Task ReadAnimals(HttpContext context, IEnumerable<IAnimal> animals) {
            await context.Response.WriteAsync("Read Animals in Html.");
        }
    }
}
