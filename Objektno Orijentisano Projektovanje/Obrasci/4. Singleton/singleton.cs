using System;

namespace DoFactory.GangOfFour.Singleton.Structural
{
  
  // MainApp test aplikacija 

  class MainApp
  {
    
    static void Main()
    {
      // Konstruktor je “protected” – ne može se instancirati sa “new”
      Singleton s1 = Singleton.Instance();
      Singleton s2 = Singleton.Instance();

      if (s1 == s2)
      {
        Console.WriteLine("Objects are the same instance");
      }

      // Čekanje na korisnički unos 
      Console.Read();
    }
  }

  // "Singleton" 

  class Singleton
  {
    private static Singleton instance;

    // “protected” konstruktor
    protected Singleton() 
    {
    }

    public static Singleton Instance()
    {
      // Ovo se zove “lenja” inicijalizacija 
      if (instance == null)
      {
        instance = new Singleton();
      }

      return instance;
    }
  }
}
