using AoC.Helpers.Utils;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace AoC.Helpers.Input
{
    public class InputProvider
    {
        private HttpClient client;

        public InputProvider()
        {
            this.InitClient();
        }

        public byte[] GetInput(int year, int day) => GetInputAsync(year, day).Result;

        public async Task<byte[]> GetInputAsync(int year, int day)
        {
            var tempFilePath = GetTempFilePath(year.ToString(), day.ToString());

            var fileData = GetTempFileData(tempFilePath);

            if (fileData != null)
            {
                return fileData;
            }

            fileData = await this.Download(client, $"{year}/day/{day}/input");

            File.WriteAllBytes(tempFilePath, fileData);

            return fileData;
        }

        private Cookie CreateSessionCookie() => new Cookie
        {
            Name = "session",
            Domain = ".adventofcode.com",
            Path = "/",
            Expires = new DateTime(2029, 11, 11, 05, 42, 29),
            Value = Constants.CurrentToken,
            HttpOnly = true
        };

        private async Task<byte[]> Download(HttpClient client, string path)
        {
            Console.WriteLine($"Downloading {client.BaseAddress + path}");
            var response = await client.GetAsync(path);

            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsByteArrayAsync();
        }

        private string GetAocTempPath(string year)
        {
            var aocPath = Path.Combine(Path.GetTempPath(), "AoC", year);

            Directory.CreateDirectory(aocPath);

            return aocPath;
        }

        private byte[] GetTempFileData(string path)
        {
            if (File.Exists(path))
            {
                return File.ReadAllBytes(path);
            }

            return null;
        }

        private string GetTempFilePath(string year, string day) => Path.Combine(GetAocTempPath(year), $"{day}.input");

        private void InitClient()
        {
            var cookieContainer = new CookieContainer();

            this.client = new HttpClient(
                new HttpClientHandler
                {
                    CookieContainer = cookieContainer,
                    AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
                });

            var baseAddress = new Uri("https://adventofcode.com/");
            client.BaseAddress = baseAddress;
            cookieContainer.Add(baseAddress, this.CreateSessionCookie());
        }
    }
}