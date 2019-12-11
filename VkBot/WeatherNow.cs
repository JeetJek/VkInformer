using System;
using System.Collections.Generic;
using System.Text;

namespace VkBot
{
	class WeatherFullNow
	{
		public Coordinate coord;
		public Weather weather;
		public string base1;
		public Main main;
		public int visibility;
		public Wind wind;
		public Clouds clouds;
		public int date;
		public System sys;
		public int timezone;
		public int id;
		public string name;
		public int cod;
	}

	struct Coordinate
	{
		public double lon;
		public double lat;
	}

	struct Weather
	{
		public int id;
		public string main;
		public string description;
		public string icon;
	}

	struct Main
	{
		public double temp;
		public double pressure;
		public int humidity;
		public double temp_min;
		public double temp_max;
	}

	struct Wind
	{
		public int speed;
		public int deg; 
	}

	struct Clouds
	{
		public int all;
	}

	struct System
	{
		public int type;
		public int id;
		public string country;
		public int sunrise;
		public int sunset;
	}
}
