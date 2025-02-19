using ASP_NET_Practice_4.Services.Abstract;

namespace ASP_NET_Practice_4.Services.Implementation
{
    public class Cat : IAnimal
    {
        public string AnimalName { get; init; }
        public string AnimalSound { get; init; }
        public Cat()
        {
            AnimalName = "Cat";
            AnimalSound = "mew, meow, purr, hiss, trill, caterwaul, growl";
        }
    }
}
