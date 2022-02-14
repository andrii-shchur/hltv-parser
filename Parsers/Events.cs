using System;
using System.Collections.Generic;
using System.IO;
using CW.Prototypes;
using HtmlAgilityPack;

namespace CW.Parsers
{
    public static class Events
    {
        public static List<Event> ParseBigEvents(HtmlNode page)
        {
            List<Event> events = new List<Event>();
            File.WriteAllText("index.html",page.InnerHtml);
            for(int i = 1; i <= 3; ++i)
            {
                string genEvent = $"/html/body/div[2]/div/div[2]/div[1]/div[2]/div[3]/div[1]/div[2]/a[{i}]";
                var name = page.OwnerDocument.DocumentNode.SelectSingleNode(genEvent + "/div[2]/div[1]/div[1]").InnerText;
                var startDate = page.OwnerDocument.DocumentNode.SelectSingleNode(genEvent + "/div[2]/div[2]/table/tr[1]/td[1]/span[1]").InnerText;
                var endDate = page.OwnerDocument.DocumentNode.SelectSingleNode(genEvent + "/div[2]/div[2]/table/tr[1]/td[1]/span[2]/span").InnerText;
                var prize = page.OwnerDocument.DocumentNode.SelectSingleNode(genEvent + "/div[2]/div[2]/table/tr[1]/td[2]").InnerText;
                var teamsCount = page.OwnerDocument.DocumentNode.SelectSingleNode(genEvent + "/div[2]/div[2]/table/tr[1]/td[3]").InnerText;
                var location = page.OwnerDocument.DocumentNode.SelectSingleNode(genEvent + "/div[2]/div[1]/div[2]/div[1]/span").InnerText;
                events.Add(new Event()
                {
                    Name = name,
                    StartDate = startDate,
                    EndDate = endDate,
                    Prize = prize,
                    TeamsCount = teamsCount,
                    Location = location
                });
            }

            return events;
        }

        public static List<Event> ParseCommonEvents(HtmlNode page)
        {
            List<Event> events = new List<Event>();
            File.WriteAllText("index.html",page.InnerHtml);
            for(int i = 1; i <= 6; ++i)
            {
                string genEvent = $"/html/body/div[2]/div/div[2]/div[1]/div[2]/div[3]/div[1]/a[{i}]";
                var name = page.OwnerDocument.DocumentNode.SelectSingleNode(genEvent + "/div[2]/table/tr[1]/td[1]/div").InnerText;
                var startDate = page.OwnerDocument.DocumentNode.SelectSingleNode(genEvent + "/div[2]/table/tr[2]/td[1]/span[2]/span/span[1]").InnerText;
                var endDate = page.OwnerDocument.DocumentNode.SelectSingleNode(genEvent + "/div[2]/table/tr[2]/td[1]/span[2]/span/span[2]/span").InnerText;
                var prize = page.OwnerDocument.DocumentNode.SelectSingleNode(genEvent + "/div[2]/table/tr[1]/td[3]").InnerText;
                var teamsCount = page.OwnerDocument.DocumentNode.SelectSingleNode(genEvent + "/div[2]/table/tr[1]/td[2]").InnerText;
                var location = page.OwnerDocument.DocumentNode.SelectSingleNode(genEvent + "/div[2]/table/tr[2]/td[1]/span[1]/span").InnerText;
                events.Add(new Event()
                {
                    Name = name,
                    StartDate = startDate,
                    EndDate = endDate,
                    Prize = prize,
                    TeamsCount = teamsCount,
                    Location = location
                });
            }

            return events;
        }
    }
}