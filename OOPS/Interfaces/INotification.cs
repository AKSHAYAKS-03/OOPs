namespace NotificationApp.Interfaces
{
    public interface INotification
    {
        void Send(string recipient, string message);
    }
}