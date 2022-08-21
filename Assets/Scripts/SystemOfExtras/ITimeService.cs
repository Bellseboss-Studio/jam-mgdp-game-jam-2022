namespace SystemOfExtras
{
    public interface ITimeService
    {
        void Anochecio();
        string GetTime();
        void SitUntilNight();
        bool IsNigth();
        void AddMinutes(int minutos);
        void StartToCountTime();
    }
}