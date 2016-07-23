using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Akka.Actor;
using Akka.Routing;
using FamilyCluster.Common;

namespace FamilyCluster.FamilyFriend
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting FamilyFriendSystem ...");
            var client = ConfigurationManager.AppSettings["client"];
            using (var system = ActorSystem.Create("FamilyFriendSystem"))
            {
                while (true)
                {
                    var message = Console.ReadLine();
                    var clientActor = system.ActorSelection(client);
                    clientActor.Tell(new Hello("From FamilyFriendSystem to client "+client+" : " + message), ActorRefs.NoSender);
                }
            }
        }
    }
}
