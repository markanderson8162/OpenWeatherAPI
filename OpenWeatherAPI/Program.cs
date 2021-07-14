using System;
using System.Net.Http;
using Newtonsoft.Json.Linq;


namespace OpenWeatherAPI
{
	class Program
	{
		static void Main(string[] args)
		{
			var client = new HttpClient();
			Console.WriteLine("Please enter your API key:");
			var apiKey = Console.ReadLine();

			while (true)
			{
				Console.WriteLine();
				Console.WriteLine("Please enter your city name: ");
				var cityName = Console.ReadLine();
				var weatherURL = $"http://api.openweathermap.org/data/2.5/weather?q={cityName}&appid={apiKey}&units=imperial";

				var response = client.GetStringAsync(weatherURL).Result;
				var formattedResponse = JObject.Parse(response).GetValue("main").ToString();
				Console.WriteLine(formattedResponse);
				Console.WriteLine();
				Console.WriteLine("Do you want another city?");
				var userInput = Console.ReadLine();
				Console.WriteLine();

				if(userInput.ToLower() == "no")
				{
					break;
				}

			}
		}
	}
}
