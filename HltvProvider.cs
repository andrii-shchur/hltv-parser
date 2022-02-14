using CW.Parsers;
using Newtonsoft.Json;

namespace CW
{
    public class HltvProvider : IProvider
    {
        public string GetUpcomingMatches()
        {
            var page = WebClient.GetInstance().GetPage(Links.Home + Links.UpcomingMatches);
            var matches = Matches.ParseUpcomingMatches(page);
            var result = JsonConvert.SerializeObject(matches);

            return result;
        }

        public string GetLatestResults()
        {
            var page = WebClient.GetInstance().GetPage(Links.Home + Links.Results);
            var matches = Results.ParseResults(page);
            var result = JsonConvert.SerializeObject(matches);

            return result;
        }

        public string GetBigEvents()
        {
            var page = WebClient.GetInstance().GetPage(Links.Home + Links.Events);
            var events = Events.ParseBigEvents(page);
            var result = JsonConvert.SerializeObject(events);

            return result;
        }

        public string GetCommonEvents()
        {
            var page = WebClient.GetInstance().GetPage(Links.Home + Links.Events);
            var events = Events.ParseCommonEvents(page);
            var result = JsonConvert.SerializeObject(events);

            return result;
        }

        public string GetTopPlayersStats()
        {
            var page = WebClient.GetInstance().GetPage(Links.Home + Links.Stats);
            var events = Stats.ParseTopPlayersEvents(page);
            var result = JsonConvert.SerializeObject(events);

            return result;
        }

        public string GetTopTeamsStats()
        {
            var page = WebClient.GetInstance().GetPage(Links.Home + Links.Stats);
            var events = Stats.ParseTopTeamsEvents(page);
            var result = JsonConvert.SerializeObject(events);

            return result;
        }
    }
}