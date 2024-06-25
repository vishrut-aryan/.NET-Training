using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WebScrapingTool
{
    class Program
    {
        static async Task Main(string[] args)
        {
            List<string> urls = new List<string>
            {
                "https://github.com/vishrut-aryan/",
                "https://learn.microsoft.com/en-us/dotnet/csharp/asynchronous-programming/",
                "https://www.c-sharpcorner.com/UploadFile/1e050f/creating-and-using-dll-class-library-in-C-Sharp/"
            };

            List<Task<string>> scrapingTasks = new List<Task<string>>();

            foreach (var url in urls)
            {
                scrapingTasks.Add(ScrapeWebsiteAsync(url));
            }

            var results = await Task.WhenAll(scrapingTasks);

            foreach (var result in results)
            {
                int cutoff = 0;
                if (result != null)
                {
                    cutoff = Math.Min(250, result.Length);
                    Console.WriteLine(result.Substring(0, cutoff));
                }
            }
            Console.ReadLine();
        }

        static async Task<string> ScrapeWebsiteAsync(string url)
        {
            HttpClient client = new HttpClient();
            try
            {
                string content = await client.GetStringAsync(url);
                Console.WriteLine($"Successfully scraped {url}");
                return content;
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"Request error: {e.Message}");
                Console.ReadLine();
                return null;
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine($"Request error: {e.Message}");
                Console.ReadLine();
                return null;
            }
        }
    }
}
