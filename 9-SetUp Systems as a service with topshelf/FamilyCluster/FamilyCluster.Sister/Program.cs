using System;
using System.Configuration;
using Akka.Actor;
using Akka.Routing;
using FamilyCluster.Common;
using Topshelf;

namespace FamilyCluster.Sister
{
    public class ProgramStart
    {
        public void Start()
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
        public void Stop() { /*todo: update code so service can be stoped*/ }
    }

    public class Program
    {
        public static void Main()
        {
            HostFactory.Run(x =>
            {
                x.Service<ProgramStart>(s =>
                {
                    s.ConstructUsing(name => new ProgramStart());
                    s.WhenStarted(tc => tc.Start());
                    s.WhenStopped(tc => tc.Stop());
                });
                x.RunAsLocalSystem();

                x.SetDescription("AkkaBootCampTDD");
                x.SetDisplayName("AkkaBootCampTDD-SisterSystem");
                x.SetServiceName("AkkaBootCampTDD-SisterSystem");
            });
        }
    }
}