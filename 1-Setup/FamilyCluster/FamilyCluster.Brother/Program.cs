using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Akka.Actor;
using FamilyCluster.Common;

namespace FamilyCluster.Brother
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting BrotherSystem ...");
            using (var system = ActorSystem.Create("BrotherSystem"))
            {
                var brotherEchoActor = system.ActorOf(Props.Create(() => new EchoActor()), "BrotherEchoActor");

                while (true)
                {
                    var message = Console.ReadLine();
                    brotherEchoActor.Tell(new Hello(message), ActorRefs.NoSender);
                }

            }
        }
    }
}
