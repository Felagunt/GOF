using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoadBalancing
{
    /// <summary>
    /// MainApp startup class for Real-world
    /// singleton design pattern.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Entry point into console application
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            LoadBalancer b1 = LoadBalancer.GetLoadBalancer();
            LoadBalancer b2 = LoadBalancer.GetLoadBalancer();
            LoadBalancer b3 = LoadBalancer.GetLoadBalancer();
            LoadBalancer b4 = LoadBalancer.GetLoadBalancer();
            //confirm these are the same instance
            if (b1==b2 && b2==b3 && b3==b4)
            {
                Console.WriteLine("Same instance\n");
            }

            //load balance 15 server requests
            LoadBalancer balancer = LoadBalancer.GetLoadBalancer();
            for(int i=0;i<15;i++)
            {
                string server = balancer.NextServer.Name;
                Console.WriteLine("Dispatch Request to: " + server);
            }
            //wait for user
            Console.ReadKey();
        }
    }
    /// <summary>
    /// The singleton class
    /// </summary>
    /// 
    sealed class LoadBalancer
    {
        //static members are 'eagerly initialized', that is,
        //immediately when class is loded for the first time.
        //.Net guarantees thread safety for static initialization
        private static readonly LoadBalancer _instance =
            new LoadBalancer();
        //type-safe generic list of servers
        private List<Server> _servers;
        private Random _random = new Random();
        //lock synchronization object
        private static object syncLock = new object();
        //constuctor (private)
        private LoadBalancer()
        {
            //load list of available servers
            _servers = new List<Server>
            {
                new Server {Name= "ServerI",IP="120.14.220.18" },
                new Server {Name= "ServerII",IP="120.14.220.19" },
                new Server {Name= "ServerIII",IP="120.14.220.20" },
                new Server {Name= "ServerIV",IP="120.14.220.21" },
                new Server {Name= "ServerV",IP="120.14.220.22" },
            };
        }
        public static LoadBalancer GetLoadBalancer()
        {
            return _instance;
        }
        //simple but effective load balancer
        public Server NextServer
        {
            get
            {
                int r = _random.Next(_servers.Count);
                return _servers[r];
            }
        }
    }
    /// <summary>
    /// represents a server machine
    /// </summary>
    public class Server
    {
        //gets or sets server name
        public string Name { get; set; }
        //gets or sets server ip address
        public string IP { get; set; }
    }
}
