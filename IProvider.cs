namespace CW
{
    public interface IProvider
    {
        string GetUpcomingMatches();
        string GetLatestResults();
        string GetBigEvents();
        string GetCommonEvents();
        string GetTopPlayersStats();
        string GetTopTeamsStats();
    }
}