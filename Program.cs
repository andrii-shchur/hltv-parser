using System;
using System.IO;
using System.Text.Json;
using Autofac;

namespace CW
{
    static class Program
    {
        static void Main(string[] args)
        {
            var container = ContainerConfigure.Configure();

            using var scope = container.BeginLifetimeScope();
            var provider = scope.Resolve<IProvider>();
            
            Start(provider);
        }
        
        public static string PrettyJson(string unPrettyJson)
        {
            var options = new JsonSerializerOptions(){
                WriteIndented = true
            };

            var jsonElement = JsonSerializer.Deserialize<JsonElement>(unPrettyJson);

            return JsonSerializer.Serialize(jsonElement, options);
        }

        public static void Start(IProvider provider)
        {
            Console.WriteLine("Choose operation:\n" +
                              "1 - Get upcoming matches\n" +
                              "2 - Get latest results\n" +
                              "3 - Get big events\n" +
                              "4 - Get common events\n" +
                              "5 - Get top players by rating\n" +
                              "6 - Get top teams by rating\n" +
                              "e - Exit");
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "output.txt");
            bool ok = true;
            while (ok)
            {
                var key = Console.ReadLine();
                switch (key)
                {
                    case "1":
                        File.AppendAllText(path, PrettyJson(provider.GetUpcomingMatches()));
                        Console.WriteLine("Result is in output.txt");
                        break;
                    case "2":
                        File.AppendAllText(path, PrettyJson(provider.GetLatestResults()));
                        Console.WriteLine("Result is in output.txt");
                        break;
                    case "3":
                        File.AppendAllText(path, PrettyJson(provider.GetBigEvents()));
                        Console.WriteLine("Result is in output.txt");
                        break;
                    case "4":
                        File.AppendAllText(path, PrettyJson(provider.GetCommonEvents()));
                        Console.WriteLine("Result is in output.txt");
                        break;
                    case "5":
                        File.AppendAllText(path, PrettyJson(provider.GetTopPlayersStats()));
                        Console.WriteLine("Result is in output.txt");
                        break;
                    case "6":
                        File.AppendAllText(path, PrettyJson(provider.GetTopTeamsStats()));
                        Console.WriteLine("Result is in output.txt");
                        break;
                    case "e":
                        ok = false;
                        break;
                    default:
                        Console.WriteLine("Try again!");
                        break;
                }
            }
        }
    }
}
