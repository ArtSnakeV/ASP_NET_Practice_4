using ASP_NET_Practice_4.Services.Abstract;

namespace ASP_NET_Practice_4.Services.Implementation
{
    public class Crab : IAnimal
    {
        public string AnimalName { get; init; }
        public string AnimalSound { get; init; }
        public Crab()
        {
            AnimalName = "Crab";
            AnimalSound = "chirp, click, creak";
        }
    }
}
