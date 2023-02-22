using HtmlAgilityPack;
using System;
using System.Net.Http;

namespace WebScraper
{
    class Program
    {
        static void Main(String[] args)
        {
            // Send get request to weather.com
            String url = "https://weather.com/weather/today/l/624f0cccc10bececfa4c083056cef743837a76588790f476c9ebea44be35e51f";
            var httpClient = new HttpClient();
            var html = httpClient.GetStringAsync(url).Result;
            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(html);

            // Get the temperature
            var temperatureElement = htmlDocument.DocumentNode.SelectSingleNode("//span[@class='CurrentConditions--tempValue--MHmYY']");
            var temperature = temperatureElement.InnerText.Trim();
            Console.WriteLine("Temperature: " + temperature);

            // Get the conditions
            var conditionElement = htmlDocument.DocumentNode.SelectSingleNode("//div[@class='CurrentConditions--phraseValue--mZC_p']");
            var conditions = conditionElement.InnerText.Trim();
            Console.WriteLine("Conditions: " + conditions);

            // Get the location
            var cityElement = htmlDocument.DocumentNode.SelectSingleNode("//h1[@class='CurrentConditions--location--1YWj_']");
            var city = cityElement.InnerText.Trim();
            Console.WriteLine("City: " + city);
        }
    }
}
