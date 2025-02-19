using ASP_NET_Practice_4.Services.Abstract;
using System.Text;
using System.Text.Json;

namespace ASP_NET_Practice_4.Services.Implementation
{
    public class JSONAnimalsSender : IAnimalsSender
    {
        private readonly IEnumerable<IAnimal> animals;

        public JSONAnimalsSender(IAnimal animal, IEnumerable<IAnimal> animals)
        {
            this.animals = animals;
        }

        public async Task GetAnimals(HttpContext context, IEnumerable<IAnimal> animals)
        {
            context.Response.ContentType = "application/json"; // Set correct ContentType before writing
            await context.Response.WriteAsJsonAsync(this.animals);
        }

        // Writing to Json file
        public async Task WriteAnimals(HttpContext context, IEnumerable<IAnimal> animals)
        {
            if (animals == null || !animals.Any())
            {
                await context.Response.WriteAsync("No animals to write.");
                return;
            }

            context.Response.ContentType = "application/json"; // Set before writing
            string newPath = Path.Combine(Directory.GetCurrentDirectory(), "animals.json");

            try
            {
                await using FileStream createStream = File.Create(newPath);

                await JsonSerializer.SerializeAsync(createStream, animals);

                await context.Response.WriteAsync($"</br><h1>Writing to file successful!</h1>");
            }
            catch (Exception ex)
            {
                await context.Response.WriteAsync($"An error `{ex.Message}` occurred while writing to the file.");
            }
        }

        // Reading from JSON file
        public async Task ReadAnimals(HttpContext context, IEnumerable<IAnimal> animals)
        {
            // Let's read from file
            try
            {
                //string readPath = System.IO.Path.Combine(Directory.GetCurrentDirectory(), "animals.json");
                //await using FileStream stream = File.OpenRead(readPath);
                //IEnumerable<IAnimal> readedAnimals = await JsonSerializer.DeserializeAsync<IEnumerable<IAnimal>>(stream);
                //await context.Response.WriteAsync($"</br><h1>Result of reading from file:</h1></br>");
                //await context.Response.WriteAsync(JsonSerializer.Serialize(readedAnimals));


                using (FileStream stream = File.OpenRead("animals.json"))
                {
                    IEnumerable<AnimalService> readedAnimals = await JsonSerializer.DeserializeAsync<IEnumerable<AnimalService>>(stream);
                    await context.Response.WriteAsync($"</br><h1>Result of reading from file:</h1></br>");
                    await context.Response.WriteAsync(JsonSerializer.Serialize(readedAnimals));
                }
            }
            catch (Exception ex)
            {
                await context.Response.WriteAsync($"An error `{ex.Message}` occurred while reading to the file.");
            }
        }
    }
}

// Version with separate functions for read, write, and others
//using ASP_NET_Practice_4.Services.Abstract;
//using System.Text;
//using System.Text.Json;

//namespace ASP_NET_Practice_4.Services.Implementation
//{
//    public class JSONAnimalsSender : IAnimalsSender
//    {
//        private readonly IEnumerable<IAnimal> animals;

//        public JSONAnimalsSender(IAnimal animal, IEnumerable<IAnimal> animals)
//        {
//            this.animals = animals;
//        }

//        public async Task GetAnimals(HttpContext context, IEnumerable<IAnimal> animals)
//        {
//            await context.Response.WriteAsJsonAsync(animals); // Writing `animals` collection as JSON
//            context.Response.ContentType = "text/html;charset=utf-8";
//            StringBuilder sb = new StringBuilder();
//            sb.Append("<h1>");
//            string jsonText = JsonSerializer.Serialize(animals);
//            sb.Append("</h1>");
//            await context.Response.WriteAsync(sb.ToString());
//        }

//        // Writing to Json file
//        public async Task WriteAnimals(HttpContext context, IEnumerable<IAnimal> animals)
//        {
//            if (animals == null || !animals.Any())
//            {
//                await context.Response.WriteAsync("No animals to write.");
//                return;
//            }
//            await context.Response.WriteAsJsonAsync(animals); // Writing `animals` collection as JSON
//            try
//            {
//                //string newPath = System.IO.Path.Combine(Directory.GetCurrentDirectory(), "animals.json");
//                //await using FileStream createStream = File.Create(newPath);
//                //await JsonSerializer.SerializeAsync(createStream, animals);
//                //context.Response.ContentType = "text/html;charset=utf-8";
//                //await context.Response.WriteAsync($"</br><h1>Writing to file successful!</h1>");

//                // Writing JSON to file
//                string newPath = System.IO.Path.Combine(Directory.GetCurrentDirectory(), "animals.json");
//                await using FileStream createStream = File.Create(newPath);
//                await JsonSerializer.SerializeAsync(createStream, animals);
//                context.Response.ContentType = "text/html;charset=utf-8";
//                // writing that saving to file is successfull
//                await context.Response.WriteAsync($"</br><h1>Writing to file successfull!</h1>");
//                createStream.Flush();
//                createStream.Close();
//            }
//            catch (Exception ex)
//            {
//                await context.Response.WriteAsync($"An error `{ex.Message}` occurred while writing to the file.");
//            }
//        }

//        // Reading from JSON file
//        public async Task ReadAnimals(HttpContext context, IEnumerable<IAnimal> animals)
//        {
//            // Let's read from file
//            try
//            {
//                //string readPath = System.IO.Path.Combine(Directory.GetCurrentDirectory(), "animals.json");
//                //await using FileStream stream = File.OpenRead(readPath);
//                //IEnumerable<IAnimal> readedAnimals = await JsonSerializer.DeserializeAsync<IEnumerable<IAnimal>>(stream);
//                //await context.Response.WriteAsync($"</br><h1>Result of reading from file:</h1></br>");
//                //await context.Response.WriteAsync(JsonSerializer.Serialize(readedAnimals));


//                using (FileStream stream = File.OpenRead("animals.json"))
//                {
//                    IEnumerable<AnimalService> readedAnimals = await JsonSerializer.DeserializeAsync<IEnumerable<AnimalService>>(stream);
//                    await context.Response.WriteAsync($"</br><h1>Result of reading from file:</h1></br>");
//                    await context.Response.WriteAsync(JsonSerializer.Serialize(readedAnimals));
//                }
//            }
//            catch (Exception ex)
//            {
//                await context.Response.WriteAsync($"An error `{ex.Message}` occurred while reading to the file.");
//            }
//        }
//    }
//}
