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
            VkBot infoBot;
            if (File.Exists("Token"))
                infoBot = new VkBot(File.ReadAllText("Token"), "https://vk.com/club189537036");
            else
                infoBot = new VkBot(Console.ReadLine(), Console.ReadLine());

            String Msg="Температура за окном: "+ GetTemperature()+ "°C";
            Bot(ref infoBot, "jek_ouwl", Msg);
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
            finally
            {
                infoBot.Start();
                infoBot.Dispose();
            }
            
        }
    }
}
