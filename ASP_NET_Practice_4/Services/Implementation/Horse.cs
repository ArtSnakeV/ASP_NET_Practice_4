using ASP_NET_Practice_4.Services.Abstract;
namespace ASP_NET_Practice_4.Services.Implementation
{
    public class Horse : IAnimal
    {
        public string AnimalName { get; init; }
        public string AnimalSound { get; init; }
        public Horse()
        {            
            AnimalName = "Horse";
            AnimalSound = "neigh, whinny, nicker, hoofbeats (clip-clop)";
        }
    }
}
