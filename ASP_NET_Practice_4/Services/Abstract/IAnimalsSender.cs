namespace ASP_NET_Practice_4.Services.Abstract
{
    public interface IAnimalsSender
    {
        Task GetAnimals(HttpContext context, IEnumerable<IAnimal> animals);
        Task WriteAnimals(HttpContext context, IEnumerable<IAnimal> animals);
        Task ReadAnimals(HttpContext context, IEnumerable<IAnimal> animals);
    }
}
