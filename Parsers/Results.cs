using System.Collections.Generic;
using System.IO;
using CW.Prototypes;
using HtmlAgilityPack;

namespace CW.Parsers
{
    public static class Results
    {
        public static List<Match> ParseResults(HtmlNode page)
        {
            //File.WriteAllText("index.html", page.InnerHtml);
            List<Match> matches = new List<Match>();
            for(int i = 1; i <= 10; ++i)
            {
                string genMatch = $"/html/body/div[2]/div/div[2]/div[1]/div[2]/div[4]/div[1]/div[1]/div[{i}]";
                var team1 = page.OwnerDocument.DocumentNode.
                    SelectSingleNode(genMatch + "/a/div/table/tr/td[1]/div").InnerText;
                var team2 = page.OwnerDocument.DocumentNode.
                    SelectSingleNode(genMatch + "/a/div/table/tr/td[3]/div").InnerText;
                var score = page.OwnerDocument.DocumentNode.
                    SelectSingleNode(genMatch + "/a/div/table/tr/td[2]").InnerText;
                var tournament = page.OwnerDocument.DocumentNode.
                    SelectSingleNode(genMatch + "/a/div/table/tr/td[4]").InnerText;
                matches.Add(new Match()
                {
                    //FirstTeamName = team1,
                    //SecondTeamName = team2,
                    Score = score,
                    Tournament = tournament
                });
            }

            return matches;
        }
    }
}