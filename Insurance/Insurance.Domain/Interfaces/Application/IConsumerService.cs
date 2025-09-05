namespace Insurance.Domain.Interfaces.Application
{
    public interface IConsumerService
    {
        Task<bool> ConsumeMessage();
    }
}
