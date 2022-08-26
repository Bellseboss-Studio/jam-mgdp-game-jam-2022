namespace SystemOfExtras
{
    public interface IStatesMissions
    {
        bool IsActiveMission(IdMissions idMissions);
        void AddMission(IdMissions idMissions);
        void MissionCompleted(IdMissions idMissions);
    }
}