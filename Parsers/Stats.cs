using System;
using System.Collections.Generic;
using System.IO;
using CW.Prototypes;
using HtmlAgilityPack;

namespace CW.Parsers
{
    public class Stats
    {
        public static List<Player> ParseTopPlayersEvents(HtmlNode page)
        {
            List<Player> players = new List<Player>();
            for(int i = 2; i <= 9; ++i)
            {
                string genPlayer = $"/html/body/div[2]/div/div[2]/div[1]/div[2]/div[7]/div[1]/div[{i}]";
                var name = page.OwnerDocument.DocumentNode.SelectSingleNode(genPlayer + "/a").InnerText;
                var rating = page.OwnerDocument.DocumentNode.SelectSingleNode(genPlayer + "/div[4]/span").InnerText;
                var maps = Convert.ToInt32(
                    page.OwnerDocument.DocumentNode.SelectSingleNode(genPlayer + "/div[5]/span").InnerText);
                players.Add(new Player()
                {
                    Name = name,
                    Rating = rating,
                    Maps = maps
                });
            }

            return players;
        }

        public static List<Team> ParseTopTeamsEvents(HtmlNode page)
        {
            List<Team> teams = new List<Team>();
            for(int i = 2; i <= 9; ++i)
            {
                string genPlayer = $"/html/body/div[2]/div/div[2]/div[1]/div[2]/div[7]/div[2]/div[{i}]";
                var name = page.OwnerDocument.DocumentNode.SelectSingleNode(genPlayer + "/a").InnerText;
                var rating = page.OwnerDocument.DocumentNode.SelectSingleNode(genPlayer + "/div[3]/span").InnerText;
                var maps = Convert.ToInt32(
                    page.OwnerDocument.DocumentNode.SelectSingleNode(genPlayer + "/div[4]/span").InnerText);
                teams.Add(new Team()
                {
                    Name = name,
                    Rating = rating,
                    Maps = maps
                });
            }

            return teams;
        }
    }
}