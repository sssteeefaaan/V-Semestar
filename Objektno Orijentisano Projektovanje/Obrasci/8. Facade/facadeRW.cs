 // Facade pattern -- Primer iz stvarnog sveta 

using System;

namespace DoFactory.GangOfFour.Facade.RealWorld
{
  // MainApp test aplikacija 

  class MainApp
  {
    static void Main()
    {
      // Fasada 
      Mortgage mortgage = new Mortgage();

      // Računanje hipoteke za kupca 
      Customer customer = new Customer("Ann McKinsey");
      bool eligable = mortgage.IsEligible(customer,125000);
      
      Console.WriteLine("\n" + customer.Name + 
          " has been " + (eligable ? "Approved" : "Rejected"));

      // Čekanje na korisnički unos
      Console.Read();
    }
  }

  // "Subsystem ClassA" 

  class Bank
  {
    public bool HasSufficientSavings(Customer c, int amount)
    {
      Console.WriteLine("Check bank for " + c.Name);
      return true;
    }
  }

  // "Subsystem ClassB" 

  class Credit
  {
    public bool HasGoodCredit(Customer c)
    {
      Console.WriteLine("Check credit for " + c.Name);
      return true;
    }
  }

  // "Subsystem ClassC" 

  class Loan
  {
    public bool HasNoBadLoans(Customer c)
    {
      Console.WriteLine("Check loans for " + c.Name);
      return true;
    }
  }

  class Customer
  {
    private string name;
    
    public Customer(string name)
    {
      this.name = name;
    }

    public string Name
    {
      get{ return name; }
    }
  }

  // "Facade" 

  class Mortgage
  {
    private Bank bank = new Bank();
    private Loan loan = new Loan();
    private Credit credit = new Credit();

    public bool IsEligible(Customer cust, int amount)
    {
      Console.WriteLine("{0} applies for {1:C} loan\n",
        cust.Name, amount);

      bool eligible = true;

      // Provera kreditne sposobnosti 
      if (!bank.HasSufficientSavings(cust, amount)) 
      {
        eligible = false;
      }
      else if (!loan.HasNoBadLoans(cust)) 
      {
        eligible = false;
      }
      else if (!credit.HasGoodCredit(cust)) 
      {
        eligible = false;
      }

      return eligible;
    }
  }
}
