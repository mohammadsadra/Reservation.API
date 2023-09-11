namespace Reservation.API.Services
{
    public interface IMailService
    {
        void Email(string subject, string htmlString);
        void LogData();
    }
}