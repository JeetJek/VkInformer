using System;
using System.IO;
using System.Net;
using Newtonsoft.Json;
using VkBotFramework;

namespace VkInformer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Запуск");
            VkBot infoBot;
            String Token = "";
            String Group = "";
            String User="";
            if(args.Length != 0)
            {
                for(int i=0;i<args.Length;i++)
                {
                    if(args[i] == "-t")
                    {
                        try
                        {
                            Token = args[i+1];
                        }
                        catch
                        {
                            Console.WriteLine("Не задан токен!");
                        }
                    }
                if(args[i] == "-g")
                {
                    try
                    {
                        Group = args[i+1];
                    }
                    catch
                    {
                        Console.WriteLine("Не задана группа!");
                    }
                }
                if(args[i] == "-u")
                {
                    try
                    {
                        User = args[i+1];
                    }
                    catch
                    {
                        Console.WriteLine("Не задан пользователь!");
                    }
                }
                }
                if(args[0] == "-h" || args[0] =="--help")
                {
                    Console.WriteLine("--help | -h  -  Вызов справки");
                    Console.WriteLine("-t  -  Задать токен");
                    Console.WriteLine("-g  -  Задать группу");
                    Console.WriteLine("-u  -  Задать пользователя");
                    return;
                }
            }
            if(User=="")
            {
                Console.WriteLine("Пользователь не задан");
                return;
            }
            if (File.Exists("Token")&&File.Exists("Group"))
            {
                Console.WriteLine(File.ReadAllText("Token"));
                infoBot = new VkBot(File.ReadAllText("Token"),File.ReadAllText("Group")); 
            }
            else
            {
                if((Token != "") && (Group != ""))
                {
                    infoBot = new VkBot(Token, Group);
                }
                else
                {
                    Console.WriteLine("Введите токен и группу:");
                    infoBot = new VkBot(Console.ReadLine(), Console.ReadLine());
                }
            }

            // Получение данных
            WeatherFull Weather;
            try
            {
                Weather = JsonConvert.DeserializeObject<WeatherFull>(GetData());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return;
            }
            String Msg = "Температура за окном: "+ GetTemperature(Weather) + "°C";
            Bot(ref infoBot, User, Msg);
            infoBot.Dispose();
            Console.WriteLine("Закрытие");
            return;
        }
       
        public static double GetTemperature(WeatherFull weather)
        {
            return weather.Main.Temperature;
        }

        public static string GetData()
        {
            WebRequest webRequest = WebRequest.Create("https://api.openweathermap.org/data/2.5/weather?id=1489425&units=metric&appid=fe9ca06f442d762050d864bb19d574e0");
            WebResponse webResponse = webRequest.GetResponse();
            string response = "";
            using (Stream stream = webResponse.GetResponseStream())
            {
                using (StreamReader streamReader = new StreamReader(stream))
                {
                    response = streamReader.ReadToEnd();
                }
            }
            return response;
        }

        public static void Bot(ref VkBot infoBot, String user, String Msg)
        {
            try
            {
                infoBot.Api.Messages.Send(new VkNet.Model.RequestParams.MessagesSendParams
                {
                    RandomId = Math.Abs(Environment.TickCount),
                    Message = Msg,
                    Domain = user
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine("         Error!");
                Console.WriteLine("################################");
                Console.WriteLine();
                Console.WriteLine(ex.ToString());
                Console.WriteLine();
                Console.WriteLine("################################");
            }         
        }
    }
}
