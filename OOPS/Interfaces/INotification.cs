namespace OOPS.Interfaces
{
    public interface INotification
    {
        void Send(string recipient, string message);
    }
}