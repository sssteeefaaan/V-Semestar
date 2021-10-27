 
// Adapter -- Strukturni primer

using System;

namespace DoFactory.GangOfFour.Adapter.Structural
{

  // MainApp test aplikacija 

  class MainApp
  {
    static void Main()
    {
      // Create adapter and place a request 
      Target target = new Adapter();
      target.Request();

      // Wait for user 
      Console.Read();
    }
  }

  // "Target" 

  class Target
  {
    public virtual void Request()
    {
      Console.WriteLine("Called Target Request()");
    }
  }

  // "Adapter" 

  class Adapter : Target
  {
    private Adaptee adaptee = new Adaptee();

    public override void Request()
    {
      // Ovde je moguće uraditi najpre i neki drugi posao 
      // pa tek onda pozvati SpecificRequest
      adaptee.SpecificRequest();
    }
  }

  // "Adaptee" 

  class Adaptee
  {
    public void SpecificRequest()
    {
      Console.WriteLine("Called SpecificRequest()");
    }
  }
}
