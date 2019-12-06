using System;
using System.IO;
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
            infoBot.Api.Messages.Send(new VkNet.Model.RequestParams.MessagesSendParams
            {
                RandomId = Math.Abs(Environment.TickCount),
                Message = "Test",
                Domain = "jek_ouwl"
            });

            infoBot.Start();
        }
    }
}
