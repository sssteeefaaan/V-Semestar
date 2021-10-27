 // Singleton pattern -- Primer iz stvarnog sveta 

using System;
using System.Collections;
using System.Threading;

namespace DoFactory.GangOfFour.Singleton.RealWorld
{
  
  // MainApp test aplikacija 

  class MainApp
  {
    static void Main()
    {
      LoadBalancer b1 = LoadBalancer.GetLoadBalancer();
      LoadBalancer b2 = LoadBalancer.GetLoadBalancer();
      LoadBalancer b3 = LoadBalancer.GetLoadBalancer();
      LoadBalancer b4 = LoadBalancer.GetLoadBalancer();

      // Iste instance? 
      if (b1 == b2 && b2 == b3 && b3 == b4)
      {
        Console.WriteLine("Same instance\n");
      }

      // Pošto su svi zapravo ista instanca b1 će se koristiti arbitrarno 
      // Učitavanje 15 zahteva serveru 
      for (int i = 0; i < 15; i++)
      {
        Console.WriteLine(b1.Server);
      }

      // Čekanje na korisnički unos 
      Console.Read();    
    }
  }

  // "Singleton" 

  class LoadBalancer
  {
    private static LoadBalancer instance;
    private ArrayList servers = new ArrayList();

    private Random random = new Random();

    // Sinhronizacioni objekat 
    private static object syncLock = new object();

    // Konstruktor (protected) 
    protected LoadBalancer() 
    {
      // Lista raspoloživih servera 
      servers.Add("ServerI");
      servers.Add("ServerII");
      servers.Add("ServerIII");
      servers.Add("ServerIV");
      servers.Add("ServerV");
    }

    public static LoadBalancer GetLoadBalancer()
    {
      // Podrška za aplikaciju sa više niti kroz tzv. 
      // 'Double checked locking' metodu sinhronizacije.
      // Ovo će omogućiti da kada se jednom kreira instanca, zaključavanje 
      // se neće vršiti pri svakom zahtevu 
      if (instance == null)
      {
        lock (syncLock)
        {
          if (instance == null)
          {
            instance = new LoadBalancer();
          }
        }
      }

      return instance;
    }

    // Jednostavno kreriranje servera 

    public string Server
    {
      get
      {
        int r = random.Next(servers.Count);
        return servers[r].ToString();
      }
    }
  }
}
