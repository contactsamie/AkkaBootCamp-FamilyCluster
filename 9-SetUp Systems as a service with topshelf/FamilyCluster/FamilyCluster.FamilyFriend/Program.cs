using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Akka.Actor;
using Akka.Routing;
using FamilyCluster.Common;
using Topshelf;

namespace FamilyCluster.FamilyFriend
{
    

    public class ProgramStart
    {
        public void Start()
        {
            Console.WriteLine("Starting FamilyFriendSystem ...");
            var client = ConfigurationManager.AppSettings["client"];
            using (var system = ActorSystem.Create("FamilyFriendSystem"))
            {
                while (true)
                {
                    var message = Console.ReadLine();
                    var clientActor = system.ActorSelection(client);
                    clientActor.Tell(new Hello("From FamilyFriendSystem to client " + client + " : " + message), ActorRefs.NoSender);
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
                x.SetDisplayName("AkkaBootCampTDD-FamilyFriendSystem");
                x.SetServiceName("AkkaBootCampTDD-FamilyFriendSystem");
            });
        }
    }
}
