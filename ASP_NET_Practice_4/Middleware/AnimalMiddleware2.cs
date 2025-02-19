using ASP_NET_Practice_4.Services.Abstract;
using ASP_NET_Practice_4.Services.Implementation;
using System.IO;
using System.Text;

namespace ASP_NET_Practice_4.Middleware
{
    public class AnimalMiddleware2
    {
        private readonly RequestDelegate next;

        public AnimalMiddleware2(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext context,
            IEnumerable<IAnimal> animals,
            IAnimalSender animalSender
            )
        {
            // First version
            //string path = context.Request.Path;
            //if (!string.IsNullOrEmpty(path) && (path.ToLower() == "/animal" || path.ToLower() == "/animals"))
            //{
            //    StringBuilder sb = new StringBuilder();

            //    sb.Append($"<h1>Animals</h1>");
            //    //var animal = animalSender.GetAnimal(context);
            //    foreach(var animal in animals) { 
            //        sb.Append($"<h2>Animal name: `{animal.AnimalName}`</h2>");
            //        sb.Append($"<h2>Animal sound: `{animal.AnimalSound}`</h2>");
            //        sb.Append($"</br>");
            //        //sb.Append($"<h2>From service: {animalService.Animal.AnimalName} and {animalService.Animal.AnimalSound}");
            //    }
            //    context.Response.ContentType = "text/html; charset=utf-8";
            //    await context.Response.WriteAsync(sb.ToString());
            //}
            //else
            //{
            //    await next(context);
            //}

            // Second version
            //string path = context.Request.Path;
            //if (!string.IsNullOrEmpty(path) && (path.ToLower() == "/animal" || path.ToLower() == "/animals"))
            //{
            //    animalSender.GetAnimal(context); // Sending our animal depending of choosed sender
            //}
            //else
            //{
            //    await next(context);
            //}


            // Third version
            string path = context.Request.Path;
            if (!string.IsNullOrEmpty(path) && (path.ToLower() == "/animal" || path.ToLower() == "/animals"))
            {
                if (animals.Count() > 1)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append($"<h1>Animals</h1>");
                    foreach (var animal in animals)
                    {
                        sb.Append($"<h2 style = 'text-align:center; color: green'>Animal name: `{animal.AnimalName}`</h2>");
                        sb.Append($"<h2>Animal sound: `{animal.AnimalSound}`</h2>");
                        sb.Append($"</br>");
                    }
                    context.Response.ContentType = "text/html; charset=utf-8";
                    await context.Response.WriteAsync(sb.ToString());
                }
                else{
                     animalSender?.GetAnimal(context); // Sending our animal depending of choosed sender
                }                               
            }
            else
            {
                await next(context);
            }


        }
    }
}
