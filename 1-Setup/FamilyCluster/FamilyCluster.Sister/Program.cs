using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Akka.Actor;
using Akka.Configuration;
using FamilyCluster.Common;

namespace FamilyCluster.Sister
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting SisterSystem ...");
            using (var system = ActorSystem.Create("SisterSystem"))
            {
              var  sisterEchoActor= system.ActorOf(Props.Create(() => new EchoActor()), "SisterEchoActor");

                while (true)
                {
                    var message = Console.ReadLine();
                    sisterEchoActor.Tell(new Hello(message), ActorRefs.NoSender);
                }

            }
        }
    }
}
