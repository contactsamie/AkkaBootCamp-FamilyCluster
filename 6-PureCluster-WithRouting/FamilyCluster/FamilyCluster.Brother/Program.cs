using System;
using System.Configuration;
using Akka.Actor;
using Akka.Routing;
using FamilyCluster.Common;

namespace FamilyCluster.Brother
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Starting BrotherSystem ...");
            using (var system = ActorSystem.Create("FamilyCluster"))
            {
                // var client = ConfigurationManager.AppSettings["client"];
                var brotherEchoActor = system.ActorOf(Props.Create(() => new EchoActor()).WithRouter(FromConfig.Instance), "BrotherEchoActor");

                while (true)
                {
                    var message = Console.ReadLine();
                    brotherEchoActor.Tell(new Hello("From BrotherSystem to BrotherEchoActor" + message),
                        ActorRefs.NoSender);

                   // system.ActorSelection(client).Tell(new Hello("From BrotherSystem to client at " + client + message));
                }
            }
        }
    }
}