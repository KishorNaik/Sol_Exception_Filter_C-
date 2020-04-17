using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Sol_Demo
{
    class Program
    {
        async static Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Demo demo = new Demo();
            string response = await demo?.MakeRequestAsync();
            Console.WriteLine(response);

        }
    }

    public class Demo
    {
        public async Task<String> MakeRequestAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    var responseText = await client.GetStringAsync("https://docs.microsoft.com/en-us/dotnet/about/");

                    return responseText;
                }
                catch (Exception ex) when (ex.Message.Contains("301"))
                {
                    return "Site Moved";
                }
                catch(Exception ex) when (ex.Message.Contains("401"))
                {
                    return "Bad Request";
                }
            }
        }
    }
}
