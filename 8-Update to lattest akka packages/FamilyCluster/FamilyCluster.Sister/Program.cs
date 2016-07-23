using System;
using System.Configuration;
using Akka.Actor;
using Akka.Routing;
using FamilyCluster.Common;

namespace FamilyCluster.Sister
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Starting SisterSystem ...");
            using (var system = ActorSystem.Create("FamilyCluster"))
            {
                var sisterEchoActor = system.ActorOf(Props.Create(() => new EchoActor()).WithRouter(FromConfig.Instance), "SisterEchoActor");

                while (true)
                {
                    var message = Console.ReadLine();
                    sisterEchoActor.Tell(new Hello("From SisterSystem to sisterEchoActor" + message), ActorRefs.NoSender);
                }
            }
        }
    }
}