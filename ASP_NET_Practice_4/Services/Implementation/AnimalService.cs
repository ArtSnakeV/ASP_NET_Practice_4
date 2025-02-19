using ASP_NET_Practice_4.Services.Abstract;

namespace ASP_NET_Practice_4.Services.Implementation
{
    public class AnimalService
    {
        public AnimalService(IAnimal animal)
        {
            Animal = animal;
        }
        public IAnimal Animal { get; }

    }
}
