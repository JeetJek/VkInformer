using System;
using System.IO;
using System.Net;

using Newtonsoft.Json;
using VkBotFramework;
using System.Text.Json;

namespace VkInformer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Запуск");
            VkBot infoBot;
            String Token="";
            String Group="";
            if(args.Length!=0)
            {
                if(args[0]== "-t")
                {
                    Console.WriteLine("-t использовано");
                    try
                    {
                        Token=args[1];
                    }
                    catch
                    {
                        Console.WriteLine("Не задан токен!");
                    }
                }
                if(args[2]== "-g")
                {
                    Console.WriteLine("-g использовано");
                    try
                    {
                        Group=args[3];
                    }
                    catch
                    {
                        Console.WriteLine("Не задана группа!");
                    }
                }
                if(args[0]== "-h")
                {
                    Console.WriteLine("-h  -  Вызов справки");
                    Console.WriteLine("-t  -  Задать токен");
                    Console.WriteLine("-g  -  Задать группу");
                }
            }
            if (File.Exists("Token"))
            {
                Console.WriteLine(File.ReadAllText("Token"));
                infoBot = new VkBot(File.ReadAllText("Token").Replace("\n",""), "https://vk.com/club189537036");
            }
            else
            {
                if(Token!="" && Group!="")
                {
                    infoBot = new VkBot(Token, Group);
                }
                else
                {
                    Console.WriteLine("Введите токен и группу");
                    infoBot = new VkBot(Console.ReadLine(), Console.ReadLine());
                }
            }

            String Msg="Температура за окном: "+ GetTemperature()+ "°C";
            Bot(ref infoBot, "jek_ouwl", Msg);
            infoBot.Dispose();
            Console.WriteLine("Закрытие");
            return;
        }

        public static String GetTemperature()
        {
            String respons="";
            WebRequest request = WebRequest.Create("https://api.openweathermap.org/data/2.5/weather?id=1489425&units=metric&appid=fe9ca06f442d762050d864bb19d574e0");
            WebResponse response = request.GetResponse();
            using (Stream stream = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    string line = "";
                    while ((line = reader.ReadLine()) != null)
                    {
                        respons += line;
                        Console.WriteLine(line);
                    }
                }
            }
            response.Close();
            Console.WriteLine("Запрос выполнен");
            String find1 = "\"temp\":";
            String answer=respons.Substring(respons.IndexOf(find1)+find1.Length, respons.IndexOf(",", respons.IndexOf(find1)) - respons.IndexOf(find1)-find1.Length);
            return answer;
        }
        
        public static void Bot(ref VkBot infoBot,String user,String Msg)
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
