using System;
using System.Collections.Generic;
using System.IO;
using CW.Prototypes;
using HtmlAgilityPack;
using Newtonsoft.Json;
using ScrapySharp.Network;

namespace CW.Parsers
{
    public static class Matches
    {
        public static List<Match> ParseUpcomingMatches(HtmlNode page)
        {
            List<Match> matches = new List<Match>();
            for(int i = 1; i <= 5; ++i)
            {
                string genMatch = $"/html/body/div[2]/div/div[2]/div[1]/div[2]/div[4]/div/div[3]/div/div[1]/div[1]/div[{i}]";
                var time = page.OwnerDocument.DocumentNode.SelectSingleNode(genMatch + "/a[1]/div[1]/div[1]").InnerText;
                var team1 = page.OwnerDocument.DocumentNode.SelectSingleNode(genMatch + "/a[1]/div[2]/div[1]/div[2]").InnerText;
                var team2 = page.OwnerDocument.DocumentNode.SelectSingleNode(genMatch + "/a[1]/div[2]/div[2]/div[2]").InnerText;
                var tournament = page.OwnerDocument.DocumentNode.SelectSingleNode(genMatch + "/a[1]/div[3]/div[2]").InnerText;
                matches.Add(new Match()
                {
                    Time = time,
                    FirstTeamName = team1,
                    SecondTeamName = team2,
                    Tournament = tournament
                });
            }

            return matches;
        }
    }
}