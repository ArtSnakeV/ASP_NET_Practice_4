using ASP_NET_Practice_4.Services.Abstract;
using System.Text;

namespace ASP_NET_Practice_4.Middleware
{
    public class AnimalsMiddleware3
    {
        private readonly RequestDelegate next;

        public AnimalsMiddleware3(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext context,
            IEnumerable<IAnimal> animals,
            IAnimalsSender animalsSender
            )
        {
            string path = context.Request.Path;
            if (!string.IsNullOrEmpty(path) && (path.ToLower() == "/animal" || path.ToLower() == "/animals"))
            {
                animalsSender?.GetAnimals(context, animals);
            }
            if (!string.IsNullOrEmpty(path) && (path.ToLower() == "/write"))
            {
                animalsSender?.WriteAnimals(context, animals);
            }
            if (!string.IsNullOrEmpty(path) && (path.ToLower() == "/read"))
            {
                animalsSender?.ReadAnimals(context, animals);
            }
            else
            {
                await next(context);
            }
        }
    }
}
