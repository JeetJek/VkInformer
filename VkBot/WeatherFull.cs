using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Collections.Specialized;
using Newtonsoft.Json;

namespace VkInformer
{

	public class WeatherFull
	{
		[JsonProperty("coord")]
		public Coordinate Coord { get; set; }

		[JsonProperty("weather")]
		public List<Weather> Weathers { get; set; }

		[JsonProperty("base")]
		public string Base { get; set; }

		[JsonProperty("main")]
		public Main Main { get; set; }

		[JsonProperty("visibility")]
		public int Visibility { get; set; }

		[JsonProperty("wind")]
		public Wind Wind { get; set; }

		[JsonProperty("Clouds")]
		public Clouds clouds { get; set; }

		[JsonProperty("Date")]
		public int Date { get; set; }

		[JsonProperty("sys")]
		public System Sys { get; set; }

		[JsonProperty("timezone")]
		public int TimeZone { get; set; }

		[JsonProperty("id")]
		public int Id { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("cod")]
		public int Cod { get; set; }
	}

	public class Coordinate
	{
		[JsonProperty("lon")]
		public double Lon { get; set; }

		[JsonProperty("lat")]
		public double Lat { get; set; }
	}

	public class Weather
	{
		[JsonProperty("id")]
		public int Id { get; set; }

		[JsonProperty("main")]
		public string Main { get; set; }

		[JsonProperty("description")]
		public string Description { get; set; }

		[JsonProperty("icon")]
		public string Icon { get; set; }
	}

	public class Main
	{
		[JsonProperty("temp")]
		public double Temperature { get; set; }

		[JsonProperty("pressure")]
		public double Pressure { get; set; }

		[JsonProperty("humidity")]
		public int Humidity { get; set; }

		[JsonProperty("temp_min")]
		public double TempMin { get; set; }

		[JsonProperty("temp_max")]
		public double TempMax { get; set; }
	}

	public class Wind
	{
		[JsonProperty("speed")]
		public int Speed { get; set; }

		[JsonProperty("deg")]
		public int Deg { get; set; }
	}

	public class Clouds
	{
		[JsonProperty("all")]
		public int All { get; set; }
	}

	public class System
	{
		[JsonProperty("type")]
		public int Type { get; set; }

		[JsonProperty("id")]
		public int Id { get; set; }

		[JsonProperty("country")]
		public string Country { get; set; }

		[JsonProperty("sunrise")]
		public int Sunrise { get; set; }

		[JsonProperty("sunset")]
		public int Sunset { get; set; }
	}
}
