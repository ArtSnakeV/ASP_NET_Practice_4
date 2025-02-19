namespace ASP_NET_Practice_4.Services.Abstract
{
    public interface IAnimalSender
    {
        Task GetAnimal(HttpContext context);
    }
}
