using Microsoft.AspNet.SignalR.Client.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRExample.WebClientConsole
{
    public class Program
    {

        //public class MyHub : Hub
        //{
        //    public void Send(string name, string message)
        //    {
        //        Clients.All.addMessage(name, message);
        //    }
        //}
        private static void Main(string[] args)
        {
            //Set connection
            var connection = new HubConnection("http://localhost:8080/");
            //Make proxy to hub based on hub name on server
            var myHub = connection.CreateHubProxy("MyHub");
            //Start connection

            connection.Start().ContinueWith(task =>
            {
                if (task.IsFaulted)
                {
                    Console.WriteLine("There was an error opening the connection:{0}",
                                      task.Exception.GetBaseException());
                }
                else
                {
                    Console.WriteLine("Connected");
                }

            }).Wait();

            myHub.Invoke<string>("Send", "Renan", "Hello World!!").ContinueWith(task =>
            {
                if (task.IsFaulted)
                {
                    Console.WriteLine("There was an error calling send: {0}",
                                      task.Exception.GetBaseException());
                }
                else
                {
                    Console.WriteLine(task.Result);
                }
            });

            Console.Read();
            connection.Stop();
        }
    }
}
