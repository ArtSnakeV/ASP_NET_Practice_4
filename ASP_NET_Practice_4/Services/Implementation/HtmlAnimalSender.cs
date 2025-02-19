using ASP_NET_Practice_4.Services.Abstract;
using System.Runtime.CompilerServices;
using System.Text;

namespace ASP_NET_Practice_4.Services.Implementation
{    
    public class HtmlAnimalSender: IAnimalSender
    {
        private readonly IAnimal animal;
        public HtmlAnimalSender(IAnimal animal)
        {
            this.animal = animal;
        }

        public async Task GetAnimal(HttpContext context)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<h1 style = 'text-align:center; color: green'>Animal info</h1>");
            sb.Append($"<h2>Name: {animal.AnimalName}</h2>");
            sb.Append($"<h2>Sound: {animal.AnimalSound}</h2>");
            context.Response.ContentType = "text/html;charset=utf-8";
            await context.Response.WriteAsync(sb.ToString());
        }
        
    }
}
