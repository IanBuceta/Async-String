using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Async_String
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string taskString = await returnString(args[0], Convert.ToUInt32(args[1]), args[2], args[3]);
            Console.WriteLine(taskString);            
        }

        async static Task<string> returnString(string path, uint id, string teamName, string src)
        {
            Random random = new Random(DateTime.Now.Millisecond);

            var returnText = $"{DateTime.Now} {id} {teamName} {src}";
            using (StreamWriter sw = File.AppendText(path))
            {
                await sw.WriteLineAsync(returnText);
                await Task.Delay(random.Next(2, 5) * 1000);
            }
            return returnText;
        }
    }
}
