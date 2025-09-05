namespace Insurance.Domain.Interfaces.Application
{
    public interface IProducerService
    {
        Task<bool> GenerateMessage(string message);
    }
}
