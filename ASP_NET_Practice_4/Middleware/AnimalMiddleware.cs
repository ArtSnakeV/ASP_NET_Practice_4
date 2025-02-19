using ASP_NET_Practice_4.Services.Abstract;
using ASP_NET_Practice_4.Services.Implementation;
using System.Text;

namespace ASP_NET_Practice_4.Middleware
{
    public class AnimalMiddleware
    {
        private readonly RequestDelegate next;
        
        public AnimalMiddleware(RequestDelegate next)
        {
            this.next = next;
        }
        
        public async Task InvokeAsync(HttpContext context,
            IEnumerable<IAnimal> animals)
        {
            string path = context.Request.Path;
            if(!string.IsNullOrEmpty(path) && (path.ToLower() == "/animal" || path.ToLower() == "/animals"))
            {
                StringBuilder sb = new StringBuilder();

                sb.Append($"<h1>Animals</h1>");
                foreach(var animal in animals)
                {
                    sb.Append($"<h2>Animal name: `{animal.AnimalName}`</h2>");
                    sb.Append($"<h2>Animal sound: `{animal.AnimalSound}`</h2>");
                    sb.Append($"</br>");
                }
                context.Response.ContentType = "text/html;charset=utf-8";
                await context.Response.WriteAsync(sb.ToString());
            }
            else
            {
                await next(context);
            }
        }

    }
}
